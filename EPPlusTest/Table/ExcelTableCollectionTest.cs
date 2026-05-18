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
                
#if Core
                // In dotnetport (.NET 9), names that look like cell addresses are disallowed.
                try
                {
                    ws.Tables.Add(range, "A1");
                    Assert.Fail("Should have thrown ArgumentException for name 'A1'");
                }
                catch (ArgumentException ex)
                {
                    Assert.AreEqual("Tablename is not valid", ex.Message);
                }
                
                // A valid name should still work
                ws.Tables.Add(range, "MyTable");
                Assert.AreEqual("MyTable", ws.Tables[0].Name);
#else
                // In stable (Mono), "A1" is allowed as a table name.
                ws.Tables.Add(range, "A1");
                Assert.AreEqual("A1", ws.Tables[0].Name);
#endif
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
