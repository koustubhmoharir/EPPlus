using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;

namespace EPPlusE2ETest
{
    [TestClass]
    public class WorksheetLifecycle : TestsBase
    {
        static string template = "WorksheetLifecycle.xlsx";

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            SaveTemplate(template, package =>
            {
                var ws1 = package.Workbook.Worksheets.Add("Sheet1");
                ws1.Cells["A1"].Value = "Value1";
                ws1.Cells["B1"].Value = "Value2";

                var ws2 = package.Workbook.Worksheets.Add("Sheet2");
                ws2.Cells["A1"].Value = "Sheet2Value";

                var wsHidden = package.Workbook.Worksheets.Add("SheetHidden");
                wsHidden.Cells["A1"].Value = "HiddenValue";
                wsHidden.Hidden = eWorkSheetHidden.Hidden;

                var wsVeryHidden = package.Workbook.Worksheets.Add("SheetVeryHidden");
                wsVeryHidden.Cells["A1"].Value = "VeryHiddenValue";
                wsVeryHidden.Hidden = eWorkSheetHidden.VeryHidden;
            });
        }

        [TestMethod]
        public void CloneWorksheet()
        {
            Test(template, null, "WorksheetLifecycle.CloneWorksheet.xlsx", null, package =>
            {
                var srcSheet = package.Workbook.Worksheets["Sheet1"];
                var destSheet = package.Workbook.Worksheets.Add("ClonedSheet", srcSheet);
            }, package =>
            {
                var cloned = package.Workbook.Worksheets["ClonedSheet"];
                Assert.IsNotNull(cloned);
                Assert.AreEqual("Value1", cloned.Cells["A1"].GetValue<string>());
                Assert.AreEqual("Value2", cloned.Cells["B1"].GetValue<string>());
            });
        }

        [TestMethod]
        public void DeleteAndMoveWorksheets()
        {
            Test(template, null, "WorksheetLifecycle.DeleteAndMoveWorksheets.xlsx", null, package =>
            {
                var wb = package.Workbook;
                
                // Delete Sheet2
                var toDelete = wb.Worksheets["Sheet2"];
                wb.Worksheets.Delete(toDelete);

                // Add a new sheet and move to start
                var newSheet = wb.Worksheets.Add("NewFirst");
                wb.Worksheets.MoveToStart("NewFirst");

                // Move Sheet1 after NewFirst
                wb.Worksheets.MoveAfter("Sheet1", "NewFirst");
            }, package =>
            {
                var wb = package.Workbook;
                Assert.IsNull(wb.Worksheets["Sheet2"]);
                
                // Check order: NewFirst should be at index 1 (1-indexed in EPPlus)
                Assert.AreEqual("NewFirst", wb.Worksheets[1].Name);
                Assert.AreEqual("Sheet1", wb.Worksheets[2].Name);
            });
        }

        [TestMethod]
        public void HiddenSheets()
        {
            Test(template, null, "WorksheetLifecycle.HiddenSheets.xlsx", null, package =>
            {
                var wsHidden = package.Workbook.Worksheets["SheetHidden"];
                var wsVeryHidden = package.Workbook.Worksheets["SheetVeryHidden"];

                // Toggle visibility
                wsHidden.Hidden = eWorkSheetHidden.Visible;
                wsVeryHidden.Hidden = eWorkSheetHidden.Hidden;
            }, package =>
            {
                var wsHidden = package.Workbook.Worksheets["SheetHidden"];
                var wsVeryHidden = package.Workbook.Worksheets["SheetVeryHidden"];

                Assert.AreEqual(eWorkSheetHidden.Visible, wsHidden.Hidden);
                Assert.AreEqual(eWorkSheetHidden.Hidden, wsVeryHidden.Hidden);
            });
        }
    }
}
