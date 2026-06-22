using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;

namespace EPPlusE2ETest
{
    [TestClass]
    public class CellValuesAndErrors : TestsBase
    {
        static string template = "CellValuesAndErrors.xlsx";

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            SaveTemplate(template, package =>
            {
                package.Workbook.Worksheets.Add("Values");
            });
        }

        [TestMethod]
        public void ValuesErrorsAndLongStringsRoundTrip()
        {
            Test(template, null, "CellValuesAndErrors.ValuesErrorsAndLongStringsRoundTrip.xlsx", null, package =>
            {
                var sheet = package.Workbook.Worksheets["Values"];
                sheet.Cells["A1"].Value = "text";
                sheet.Cells["A2"].Value = 12.5d;
                sheet.Cells["A3"].Value = true;
                sheet.Cells["A4"].Value = ExcelErrorValue.Create(eErrorType.Div0);
                sheet.Cells["A5"].Value = ExcelErrorValue.Create(eErrorType.Value);
                sheet.Cells["A6"].Value = ExcelErrorValue.Create(eErrorType.Ref);
                sheet.Cells["A7"].Value = ExcelErrorValue.Create(eErrorType.Name);
                sheet.Cells["A8"].Value = ExcelErrorValue.Create(eErrorType.Num);
                sheet.Cells["A9"].Value = ExcelErrorValue.Create(eErrorType.NA);
                sheet.Cells["A10"].Value = null;
                sheet.Cells["A11"].Value = new string('x', 32767);
                sheet.Cells["B1:C2"].Value = new object[,] { { 1, "a" }, { 2, "b" } };
            }, package =>
            {
                var sheet = package.Workbook.Worksheets["Values"];
                Assert.AreEqual("text", sheet.Cells["A1"].Value);
                Assert.AreEqual(12.5d, sheet.Cells["A2"].Value);
                Assert.AreEqual(true, sheet.Cells["A3"].Value);
                Assert.AreEqual(ExcelErrorValue.Create(eErrorType.Div0), sheet.Cells["A4"].Value);
                Assert.AreEqual(ExcelErrorValue.Create(eErrorType.Value), sheet.Cells["A5"].Value);
                Assert.AreEqual(ExcelErrorValue.Create(eErrorType.Ref), sheet.Cells["A6"].Value);
                Assert.AreEqual(ExcelErrorValue.Create(eErrorType.Name), sheet.Cells["A7"].Value);
                Assert.AreEqual(ExcelErrorValue.Create(eErrorType.Num), sheet.Cells["A8"].Value);
                Assert.AreEqual(ExcelErrorValue.Create(eErrorType.NA), sheet.Cells["A9"].Value);
                Assert.IsNull(sheet.Cells["A10"].Value);
                Assert.AreEqual(32767, ((string)sheet.Cells["A11"].Value).Length);
                Assert.AreEqual(1d, sheet.Cells["B1"].Value);
                Assert.AreEqual("b", sheet.Cells["C2"].Value);
            });
        }
    }
}
