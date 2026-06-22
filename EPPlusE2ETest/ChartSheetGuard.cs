using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;

namespace EPPlusE2ETest
{
    [TestClass]
    public class ChartSheetGuard : TestsBase
    {
        static string template = "ChartSheetGuard.xlsx";

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            SaveTemplate(template, package =>
            {
                var ws = package.Workbook.Worksheets.Add("Data");

                ws.Cells["A1"].Value = "Month";
                ws.Cells["B1"].Value = "Revenue";

                ws.Cells["A2"].Value = "Jan";
                ws.Cells["B2"].Value = 100;

                ws.Cells["A3"].Value = "Feb";
                ws.Cells["B3"].Value = 200;

                // Create Chart Sheet
                var chartSheet = package.Workbook.Worksheets.AddChart(
                    "RevenueChart",
                    eChartType.ColumnClustered);

                chartSheet.Chart.Series.Add(
                    ws.Cells["B2:B3"],
                    ws.Cells["A2:A3"]);
            });
        }

        [TestMethod]
        public void PreserveChartSheet()
        {
            Test(template, null,
                "ChartSheetGuard.PreserveChartSheet.xlsx",
                null,
                package =>
                {
                    var ws = package.Workbook.Worksheets["Data"];

                    // Simulate export updates
                    ws.Cells["A4"].Value = "Mar";
                    ws.Cells["B4"].Value = 300;
                },
                package =>
                {
                    var chartSheet =
                        package.Workbook.Worksheets["RevenueChart"];

                    Assert.IsNotNull(chartSheet);

                    Assert.IsInstanceOfType(
                        chartSheet,
                        typeof(ExcelChartsheet));

                    var dataSheet =
                        package.Workbook.Worksheets["Data"];

                    Assert.AreEqual(
                        "Mar",
                        dataSheet.Cells["A4"].Text);

                    Assert.AreEqual(
                        "300",
                        dataSheet.Cells["B4"].Text);
                });
        }
      
    }
}
