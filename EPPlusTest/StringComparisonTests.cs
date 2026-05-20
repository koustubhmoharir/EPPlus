using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using System;

namespace EPPlusTest
{
    [TestClass]
    public class StringComparisonTests
    {
        [TestMethod]
        public void WorksheetLookup_ShouldBeCaseInsensitive()
        {
            using (var package = new ExcelPackage())
            {
                var ws = package.Workbook.Worksheets.Add("MySheet");
                Assert.IsNotNull(package.Workbook.Worksheets["MYSHEET"]);
                Assert.IsNotNull(package.Workbook.Worksheets["mysheet"]);
            }
        }

        [TestMethod]
        public void TableLookup_ShouldBeCaseInsensitive()
        {
            using (var package = new ExcelPackage())
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                var table = ws.Tables.Add(ws.Cells["A1:B2"], "MyTable");
                Assert.AreEqual("MyTable", ws.Tables["MYTABLE"].Name);
                Assert.AreEqual("MyTable", ws.Tables["mytable"].Name);
            }
        }
    }
}
