using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.Table;

namespace EPPlusTest.Table
{
    [TestClass]
    public class ExcelTableCollectionTest
    {
        [TestMethod]
        public void TableNameValidationTest()
        {
            using (var pck = new ExcelPackage())
            {
                var ws = pck.Workbook.Worksheets.Add("Sheet1");
                var range = ws.Cells["A1:C5"];
                
                // "A1" should be allowed in stable but might be disallowed in dotnetport if it looks like an address
                // Actually, let's try something that is definitely a valid name in stable but potentially invalid in Excel
                ws.Tables.Add(range, "A1");
                Assert.AreEqual("A1", ws.Tables[0].Name);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TableNameWithSpacesShouldFail()
        {
            using (var pck = new ExcelPackage())
            {
                var ws = pck.Workbook.Worksheets.Add("Sheet1");
                var range = ws.Cells["A1:C5"];
                ws.Tables.Add(range, "Table with spaces");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TableNameWithInvalidStartCharShouldFail()
        {
            using (var pck = new ExcelPackage())
            {
                var ws = pck.Workbook.Worksheets.Add("Sheet1");
                var range = ws.Cells["A1:C5"];
                ws.Tables.Add(range, "1Table");
            }
        }
    }
}
