using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.Table.PivotTable;

namespace EPPlusTest.Table
{
    [TestClass]
    public class PivotTableTest
    {
        [TestMethod]
        public void PivotTableSourceRangeTest()
        {
            using (var pck = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var wsSource = pck.Workbook.Worksheets.Add("Source");
                wsSource.Cells["A1"].Value = "Col1";
                wsSource.Cells["A2"].Value = 1;
                var wsPivot = pck.Workbook.Worksheets.Add("Pivot");
                
                var pivotTable = wsPivot.PivotTables.Add(wsPivot.Cells["A1"], wsSource.Cells["A1:A2"], "Pivot1");
                
                Assert.IsNotNull(pivotTable.CacheDefinition.SourceRange);
                Assert.AreEqual("Source", pivotTable.CacheDefinition.SourceRange.Worksheet.Name);
                Assert.AreEqual("A1:A2", pivotTable.CacheDefinition.SourceRange.Address);
            }
        }

        [TestMethod]
        public void PivotTableSourceRangeCasingTest()
        {
            using (var pck = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var wsSource = pck.Workbook.Worksheets.Add("SourceSheet");
                wsSource.Cells["A1"].Value = "Col1";
                wsSource.Cells["A2"].Value = 1;
                
                var wsPivot = pck.Workbook.Worksheets.Add("Pivot");
                var pivotTable = wsPivot.PivotTables.Add(wsPivot.Cells["A1"], wsSource.Cells["A1:A2"], "Pivot1");
                
                var stream = new System.IO.MemoryStream();
                pck.SaveAs(stream);
                
                stream.Position = 0;
                using (var pck2 = new ExcelPackage(stream, EPPlusTest.TempFolderHelper.Create()))
                {
                    var wsPivot2 = pck2.Workbook.Worksheets["Pivot"];
                    var pivotTable2 = wsPivot2.PivotTables["Pivot1"];
                    
                    Assert.IsNotNull(pivotTable2.CacheDefinition.SourceRange);
                    Assert.AreEqual("SourceSheet", pivotTable2.CacheDefinition.SourceRange.Worksheet.Name);
                }
            }
        }

        [TestMethod]
        public void PivotTableDefaultNameTest()
        {
            using (var pck = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var wsSource = pck.Workbook.Worksheets.Add("Source");
                wsSource.Cells["A1"].Value = "Col1";
                wsSource.Cells["A2"].Value = 1;
                var wsPivot = pck.Workbook.Worksheets.Add("Pivot");
                
                var pivotTable = wsPivot.PivotTables.Add(wsPivot.Cells["A1"], wsSource.Cells["A1:A2"], "");
                
                Assert.AreEqual("PivotTable1", pivotTable.Name);
            }
        }
    }
}
