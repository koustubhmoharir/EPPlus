using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;

namespace EPPlusE2ETest
{
    [TestClass]
    public class Charts : TestsBase
    {
        static string template = "Charts.xlsx";

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            SaveTemplate(template, package =>
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                ws.Cells["A1"].Value = "Month";
                ws.Cells["B1"].Value = "Revenue";
                ws.Cells["A2"].Value = "Jan";
                ws.Cells["B2"].Value = 100.0;
                ws.Cells["A3"].Value = "Feb";
                ws.Cells["B3"].Value = 150.0;

                // Create workbook-level named ranges for the chart series
                package.Workbook.Names.Add("ChartX", ws.Cells["A2:A3"]);
                package.Workbook.Names.Add("ChartY", ws.Cells["B2:B3"]);

                // Add a Column Chart
                var chart = ws.Drawings.AddChart("RevenueChart", eChartType.ColumnClustered);
                chart.SetPosition(5, 0, 0, 0);
                chart.SetSize(400, 300);

                // Add a series linked to the named ranges using string formulas
                chart.Series.Add("Sheet1!ChartY", "Sheet1!ChartX");
            });
        }

        [TestMethod]
        public void ChartNamedRangeUpdate()
        {
            Test(template, null, "Charts.ChartNamedRangeUpdate.xlsx", null, package =>
            {
                var ws = package.Workbook.Worksheets["Sheet1"];

                // 1. Replace/add data with more rows
                ws.Cells["A4"].Value = "Mar";
                ws.Cells["B4"].Value = 200.0;
                ws.Cells["A5"].Value = "Apr";
                ws.Cells["B5"].Value = 250.0;

                // 2. Update the named ranges to point to the new range
                package.Workbook.Names["ChartX"].Address = "Sheet1!A2:A5";
                package.Workbook.Names["ChartY"].Address = "Sheet1!B2:B5";

                // Simulating SheetKraft chart series re-writing to ensure everything is saved cleanly
                var chart = ws.Drawings["RevenueChart"] as ExcelChart;
                Assert.IsNotNull(chart);
                var serie = chart.Series[0];
                serie.XSeries = "Sheet1!ChartX";
                serie.Series = "Sheet1!ChartY";
            }, package =>
            {
                var ws = package.Workbook.Worksheets["Sheet1"];
                var chart = ws.Drawings["RevenueChart"] as ExcelChart;

                Assert.IsNotNull(chart);
                Assert.AreEqual(1, chart.Series.Count);

                var serie = chart.Series[0];
                
                // Assert that the chart series formulas are preserved
                Assert.AreEqual("Sheet1!ChartY", serie.Series);
                Assert.AreEqual("Sheet1!ChartX", serie.XSeries);

                // Verify the named ranges themselves were updated and evaluate to the new size
                var chartX = package.Workbook.Names["ChartX"];
                var chartY = package.Workbook.Names["ChartY"];

                Assert.IsNotNull(chartX);
                Assert.IsNotNull(chartY);
                Assert.AreEqual("'Sheet1'!$A$2:$A$5", chartX.Address);
                Assert.AreEqual("'Sheet1'!$B$2:$B$5", chartY.Address);
            });
        }
    }
}
