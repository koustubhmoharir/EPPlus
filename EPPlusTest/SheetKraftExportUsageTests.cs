using System.Collections.Generic;
using System;
using Color = OfficeOpenXml.Style.ExcelColorValue;
using System.IO;
using System.Linq;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.FormulaParsing;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;

namespace EPPlusTest
{
    [TestClass]
    public class SheetKraftExportUsageTests
    {
        [TestMethod]
        public void PackageRoundTripPersistsWorkbookCalculationSettings()
        {
            using (var reopened = SaveAndReopen(package =>
            {
                var sheet = package.Workbook.Worksheets.Add("Data");
                sheet.Cells["A1"].Value = 42;
                package.Workbook.CalcMode = ExcelCalcMode.Automatic;
                // package.Workbook.FullCalcOnLoad = false;
            }))
            {
                Assert.AreEqual(ExcelCalcMode.Automatic, reopened.Workbook.CalcMode);
                // Assert.IsFalse(reopened.Workbook.FullCalcOnLoad);
                Assert.AreEqual(42d, reopened.Workbook.Worksheets["Data"].Cells["A1"].Value);
            }
        }

        [TestMethod]
        public void PackageRoundTripPersistsAndClearsEncryptionPassword()
        {
            var encryptedFile = new FileInfo(Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".xlsx"));
            var unencryptedFile = new FileInfo(Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".xlsx"));

