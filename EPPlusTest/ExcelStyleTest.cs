using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
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
            using (var p = new ExcelPackage())
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
                // Use a safe way to access the node, as StyleID might behave differently across versions
                bool found = false;
                foreach(System.Xml.XmlNode node in nodes)
                {
                    if (node.Attributes["quotePrefix"] != null && node.Attributes["quotePrefix"].Value == "1")
                    {
                        found = true;
                        break;
                    }
                }
                Assert.IsTrue(found, "quotePrefix='1' should be found in one of the xf nodes");
            }
        }

        [TestMethod]
        public void ApplyProtectionAndAlignmentTest()
        {
            using (var p = new ExcelPackage())
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
                
                foreach(System.Xml.XmlNode node in nodes)
                {
                    Assert.IsNull(node.Attributes["applyProtection"], "applyProtection should not exist in stable");
                    Assert.IsNull(node.Attributes["applyAlignment"], "applyAlignment should not exist in stable");
                }
            }
        }
    }
}
