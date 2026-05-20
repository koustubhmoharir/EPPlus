using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;

namespace EPPlusTest
{
    [TestClass]
    public class ExcelWorksheetViewDivergenceTest
    {
        [TestMethod]
        public void TestTabSelectedBaseline()
        {
            using (var pck = new ExcelPackage())
            {
                var ws1 = pck.Workbook.Worksheets.Add("Sheet1");
                var ws2 = pck.Workbook.Worksheets.Add("Sheet2");

                ws1.View.TabSelected = true;
                Assert.IsTrue(ws1.View.TabSelected);
                Assert.IsFalse(ws2.View.TabSelected);

                ws2.View.TabSelected = true;
                Assert.IsTrue(ws2.View.TabSelected);
                Assert.IsFalse(ws1.View.TabSelected, "Setting TabSelected=true on Sheet2 should deselect Sheet1");
            }
        }

#if Core
        [TestMethod]
        public void TestTabSelectedMulti()
        {
            using (var pck = new ExcelPackage())
            {
                var ws1 = pck.Workbook.Worksheets.Add("Sheet1");
                var ws2 = pck.Workbook.Worksheets.Add("Sheet2");

                ws1.View.TabSelected = true;
                ws2.View.TabSelectedMulti = true;
                
                Assert.IsTrue(ws1.View.TabSelected, "Sheet1 should still be selected");
                Assert.IsTrue(ws2.View.TabSelected, "Sheet2 should also be selected");
            }
        }
#endif
    }
}
