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

#if Core
                // In dotnetport, '#' is rejected by ValidateTableName
                try
                {
                    ws.Tables.Add(range, "Table#");
                    Assert.Fail("Should have thrown ArgumentException for name 'Table#'");
                }
                catch (ArgumentException ex)
                {
                    Assert.AreEqual("Tablename is not valid", ex.Message);
                }

                // A valid name should work and NOT be cleaned
                var table = ws.Tables.Add(range, "Table_Name_With_Underscore");
                Assert.AreEqual("Table_Name_With_Underscore", table.Name);
                var displayName = table.TableXml.DocumentElement.GetAttribute("displayName");
                Assert.AreEqual("Table_Name_With_Underscore", displayName);
#else
                // In stable, # is replaced by _ in displayName but kept in Name attribute
                string name = "Table_Name_With_#";
                var table = ws.Tables.Add(range, name);
                
                Assert.AreEqual(name, table.Name);
                
                var doc = table.TableXml;
                var displayName = doc.DocumentElement.GetAttribute("displayName");
                
                // In stable, # is replaced by _
                Assert.AreEqual("Table_Name_With__", displayName);
#endif
            }
        }
    }
}
