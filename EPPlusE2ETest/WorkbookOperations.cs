using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;

namespace EPPlusE2ETest
{
    [TestClass]
    public class WorkbookOperations : TestsBase
    {
        [TestMethod]
        public void ReuseExistingWorkbook_AddNewSheet()
        {
            string filePath =
                Path.Combine(OutputsDirectory,
                "ExistingWorkbook.AddNewSheet.xlsx");

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            // Create initial workbook
            using (var package = new ExcelPackage())
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                ws.Cells["A1"].Value = "Original Sheet";

                package.SaveAs(new FileInfo(filePath));
            }

            // Simulate replaceExistingFile = 0
            using (var package =
                new ExcelPackage(new FileInfo(filePath)))
            {
                var ws = package.Workbook.Worksheets.Add("Sheet2");
                ws.Cells["A1"].Value = "New Sheet";

                package.Save();
            }

            // Verify
            using (var package =
                new ExcelPackage(new FileInfo(filePath)))
            {
                Assert.AreEqual(
                    2,
                    package.Workbook.Worksheets.Count);

                Assert.AreEqual(
                    "Original Sheet",
                    package.Workbook.Worksheets["Sheet1"]
                        .Cells["A1"].Text);

                Assert.AreEqual(
                    "New Sheet",
                    package.Workbook.Worksheets["Sheet2"]
                        .Cells["A1"].Text);
            }
        }

        [TestMethod]
        public void ExistingSheet_ClearAndRewrite()
        {
            string filePath =
                Path.Combine(OutputsDirectory,
                "ExistingWorkbook.ClearSheet.xlsx");

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            // Create initial workbook
            using (var package = new ExcelPackage())
            {
                var ws = package.Workbook.Worksheets.Add("Report");

                ws.Cells["A1"].Value = "Old Data";
                ws.Cells["B1"].Value = "Old Value";

                package.SaveAs(new FileInfo(filePath));
            }

            // Simulate SheetKraft sheet.Cells.Clear()
            using (var package =
                new ExcelPackage(new FileInfo(filePath)))
            {
                var ws =
                    package.Workbook.Worksheets["Report"];

                ws.Cells.Clear();

                ws.Cells["A1"].Value = "New Data";
                ws.Cells["B1"].Value = "New Value";

                package.Save();
            }

            // Verify
            using (var package =
                new ExcelPackage(new FileInfo(filePath)))
            {
                var ws =
                    package.Workbook.Worksheets["Report"];

                Assert.AreEqual(
                    "New Data",
                    ws.Cells["A1"].Text);

                Assert.AreEqual(
                    "New Value",
                    ws.Cells["B1"].Text);

                Assert.AreNotEqual(
                    "Old Data",
                    ws.Cells["A1"].Text);
            }
        }
    }
}
