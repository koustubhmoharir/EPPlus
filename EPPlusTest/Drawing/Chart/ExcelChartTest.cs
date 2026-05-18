using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using System.IO;

namespace EPPlusTest.Drawing.Chart
{
    [TestClass]
    public class ExcelChartTest
    {
        private ExcelPackage _package;
        private ExcelWorksheet _worksheet;

        [TestInitialize]
        public void Initialize()
        {
            _package = new ExcelPackage();
            _worksheet = _package.Workbook.Worksheets.Add("TestSheet");
        }

        [TestCleanup]
        public void Cleanup()
        {
            _package.Dispose();
        }

        [TestMethod]
        public void RoundedCorners_Default_IsFalse()
        {
            var chart = _worksheet.Drawings.AddChart("ColumnChart", eChartType.ColumnClustered);
            Assert.IsFalse(chart.RoundedCorners, "By default, RoundedCorners should be false");
        }

        [TestMethod]
        public void RoundedCorners_SetToTrue_IsTrue()
        {
            var chart = _worksheet.Drawings.AddChart("ColumnChart", eChartType.ColumnClustered);
            chart.RoundedCorners = true;
            Assert.IsTrue(chart.RoundedCorners);

            chart.RoundedCorners = false;
            Assert.IsFalse(chart.RoundedCorners);
        }

        [TestMethod]
        public void Style_SetAndGet_WorksCorrectly()
        {
            var chart = _worksheet.Drawings.AddChart("ColumnChart", eChartType.ColumnClustered);
            Assert.AreEqual(eChartStyle.None, chart.Style);

            chart.Style = eChartStyle.Style10;
            Assert.AreEqual(eChartStyle.Style10, chart.Style);
        }

        [TestMethod]
        public void SaveAndLoad_ChartWithRoundedCornersAndStyle_PersistsCorrectly()
        {
            var chart = _worksheet.Drawings.AddChart("ColumnChart", eChartType.ColumnClustered);
            chart.RoundedCorners = true;
            chart.Style = eChartStyle.Style12;

            using (var stream = new MemoryStream())
            {
                _package.SaveAs(stream);
                
                stream.Position = 0;
                using (var loadedPackage = new ExcelPackage(stream))
                {
                    var loadedWorksheet = loadedPackage.Workbook.Worksheets["TestSheet"];
                    Assert.AreEqual(1, loadedWorksheet.Drawings.Count);
                    
                    var loadedChart = loadedWorksheet.Drawings[0] as ExcelChart;
                    Assert.IsNotNull(loadedChart);
                    Assert.IsTrue(loadedChart.RoundedCorners, "RoundedCorners should persist after saving and loading");
                    Assert.AreEqual(eChartStyle.Style12, loadedChart.Style, "Style should persist after saving and loading");
                }
            }
        }
    }
}
