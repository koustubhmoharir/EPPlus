using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;

namespace EPPlusE2ETest
{
    [TestClass]
    public class CalculationSettings : TestsBase
    {
        static string template = "CalculationSettings.xlsx";

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            SaveTemplate(template, package =>
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");

                ws.Cells["A1"].Value = 10;
                ws.Cells["A2"].Value = 20;
                ws.Cells["A3"].Formula = "SUM(A1:A2)";
            });
        }

        [TestMethod]
        public void WorkbookCalculationSettings()
        {
            Test(template, null,
                "CalculationSettings.WorkbookCalculationSettings.xlsx",
                null,
                package =>
                {
                    package.Workbook.CalcMode = ExcelCalcMode.Automatic;
                    package.Workbook.FullCalcOnLoad = false;
                },
                package =>
                {
                    Assert.AreEqual(
                        ExcelCalcMode.Automatic,
                        package.Workbook.CalcMode);

                    var ws = package.Workbook.Worksheets["Sheet1"];

                    Assert.AreEqual(
                        "SUM(A1:A2)",
                        ws.Cells["A3"].Formula);
                });
        }
    }
}
