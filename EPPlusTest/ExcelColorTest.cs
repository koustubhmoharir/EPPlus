using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using System;

namespace EPPlusTest
{
    [TestClass]
    public class ExcelColorTest
    {
        [TestMethod]
        public void LookupColorTintRounding()
        {
            using (var p = new ExcelPackage())
            {
                var ws = p.Workbook.Worksheets.Add("ColorTest");
                var cell = ws.Cells["A1"];
                cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                var color = cell.Style.Fill.BackgroundColor;
                
                color.Indexed = 64;

                color.Tint = -0.5m; 
                // -0.5 * -512 = 256. Round(256) = 256. 256 in hex is 100.
                Assert.AreEqual("#FF100100100", color.LookupColor());

                color.Tint = -0.12345m;
                // -0.12345 * -512 = 63.2064. Round = 63. Hex = 3F.
                Assert.AreEqual("#FF3F3F3F", color.LookupColor());

                color.Tint = -0.999m;
                // -0.999 * -512 = 511.488. Round = 511. Hex = 1FF.
                Assert.AreEqual("#FF1FF1FF1FF", color.LookupColor());
                
                // Testing midpoint rounding
                // -0.0009765625 * -512 = 0.5
                color.Tint = -0.0009765625m;
                // decimal.Round(0.5) = 0 (ToEven)
                Assert.AreEqual("#FF000", color.LookupColor());

                // -0.0029296875 * -512 = 1.5
                color.Tint = -0.0029296875m;
                // decimal.Round(1.5) = 2 (ToEven)
                Assert.AreEqual("#FF222", color.LookupColor());
            }
        }

        [TestMethod]
        public void SetColorTest()
        {
            using (var p = new ExcelPackage())
            {
                var ws = p.Workbook.Worksheets.Add("ColorTest");
                var cell = ws.Cells["A1"];
                cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                var color = cell.Style.Fill.BackgroundColor;
                
                color.SetColor(Color.Red);
                Assert.AreEqual("FFFF0000", color.Rgb);

                color.SetColor(128, 255, 0, 255);
                Assert.AreEqual("80FF00FF", color.Rgb);
            }
        }
    }
}
