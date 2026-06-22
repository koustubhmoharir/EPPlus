using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;

namespace EPPlusE2ETest
{
    [TestClass]
    public class MergedCells : TestsBase
    {
        static string template = "MergedCells.xlsx";

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            SaveTemplate(template, package =>
            {
                package.Workbook.Worksheets.Add("Merges");
            });
        }

        [TestMethod]
        public void MergedCellsRoundTrip()
        {
            Test(template, null, "MergedCells.MergedCellsRoundTrip.xlsx", null, package =>
            {
                var sheet = package.Workbook.Worksheets["Merges"];
                sheet.Cells["A1:C1"].Merge = true;
                sheet.Cells["A1"].Value = "source merge";

                var outputStartColumn = 5;
                sheet.Cells[3, outputStartColumn, 3, outputStartColumn + 1].Merge = true;
                sheet.Cells[3, outputStartColumn].Value = "projected header";
            }, package =>
            {
                var sheet = package.Workbook.Worksheets["Merges"];
                Assert.IsTrue(sheet.MergedCells.Contains("A1:C1"));
                Assert.IsTrue(sheet.MergedCells.Contains("E3:F3"));
                Assert.AreEqual("projected header", sheet.Cells["E3"].Value);
            });
        }
    }
}
