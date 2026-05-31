using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using OfficeOpenXml.Table.PivotTable;

namespace EPPlusE2ETest
{
    [TestClass]
    public class TablesAndPivotTables : TestsBase
    {
        static string template = "TablesAndPivotTables.xlsx";

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            SaveTemplate(template, package =>
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                ws.Cells["A1"].Value = "Name";
                ws.Cells["B1"].Value = "Sales";
                ws.Cells["A2"].Value = "Alice";
                ws.Cells["B2"].Value = 100.0;
                ws.Cells["A3"].Value = "Bob";
                ws.Cells["B3"].Value = 200.0;

                // Create a workbook-level named range for the pivot table source
                var namedRange = package.Workbook.Names.Add("PivotSource", ws.Cells["A1:B3"]);

                // Add a Pivot Table linked to the named range
                var wsPivot = package.Workbook.Worksheets.Add("PivotSheet");
                var pt = wsPivot.PivotTables.Add(wsPivot.Cells["A1"], namedRange, "Pivot1");
                
                // Add default cache definition flag
                pt.CacheDefinition.CacheDefinitionXml.DocumentElement.SetAttribute("refreshOnLoad", "1");
            });
        }

        [TestMethod]
        public void CreateTableWithOptions()
        {
            Test(template, null, "TablesAndPivotTables.CreateTableWithOptions.xlsx", null, package =>
            {
                var ws = package.Workbook.Worksheets["Sheet1"];
                
                // Add table on A1:B3
                var table = ws.Tables.Add(ws.Cells["A1:B3"], "SalesTable");
                
                // Configure SheetKraft display options
                table.ShowHeader = true;
                table.ShowFilter = true;
                table.ShowFirstColumn = true;
                table.ShowLastColumn = true;
                table.ShowRowStripes = true;
                table.ShowColumnStripes = true;
                table.ShowTotal = true;
                table.StyleName = "TableStyleMedium9";
            }, package =>
            {
                var ws = package.Workbook.Worksheets["Sheet1"];
                var table = ws.Tables["SalesTable"];

                Assert.IsNotNull(table);
                Assert.IsTrue(table.ShowHeader);
                Assert.IsTrue(table.ShowFilter);
                Assert.IsTrue(table.ShowFirstColumn);
                Assert.IsTrue(table.ShowLastColumn);
                Assert.IsTrue(table.ShowRowStripes);
                Assert.IsTrue(table.ShowColumnStripes);
                Assert.IsTrue(table.ShowTotal);
                Assert.AreEqual("TableStyleMedium9", table.StyleName);
            });
        }

        [TestMethod]
        public void PivotTableNamedRangeUpdate()
        {
            Test(template, null, "TablesAndPivotTables.PivotTableNamedRangeUpdate.xlsx", null, package =>
            {
                var ws = package.Workbook.Worksheets["Sheet1"];
                
                // 1. Replace the data with more rows
                ws.Cells["A4"].Value = "Charlie";
                ws.Cells["B4"].Value = 300.0;
                ws.Cells["A5"].Value = "David";
                ws.Cells["B5"].Value = 400.0;

                // 2. Update the named range to encompass the new rows (A1:B5)
                package.Workbook.Names["PivotSource"].Address = "Sheet1!A1:B5";

                // Update the pivot table's SourceRange using the named range
                var wsPivot = package.Workbook.Worksheets["PivotSheet"];
                var pt = wsPivot.PivotTables["Pivot1"];
                pt.CacheDefinition.SourceRange = package.Workbook.Names["PivotSource"];

                // Trigger Cache Refresh on Load mutation
                pt.CacheDefinition.CacheDefinitionXml.DocumentElement.SetAttribute("refreshOnLoad", "1");
            }, package =>
            {
                var wsPivot = package.Workbook.Worksheets["PivotSheet"];
                var pt = wsPivot.PivotTables["Pivot1"];

                Assert.IsNotNull(pt);
                
                // 3. Assert that the pivot table actually references the new data range
                Assert.IsNotNull(pt.CacheDefinition.SourceRange);
                Assert.AreEqual("Sheet1!A1:B5", pt.CacheDefinition.SourceRange.Address);
                Assert.AreEqual("Sheet1", pt.CacheDefinition.SourceRange.Worksheet.Name);
            });
        }
    }
}
