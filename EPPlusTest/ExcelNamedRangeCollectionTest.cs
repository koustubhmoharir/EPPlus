using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.ExcelUtilities;

namespace EPPlusTest
{
    [TestClass]
    public class ExcelNamedRangeCollectionTest
    {
        [TestMethod]
        public void TestNamedRangeCollectionAddAndLookup()
        {
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                
                // Test Add range
                var range = ws.Cells["A1:B2"];
                var namedRange = ws.Names.Add("MyRange", range);
                Assert.AreEqual("MyRange", namedRange.Name);
                Assert.AreEqual("A1:B2", namedRange.Address);
                
                // Test contains and indexer (case insensitivity)
                Assert.IsTrue(ws.Names.ContainsKey("MyRange"));
                Assert.IsTrue(ws.Names.ContainsKey("MYRANGE"));
                Assert.IsTrue(ws.Names.ContainsKey("myrange"));
                
                var lookedUp = ws.Names["MYRANGE"];
                Assert.AreEqual(namedRange, lookedUp);

                // Test index-based indexer
                Assert.AreEqual(namedRange, ws.Names[0]);
            }
        }

        [TestMethod]
        public void TestNamedRangeCollectionAddValueAndFormula()
        {
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                
                // Test AddValue
                var namedValue = ws.Names.AddValue("MyValue", 42);
                Assert.AreEqual("MyValue", namedValue.Name);
                Assert.AreEqual(42, namedValue.NameValue);
                
                // Test AddFormula
                var namedFormula = ws.Names.AddFormula("MyFormula", "SUM(A1:B2)");
                Assert.AreEqual("MyFormula", namedFormula.Name);
                Assert.AreEqual("SUM(A1:B2)", namedFormula.NameFormula);
                
                // Test AddFormla (obsolete)
#pragma warning disable 0618
                var namedFormlaObsolete = ws.Names.AddFormla("MyFormlaObsolete", "AVERAGE(A1:B2)");
                Assert.AreEqual("MyFormlaObsolete", namedFormlaObsolete.Name);
                Assert.AreEqual("AVERAGE(A1:B2)", namedFormlaObsolete.NameFormula);
#pragma warning restore 0618
            }
        }

        [TestMethod]
        public void TestNamedRangeCollectionRemoveAndClear()
        {
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                
                ws.Names.Add("Range1", ws.Cells["A1"]);
                ws.Names.Add("Range2", ws.Cells["A2"]);
                ws.Names.Add("Range3", ws.Cells["A3"]);
                
                Assert.AreEqual(3, ws.Names.Count);
                
                ws.Names.Remove("Range2");
                Assert.AreEqual(2, ws.Names.Count);
                Assert.IsTrue(ws.Names.ContainsKey("Range1"));
                Assert.IsFalse(ws.Names.ContainsKey("Range2"));
                Assert.IsTrue(ws.Names.ContainsKey("Range3"));
                
                // Assert indices were updated/shifted down
                Assert.AreEqual("Range1", ws.Names[0].Name);
                Assert.AreEqual("Range3", ws.Names[1].Name);
                
                ws.Names.Clear();
                Assert.AreEqual(0, ws.Names.Count);
            }
        }

        [TestMethod]
        public void TestNamedRangeCollectionNameValidation()
        {
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                
                // On dotnetport, invalid names should throw.
                // Check if ExcelAddressUtil.IsValidName exists (i.e. dotnetport).
                var isValidNameMethod = typeof(ExcelAddressUtil).GetMethod("IsValidName", new[] { typeof(string) });
                if (isValidNameMethod != null)
                {
                    // Dotnetport behavior
                    try
                    {
                        ws.Names.Add("Invalid?Name", ws.Cells["A1"]);
                        Assert.Fail("Should have thrown ArgumentException for invalid name on dotnetport branch");
                    }
                    catch (ArgumentException)
                    {
                        // Expected
                    }
                }
                else
                {
                    // Stable branch behavior: should not throw
                    var nr = ws.Names.Add("Invalid?Name", ws.Cells["A1"]);
                    Assert.AreEqual("Invalid?Name", nr.Name);
                }
            }
        }

        [TestMethod]
        public void TestNamedRangeCollectionInsertRowsAndColumnsBounds()
        {
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                
                int maxCols = ExcelPackage.MaxColumns;
                int maxRows = ExcelPackage.MaxRows;

                var nrColEdge = ws.Names.Add("ColEdge", ws.Cells[1, maxCols - 2, 2, maxCols - 1]); // e.g. columns 16382 to 16383
                var nrRowEdge = ws.Names.Add("RowEdge", ws.Cells[maxRows - 2, 1, maxRows - 1, 2]); // e.g. rows 1048574 to 1048575

                var isValidNameMethod = typeof(ExcelAddressUtil).GetMethod("IsValidName", new[] { typeof(string) });
                if (isValidNameMethod != null)
                {
                    // dotnetport: bounds check exists
                    ws.InsertColumn(maxCols - 1, 2);
                    Assert.AreEqual("Sheet1!" + ExcelCellBase.GetAddress(1, maxCols - 2, 2, maxCols - 1), nrColEdge.FullAddress.Replace("'", ""));

                    ws.InsertRow(maxRows - 1, 2);
                    Assert.AreEqual("Sheet1!" + ExcelCellBase.GetAddress(maxRows - 2, 1, maxRows - 1, 2), nrRowEdge.FullAddress.Replace("'", ""));
                }
                else
                {
                    // stable: no bounds check, so it might throw ArgumentOutOfRangeException or similar.
                    try
                    {
                        ws.InsertColumn(maxCols - 1, 2);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        // Expected on stable
                    }

                    try
                    {
                        ws.InsertRow(maxRows - 1, 2);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        // Expected on stable
                    }
                }
            }
        }
    }
}
