using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;

namespace EPPlusE2ETest
{
    [TestClass]
    public class PartitionedSheets : TestsBase
    {
        static string template = "PartitionedSheets.xlsx";

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            SaveTemplate(template, package =>
            {
                package.Workbook.Worksheets.Add("Sheet1");
            });
        }

        [TestMethod]
        public void PartitionByColumnValueWithHeaderAndFooter()
        {
            Test(template, null,
                "PartitionedSheets.PartitionByColumnValueWithHeaderAndFooter.xlsx",
                null,
                package =>
                {
                    var src = package.Workbook.Worksheets["Sheet1"];

                    // Report Header
                    src.Cells["A1:D1"].Merge = true;
                    src.Cells["A1"].Value = "Employee Report";
                    src.Cells["A1"].Style.Font.Bold = true;
                    src.Cells["A1"].Style.Font.Size = 14;

                    // Column Headers
                    src.Cells["A2"].Value = "Id";
                    src.Cells["B2"].Value = "Value1";
                    src.Cells["C2"].Value = "Value2";
                    src.Cells["D2"].Value = "Value3";

                    src.Cells["A2:D2"].Style.Font.Bold = true;

                    // Data
                    for (int i = 1; i <= 5; i++)
                    {
                        int row = i + 2;

                        src.Cells[row, 1].Value = i;
                        src.Cells[row, 2].Value = i + 1;
                        src.Cells[row, 3].Value = i + 2;
                        src.Cells[row, 4].Value = i + 3;
                    }

                    // Footer
                    src.Cells["A8"].Value = "Total";
                    src.Cells["A8"].Style.Font.Bold = true;

                    src.Cells["B8"].Formula = "SUM(B3:B7)";
                    src.Cells["C8"].Formula = "SUM(C3:C7)";
                    src.Cells["D8"].Formula = "SUM(D3:D7)";

                    package.Workbook.Calculate();

                    // Simulate SheetKraft Partition By Column A
                    for (int i = 1; i <= 5; i++)
                    {
                        string sheetName = i.ToString();

                        var partitionSheet =
                            package.Workbook.Worksheets.Add(sheetName);

                        // Header
                        src.Cells["A1:D1"]
                            .Copy(partitionSheet.Cells["A1"]);

                        // Column Header
                        src.Cells["A2:D2"]
                            .Copy(partitionSheet.Cells["A2"]);

                        // Matching Row
                        int sourceRow = i + 2;

                        src.Cells[sourceRow, 1, sourceRow, 4]
                            .Copy(partitionSheet.Cells["A3"]);

                        // Footer
                        src.Cells["A8:D8"]
                            .Copy(partitionSheet.Cells["A4"]);
                    }
                },
                package =>
                {
                    // Sheet1 + 5 Partition Sheets
                    Assert.AreEqual(
                        6,
                        package.Workbook.Worksheets.Count);

                    var sheet1 =
                        package.Workbook.Worksheets["1"];

                    var sheet5 =
                        package.Workbook.Worksheets["5"];

                    Assert.IsNotNull(sheet1);
                    Assert.IsNotNull(sheet5);

                    // Verify Report Header
                    Assert.AreEqual(
                        "Employee Report",
                        sheet1.Cells["A1"].Text);

                    Assert.IsTrue(
                        sheet1.Cells["A1"].Style.Font.Bold);

                    // Verify Column Header
                    Assert.AreEqual(
                        "Id",
                        sheet1.Cells["A2"].Text);

                    Assert.IsTrue(
                        sheet1.Cells["A2"].Style.Font.Bold);

                    // Verify Data Row
                    Assert.AreEqual(
                        "1",
                        sheet1.Cells["A3"].Text);

                    Assert.AreEqual(
                        "2",
                        sheet1.Cells["B3"].Text);

                    Assert.AreEqual(
                        "3",
                        sheet1.Cells["C3"].Text);

                    Assert.AreEqual(
                        "4",
                        sheet1.Cells["D3"].Text);

                    // Verify Footer
                    Assert.AreEqual(
                        "Total",
                        sheet1.Cells["A4"].Text);

                    Assert.IsTrue(
                        sheet1.Cells["A4"].Style.Font.Bold);

                    // Verify Last Partition Sheet
                    Assert.AreEqual(
                        "5",
                        sheet5.Cells["A3"].Text);

                    Assert.AreEqual(
                        "6",
                        sheet5.Cells["B3"].Text);

                    Assert.AreEqual(
                        "7",
                        sheet5.Cells["C3"].Text);

                    Assert.AreEqual(
                        "8",
                        sheet5.Cells["D3"].Text);
                });
        }
        [TestMethod]
        public void PartitionIntoMultipleFiles()
        {
            string exportFolder =
                Path.Combine(OutputsDirectory, "PartitionFiles");

            if (Directory.Exists(exportFolder))
            {
                Directory.Delete(exportFolder, true);
            }

            Directory.CreateDirectory(exportFolder);

            // Simulate partition values 1,2,3,4,5
            for (int i = 1; i <= 5; i++)
            {
                string filePath =
                    Path.Combine(exportFolder, $"{i}.xlsx");

                using (var package = new ExcelPackage())
                {
                    var ws =
                        package.Workbook.Worksheets.Add("Sheet1");

                    // Header
                    ws.Cells["A1:D1"].Merge = true;
                    ws.Cells["A1"].Value = "Employee Report";
                    ws.Cells["A1"].Style.Font.Bold = true;

                    // Column Headers
                    ws.Cells["A2"].Value = "Id";
                    ws.Cells["B2"].Value = "Value1";
                    ws.Cells["C2"].Value = "Value2";
                    ws.Cells["D2"].Value = "Value3";

                    ws.Cells["A2:D2"].Style.Font.Bold = true;

                    // Data Row
                    ws.Cells["A3"].Value = i;
                    ws.Cells["B3"].Value = i + 1;
                    ws.Cells["C3"].Value = i + 2;
                    ws.Cells["D3"].Value = i + 3;

                    // Footer
                    ws.Cells["A4"].Value = "Total";
                    ws.Cells["A4"].Style.Font.Bold = true;

                    package.SaveAs(new FileInfo(filePath));
                }
            }

            // Verify folder
            Assert.IsTrue(Directory.Exists(exportFolder));

            var files =
                Directory.GetFiles(exportFolder, "*.xlsx");

            Assert.AreEqual(5, files.Length);

            // Verify first file
            using (var package =
                new ExcelPackage(
                    new FileInfo(
                        Path.Combine(exportFolder, "1.xlsx"))))
            {
                var ws =
                    package.Workbook.Worksheets["Sheet1"];

                Assert.AreEqual(
                    "Employee Report",
                    ws.Cells["A1"].Text);

                Assert.AreEqual(
                    "Id",
                    ws.Cells["A2"].Text);

                Assert.AreEqual(
                    "1",
                    ws.Cells["A3"].Text);

                Assert.AreEqual(
                    "2",
                    ws.Cells["B3"].Text);

                Assert.AreEqual(
                    "Total",
                    ws.Cells["A4"].Text);

                Assert.IsTrue(
                    ws.Cells["A1"].Style.Font.Bold);

                Assert.IsTrue(
                    ws.Cells["A2"].Style.Font.Bold);
            }
        }
    }
}
