using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;

namespace EPPlusE2ETest
{
    [TestClass]
    public class PasswordWorkflow : TestsBase
    {
        static string template = "PasswordWorkflow.xlsx";

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            SaveTemplate(template, package =>
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                ws.Cells["A1"].Value = "Original Data";
            });
        }

        [TestMethod]
        public void SetPasswordOnOutput()
        {
            Test(template,
                null,
                "PasswordWorkflow.SetPasswordOnOutput.xlsx",
                "Password123",
                package =>
                {
                    package.Workbook.Worksheets["Sheet1"]
                        .Cells["A2"].Value = "Protected";
                },
                package =>
                {
                    Assert.AreEqual(
                        "Original Data",
                        package.Workbook.Worksheets["Sheet1"]
                            .Cells["A1"].Text);

                    Assert.AreEqual(
                        "Protected",
                        package.Workbook.Worksheets["Sheet1"]
                            .Cells["A2"].Text);
                });
        }

        [TestMethod]
        public void ChangePassword()
        {
            Test(template,
                null,
                "PasswordWorkflow.ChangePassword.xlsx",
                "NewPassword456",
                package =>
                {
                    package.Workbook.Worksheets["Sheet1"]
                        .Cells["B1"].Value = "Changed";
                },
                package =>
                {
                    Assert.AreEqual(
                        "Changed",
                        package.Workbook.Worksheets["Sheet1"]
                            .Cells["B1"].Text);
                });
        }
    }
}
