using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Sparkline;
using Color = OfficeOpenXml.Style.ExcelColorValue;
using System;

namespace EPPlusTest
{
    [TestClass]
    public class ExcelColorTest
    {
        [TestMethod]
        public void LookupColorTintRounding()
        {
            using (var p = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
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
            using (var p = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = p.Workbook.Worksheets.Add("ColorTest");
                var cell = ws.Cells["A1"];
                cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                var color = cell.Style.Fill.BackgroundColor;

                color.SetColor(Color.Red);
                Assert.AreEqual("FFFF0000", color.Rgb);

                color.SetColor(128, 255, 0, 255);
                Assert.AreEqual("80FF00FF", color.Rgb);

                color.SetColor(new ExcelColorValue(0x80, 0x11, 0x22, 0x33));
                Assert.AreEqual("80112233", color.Rgb);

                color.SetColor("80112233");
                Assert.AreEqual("80112233", color.Rgb);
            }
        }

        [TestMethod]
        public void ExcelColorValueToArgbHex()
        {
            var color = new ExcelColorValue(0x12, 0x34, 0x56, 0x78);

            Assert.AreEqual("12345678", color.ToArgbHex());
            Assert.AreEqual("12345678", color.ToString());
            Assert.AreEqual(color, new ExcelColorValue(0x12, 0x34, 0x56, 0x78));
            Assert.AreNotEqual(color, new ExcelColorValue(0x12, 0x34, 0x56, 0x79));
        }

        [TestMethod]
        public void SparklineColorSupportsNativeValue()
        {
            using (var p = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = p.Workbook.Worksheets.Add("SparklineColorTest");
                ws.Cells["A1"].Value = 1;
                ws.Cells["A2"].Value = 2;
                var sparkline = ws.SparklineGroups.Add(eSparklineType.Column, ws.Cells["B1:B2"], ws.Cells["A1:A2"]);

                sparkline.ColorHigh.SetColor(new ExcelColorValue(0xFF, 0xAA, 0xBB, 0xCC));
                Assert.AreEqual("FFAABBCC", sparkline.ColorHigh.Rgb);
            }
        }
    }
}
