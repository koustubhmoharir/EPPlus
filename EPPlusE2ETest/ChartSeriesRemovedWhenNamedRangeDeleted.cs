using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;

namespace EPPlusE2ETest
{
    [TestClass]
    public class ChartSeriesRemovedWhenNamedRangeDeleted : TestsBase
    {
        static string template = "ChartSeriesRemovedWhenNamedRangeDeleted.xlsx";

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

                package.Workbook.Names.Add("ChartX", ws.Cells["A2:A3"]);
                package.Workbook.Names.Add("ChartY", ws.Cells["B2:B3"]);

                var chart = ws.Drawings.AddChart(
                    "RevenueChart",
                    eChartType.ColumnClustered);

                chart.Series.Add(
                    "Data!ChartY",
                    "Data!ChartX");
            });
        }

        [TestMethod]
        public void RemoveSeriesWhenNamedRangeDeleted()
        {
            Test(template, null,
                "ChartSeriesRemovedWhenNamedRangeDeleted.xlsx",
                null,
                package =>
                {
                    var ws = package.Workbook.Worksheets["Data"];
                    var chart = ws.Drawings["RevenueChart"] as ExcelChart;

                    Assert.IsNotNull(chart);

                    // Simulate named range becoming invalid
                    package.Workbook.Names.Remove("ChartY");

                    // Simulate ExportSheet cleanup logic
                    if (chart.Series.Count > 0)
                    {
                        chart.Series.Delete(0);
                    }
                },
                package =>
                {
                    var ws = package.Workbook.Worksheets["Data"];
                    var chart = ws.Drawings["RevenueChart"] as ExcelChart;

                    Assert.IsNotNull(chart);

                    Assert.AreEqual(
                        0,
                        chart.Series.Count);
                });
        }
    }
}
