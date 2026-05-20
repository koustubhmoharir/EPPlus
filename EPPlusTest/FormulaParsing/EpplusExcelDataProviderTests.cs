using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing;
using System;
using System.Linq;

namespace EPPlusTest.FormulaParsing
{
    [TestClass]
    public class EpplusExcelDataProviderTests
    {
        [TestMethod]
        public void GetRange_WithTableThisRow_ShouldReturnCorrectRange()
        {
            using (var package = new ExcelPackage())
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                ws.Cells["A1"].Value = "Header1";
                ws.Cells["A2"].Value = 1;
                ws.Cells["A3"].Value = 2;
                ws.Cells["A4"].Value = "Total";
                var table = ws.Tables.Add(ws.Cells["A1:A3"], "Table1");
                table.ShowTotal = true; // Adds a row, so table is A1:A4

                var provider = new EpplusExcelDataProvider(package);
                var range = provider.GetRange("Sheet1", 2, 1, "Table1[#This Row]");
                
                Assert.IsNotNull(range);
                Assert.AreEqual(2, range.Address.Start.Row);
                Assert.AreEqual(2, range.Address.End.Row);
                Assert.AreEqual(1, range.Address.Start.Column);
                Assert.AreEqual(1, range.Address.End.Column);
            }
        }

        [TestMethod]
        public void GetRange_WithTableAll_ShouldReturnCorrectRange()
        {
            using (var package = new ExcelPackage())
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                ws.Cells["A1"].Value = "Header1";
                ws.Cells["A2"].Value = 1;
                ws.Cells["A3"].Value = 2;
                ws.Cells["A4"].Value = "Total";
                var table = ws.Tables.Add(ws.Cells["A1:A3"], "Table1");
                table.ShowTotal = true; // Becomes A1:A4

                var provider = new EpplusExcelDataProvider(package);
                var range = provider.GetRange("Sheet1", 2, 1, "Table1[#All]");
                
                Assert.IsNotNull(range);
                Assert.AreEqual(1, range.Address.Start.Row);
                Assert.AreEqual(4, range.Address.End.Row);
                Assert.AreEqual(1, range.Address.Start.Column);
                Assert.AreEqual(1, range.Address.End.Column);
            }
        }

        [TestMethod]
        public void GetRange_WithTableAddress_ShouldReturnCorrectRange()
        {
            using (var package = new ExcelPackage())
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                ws.Cells["A1"].Value = "Header1";
                ws.Cells["A2"].Value = 1;
                ws.Cells["A3"].Value = 2;
                var table = ws.Tables.Add(ws.Cells["A1:A3"], "Table1");

                var provider = new EpplusExcelDataProvider(package);
                var range = provider.GetRange("Sheet1", "Table1[#All]");

                Assert.IsNotNull(range);
                Assert.AreEqual(1, range.Address.Start.Row);
                Assert.AreEqual(3, range.Address.End.Row);
                Assert.AreEqual(1, range.Address.Start.Column);
                Assert.AreEqual(1, range.Address.End.Column);
            }
        }

        [TestMethod]
        public void GetRange_WithTableHeaders_ShouldReturnCorrectRange()
        {
            using (var package = new ExcelPackage())
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                ws.Cells["A1"].Value = "Header1";
                ws.Cells["A2"].Value = 1;
                var table = ws.Tables.Add(ws.Cells["A1:A2"], "Table1");

                var provider = new EpplusExcelDataProvider(package);
                var range = provider.GetRange("Sheet1", 2, 1, "Table1[#Headers]");
                
                Assert.IsNotNull(range);
                Assert.AreEqual(1, range.Address.Start.Row);
                Assert.AreEqual(1, range.Address.End.Row);
            }
        }

        [TestMethod]
        public void GetRange_WithTableData_ShouldReturnCorrectRange()
        {
            using (var package = new ExcelPackage())
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                ws.Cells["A1"].Value = "Header1";
                ws.Cells["A2"].Value = 1;
                ws.Cells["A3"].Value = 2;
                ws.Cells["A4"].Value = "Total";
                var table = ws.Tables.Add(ws.Cells["A1:A3"], "Table1");
                table.ShowTotal = true; // Becomes A1:A4

                var provider = new EpplusExcelDataProvider(package);
                var range = provider.GetRange("Sheet1", 2, 1, "Table1[#Data]");
                
                Assert.IsNotNull(range);
                Assert.AreEqual(2, range.Address.Start.Row);
                Assert.AreEqual(3, range.Address.End.Row);
            }
        }

        [TestMethod]
        public void GetRange_WithTableTotals_ShouldReturnCorrectRange()
        {
            using (var package = new ExcelPackage())
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                ws.Cells["A1"].Value = "Header1";
                ws.Cells["A2"].Value = 1;
                ws.Cells["A3"].Value = "Total";
                var table = ws.Tables.Add(ws.Cells["A1:A2"], "Table1");
                table.ShowTotal = true; // Becomes A1:A3

                var provider = new EpplusExcelDataProvider(package);
                var range = provider.GetRange("Sheet1", 2, 1, "Table1[#Totals]");
                
                Assert.IsNotNull(range);
                Assert.AreEqual(3, range.Address.Start.Row);
                Assert.AreEqual(3, range.Address.End.Row);
            }
        }

        [TestMethod]
        public void GetRange_WithNormalAddress_ShouldReturnCorrectRange()
        {
            using (var package = new ExcelPackage())
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                ws.Cells["A1"].Value = 1;
                ws.Cells["B1:B2"].Value = 2;

                var provider = new EpplusExcelDataProvider(package);
                var range = provider.GetRange("Sheet1", 1, 1, "B1:B2");
                
                Assert.IsNotNull(range);
                Assert.AreEqual(1, range.Address.Start.Row);
                Assert.AreEqual(2, range.Address.End.Row);
                Assert.AreEqual(2, range.Address.Start.Column);
                Assert.AreEqual(2, range.Address.End.Column);
            }
        }
    }
}
