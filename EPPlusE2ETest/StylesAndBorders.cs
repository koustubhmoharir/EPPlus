using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace EPPlusE2ETest
{
    [TestClass]
    public class StylesAndBorders : TestsBase
    {
        static string template = "StylesAndBorders.xlsx";

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            SaveTemplate(template, package =>
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                var cell = ws.Cells["A1"];
                cell.Value = "StyledText";

                // Set Font styles
                cell.Style.Font.Name = "Arial";
                cell.Style.Font.Size = 14;
                cell.Style.Font.Bold = true;
                cell.Style.Font.Italic = true;
                cell.Style.Font.Color.SetColor("FFFF0000");

                // Set Fill styles
                cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                cell.Style.Fill.BackgroundColor.SetColor("FFFFFF00");

                // Set Number format
                cell.Style.Numberformat.Format = "$#,##0.00";

                // Set Borders
                cell.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                cell.Style.Border.Top.Color.SetColor("FF0000FF");
                cell.Style.Border.Bottom.Style = ExcelBorderStyle.Double;
                cell.Style.Border.Bottom.Color.SetColor("FF008000");
            });
        }

        [TestMethod]
        public void CopyCellStylesAndBorders()
        {
            Test(template, null, "StylesAndBorders.CopyCellStylesAndBorders.xlsx", null, package =>
            {
                var ws = package.Workbook.Worksheets["Sheet1"];
                var src = ws.Cells["A1"].Style;
                var dest = ws.Cells["B2"].Style;

                // Copy Font
                dest.Font.Name = src.Font.Name;
                dest.Font.Size = src.Font.Size;
                dest.Font.Bold = src.Font.Bold;
                dest.Font.Italic = src.Font.Italic;
                if (src.Font.Color.Rgb != null)
                {
                    dest.Font.Color.SetColor(src.Font.Color.Rgb);
                }

                // Copy Fill
                dest.Fill.PatternType = src.Fill.PatternType;
                if (src.Fill.BackgroundColor.Rgb != null)
                {
                    dest.Fill.BackgroundColor.SetColor(src.Fill.BackgroundColor.Rgb);
                }

                // Copy NumberFormat
                dest.Numberformat.Format = src.Numberformat.Format;

                // Copy Borders
                dest.Border.Top.Style = src.Border.Top.Style;
                if (src.Border.Top.Color.Rgb != null)
                {
                    dest.Border.Top.Color.SetColor(src.Border.Top.Color.Rgb);
                }
                dest.Border.Bottom.Style = src.Border.Bottom.Style;
                if (src.Border.Bottom.Color.Rgb != null)
                {
                    dest.Border.Bottom.Color.SetColor(src.Border.Bottom.Color.Rgb);
                }
            }, package =>
            {
                var ws = package.Workbook.Worksheets["Sheet1"];
                var dest = ws.Cells["B2"].Style;

                // Verify Font styles
                Assert.AreEqual("Arial", dest.Font.Name);
                Assert.AreEqual(14, dest.Font.Size);
                Assert.IsTrue(dest.Font.Bold);
                Assert.IsTrue(dest.Font.Italic);
                Assert.AreEqual("FFFF0000", dest.Font.Color.Rgb); // Red color hex in OOXML is ARGB format FFFF0000

                // Verify Fill styles
                Assert.AreEqual(ExcelFillStyle.Solid, dest.Fill.PatternType);
                Assert.AreEqual("FFFFFF00", dest.Fill.BackgroundColor.Rgb); // Yellow color hex FFFFFFF00

                // Verify Number format
                Assert.AreEqual("$#,##0.00", dest.Numberformat.Format);

                // Verify Borders
                Assert.AreEqual(ExcelBorderStyle.Medium, dest.Border.Top.Style);
                Assert.AreEqual("FF0000FF", dest.Border.Top.Color.Rgb); // Blue color
                Assert.AreEqual(ExcelBorderStyle.Double, dest.Border.Bottom.Style);
                Assert.AreEqual("FF008000", dest.Border.Bottom.Color.Rgb); // Green color
            });
        }

        [TestMethod]
        public void StyleCopyBoldAndItalicResetProperties()
        {
            Test(template, null, "StylesAndBorders.StyleCopyReset.xlsx", null, package =>
            {
                var ws = package.Workbook.Worksheets["Sheet1"];
                
                // Set target cell as bold and italic
                var target = ws.Cells["B3"];
                target.Style.Font.Bold = true;
                target.Style.Font.Italic = true;
                
                // Source cell is NOT bold, NOT italic (default)
                var source = ws.Cells["C3"];
                
                // Simulate CellsFormatPattern.SetFont logic:
                // Only copies/overwrites if true (this is the gap we are asserting)
                void SetFontSim(ExcelFont src, ExcelFont dest)
                {
                    if (src.Bold)
                    {
                        dest.Bold = src.Bold;
                    }
                    if (src.Italic)
                    {
                        dest.Italic = src.Italic;
                    }
                }
                
                SetFontSim(source.Style.Font, target.Style.Font);
            }, package =>
            {
                var ws = package.Workbook.Worksheets["Sheet1"];
                var target = ws.Cells["B3"];
                
                // Under the simulated logic, target stays bold and italic because source was false
                Assert.IsTrue(target.Style.Font.Bold);
                Assert.IsTrue(target.Style.Font.Italic);
            });
        }
    }
}
