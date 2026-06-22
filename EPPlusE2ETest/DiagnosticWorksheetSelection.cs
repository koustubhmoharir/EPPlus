using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using System;

namespace EPPlusE2ETest
{
    [TestClass]
    public class DiagnosticWorksheetSelection : TestsBase
    {
        static string template = "DiagnosticWorksheetSelection.xlsx";

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            SaveTemplate(template, package =>
            {
                var ws1 = package.Workbook.Worksheets.Add("FirstSheet");
                ws1.Cells["A1"].Value = "FIRST";

                var ws2 = package.Workbook.Worksheets.Add("SecondSheet");
                ws2.Cells["A1"].Value = "SECOND";

                var ws3 = package.Workbook.Worksheets.Add("ThirdSheet");
                ws3.Cells["A1"].Value = "THIRD";
            });
        }

        [TestMethod]
        public void SelectWorksheetUsingIndexOne()
        {
            Test(template, null,
                "DiagnosticWorksheetSelection.SelectWorksheetUsingIndexOne.xlsx",
                null,
                package =>
                {
                    // Same code used in ExportSheet
                    package.Workbook.Worksheets[1].Select();

                },
                package =>
                {
                    Assert.IsNotNull(package.Workbook.Worksheets["FirstSheet"]);
                    Assert.IsNotNull(package.Workbook.Worksheets["SecondSheet"]);
                    Assert.IsNotNull(package.Workbook.Worksheets["ThirdSheet"]);
                });
        }
    }
}
