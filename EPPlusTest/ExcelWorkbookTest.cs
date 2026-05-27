using System;
using System.IO;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;

namespace EPPlusTest
{
    [TestClass]
    public class ExcelWorkbookTest : TestBase
    {
        [TestMethod]
        public void Workbook_Worksheets_Access_1Based()
        {
            using (var package = new ExcelPackage(new MemoryStream(), EPPlusTest.TempFolderHelper.Create()))
            {
                var ws1 = package.Workbook.Worksheets.Add("Sheet1");
                var ws2 = package.Workbook.Worksheets.Add("Sheet2");

                Assert.AreEqual(1, ws1.PositionID);
                Assert.AreEqual(2, ws2.PositionID);

                Assert.AreEqual("Sheet1", package.Workbook.Worksheets[1].Name);
                Assert.AreEqual("Sheet2", package.Workbook.Worksheets[2].Name);
            }
        }

        [TestMethod]
        public void Workbook_TableNames_CaseInsensitive_On_Stable()
        {
            using (var package = new ExcelPackage(new MemoryStream(), EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                var table = ws.Tables.Add(ws.Cells["A1:B2"], "MyTable");

                Assert.IsTrue(package.Workbook.ExistsTableName("MyTable"));
                Assert.IsTrue(package.Workbook.ExistsTableName("mytable"));
            }
        }

        [TestMethod]
        public void Workbook_PivotTableNames_CaseSensitive_On_Stable()
        {
            using (var package = new ExcelPackage(new MemoryStream(), EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                ws.Cells["A1:B10"].Value = 1;
                ws.Cells["A1"].Value = "Col1";
                ws.Cells["B1"].Value = "Col2";
                
                var pt = ws.PivotTables.Add(ws.Cells["D1"], ws.Cells["A1:B10"], "MyPivot");

                Assert.IsTrue(package.Workbook.ExistsPivotTableName("MyPivot"));
                Assert.IsFalse(package.Workbook.ExistsPivotTableName("mypivot"));
            }
        }

        [TestMethod]
        public void Workbook_Properties_CalcMode()
        {
            using (var package = new ExcelPackage(new MemoryStream(), EPPlusTest.TempFolderHelper.Create()))
            {
                Assert.AreEqual(ExcelCalcMode.Automatic, package.Workbook.CalcMode);
                
                package.Workbook.CalcMode = ExcelCalcMode.Manual;
                Assert.AreEqual(ExcelCalcMode.Manual, package.Workbook.CalcMode);

                package.Workbook.CalcMode = ExcelCalcMode.AutomaticNoTable;
                Assert.AreEqual(ExcelCalcMode.AutomaticNoTable, package.Workbook.CalcMode);
            }
        }

        [TestMethod]
        public void Workbook_Properties_Date1904()
        {
            using (var package = new ExcelPackage(new MemoryStream(), EPPlusTest.TempFolderHelper.Create()))
            {
                package.Workbook.Worksheets.Add("Sheet1");
                Assert.IsFalse(package.Workbook.Date1904);
                
                package.Workbook.Date1904 = true;
                Assert.IsTrue(package.Workbook.Date1904);
            }
        }
    }
}
