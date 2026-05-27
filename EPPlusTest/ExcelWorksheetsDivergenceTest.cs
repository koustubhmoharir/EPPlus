using System;
using System.IO;
using System.Linq;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.Table.PivotTable;

namespace EPPlusTest
{
    [TestClass]
    public class ExcelWorksheetsDivergenceTest
    {
        [TestMethod]
        public void TestWorksheetIndexingBaseline()
        {
            using (var pck = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws1 = pck.Workbook.Worksheets.Add("Sheet1");
                var ws2 = pck.Workbook.Worksheets.Add("Sheet2");

                Assert.AreEqual(1, ws1.PositionID, "First worksheet should have PositionID 1");
                Assert.AreEqual(2, ws2.PositionID, "Second worksheet should have PositionID 2");
                Assert.AreEqual(ws1, pck.Workbook.Worksheets[1], "Indexer[1] should return Sheet1");
                Assert.AreEqual(ws2, pck.Workbook.Worksheets[2], "Indexer[2] should return Sheet2");
            }
        }

        [TestMethod]
        public void TestExtendedPropertiesSyncBaseline()
        {
            using (var pck = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = pck.Workbook.Worksheets.Add("SyncTest");
                
                var appXml = pck.Workbook.Properties.ExtendedPropertiesXml;
                var nsm = new XmlNamespaceManager(appXml.NameTable);
                nsm.AddNamespace("xp", "http://schemas.openxmlformats.org/officeDocument/2006/extended-properties");
                nsm.AddNamespace("vt", "http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes");

                var titlesNode = appXml.SelectSingleNode("//xp:TitlesOfParts/vt:vector", nsm);
                
                if (titlesNode != null)
                {
                    bool containsSheet = false;
                    foreach (XmlNode node in titlesNode.ChildNodes)
                    {
                        if (node.InnerText == "SyncTest") containsSheet = true;
                    }
                    Console.WriteLine("TitlesOfParts contains sheet: " + containsSheet);
                }
            }
        }

        [TestMethod]
        public void TestWorksheetCopyingWithPivotTable()
        {
            using (var pck = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = pck.Workbook.Worksheets.Add("Source");
                ws.Cells["A1"].Value = "Category";
                ws.Cells["A2"].Value = "A";
                ws.Cells["A3"].Value = "B";
                ws.Cells["B1"].Value = "Value";
                ws.Cells["B2"].Value = 10;
                ws.Cells["B3"].Value = 20;

                var pt = ws.PivotTables.Add(ws.Cells["D1"], ws.Cells["A1:B3"], "Pivot1");
                pt.RowFields.Add(pt.Fields["Category"]);
                pt.DataFields.Add(pt.Fields["Value"]);

                var wsCopy = pck.Workbook.Worksheets.Add("Copy", ws);
                Assert.AreEqual(1, wsCopy.PivotTables.Count, "Copied worksheet should have one pivot table");
                Assert.IsTrue(wsCopy.PivotTables[0].Name.StartsWith("Pivot"), "Copied pivot table should have a valid name");
            }
        }

        [TestMethod]
        public void TestWorksheetCopyingWithMergedCells()
        {
            using (var pck = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = pck.Workbook.Worksheets.Add("Source");
                ws.Cells["A1:B2"].Merge = true;
                
                var wsCopy = pck.Workbook.Worksheets.Add("Copy", ws);
                Assert.AreEqual(1, wsCopy.MergedCells.Count, "Merged cells count should be preserved");
                Assert.AreEqual("A1:B2", wsCopy.MergedCells[0], "Merged address should be preserved");
            }
        }

        [TestMethod]
        public void TestVBAModuleCreationBaseline()
        {
            using (var pck = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                pck.Workbook.CreateVBAProject();
                var ws = pck.Workbook.Worksheets.Add("SheetWithVBA");
                
                bool exists = false;
                foreach (var m in pck.Workbook.VbaProject.Modules)
                {
                    if (m.Name == ws.CodeModuleName) exists = true;
                }
                Console.WriteLine("VBA Module exists: " + exists);
            }
        }

        [TestMethod]
        public void TestNextTableIdInitializationBaseline()
        {
            using (var pck = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = pck.Workbook.Worksheets.Add("TableTest");
                var table = ws.Tables.Add(ws.Cells["A1:B2"], "Table1");
                
                var nextTableIdField = typeof(ExcelWorkbook).GetField("_nextTableID", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic );
                if (nextTableIdField != null)
                {
                    int nextTableId = (int)nextTableIdField.GetValue(pck.Workbook);
                    Console.WriteLine("Next Table ID: " + nextTableId);
                }
            }
        }
    }
}
