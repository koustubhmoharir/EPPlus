using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using System.Xml;
using OfficeOpenXml.Style;
using System;

namespace EPPlusTest
{
    [TestClass]
    public class ExcelStyleTest
    {
        [TestMethod]
        public void QuotePrefixStyle()
        {
            using (var p = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = p.Workbook.Worksheets.Add("QuotePrefixTest");
                var cell = ws.Cells["B2"];
                cell.Style.QuotePrefix = true;
                Assert.IsTrue(cell.Style.QuotePrefix);

                p.Workbook.Styles.UpdateXml();                
                var nodes = p.Workbook.StylesXml.SelectNodes("//d:cellXfs/d:xf", p.Workbook.NameSpaceManager);
                // Since the quotePrefix attribute is not part of the default style,
                // a new one should be created and referenced.
                Assert.AreNotEqual(0, cell.StyleID);
                Assert.IsNull(nodes[0].Attributes["quotePrefix"]);
                Assert.AreEqual("1", nodes[cell.StyleID].Attributes["quotePrefix"].Value);
            }
        }
        [TestMethod]
        public void FontBaselineStyle()
        {
            using (var p = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = p.Workbook.Worksheets.Add("BaselineTest");
                var cell = ws.Cells["A1"];
                cell.Style.Font.VerticalAlign = ExcelVerticalAlignmentFont.Baseline;
                Assert.AreEqual(ExcelVerticalAlignmentFont.Baseline, cell.Style.Font.VerticalAlign);

                p.Workbook.Styles.UpdateXml();
                var nodes = p.Workbook.StylesXml.SelectNodes("//d:fonts/d:font/d:vertAlign", p.Workbook.NameSpaceManager);
                Assert.AreEqual(1, nodes.Count);
                Assert.AreEqual("baseline", nodes[0].Attributes["val"].Value);
            }
        }

        [TestMethod]
        public void GetFontHeightTest()
        {
            // Exact size
            var h12 = OfficeOpenXml.Style.XmlAccess.ExcelFontXml.GetFontHeight("Arial", 12);
            Assert.AreEqual(21f, h12);

            // In-between size
            var h13 = OfficeOpenXml.Style.XmlAccess.ExcelFontXml.GetFontHeight("Arial", 13);
            Assert.AreEqual(22.5f, h13);

            // Unknown font (falls back to Calibri)
            // Calibri 11 is 20
            var hUnknown = OfficeOpenXml.Style.XmlAccess.ExcelFontXml.GetFontHeight("UnknownFont", 11);
            Assert.AreEqual(20f, hUnknown);
        }

        [TestMethod]
        public void GetFontHeightEdgeCasesTest()
        {
            // Below minimum (Arial min is 6, height 20)
            var h4 = OfficeOpenXml.Style.XmlAccess.ExcelFontXml.GetFontHeight("Arial", 4);
            Assert.AreEqual(20f, h4);

            // Above maximum (Arial max is 256, height 424)
            var h300 = OfficeOpenXml.Style.XmlAccess.ExcelFontXml.GetFontHeight("Arial", 300);
            Assert.AreEqual(424f, h300);
        }

        [TestMethod]
        public void ApplyProtectionAndAlignmentTest()
        {
            using (var p = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = p.Workbook.Worksheets.Add("ApplyTest");
                var cell = ws.Cells["A1"];
                
                // Set protection
                cell.Style.Locked = false;
                
                // Set alignment
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                
                p.Workbook.Styles.UpdateXml();
                var nodes = p.Workbook.StylesXml.SelectNodes("//d:cellXfs/d:xf", p.Workbook.NameSpaceManager);
                
                Assert.IsTrue(nodes.Count > 0, "Should have at least one xf node");
                
                bool foundApplyProtection = false;
                bool foundApplyAlignment = false;

                foreach(System.Xml.XmlNode node in nodes)
                {
                    if (node.Attributes["applyProtection"] != null && node.Attributes["applyProtection"].Value == "1")
                    {
                        foundApplyProtection = true;
                    }
                    if (node.Attributes["applyAlignment"] != null && node.Attributes["applyAlignment"].Value == "1")
                    {
                        foundApplyAlignment = true;
                    }
                }

                // In dotnetport, these attributes SHOULD exist as "1" for the modified style.
                Assert.IsTrue(foundApplyProtection, "applyProtection='1' should exist in dotnetport");
                Assert.IsTrue(foundApplyAlignment, "applyAlignment='1' should exist in dotnetport");
            }
        }
    }
}
