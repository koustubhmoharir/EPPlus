using System;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace EPPlusE2ETest
{
    [TestClass]
    public class LargeDatasetExport : TestsBase
    {
        static string template = "LargeDatasetExport.xlsx";

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            SaveTemplate(template, package =>
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                ws.Cells["A1"].Value = "ID";
                ws.Cells["B1"].Value = "Name";
                ws.Cells["C1"].Value = "Date";
                ws.Cells["D1"].Value = "Value";
                ws.Cells["E1"].Value = "Flag";
            });
        }

        [TestMethod]
        public void ExportLakhRows()
        {
            const int RowCount = 500000;
            Test(template, null, "LargeDatasetExport.ExportOneLakhRows.xlsx", null, package =>
            {
                var ws = package.Workbook.Worksheets["Sheet1"];
                var today = DateTime.Today;

                // Write 100,000 rows of data
                for (int i = 2; i <= RowCount + 1; i++)
                {
                    ws.Cells[i, 1].Value = i - 1;
                    ws.Cells[i, 2].Value = "Record " + (i - 1);
                    ws.Cells[i, 3].Value = today.AddDays(i - 2);
                    ws.Cells[i, 4].Formula = $"A{i}*1.5";
                    ws.Cells[i, 5].Value = (i % 2 == 0);
                }
            }, package =>
            {
                var ws = package.Workbook.Worksheets["Sheet1"];
                Assert.IsNotNull(ws);
                Assert.AreEqual(RowCount + 1, ws.Dimension.End.Row);
                Assert.AreEqual(5, ws.Dimension.End.Column);

                // Assert correct values in first data row
                Assert.AreEqual(1.0, ws.Cells["A2"].Value);
                Assert.AreEqual("Record 1", ws.Cells["B2"].Value);
                Assert.AreEqual("A2*1.5", ws.Cells["D2"].Formula);
                Assert.AreEqual(true, ws.Cells["E2"].Value);

                // Assert correct values in last data row
                Assert.AreEqual((double)RowCount, ws.Cells[RowCount + 1, 1].Value);
                Assert.AreEqual("Record " + RowCount, ws.Cells[RowCount + 1, 2].Value);
                Assert.AreEqual($"A{RowCount + 1}*1.5", ws.Cells[RowCount + 1, 4].Formula);
            });
        }

        [TestMethod]
        public async Task ExportSheetMemoryPeakTest()
        {
            var customTempDir = Path.Combine(TempDirectory, Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(customTempDir);

            string outputName = "LargeDatasetExport.MemoryPeakTest.xlsx";
            string outputPath = Path.Combine(OutputsDirectory, outputName);
            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }

            string templatePath = Path.Combine(TemplatesDirectory, template);

            // Force GC to get clean baseline
            GC.Collect();
            GC.WaitForPendingFinalizers();
            long startMemory = GC.GetTotalMemory(true);
            long startWorkingSet = Process.GetCurrentProcess().WorkingSet64;

            long peakManagedHeap = 0;
            long peakWorkingSet = 0;
            bool keepPolling = true;

            var pollingTask = Task.Run(() =>
            {
                var currentProcess = Process.GetCurrentProcess();
                while (keepPolling)
                {
                    long currentHeap = GC.GetTotalMemory(false);
                    if (currentHeap > peakManagedHeap)
                    {
                        peakManagedHeap = currentHeap;
                    }

                    currentProcess.Refresh();
                    long currentWorkingSet = currentProcess.WorkingSet64;
                    if (currentWorkingSet > peakWorkingSet)
                    {
                        peakWorkingSet = currentWorkingSet;
                    }

                    Thread.Sleep(10);
                }
            });

            // Perform large sheet export simulating SheetKraft logic
            using (var package = new ExcelPackage(new FileInfo(templatePath), tempFolder: customTempDir))
            {
                var ws = package.Workbook.Worksheets["Sheet1"];
                var today = DateTime.Today;

                const int RowCount = 500000;
                for (int i = 2; i <= RowCount + 1; i++)
                {
                    ws.Cells[i, 1].Value = i - 1;
                    ws.Cells[i, 2].Value = "Record " + (i - 1);
                    ws.Cells[i, 3].Value = today.AddDays(i - 2);
                    ws.Cells[i, 4].Formula = $"A{i}*1.5";
                    ws.Cells[i, 5].Value = (i % 2 == 0);

                    // Add formatting (adds to peak memory)
                    var range = ws.Cells[i, 1, i, 5];
                    range.Style.Font.Name = "Calibri";
                    range.Style.Font.Size = 11;
                    range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }

                // Verify files were generated in the temp folder during template load/construction
                var tempFilesAfterLoad = Directory.GetFiles(customTempDir, "*", SearchOption.AllDirectories);
                Assert.IsTrue(tempFilesAfterLoad.Length > 0, "Temporary files should be created in the temp directory upon template load");

                package.SaveAs(new FileInfo(outputPath));
            }

            // Verify that all temporary files were deleted on package dispose
            var tempFilesAfterDispose = Directory.Exists(customTempDir) ? Directory.GetFiles(customTempDir, "*", SearchOption.AllDirectories) : Array.Empty<string>();
            Assert.AreEqual(0, tempFilesAfterDispose.Length, "All temporary files should be deleted after ExcelPackage is disposed");

            keepPolling = false;
            await pollingTask;

            if (Directory.Exists(customTempDir))
            {
                Directory.Delete(customTempDir, true);
            }

            Console.WriteLine($"[Memory Peak Metrics]");
            Console.WriteLine($"Total Peak Managed Heap: {peakManagedHeap / 1024.0 / 1024.0:F2} MB");
            Console.WriteLine($"Total Peak Physical RAM (Working Set): {peakWorkingSet / 1024.0 / 1024.0:F2} MB");

            // File.Delete(outputPath);
        }

        [TestMethod]
        public async Task ExportSheetHeavyDataPerformanceTest()
        {
            var customTempDir = Path.Combine(TempDirectory, Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(customTempDir);

            string outputName = "LargeDatasetExport.HeavyDataPerformanceTest.xlsx";
            string outputPath = Path.Combine(OutputsDirectory, outputName);
            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }

            string templatePath = Path.Combine(TemplatesDirectory, template);

            // Force GC to get clean baseline
            GC.Collect();
            GC.WaitForPendingFinalizers();
            long startMemory = GC.GetTotalMemory(true);
            long startWorkingSet = Process.GetCurrentProcess().WorkingSet64;

            long peakManagedHeap = 0;
            long peakWorkingSet = 0;
            bool keepPolling = true;

            var pollingTask = Task.Run(() =>
            {
                var currentProcess = Process.GetCurrentProcess();
                while (keepPolling)
                {
                    long currentHeap = GC.GetTotalMemory(false);
                    if (currentHeap > peakManagedHeap)
                    {
                        peakManagedHeap = currentHeap;
                    }

                    currentProcess.Refresh();
                    long currentWorkingSet = currentProcess.WorkingSet64;
                    if (currentWorkingSet > peakWorkingSet)
                    {
                        peakWorkingSet = currentWorkingSet;
                    }

                    Thread.Sleep(10);
                }
            });

            var stopwatch = Stopwatch.StartNew();

            using (var package = new ExcelPackage(new FileInfo(templatePath), tempFolder: customTempDir))
            {
                // We will populate 3 worksheets: Summary, Details_1, Details_2
                var wsSummary = package.Workbook.Worksheets["Sheet1"];
                wsSummary.Name = "Summary";
                PopulateHeavySheet(wsSummary, 20000);

                var wsDetails1 = package.Workbook.Worksheets.Add("Details_1");
                PopulateHeavySheet(wsDetails1, 20000);

                var wsDetails2 = package.Workbook.Worksheets.Add("Details_2");
                PopulateHeavySheet(wsDetails2, 20000);

                // Verify files were generated in the temp folder during template load/construction
                var tempFilesAfterLoad = Directory.GetFiles(customTempDir, "*", SearchOption.AllDirectories);
                Assert.IsTrue(tempFilesAfterLoad.Length > 0, "Temporary files should be created in the temp directory upon template load");

                package.SaveAs(new FileInfo(outputPath));
            }

            // Verify that all temporary files were deleted on package dispose
            var tempFilesAfterDispose = Directory.Exists(customTempDir) ? Directory.GetFiles(customTempDir, "*", SearchOption.AllDirectories) : Array.Empty<string>();
            Assert.AreEqual(0, tempFilesAfterDispose.Length, "All temporary files should be deleted after ExcelPackage is disposed");

            keepPolling = false;
            await pollingTask;
            stopwatch.Stop();

            if (Directory.Exists(customTempDir))
            {
                Directory.Delete(customTempDir, true);
            }

            Console.WriteLine($"[Heavy Data Performance Metrics]");
            Console.WriteLine($"Execution Duration: {stopwatch.Elapsed.TotalSeconds:F2} seconds");
            Console.WriteLine($"Total Peak Managed Heap: {peakManagedHeap / 1024.0 / 1024.0:F2} MB");
            Console.WriteLine($"Total Peak Physical RAM (Working Set): {peakWorkingSet / 1024.0 / 1024.0:F2} MB");

            // File.Delete(outputPath);
        }

        private void PopulateHeavySheet(ExcelWorksheet ws, int rowCount)
        {
            // Set up headers
            string[] headers = new[]
            {
                "ID", "Transaction ID", "Client Name", "Country", "Value Date", 
                "Due Date", "Quantity", "Unit Price", "Total Amount", "Discount %", 
                "Discounted Amount", "Tax Rate", "Tax Amount", "Net Amount", "Status", 
                "Category", "Rep ID", "Rating", "Approved", "Remarks"
            };

            for (int col = 1; col <= 20; col++)
            {
                var cell = ws.Cells[1, col];
                cell.Value = headers[col - 1];
                cell.Style.Font.Bold = true;
                cell.Style.Font.Name = "Segoe UI";
                cell.Style.Font.Size = 11;
                cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                cell.Style.Fill.BackgroundColor.SetColor("#366092");
                cell.Style.Font.Color.SetColor("#FFFFFF");
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            }

            var today = DateTime.Today;

            for (int i = 2; i <= rowCount + 1; i++)
            {
                // Write data
                ws.Cells[i, 1].Value = i - 1; // ID
                ws.Cells[i, 1].Style.Numberformat.Format = "#,##0";
                
                ws.Cells[i, 2].Value = "TXN-" + (1000000 + i - 1); // Transaction ID
                ws.Cells[i, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                
                ws.Cells[i, 3].Value = "Client " + (i - 1); // Client Name
                
                ws.Cells[i, 4].Value = (i % 4 == 0) ? "USA" : (i % 4 == 1) ? "UK" : (i % 4 == 2) ? "Germany" : "India"; // Country
                
                ws.Cells[i, 5].Value = today.AddDays(i - 2); // Value Date
                ws.Cells[i, 5].Style.Numberformat.Format = "yyyy-MM-dd";
                
                ws.Cells[i, 6].Value = today.AddDays(i); // Due Date
                ws.Cells[i, 6].Style.Numberformat.Format = "yyyy-MM-dd";
                
                ws.Cells[i, 7].Value = (i * 3) % 250 + 1; // Quantity
                ws.Cells[i, 7].Style.Numberformat.Format = "#,##0";
                
                ws.Cells[i, 8].Value = (double)((i * 17) % 1000) / 10.0 + 5.0; // Unit Price
                ws.Cells[i, 8].Style.Numberformat.Format = "$#,##0.00";
                
                ws.Cells[i, 9].Formula = $"G{i}*H{i}"; // Total Amount
                ws.Cells[i, 9].Style.Numberformat.Format = "$#,##0.00";
                
                ws.Cells[i, 10].Value = (double)(i % 10) / 100.0; // Discount %
                ws.Cells[i, 10].Style.Numberformat.Format = "0.0%";
                
                ws.Cells[i, 11].Formula = $"I{i}*(1-J{i})"; // Discounted Amount
                ws.Cells[i, 11].Style.Numberformat.Format = "$#,##0.00";
                
                ws.Cells[i, 12].Value = 0.18; // Tax Rate
                ws.Cells[i, 12].Style.Numberformat.Format = "0.00%";
                
                ws.Cells[i, 13].Formula = $"K{i}*L{i}"; // Tax Amount
                ws.Cells[i, 13].Style.Numberformat.Format = "$#,##0.00";
                
                ws.Cells[i, 14].Formula = $"K{i}+M{i}"; // Net Amount
                ws.Cells[i, 14].Style.Numberformat.Format = "$#,##0.00";
                
                ws.Cells[i, 15].Value = (i % 3 == 0) ? "Completed" : (i % 3 == 1) ? "Pending" : "Cancelled"; // Status
                
                ws.Cells[i, 16].Value = (i % 4 == 0) ? "Electronics" : (i % 4 == 1) ? "Furniture" : (i % 4 == 2) ? "Apparel" : "Groceries"; // Category
                
                ws.Cells[i, 17].Value = (i % 50) + 100; // Rep ID
                ws.Cells[i, 17].Style.Numberformat.Format = "0000";
                
                ws.Cells[i, 18].Value = (double)(i % 50) / 10.0; // Rating
                ws.Cells[i, 18].Style.Numberformat.Format = "0.0";
                
                ws.Cells[i, 19].Value = (i % 2 == 0); // Approved
                
                ws.Cells[i, 20].Value = "System Generated Row " + (i - 1); // Remarks

                // Alternate row colors (zebra striping) and borders
                var rowRange = ws.Cells[i, 1, i, 20];
                rowRange.Style.Font.Name = "Calibri";
                rowRange.Style.Font.Size = 10;
                rowRange.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                rowRange.Style.Border.Bottom.Color.SetColor("#D9D9D9");

                if (i % 2 == 0)
                {
                    rowRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rowRange.Style.Fill.BackgroundColor.SetColor("#F2F5F9");
                }
            }
        }
    }
}
