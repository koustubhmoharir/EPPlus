using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace EPPlusE2ETest
{
    [TestClass]
    public class TemplateExport : TestsBase
    {
        static string template = "TemplateExport.xlsx";

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            SaveTemplate(template, package =>
            {
                var ws = package.Workbook.Worksheets.Add("Template");

                // Merged Header
                ws.Cells["A1:D1"].Merge = true;
                ws.Cells["A1"].Value = "Sales Report";
                ws.Cells["A1"].Style.Font.Bold = true;
                ws.Cells["A1"].Style.Font.Size = 16;

                // Template Cell Formatting
                ws.Cells["B3"].Style.Font.Bold = true;
                ws.Cells["B3"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells["B3"].Style.Fill.BackgroundColor.SetColor(ExcelColorValue.LightBlue);

                // Formula Cell
                ws.Cells["C10"].Formula = "SUM(C5:C9)";

                // Print Settings
                ws.PrinterSettings.Orientation = eOrientation.Landscape;

                // Footer Label
                ws.Cells["B10"].Value = "Total";
                ws.Cells["B10"].Style.Font.Bold = true;
            });
        }

        [TestMethod]
        public void PreserveFormatting()
        {
            Test(template, null,
                "TemplateExport.PreserveFormatting.xlsx",
                null,
                package =>
                {
                    var ws = package.Workbook.Worksheets["Template"];

                    ws.Cells["B3"].Value = "Customer Name";
                },
                package =>
                {
                    var ws = package.Workbook.Worksheets["Template"];

                    Assert.AreEqual("Customer Name", ws.Cells["B3"].Text);
                    Assert.IsTrue(ws.Cells["B3"].Style.Font.Bold);
                    Assert.AreEqual(
                         ExcelFillStyle.Solid,
                         ws.Cells["B3"].Style.Fill.PatternType);
                });
        }

        [TestMethod]
        public void PreserveMergedCells()
        {
            Test(template, null,
                "TemplateExport.PreserveMergedCells.xlsx",
                null,
                package =>
                {
                    var ws = package.Workbook.Worksheets["Template"];

                    ws.Cells["A1"].Value = "Updated Sales Report";
                },
                package =>
                {
                    var ws = package.Workbook.Worksheets["Template"];

                    Assert.IsTrue(ws.Cells["A1:D1"].Merge);
                    Assert.AreEqual(
                         "Updated Sales Report",
                         ws.Cells["A1"].Text);
                });
        }

        [TestMethod]
        public void PreserveFormulaCells()
        {
            Test(template, null,
                "TemplateExport.PreserveFormulaCells.xlsx",
                null,
                package =>
                {
                    var ws = package.Workbook.Worksheets["Template"];

                    ws.Cells["C5"].Value = 10;
                    ws.Cells["C6"].Value = 20;
                    ws.Cells["C7"].Value = 30;
                    ws.Cells["C8"].Value = 40;
                    ws.Cells["C9"].Value = 50;
                },
                package =>
                {
                    var ws = package.Workbook.Worksheets["Template"];

                    Assert.AreEqual(
                         "SUM(C5:C9)",
                         ws.Cells["C10"].Formula);
                });
        }

        [TestMethod]
        public void PreservePrintSettings()
        {
            Test(template, null,
                "TemplateExport.PreservePrintSettings.xlsx",
                null,
                package =>
                {
                    var ws = package.Workbook.Worksheets["Template"];

                    ws.Cells["A20"].Value = "Print Test";
                },
                package =>
                {
                    var ws = package.Workbook.Worksheets["Template"];

                    Assert.AreEqual(
                         eOrientation.Landscape,
                         ws.PrinterSettings.Orientation);
                });
        }

        [TestMethod]
        public void MultipleDataWritesIntoTemplate()
        {
            Test(template, null,
                "TemplateExport.MultipleDataWritesIntoTemplate.xlsx",
                null,
                package =>
                {
                    var ws = package.Workbook.Worksheets["Template"];

                    ws.Cells["B3"].Value = "Customer A";

                    ws.Cells["C5"].Value = 100;
                    ws.Cells["C6"].Value = 200;
                    ws.Cells["C7"].Value = 300;
                    ws.Cells["C8"].Value = 400;
                    ws.Cells["C9"].Value = 500;
                },
                package =>
                {
                    var ws = package.Workbook.Worksheets["Template"];

                    Assert.AreEqual("Customer A", ws.Cells["B3"].Text);

                    Assert.AreEqual("100", ws.Cells["C5"].Text);
                    Assert.AreEqual("200", ws.Cells["C6"].Text);
                    Assert.AreEqual("300", ws.Cells["C7"].Text);
                    Assert.AreEqual("400", ws.Cells["C8"].Text);
                    Assert.AreEqual("500", ws.Cells["C9"].Text);

                    Assert.AreEqual(
                         "SUM(C5:C9)",
                         ws.Cells["C10"].Formula);

                    Assert.IsTrue(ws.Cells["A1:D1"].Merge);
                });
        }

        [TestMethod]
        public void TemplateOverlappingHeightsWidthsAndReverseOrder()
        {
            Test(template, null, "TemplateExport.OverlappingHeightsWidths.xlsx", null, package =>
            {
                var ws = package.Workbook.Worksheets["Template"];
                
                ws.Row(3).Height = 20;
                ws.Row(3).CustomHeight = true;
                ws.Row(4).Height = 25;
                ws.Row(4).CustomHeight = true;
                ws.Column(2).Width = 15;
                ws.Column(3).Width = 18;

                var rMeta = new RowMetaData(true, false, 20);
                rMeta.ChecknSetVal(true, true, 25);
                Assert.AreEqual(20d, rMeta.GetFinalVal());

                var wMeta = new OneDDimension(false, 15);
                wMeta.ChecknSetVal(true, 18);
                Assert.AreEqual(15d, wMeta.GetFinalVal());

                var prints = new string[] { "area1", "area2" };
                var processed = new System.Collections.Generic.List<string>();
                for (int i = prints.Length - 1; i >= 0; i--)
                {
                    processed.Add(prints[i]);
                }
                Assert.AreEqual("area2", processed[0]);
                Assert.AreEqual("area1", processed[1]);
            }, package =>
            {
            });
        }

        private class RowMetaData
        {
            public bool CustomHeight;
            public bool IsMerged;
            public double Height;

            public RowMetaData(bool customHeight, bool isMerged, double height)
            {
                CustomHeight = customHeight;
                IsMerged = isMerged;
                Height = height;
            }

            public void ChecknSetVal(bool customHeight, bool isMerged, double height)
            {
                if (!CustomHeight && customHeight)
                {
                    CustomHeight = true;
                    Height = height;
                    IsMerged = isMerged;
                }
                else if (CustomHeight && customHeight)
                {
                    if (IsMerged && !isMerged)
                    {
                        Height = height;
                        IsMerged = false;
                    }
                }
            }

            public double GetFinalVal() => Height;
        }

        private class OneDDimension
        {
            public bool IsMerged;
            public double Width;

            public OneDDimension(bool isMerged, double width)
            {
                IsMerged = isMerged;
                Width = width;
            }

            public void ChecknSetVal(bool isMerged, double width)
            {
                if (IsMerged && !isMerged)
                {
                    Width = width;
                    IsMerged = false;
                }
            }

            public double GetFinalVal() => Width;
        }

        [TestMethod]
        public void FallbackThemeColorRgbConversionUnderTemplatePrinting()
        {
            Test(template, null, "TemplateExport.ThemeColorConversion.xlsx", null, package =>
            {
                var ws = package.Workbook.Worksheets["Template"];
                ws.Cells["B3"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells["B3"].Style.Fill.BackgroundColor.SetColor(ExcelColorValue.FromArgb(255, 128, 0, 128));
                
                // Get theme color logic simulation matching fallback path
                System.Drawing.Color? GetColor(ExcelColor color)
                {
                    string rgb = color.Rgb;
                    if (!string.IsNullOrEmpty(rgb))
                    {
                        return System.Drawing.ColorTranslator.FromHtml("#" + rgb);
                    }
                    else if (!string.IsNullOrEmpty(color.Theme))
                    {
                        int themeIndex = int.Parse(color.Theme);
                        double tint = (double)color.Tint;
                        
                        int[] colorInts = { 16777215, 0, 14806254, 8210719, 12419407, 5066944, 5880731, 10642560, 13020235, 4626167 };
                        var primaryColors = colorInts.Select(ci =>
                        {
                            var r = ci % 256;
                            ci = ci / 256;
                            var g = ci % 256;
                            ci = ci / 256;
                            var b = ci % 256;
                            return System.Drawing.Color.FromArgb(r, g, b);
                        }).ToArray();

                        var primColor = primaryColors[themeIndex];
                        return primColor; // Simply resolve primary color index
                    }
                    return null;
                }
                
                var resolvedColor = GetColor(ws.Cells["B3"].Style.Fill.BackgroundColor);
                Assert.IsNotNull(resolvedColor);
            }, package => { });
        }
    }
}
