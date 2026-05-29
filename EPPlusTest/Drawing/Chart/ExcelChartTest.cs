using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Table.PivotTable;
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
            _package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create());
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
                using (var loadedPackage = new ExcelPackage(stream, EPPlusTest.TempFolderHelper.Create()))
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

        [TestMethod]
        public void AddChart_WithPivotTableSource_CreatesPivotChart()
        {
            var wsSource = _package.Workbook.Worksheets.Add("Source");
            wsSource.Cells["A1"].Value = "Col1";
            wsSource.Cells["A2"].Value = 1;
            wsSource.Cells["A3"].Value = 2;

            var wsPivot = _package.Workbook.Worksheets.Add("Pivot");
            var pivotTable = wsPivot.PivotTables.Add(wsPivot.Cells["A1"], wsSource.Cells["A1:A3"], "Pivot1");

            var chart = _worksheet.Drawings.AddChart("PivotChart", eChartType.ColumnClustered, pivotTable);
            Assert.IsNotNull(chart.PivotTableSource);
            Assert.AreEqual(pivotTable.Name, chart.PivotTableSource.Name);

            using (var stream = new MemoryStream())
            {
                _package.SaveAs(stream);
                stream.Position = 0;
                using (var loadedPackage = new ExcelPackage(stream, EPPlusTest.TempFolderHelper.Create()))
                {
                    var loadedWorksheet = loadedPackage.Workbook.Worksheets["TestSheet"];
                    var loadedChart = loadedWorksheet.Drawings["PivotChart"] as ExcelChart;
                    Assert.IsNotNull(loadedChart);
                    Assert.IsNull(loadedChart.PivotTableSource, "PivotTableSource property is not deserialized on reload by EPPlus design");
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void AddChart_DuplicateName_ThrowsException()
        {
            _worksheet.Drawings.AddChart("Chart1", eChartType.ColumnClustered);
            _worksheet.Drawings.AddChart("Chart1", eChartType.Line);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void AddChart_DuplicateNameDifferentCase_ThrowsException()
        {
            _worksheet.Drawings.AddChart("Chart1", eChartType.ColumnClustered);
            _worksheet.Drawings.AddChart("chart1", eChartType.Line);
        }

        [TestMethod]
        [ExpectedException(typeof(System.NotImplementedException))]
        public void AddChart_UnsupportedStockChartType_ThrowsNotImplementedException()
        {
            _worksheet.Drawings.AddChart("StockChart", eChartType.StockHLC);
        }

        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void AddChart_ChartSheetMultipleCharts_ThrowsInvalidOperationException()
        {
            var wsChart = _package.Workbook.Worksheets.AddChart("ChartSheet", eChartType.ColumnClustered);
            wsChart.Drawings.AddChart("SecondChart", eChartType.Line);
        }

        [TestMethod]
        public void AddChart_ExistingDrawingPartConflict_ResolvesConflictOnCore()
        {
#if Core
            // In dotnetport/Core, creating drawing when part already exists loop-checks and succeeds by creating a unique URI drawing2.xml
            var drawingUri = new Uri("/xl/drawings/drawing1.xml", UriKind.Relative);
            _package.Package.CreatePart(drawingUri, "application/vnd.openxmlformats-officedocument.drawing+xml");
            
            var chart = _worksheet.Drawings.AddChart("Chart1", eChartType.ColumnClustered);
            Assert.IsNotNull(chart);
            Assert.AreEqual("/xl/drawings/drawing2.xml", _worksheet.Drawings.UriDrawing.OriginalString);
#else
            // On stable, it doesn't have loop check, so we just run a basic add chart test.
            var chart = _worksheet.Drawings.AddChart("Chart1", eChartType.ColumnClustered);
            Assert.IsNotNull(chart);
#endif
        }
    }
}
