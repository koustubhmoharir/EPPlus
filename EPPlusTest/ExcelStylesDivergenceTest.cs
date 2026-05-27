using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.IO;

namespace EPPlusTest
{
    [TestClass]
    public class ExcelStylesDivergenceTest
    {
        [TestMethod]
        public void CreateNamedStyleFromOtherWorkbookTest()
        {
            using (var p1 = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws1 = p1.Workbook.Worksheets.Add("Sheet1");
                var ns1 = p1.Workbook.Styles.CreateNamedStyle("CustomStyle1");
                ns1.Style.Font.Bold = true;
                ns1.Style.Fill.PatternType = ExcelFillStyle.Solid;
                ns1.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Red);

                using (var p2 = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
                {
                    var ws2 = p2.Workbook.Worksheets.Add("Sheet1");
                    
                    var ns2 = p2.Workbook.Styles.CreateNamedStyle("CustomStyle2", ns1.Style);
                    
                    Assert.AreEqual("CustomStyle2", ns2.Name);
                    Assert.IsTrue(ns2.Style.Font.Bold);
                    Assert.AreEqual(ExcelFillStyle.Solid, ns2.Style.Fill.PatternType);
                    
                    // Modify ns2 and ensure ns1 is not affected
                    ns2.Style.Font.Bold = false;
                    Assert.IsFalse(ns2.Style.Font.Bold);
                    Assert.IsTrue(ns1.Style.Font.Bold);
                }
            }
        }

        [TestMethod]
        public void AddNewStyleColumnContiguousRangeTest()
        {
            using (var p = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = p.Workbook.Worksheets.Add("Sheet1");
                
                // Define some columns but not all in a range
                ws.Column(1).Width = 10;
                ws.Column(3).Width = 20;
                
                // Apply style to range A:D (1 to 4)
                ws.Cells["A:D"].Style.Font.Bold = true;
                
                Assert.IsTrue(ws.Column(1).Style.Font.Bold);
                Assert.IsTrue(ws.Column(2).Style.Font.Bold);
                Assert.IsTrue(ws.Column(3).Style.Font.Bold);
                Assert.IsTrue(ws.Column(4).Style.Font.Bold);
                
                var col2 = ws.Column(2);
                Assert.AreEqual(2, col2.ColumnMin);
                Assert.AreEqual(2, col2.ColumnMax);
                Assert.IsTrue(col2.Style.Font.Bold);
            }
        }
    }
}
