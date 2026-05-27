using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using System.Xml;

namespace EPPlusTest.Table
{
    [TestClass]
    public class ExcelTableCollectionTest
    {
        [TestMethod]
        public void TableNameValidationTest()
        {
            using (var pck = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = pck.Workbook.Worksheets.Add("Sheet1");
                var range = ws.Cells["A1:C5"];
                
                // "A1" should be allowed in stable but might be disallowed in dotnetport if it looks like an address
                ws.Tables.Add(range, "A1");
                Assert.AreEqual("A1", ws.Tables[0].Name);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TableNameWithSpacesShouldFail()
        {
            using (var pck = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
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
            using (var pck = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = pck.Workbook.Worksheets.Add("Sheet1");
                var range = ws.Cells["A1:C5"];
                ws.Tables.Add(range, "1Table");
            }
        }

        [TestMethod]
        public void TableNameEscapingTest()
        {
            using (var pck = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = pck.Workbook.Worksheets.Add("Sheet1");
                var range = ws.Cells["A1:C5"];
                
                // In stable, displayName is cleaned using regex [^\w\.-_] -> _
                // '#' is outside the range .-_
                string name = "Table_Name_With_#";
                var table = ws.Tables.Add(range, name);
                
                Assert.AreEqual(name, table.Name);
                
                var doc = table.TableXml;
                var displayName = doc.DocumentElement.GetAttribute("displayName");
                
                // In stable, # is replaced by _
                Assert.AreEqual("Table_Name_With__", displayName);
            }
        }
    }
}