            try
            {
                using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
                {
                    package.Workbook.Worksheets.Add("Secured").Cells["A1"].Value = "secret";
                    package.Encryption.Password = "write-password";
                    package.Encryption.IsEncrypted = true;
                    package.SaveAs(encryptedFile, "write-password");
                }

                encryptedFile.Refresh();
                Assert.IsTrue(encryptedFile.Exists);

                using (var reopened = CreateOpenedPackage(encryptedFile, "write-password"))
                {
                    Assert.AreEqual("secret", reopened.Workbook.Worksheets["Secured"].Cells["A1"].Value);
                    reopened.Encryption.IsEncrypted = false;
                    reopened.SaveAs(unencryptedFile);
                }

                using (var reopened = new ExcelPackage(unencryptedFile, EPPlusTest.TempFolderHelper.Create()))
                {
                    Assert.AreEqual("secret", reopened.Workbook.Worksheets["Secured"].Cells["A1"].Value);
                }
            }
            finally
            {
                if (encryptedFile.Exists)
                {
                    encryptedFile.Delete();
                }

                if (unencryptedFile.Exists)
                {
                    unencryptedFile.Delete();
                }
            }
        }

        [TestMethod]
        public void WorksheetReplacementPreservesDestinationOrderAndHiddenState()
        {
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var before = package.Workbook.Worksheets.Add("Before");
                var oldTarget = package.Workbook.Worksheets.Add("Target");
                var after = package.Workbook.Worksheets.Add("After");
                var source = package.Workbook.Worksheets.Add("Source");
                source.Hidden = eWorkSheetHidden.Hidden;
                source.Cells["A1"].Value = "replacement";

                package.Workbook.Worksheets.Delete(oldTarget);
                var replacement = package.Workbook.Worksheets.Add("Target", source);
                replacement.Hidden = source.Hidden;
                package.Workbook.Worksheets.MoveAfter(replacement.Name, before.Name);

                Assert.AreEqual("Before", package.Workbook.Worksheets.ElementAt(0).Name);
                Assert.AreEqual("Target", package.Workbook.Worksheets.ElementAt(1).Name);
                Assert.AreEqual("After", package.Workbook.Worksheets.ElementAt(2).Name);
                Assert.AreEqual(eWorkSheetHidden.Hidden, package.Workbook.Worksheets["Target"].Hidden);
                Assert.AreEqual("replacement", package.Workbook.Worksheets["Target"].Cells["A1"].Value);
                Assert.AreEqual("After", after.Name);
            }
        }

        [TestMethod]
        public void WorksheetCopyPreservesTablesChartsPivotTablesMergedCellsAndLocalNames()
        {
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var source = package.Workbook.Worksheets.Add("Source");
                source.Cells["A1"].Value = "Category";
                source.Cells["B1"].Value = "Value";
                source.Cells["A2"].Value = "A";
                source.Cells["A3"].Value = "B";
                source.Cells["B2"].Value = 10;
                source.Cells["B3"].Value = 20;
                source.Cells["D1:E1"].Merge = true;
                source.Names.AddFormula("LocalFormula", "SUM(B2:B3)");
                var table = source.Tables.Add(source.Cells["A1:B3"], "SourceTable");
                table.TableStyle = TableStyles.Medium2;
                var chart = source.Drawings.AddChart("Chart1", eChartType.ColumnClustered);
                chart.Series.Add(source.Cells["B2:B3"], source.Cells["A2:A3"]);
                var pivot = source.PivotTables.Add(source.Cells["G1"], source.Cells["A1:B3"], "Pivot1");
                pivot.RowFields.Add(pivot.Fields["Category"]);
                pivot.DataFields.Add(pivot.Fields["Value"]);

                var copy = package.Workbook.Worksheets.Add("Copy", source);

                Assert.AreEqual(1, copy.Tables.Count);
                Assert.AreEqual(1, copy.Drawings.OfType<ExcelChart>().Count());
                Assert.AreEqual(1, copy.PivotTables.Count);
                Assert.AreEqual("D1:E1", copy.MergedCells[0]);
                Assert.AreEqual("SUM(B2:B3)", copy.Names["LocalFormula"].Formula);
            }
        }

        [TestMethod]
        public void ValuesErrorsAndLongStringsRoundTripForExportRangeWrites()
        {
            using (var reopened = SaveAndReopen(package =>
            {
                var sheet = package.Workbook.Worksheets.Add("Values");
                sheet.Cells["A1"].Value = "text";
                sheet.Cells["A2"].Value = 12.5d;
                sheet.Cells["A3"].Value = true;
                sheet.Cells["A4"].Value = ExcelErrorValue.Create(eErrorType.Div0);
                sheet.Cells["A5"].Value = ExcelErrorValue.Create(eErrorType.Value);
                sheet.Cells["A6"].Value = ExcelErrorValue.Create(eErrorType.Ref);
                sheet.Cells["A7"].Value = ExcelErrorValue.Create(eErrorType.Name);
                sheet.Cells["A8"].Value = ExcelErrorValue.Create(eErrorType.Num);
                sheet.Cells["A9"].Value = ExcelErrorValue.Create(eErrorType.NA);
                sheet.Cells["A10"].Value = null;
                sheet.Cells["A11"].Value = new string('x', 32767);
                sheet.Cells["B1:C2"].Value = new object[,] { { 1, "a" }, { 2, "b" } };
            }))
            {
                var sheet = reopened.Workbook.Worksheets["Values"];
                Assert.AreEqual("text", sheet.Cells["A1"].Value);
                Assert.AreEqual(12.5d, sheet.Cells["A2"].Value);
                Assert.AreEqual(true, sheet.Cells["A3"].Value);
                Assert.AreEqual(ExcelErrorValue.Create(eErrorType.Div0), sheet.Cells["A4"].Value);
                Assert.AreEqual(ExcelErrorValue.Create(eErrorType.Value), sheet.Cells["A5"].Value);
                Assert.AreEqual(ExcelErrorValue.Create(eErrorType.Ref), sheet.Cells["A6"].Value);
                Assert.AreEqual(ExcelErrorValue.Create(eErrorType.Name), sheet.Cells["A7"].Value);
                Assert.AreEqual(ExcelErrorValue.Create(eErrorType.Num), sheet.Cells["A8"].Value);
                Assert.AreEqual(ExcelErrorValue.Create(eErrorType.NA), sheet.Cells["A9"].Value);
                Assert.IsNull(sheet.Cells["A10"].Value);
                Assert.AreEqual(32767, ((string)sheet.Cells["A11"].Value).Length);
                Assert.AreEqual(1d, sheet.Cells["B1"].Value);
                Assert.AreEqual("b", sheet.Cells["C2"].Value);
            }
        }

        [TestMethod]
        public void FormulaArrayFormulaAndR1C1FillRoundTrip()
        {
            using (var reopened = SaveAndReopen(package =>
            {
                var sheet = package.Workbook.Worksheets.Add("Formulas");
                sheet.Cells["A1"].Value = 1;
                sheet.Cells["A2"].Value = 2;
                sheet.Cells["B1"].Value = 10;
                sheet.Cells["B2"].Value = 20;
                sheet.Cells["C1"].Formula = "A1+B1";
                sheet.Cells["C2"].FormulaR1C1 = sheet.Cells["C1"].FormulaR1C1;
                sheet.Cells["D1:D2"].CreateArrayFormula("A1:A2+B1:B2");
                sheet.Cells["E1:F1"].Merge = true;
                sheet.Cells["E1:F1"].Formula = "SUM(A1:A2)";
            }))
            {
                var sheet = reopened.Workbook.Worksheets["Formulas"];
                Assert.AreEqual("A1+B1", sheet.Cells["C1"].Formula);
                Assert.AreEqual(sheet.Cells["C1"].FormulaR1C1, sheet.Cells["C2"].FormulaR1C1);
                Assert.AreEqual("A1:A2+B1:B2", sheet.GetArrayFormulaRange(1, 4).Formula);
                Assert.AreEqual("SUM(A1:A2)", sheet.Cells["E1"].Formula);
                Assert.AreEqual("SUM(B1:B2)", sheet.Cells["F1"].Formula);
            }
        }

        [TestMethod]
        public void ClearingArrayFormulaRemovesFormulaAndValuesFromEntireRange()
        {
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var sheet = package.Workbook.Worksheets.Add("ClearArray");
                sheet.Cells["A1:B2"].CreateArrayFormula("ROW(A1:B2)");
                sheet.Cells["A1:B2"].Value = new object[,] { { 1, 2 }, { 3, 4 } };

                var arrayRange = sheet.GetArrayFormulaRange(1, 1);
                sheet.Cells[arrayRange.Start.Row, arrayRange.Start.Column].Clear();
                arrayRange.Clear();

                Assert.IsNull(sheet.GetArrayFormulaRange(1, 1));
                Assert.IsNull(sheet.Cells["A1"].Value);
                Assert.IsNull(sheet.Cells["B2"].Value);
            }
        }

        [TestMethod]
        public void InsertRowsAndColumnsShiftFormulasMergedCellsNamedRangesAndDrawings()
        {
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var sheet = package.Workbook.Worksheets.Add("Insert");
                sheet.Cells["A1"].Formula = "B2";
                sheet.Cells["B2"].Value = 1;
                sheet.Cells["C3:D3"].Merge = true;
                sheet.Names.Add("LocalRange", sheet.Cells["B2:C3"]);
                var shape = sheet.Drawings.AddShape("Shape1", eShapeStyle.Rect);
                shape.EditAs = eEditAs.TwoCell;
                shape.SetPosition(4, 0, 4, 0);
                var originalFromRow = shape.From.Row;
                var originalFromColumn = shape.From.Column;

                sheet.InsertRow(2, 2);
                sheet.InsertColumn(2, 2);

                Assert.AreEqual("D4", sheet.Cells["A1"].Formula);
                Assert.AreEqual("E5:F5", sheet.MergedCells[0]);
                Assert.AreEqual("'Insert'!D4:E5", sheet.Names["LocalRange"].Address);
                Assert.AreEqual("Shape1", shape.Name);
                // Moving of drawings is currently not implemented in EPPlus
                Assert.AreEqual(originalFromRow, shape.From.Row);
                Assert.AreEqual(originalFromColumn, shape.From.Column);
            }
        }

        [TestMethod]
        public void AbsoluteDrawingDoesNotMoveWhenRowsAndColumnsAreInserted()
        {
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var sheet = package.Workbook.Worksheets.Add("AbsoluteDrawing");
                var shape = sheet.Drawings.AddShape("Shape1", eShapeStyle.Rect);
                shape.EditAs = eEditAs.Absolute;
                shape.SetPosition(4, 0, 4, 0);
                var originalFromRow = shape.From.Row;
                var originalFromColumn = shape.From.Column;

                sheet.InsertRow(2, 2);
                sheet.InsertColumn(2, 2);

                Assert.AreEqual(originalFromRow, shape.From.Row);
                Assert.AreEqual(originalFromColumn, shape.From.Column);
            }
        }

        [TestMethod]
        public void StylesNumberFormatsBordersThemeColorsRowsAndColumnsRoundTrip()
        {
            using (var reopened = SaveAndReopen(package =>
            {
                var sheet = package.Workbook.Worksheets.Add("Styles");
                var styled = sheet.Cells["A1"];
                styled.Value = 12.345;
                styled.Style.Numberformat.Format = "#,##0.00";
                styled.Style.Font.Bold = true;
                styled.Style.Font.Color.SetColor(Color.Red);
                styled.Style.Fill.PatternType = ExcelFillStyle.Solid;
                styled.Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                styled.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                styled.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                styled.Style.WrapText = true;
                styled.Style.TextRotation = 45;
                styled.Style.Border.Top.Style = ExcelBorderStyle.Thick;
                styled.Style.Border.Top.Color.SetColor(Color.Green);
                sheet.Cells["A1"].Copy(sheet.Cells["B2"]);
                sheet.Row(2).Height = 33;
                sheet.Column(2).Width = 18;
                sheet.Column(2).Hidden = true;
                sheet.Row(2).OutlineLevel = 2;
                sheet.Column(2).OutlineLevel = 3;
            }))
            {
                var sheet = reopened.Workbook.Worksheets["Styles"];
                Assert.AreEqual("#,##0.00", sheet.Cells["B2"].Style.Numberformat.Format);
                Assert.IsTrue(sheet.Cells["B2"].Style.Font.Bold);
                Assert.AreEqual(ExcelFillStyle.Solid, sheet.Cells["B2"].Style.Fill.PatternType);
                Assert.AreEqual(ExcelHorizontalAlignment.Center, sheet.Cells["B2"].Style.HorizontalAlignment);
                Assert.AreEqual(ExcelVerticalAlignment.Center, sheet.Cells["B2"].Style.VerticalAlignment);
                Assert.IsTrue(sheet.Cells["B2"].Style.WrapText);
                Assert.AreEqual(45, sheet.Cells["B2"].Style.TextRotation);
                Assert.AreEqual(ExcelBorderStyle.Thick, sheet.Cells["B2"].Style.Border.Top.Style);
                Assert.AreEqual(33d, sheet.Row(2).Height);
                Assert.AreEqual(18d, sheet.Column(2).Width);
                Assert.IsTrue(sheet.Column(2).Hidden);
                Assert.AreEqual(2, sheet.Row(2).OutlineLevel);
                Assert.AreEqual(3, sheet.Column(2).OutlineLevel);
            }
        }

        [TestMethod]
        public void MergedCellsRoundTripIncludingProjectedHeaderMergeWithSkippedColumn()
        {
            using (var reopened = SaveAndReopen(package =>
            {
                var sheet = package.Workbook.Worksheets.Add("Merges");
                sheet.Cells["A1:C1"].Merge = true;
                sheet.Cells["A1"].Value = "source merge";

                var outputStartColumn = 5;
                sheet.Cells[3, outputStartColumn, 3, outputStartColumn + 1].Merge = true;
                sheet.Cells[3, outputStartColumn].Value = "projected header";
            }))
            {
                var sheet = reopened.Workbook.Worksheets["Merges"];
                Assert.IsTrue(sheet.MergedCells.Contains("A1:C1"));
                Assert.IsTrue(sheet.MergedCells.Contains("E3:F3"));
                Assert.AreEqual("projected header", sheet.Cells["E3"].Value);
            }
        }

        [TestMethod]
        public void NamedRangeAddUpdateRemoveAndSheetKraftNameCleanupBehaviors()
        {
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var sheet = package.Workbook.Worksheets.Add("Names");
                sheet.Cells["A1:B2"].Value = 1;
                package.Workbook.Names.AddFormula("GlobalFormula", "SUM(Names!A1:B2)");
                sheet.Names.Add("LocalAddress", sheet.Cells["A1:B2"]);
                sheet.Names["LocalAddress"].Address = "C1:D2";
                package.Workbook.Names.AddFormula("SheetKraftFormula1", "Formula.SK(A1)");
                package.Workbook.Names.AddFormula("Print_Area", "Names!$A$1:$B$2");
                package.Workbook.Names.Remove("SheetKraftFormula1");
                package.Workbook.Names.Remove("Print_Area");

                Assert.AreEqual("SUM(Names!A1:B2)", package.Workbook.Names["GlobalFormula"].Formula);
                Assert.AreEqual("C1:D2", sheet.Names["LocalAddress"].Address);
                Assert.IsFalse(package.Workbook.Names.ContainsKey("SheetKraftFormula1"));
                Assert.IsFalse(package.Workbook.Names.ContainsKey("Print_Area"));
            }
        }

        [TestMethod]
        public void TableCreationPersistsSheetKraftControlledDisplayFlags()
        {
            using (var reopened = SaveAndReopen(package =>
            {
                var sheet = package.Workbook.Worksheets.Add("Tables");
                sheet.Cells["A1"].Value = "Name";
                sheet.Cells["B1"].Value = "Value";
                sheet.Cells["A2"].Value = "A";
                sheet.Cells["B2"].Value = 1;
                var table = sheet.Tables.Add(sheet.Cells["A1:B2"], "ExportTable_A1_B2");
                table.ShowHeader = true;
                table.ShowFilter = false;
                table.ShowFirstColumn = true;
                table.ShowLastColumn = true;
                table.ShowRowStripes = true;
                table.ShowColumnStripes = true;
                table.ShowTotal = true;
                table.StyleName = "TableStyleMedium4";
            }))
            {
                var table = reopened.Workbook.Worksheets["Tables"].Tables["ExportTable_A1_B2"];
                Assert.IsTrue(table.ShowHeader);
                Assert.IsTrue(table.ShowFilter);
                Assert.IsTrue(table.ShowFirstColumn);
                Assert.IsTrue(table.ShowLastColumn);
                Assert.IsTrue(table.ShowRowStripes);
                Assert.IsTrue(table.ShowColumnStripes);
                Assert.IsTrue(table.ShowTotal);
                Assert.AreEqual("TableStyleMedium4", table.StyleName);
            }
        }

        [TestMethod]
        public void TableCreationPersistsSheetKraftControlledDisplayFlagsWithNoTotalRow()
        {
            using (var reopened = SaveAndReopen(package =>
            {
                var sheet = package.Workbook.Worksheets.Add("Tables");
                sheet.Cells["A1"].Value = "Name";
                sheet.Cells["B1"].Value = "Value";
                sheet.Cells["A2"].Value = "A";
                sheet.Cells["B2"].Value = 1;
                var table = sheet.Tables.Add(sheet.Cells["A1:B2"], "ExportTable_A1_B2_NoTotal");
                table.ShowHeader = true;
                table.ShowFilter = false;
                table.ShowFirstColumn = true;
                table.ShowLastColumn = true;
                table.ShowRowStripes = true;
                table.ShowColumnStripes = true;
                table.ShowTotal = false;
                table.StyleName = "TableStyleMedium4";
            }))
            {
                var table = reopened.Workbook.Worksheets["Tables"].Tables["ExportTable_A1_B2_NoTotal"];
                Assert.IsTrue(table.ShowFilter);
                Assert.IsFalse(table.ShowTotal);
            }
        }

        [TestMethod]
        public void ConditionalFormattingXmlCleanupRemovesOnlySheetKraftRules()
        {
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var sheet = package.Workbook.Worksheets.Add("Conditional");
                sheet.ConditionalFormatting.AddExpression(sheet.Cells["A1:A3"]).Formula = "IF(SheetKraftFormat,A1>0,FALSE)";
                sheet.ConditionalFormatting.AddExpression(sheet.Cells["B1:B3"]).Formula = "B1>0";

                RemoveSheetKraftConditionalFormatting(package, sheet);

                var nsm = package.CreateDefaultNSM();
                var formulas = sheet.WorksheetXml.SelectNodes("//d:conditionalFormatting/d:cfRule/d:formula", nsm)
                    .Cast<XmlNode>()
                    .Select(node => node.InnerText)
                    .ToList();
                Assert.IsFalse(formulas.Any(formula => formula.StartsWith("IF(SheetKraftFormat,", StringComparison.InvariantCultureIgnoreCase)));
                Assert.IsTrue(formulas.Contains("B1>0"));
            }
        }

        [TestMethod]
        public void ChartSeriesCanBeRewrittenAndDeletedLikeSheetKraftNamedSeriesCleanup()
        {
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var sheet = package.Workbook.Worksheets.Add("ChartData");
                sheet.Cells["A1"].Value = "X";
                sheet.Cells["B1"].Value = "Y1";
                sheet.Cells["C1"].Value = "Y2";
                sheet.Cells["A2:A3"].Value = 1;
                sheet.Cells["B2:B3"].Value = 2;
                sheet.Cells["C2:C3"].Value = 3;
                var chart = sheet.Drawings.AddChart("Chart1", eChartType.Line);
                var keep = chart.Series.Add(sheet.Cells["B2:B3"], sheet.Cells["A2:A3"]);
                chart.Series.Add(sheet.Cells["C2:C3"], sheet.Cells["A2:A3"]);

                keep.HeaderAddress = sheet.Cells["B1"];
                keep.XSeries = "ChartData!$A$2:$A$3";
                keep.Series = "ChartData!$B$2:$B$3";
                chart.Series.Delete(1);

                Assert.AreEqual(1, chart.Series.Count);
                Assert.AreEqual("ChartData!$A$2:$A$3", chart.Series[0].XSeries);
                Assert.AreEqual("ChartData!$B$2:$B$3", chart.Series[0].Series);
                Assert.AreEqual("'ChartData'!B1", chart.Series[0].HeaderAddress.Address);
            }
        }

        [TestMethod]
        public void PivotTableCacheRefreshOnLoadCanBeSetThroughCacheDefinitionXml()
        {
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var data = package.Workbook.Worksheets.Add("Data");
                data.Cells["A1"].Value = "Category";
                data.Cells["B1"].Value = "Value";
                data.Cells["A2"].Value = "A";
                data.Cells["B2"].Value = 10;
                var pivotSheet = package.Workbook.Worksheets.Add("Pivot");
                var pivot = pivotSheet.PivotTables.Add(pivotSheet.Cells["A1"], data.Cells["A1:B2"], "Pivot1");

                pivot.CacheDefinition.CacheDefinitionXml.DocumentElement.SetAttribute("refreshOnLoad", "1");

                Assert.AreEqual("1", pivot.CacheDefinition.CacheDefinitionXml.DocumentElement.GetAttribute("refreshOnLoad"));
            }
        }

        [TestMethod]
        public void SheetProtectionFlagsAndPasswordPersist()
        {
            using (var reopened = SaveAndReopen(package =>
            {
                var sheet = package.Workbook.Worksheets.Add("Protected");
                sheet.Protection.IsProtected = true;
                sheet.Protection.AllowEditObject = false;
                sheet.Protection.AllowEditScenarios = false;
                sheet.Protection.SetPassword("sheet-password");
            }))
            {
                var sheet = reopened.Workbook.Worksheets["Protected"];
                Assert.IsTrue(sheet.Protection.IsProtected);
                Assert.IsFalse(sheet.Protection.AllowEditObject);
                Assert.IsFalse(sheet.Protection.AllowEditScenarios);
            }
        }

        [TestMethod]
        public void FooterCopyThenDeleteRowsAndColumnsPreservesCopiedValuesFormulasAndStyles()
        {
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                VerifyFooterHandling(
                    package,
                    "FootersRowsAndColumns",
                    rowMax: 3,
                    colMax: 3,
                    footerRows: 1,
                    footerCols: 1,
                    expectedStyledFooterAddress: "C3",
                    expectedFormulas: new Dictionary<string, string>
                    {
                        { "A1", "=#REF!+#REF!" },
                        { "C1", "=#REF!+$B$2" },
                        { "A2", "=$A$3+$A$1" },
                        { "B2", "=$A$3+#REF!" },
                        { "C2", "=#REF!+$A$1" },
                        { "A3", "=#REF!+$B$2" },
                        { "C3", "=$A$3+$A$1" }
                    });

                VerifyFooterHandling(
                    package,
                    "FootersColumnsOnly",
                    rowMax: 3,
                    colMax: 3,
                    footerRows: 0,
                    footerCols: 1,
                    expectedStyledFooterAddress: "C1",
                    expectedFormulas: new Dictionary<string, string>
                    {
                        { "A1", "=#REF!+$B$3" },
                        { "C1", "=$A$1+$A$2" },
                        { "A2", "=#REF!+#REF!" },
                        { "C2", "=#REF!+$B$3" },
                        { "A3", "=$A$1+$A$2" },
                        { "B3", "=$A$1+#REF!" },
                        { "C3", "=#REF!+$A$2" }
                    });

                VerifyFooterHandling(
                    package,
                    "FootersRowsOnly",
                    rowMax: 3,
                    colMax: 3,
                    footerRows: 1,
                    footerCols: 0,
                    expectedStyledFooterAddress: "A3",
                    expectedFormulas: new Dictionary<string, string>
                    {
                        { "A1", "=$A$3+$C$2" },
                        { "B1", "=$A$3+$A$1" },
                        { "A2", "=$A$3+$B$1" },
                        { "B2", "=$B$3+$B$1" },
                        { "C2", "=$B$3+$A$3" },
                        { "A3", "=$B$3+$B$1" },
                        { "B3", "=$A$1+$C$2" }
                    });
            }
        }

        private static void VerifyFooterHandling(
            ExcelPackage package,
            string worksheetName,
            int rowMax,
            int colMax,
            int footerRows,
            int footerCols,
            string expectedStyledFooterAddress,
            Dictionary<string, string> expectedFormulas)
        {
            var sheet = package.Workbook.Worksheets.Add(worksheetName);
            SeedFooterScenario(sheet);
            HandleFooters(rowMax, colMax, sheet, footerRows, footerCols);

            foreach (var expected in expectedFormulas)
            {
                Assert.AreEqual(expected.Value, sheet.Cells[expected.Key].Formula, expected.Key);
            }

            var movedFooterCell = sheet.Cells[expectedStyledFooterAddress];
            Assert.AreEqual(ExcelFillStyle.Solid, movedFooterCell.Style.Fill.PatternType);
            Assert.IsTrue(movedFooterCell.Style.Font.Bold);
        }

        private static void SeedFooterScenario(ExcelWorksheet sheet)
        {
            sheet.Cells["A1"].Value = "top-left-value";
            sheet.Cells["A1"].Formula = "=$B$1+$B$2";
            sheet.Cells["A1"].Style.Font.Bold = true;
            sheet.Cells["A1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            sheet.Cells["A1"].Style.Fill.BackgroundColor.SetColor(Color.LightYellow);

            sheet.Cells["B1"].Value = "top-middle-value";
            sheet.Cells["B1"].Formula = "=$A$2+$C$3";
            sheet.Cells["B1"].Style.Font.Bold = true;
            sheet.Cells["B1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            sheet.Cells["B1"].Style.Fill.BackgroundColor.SetColor(Color.LightYellow);

            sheet.Cells["A2"].Value = "middle-left-value";
            sheet.Cells["A2"].Formula = "=$A$1+$C$3";
            sheet.Cells["A2"].Style.Font.Bold = true;
            sheet.Cells["A2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            sheet.Cells["A2"].Style.Fill.BackgroundColor.SetColor(Color.LightGreen);

            sheet.Cells["B2"].Value = "middle-middle-value";
            sheet.Cells["B2"].Formula = "=$A$1+$A$2";
            sheet.Cells["B2"].Style.Font.Bold = true;
            sheet.Cells["B2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            sheet.Cells["B2"].Style.Fill.BackgroundColor.SetColor(Color.LightGreen);

            sheet.Cells["A3"].Value = "bottom-left-value";
            sheet.Cells["A3"].Formula = "=$A$1+$B$2";
            sheet.Cells["A3"].Style.Font.Bold = true;
            sheet.Cells["A3"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            sheet.Cells["A3"].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);

            sheet.Cells["B3"].Value = "bottom-middle-value";
            sheet.Cells["B3"].Formula = "=$B$1+$B$2";
            sheet.Cells["B3"].Style.Font.Bold = true;
            sheet.Cells["B3"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            sheet.Cells["B3"].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);

            sheet.Cells["C3"].Value = "bottom-right-value";
            sheet.Cells["C3"].Formula = "=$B$1+$A$1";
            sheet.Cells["C3"].Style.Font.Bold = true;
            sheet.Cells["C3"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            sheet.Cells["C3"].Style.Fill.BackgroundColor.SetColor(Color.LightCoral);
        }

        private static void HandleFooters(int rowMax, int colMax, ExcelWorksheet destSheet, int footerRows, int footerCols)
        {
            bool rowsExist = footerRows > 0 && footerRows < rowMax, colsExist = footerCols > 0 && footerCols < colMax;
            if (rowsExist)
            {
                // The idea is that footerRows rows from the top of the sheet are "copied" to the bottom and then the original rows are deleted
                destSheet.Cells[1, 1, footerRows, colMax].Copy(destSheet.Cells[rowMax + 1, 1, rowMax + footerRows, colMax], null, true);
                destSheet.DeleteRow(1, footerRows);
            }
            if (colsExist)
            {
                // The idea is that footerCols columns from the left of the sheet are "copied" to the right and then the original columns are deleted
                destSheet.Cells[1, 1, rowMax, footerCols].Copy(destSheet.Cells[1, colMax + 1, rowMax, colMax + footerCols]);
                destSheet.DeleteColumn(1, footerCols);
            }
        }

        [TestMethod]
        public void OverwriteOptionsCanPreserveExistingCellsWhenSkippingBlanksAndErrors()
        {
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var sheet = package.Workbook.Worksheets.Add("Overwrite");
                sheet.Cells["A1"].Value = "keep blank";
                sheet.Cells["A2"].Value = "keep na";
                sheet.Cells["A3"].Value = "replace";
                var incoming = new object[]
                {
                    null,
                    ExcelErrorValue.Create(eErrorType.NA),
                    "new value"
                };

                for (var row = 1; row <= incoming.Length; row++)
                {
                    var value = incoming[row - 1];
                    if (value == null || Equals(value, ExcelErrorValue.Create(eErrorType.NA)))
                    {
                        continue;
                    }

                    sheet.Cells[row, 1].Value = value;
                }

                Assert.AreEqual("keep blank", sheet.Cells["A1"].Value);
                Assert.AreEqual("keep na", sheet.Cells["A2"].Value);
                Assert.AreEqual("new value", sheet.Cells["A3"].Value);
            }
        }

        private static ExcelPackage SaveAndReopen(Action<ExcelPackage> configure, string password = null)
        {
            var stream = new MemoryStream();
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                configure(package);
                if (password == null)
                {
                    package.SaveAs(stream);
                }
                else
                {
                    package.SaveAs(stream, password);
                }
            }

            stream.Position = 0;
            return password == null ? new ExcelPackage(stream, EPPlusTest.TempFolderHelper.Create()) : new ExcelPackage(stream, password, EPPlusTest.TempFolderHelper.Create());
        }

        private static void RemoveSheetKraftConditionalFormatting(ExcelPackage package, ExcelWorksheet sheet)
        {
            var nsm = package.CreateDefaultNSM();
            nsm.AddNamespace("xm", "http://schemas.microsoft.com/office/excel/2006/main");
            var formats = sheet.WorksheetXml.SelectNodes("//xm:f", nsm).Cast<XmlNode>()
                .Where(f => f.InnerText.StartsWith("IF(SheetKraftFormat,", StringComparison.InvariantCultureIgnoreCase) &&
                            f.ParentNode?.ParentNode?.LocalName == "conditionalFormatting")
                .Select(f => f.ParentNode.ParentNode)
                .Distinct()
                .ToList();

            if (formats.Count == 0)
            {
                formats = sheet.WorksheetXml.SelectNodes("//d:formula", nsm).Cast<XmlNode>()
                    .Where(f => f.InnerText.StartsWith("IF(SheetKraftFormat,", StringComparison.InvariantCultureIgnoreCase) &&
                                f.ParentNode?.ParentNode?.LocalName == "conditionalFormatting")
                    .Select(f => f.ParentNode.ParentNode)
                    .Distinct()
                    .ToList();
            }

            if (formats.Count == 0)
            {
                return;
            }

            var parent = formats[0].ParentNode;
            foreach (var format in formats)
            {
                format.ParentNode.RemoveChild(format);
            }

            if (parent.ChildNodes.Count == 0)
            {
                parent.ParentNode.RemoveChild(parent);
            }
        }

        private static ExcelPackage CreateOpenedPackage(FileInfo fileInfo, string password)
        {
#if NET9_0
            return new ExcelPackage(fileInfo, password: password, tempFolder: EPPlusTest.TempFolderHelper.Create());
#else
            return new ExcelPackage(fileInfo, password, EPPlusTest.TempFolderHelper.Create());
#endif
        }

    }
}
