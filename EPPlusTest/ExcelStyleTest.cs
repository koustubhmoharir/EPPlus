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
                
                foreach(System.Xml.XmlNode node in nodes)
                {
                    Assert.IsNull(node.Attributes["applyProtection"], "applyProtection should not exist in stable");
                    Assert.IsNull(node.Attributes["applyAlignment"], "applyAlignment should not exist in stable");
                }
            }
        }
    }
}
