using System;
using System.Drawing;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace EPPlusE2ETest
{
    [TestClass]
    public class ColumnarExportAndMapping : TestsBase
    {
        static string template = "ColumnarExportAndMapping.xlsx";

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            SaveTemplate(template, package =>
            {
                // 1. Create OptionsSheet
                var options = package.Workbook.Worksheets.Add("OptionsSheet");
                
                // Header Group (Row 1): Merge A1:C1
                options.Cells["A1:C1"].Merge = true;
                options.Cells["A1"].Value = "Employee Info";
                options.Cells["A1"].Style.Font.Bold = true;
                options.Cells["A1"].Style.Font.Size = 12;
                options.Cells["A1"].Style.Font.Color.SetColor(Color.Navy);
                options.Cells["A1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                options.Cells["A1"].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                options.Cells["A1"].Style.Border.Bottom.Style = ExcelBorderStyle.Medium;

                // Headers (Row 2): ID, Name, Salary
                options.Cells["A2"].Value = "ID";
                options.Cells["B2"].Value = "Name";
                options.Cells["C2"].Value = "Salary";
                for (int col = 1; col <= 3; col++)
                {
                    var cell = options.Cells[2, col];
                    cell.Style.Font.Bold = true;
                    cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    cell.Style.Fill.BackgroundColor.SetColor(Color.LightYellow);
                    cell.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }

                // Data format pattern (Row 3): Salary column style
                options.Cells["C3"].Style.Numberformat.Format = "$#,##0.00";

                // Footer (Row 6): Total row
                options.Cells["A6"].Value = "Total";
                options.Cells["A6"].Style.Font.Bold = true;
                options.Cells["A6"].Style.Font.Italic = true;
                options.Cells["C6"].Formula = "=SUM(C3:C5)";
                options.Cells["C6"].Style.Numberformat.Format = "$#,##0.00";
                for (int col = 1; col <= 3; col++)
                {
                    var cell = options.Cells[6, col];
                    cell.Style.Font.Bold = true;
                    cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    cell.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    cell.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    cell.Style.Border.Bottom.Style = ExcelBorderStyle.Double;
                }

                // Set custom column widths on OptionsSheet
                options.Column(1).Width = 10;
                options.Column(2).Width = 25;
                options.Column(3).Width = 15;

                // 2. Create SourceData
                var data = package.Workbook.Worksheets.Add("SourceData");
                data.Cells["A1"].Value = 1;
                data.Cells["B1"].Value = "Alice";
                data.Cells["C1"].Value = 1500.25;

                data.Cells["A2"].Value = 2;
                data.Cells["B2"].Value = "Bob";
                data.Cells["C2"].Value = 2500.50;

                data.Cells["A3"].Value = 3;
                data.Cells["B3"].Value = "Charlie";
                data.Cells["C3"].Value = 3500.75;
            });
        }

        [TestMethod]
        public void HeaderFooterValuesStylesAndWidths()
        {
            Test(template, null, "ColumnarExportAndMapping.HeaderFooterValuesStylesAndWidths.xlsx", null, package =>
            {
                var options = package.Workbook.Worksheets["OptionsSheet"];
                var data = package.Workbook.Worksheets["SourceData"];
                var dest = package.Workbook.Worksheets.Add("Exported");

                // Simulate writing Header Group (Row 1) and Headers (Row 2) from OptionsSheet
                for (int r = 1; r <= 2; r++)
                {
                    for (int c = 1; c <= 3; c++)
                    {
                        var srcCell = options.Cells[r, c];
                        var destCell = dest.Cells[r, c];
                        destCell.Value = srcCell.Value;
                        CopyCellStyle(srcCell, destCell);
                    }
                    dest.Row(r).Height = options.Row(r).Height;
                }

                // Simulate writing data from SourceData to destination rows 3, 4, 5
                for (int r = 1; r <= 3; r++)
                {
                    int destRow = r + 2;
                    for (int c = 1; c <= 3; c++)
                    {
                        var srcCell = data.Cells[r, c];
                        var destCell = dest.Cells[destRow, c];
                        destCell.Value = srcCell.Value;

                        // Apply data style pattern for Salary column (column 3 format from OptionsSheet C3)
                        if (c == 3)
                        {
                            CopyCellStyle(options.Cells["C3"], destCell);
                        }
                    }
                }

                // Simulate writing Footer (Row 6) from OptionsSheet to destination row 6
                int footerDestRow = 6;
                for (int c = 1; c <= 3; c++)
                {
                    var srcCell = options.Cells[6, c];
                    var destCell = dest.Cells[footerDestRow, c];
                    if (!string.IsNullOrEmpty(srcCell.Formula))
                    {
                        destCell.Formula = srcCell.Formula;
                    }
                    else
                    {
                        destCell.Value = srcCell.Value;
                    }
                    CopyCellStyle(srcCell, destCell);
                }
                dest.Row(footerDestRow).Height = options.Row(6).Height;

                // Replicate merging for Header Group: A1:C1
                dest.Cells["A1:C1"].Merge = true;

                // Copy Column Widths from OptionsSheet
                for (int col = 1; col <= 3; col++)
                {
                    dest.Column(col).Width = options.Column(col).Width;
                }
            }, package =>
            {
                var dest = package.Workbook.Worksheets["Exported"];
                Assert.IsNotNull(dest);

                // 1. Verify Header values & styles
                Assert.AreEqual("Employee Info", dest.Cells["A1"].Value);
                Assert.IsTrue(dest.Cells["A1"].Style.Font.Bold);
                Assert.AreEqual(12f, dest.Cells["A1"].Style.Font.Size);
                Assert.AreEqual("FF000080", dest.Cells["A1"].Style.Font.Color.Rgb); // Navy color hex
                Assert.AreEqual("ADD8E6", dest.Cells["A1"].Style.Fill.BackgroundColor.Rgb?.Substring(2)); // LightBlue is ADD8E6 (ignore alpha)
                Assert.AreEqual(ExcelBorderStyle.Medium, dest.Cells["A1"].Style.Border.Bottom.Style);

                Assert.AreEqual("ID", dest.Cells["A2"].Value);
                Assert.AreEqual("Name", dest.Cells["B2"].Value);
                Assert.AreEqual("Salary", dest.Cells["C2"].Value);
                Assert.IsTrue(dest.Cells["C2"].Style.Font.Bold);
                Assert.AreEqual("FFFFFFE0", dest.Cells["C2"].Style.Fill.BackgroundColor.Rgb); // LightYellow

                // 2. Verify Data values & salary number formatting
                Assert.AreEqual(1.0, Convert.ToDouble(dest.Cells["A3"].Value));
                Assert.AreEqual("Alice", dest.Cells["B3"].Value);
                Assert.AreEqual(1500.25, Convert.ToDouble(dest.Cells["C3"].Value));
                Assert.AreEqual("$#,##0.00", dest.Cells["C3"].Style.Numberformat.Format);

                Assert.AreEqual(3.0, Convert.ToDouble(dest.Cells["A5"].Value));
                Assert.AreEqual("Charlie", dest.Cells["B5"].Value);
                Assert.AreEqual(3500.75, Convert.ToDouble(dest.Cells["C5"].Value));
                Assert.AreEqual("$#,##0.00", dest.Cells["C5"].Style.Numberformat.Format);

                // 3. Verify Footer values & formulas
                Assert.AreEqual("Total", dest.Cells["A6"].Value);
                Assert.IsTrue(dest.Cells["A6"].Style.Font.Bold);
                Assert.IsTrue(dest.Cells["A6"].Style.Font.Italic);
                Assert.AreEqual("=SUM(C3:C5)", dest.Cells["C6"].Formula);
                Assert.AreEqual(ExcelBorderStyle.Double, dest.Cells["C6"].Style.Border.Bottom.Style);

                // 4. Verify merges
                Assert.IsTrue(dest.MergedCells.Contains("A1:C1"));

                // 5. Verify Column widths
                Assert.AreEqual(10d, dest.Column(1).Width, 0.1);
                Assert.AreEqual(25d, dest.Column(2).Width, 0.1);
                Assert.AreEqual(15d, dest.Column(3).Width, 0.1);
            });
        }

        [TestMethod]
        public void HeaderFooterCellMergingWithExcludedColumns()
        {
            Test(template, null, "ColumnarExportAndMapping.HeaderFooterCellMergingWithExcludedColumns.xlsx", null, package =>
            {
                var options = package.Workbook.Worksheets["OptionsSheet"];
                var data = package.Workbook.Worksheets["SourceData"];
                var dest = package.Workbook.Worksheets.Add("ExportedExcluded");

                // Export column mapping: Source Col 1 -> Dest Col 1; Source Col 2 -> Excluded; Source Col 3 -> Dest Col 2
                bool[] exportCol = { true, false, true };

                // Simulate writing Header Group (Row 1) and Headers (Row 2) from OptionsSheet
                for (int r = 1; r <= 2; r++)
                {
                    int destCol = 1;
                    for (int c = 1; c <= 3; c++)
                    {
                        if (!exportCol[c - 1]) continue;

                        var srcCell = options.Cells[r, c];
                        var destCell = dest.Cells[r, destCol];
                        destCell.Value = srcCell.Value;
                        CopyCellStyle(srcCell, destCell);
                        destCol++;
                    }
                    dest.Row(r).Height = options.Row(r).Height;
                }

                // Simulate writing data from SourceData to destination rows 3, 4, 5
                for (int r = 1; r <= 3; r++)
                {
                    int destRow = r + 2;
                    int destCol = 1;
                    for (int c = 1; c <= 3; c++)
                    {
                        if (!exportCol[c - 1]) continue;

                        var srcCell = data.Cells[r, c];
                        var destCell = dest.Cells[destRow, destCol];
                        destCell.Value = srcCell.Value;

                        // Apply data style pattern for Salary column (column 3 format from OptionsSheet C3)
                        if (c == 3)
                        {
                            CopyCellStyle(options.Cells["C3"], destCell);
                        }
                        destCol++;
                    }
                }

                // Simulate writing Footer (Row 6) from OptionsSheet to destination row 6
                int footerDestRow = 6;
                int footerDestCol = 1;
                for (int c = 1; c <= 3; c++)
                {
                    if (!exportCol[c - 1]) continue;

                    var srcCell = options.Cells[6, c];
                    var destCell = dest.Cells[footerDestRow, footerDestCol];
                    if (!string.IsNullOrEmpty(srcCell.Formula))
                    {
                        destCell.Formula = srcCell.Formula.Replace("C", "B");
                    }
                    else
                    {
                        destCell.Value = srcCell.Value;
                    }
                    CopyCellStyle(srcCell, destCell);
                    footerDestCol++;
                }
                dest.Row(footerDestRow).Height = options.Row(6).Height;

                // Replicate merging for Header Group: because Col 2 was excluded, 
                // the A1:C1 merge maps to A1:B1 in the destination
                dest.Cells["A1:B1"].Merge = true;

                // Copy Column Widths from OptionsSheet
                int colWidthDest = 1;
                for (int col = 1; col <= 3; col++)
                {
                    if (!exportCol[col - 1]) continue;
                    dest.Column(colWidthDest).Width = options.Column(col).Width;
                    colWidthDest++;
                }
            }, package =>
            {
                var dest = package.Workbook.Worksheets["ExportedExcluded"];
                Assert.IsNotNull(dest);

                // 1. Verify Header values & styles (now in columns A and B)
                Assert.AreEqual("Employee Info", dest.Cells["A1"].Value);
                Assert.IsTrue(dest.Cells["A1"].Style.Font.Bold);
                Assert.AreEqual("FF000080", dest.Cells["A1"].Style.Font.Color.Rgb);

                Assert.AreEqual("ID", dest.Cells["A2"].Value);
                Assert.AreEqual("Salary", dest.Cells["B2"].Value);
                Assert.IsTrue(dest.Cells["B2"].Style.Font.Bold);

                // 2. Verify Data values & salary number formatting
                Assert.AreEqual(1.0, Convert.ToDouble(dest.Cells["A3"].Value));
                Assert.AreEqual(1500.25, Convert.ToDouble(dest.Cells["B3"].Value));
                Assert.AreEqual("$#,##0.00", dest.Cells["B3"].Style.Numberformat.Format);

                // 3. Verify Footer values & formulas
                Assert.AreEqual("Total", dest.Cells["A6"].Value);
                Assert.AreEqual("=SUM(B3:B5)", dest.Cells["B6"].Formula);

                // 4. Verify merges
                Assert.IsTrue(dest.MergedCells.Contains("A1:B1"));
                Assert.IsFalse(dest.MergedCells.Contains("A1:C1"));

                // 5. Verify Column widths
                Assert.AreEqual(10d, dest.Column(1).Width, 0.1);
                Assert.AreEqual(15d, dest.Column(2).Width, 0.1);
            });
        }

        private static void CopyCellStyle(ExcelRange src, ExcelRange dest)
        {
            var s = src.Style;
            var d = dest.Style;

            d.Font.Name = s.Font.Name;
            d.Font.Size = s.Font.Size;
            d.Font.Bold = s.Font.Bold;
            d.Font.Italic = s.Font.Italic;
            if (s.Font.Color != null && s.Font.Color.Rgb != null)
            {
                d.Font.Color.SetColor(ColorTranslator.FromHtml("#" + s.Font.Color.Rgb));
            }

            d.Fill.PatternType = s.Fill.PatternType;
            if (s.Fill.BackgroundColor != null && s.Fill.BackgroundColor.Rgb != null)
            {
                d.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#" + s.Fill.BackgroundColor.Rgb));
            }

            d.Numberformat.Format = s.Numberformat.Format;

            d.Border.Top.Style = s.Border.Top.Style;
            if (s.Border.Top.Color != null && s.Border.Top.Color.Rgb != null)
            {
                d.Border.Top.Color.SetColor(ColorTranslator.FromHtml("#" + s.Border.Top.Color.Rgb));
            }

            d.Border.Bottom.Style = s.Border.Bottom.Style;
            if (s.Border.Bottom.Color != null && s.Border.Bottom.Color.Rgb != null)
            {
                d.Border.Bottom.Color.SetColor(ColorTranslator.FromHtml("#" + s.Border.Bottom.Color.Rgb));
            }

            d.Border.Left.Style = s.Border.Left.Style;
            if (s.Border.Left.Color != null && s.Border.Left.Color.Rgb != null)
            {
                d.Border.Left.Color.SetColor(ColorTranslator.FromHtml("#" + s.Border.Left.Color.Rgb));
            }

            d.Border.Right.Style = s.Border.Right.Style;
            if (s.Border.Right.Color != null && s.Border.Right.Color.Rgb != null)
            {
                d.Border.Right.Color.SetColor(ColorTranslator.FromHtml("#" + s.Border.Right.Color.Rgb));
            }
        }
    }
}
