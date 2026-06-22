using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace EPPlusE2ETest
{
    [TestClass]
    public class WorksheetProtection : TestsBase
    {
        static string template = "WorksheetProtection.xlsx";

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            SaveTemplate(template, package =>
            {
                var ws = package.Workbook.Worksheets.Add("ProtectedSheet");

                ws.Cells["A1"].Value = "Locked";
                ws.Cells["B1"].Value = "Editable";

                // Lock all cells (default behavior)
                ws.Cells.Style.Locked = true;

                // Make B1 editable
                ws.Cells["B1"].Style.Locked = false;

                // Protect worksheet
                ws.Protection.SetPassword("test123");
                ws.Protection.IsProtected = true;
            });
        }

        [TestMethod]
        public void ProtectUnprotectAndReProtectWorksheet()
        {
            Test(template, null,
                "WorksheetProtection.ProtectUnprotectAndReProtectWorksheet.xlsx",
                null,
                package =>
                {
                    var ws = package.Workbook.Worksheets["ProtectedSheet"];

                    // Simulate user editing unlocked cell
                    ws.Cells["B1"].Value = "Updated";

                    // Re-protect sheet
                    ws.Protection.SetPassword("test123");
                    ws.Protection.IsProtected = true;
                },
                package =>
                {
                    var ws = package.Workbook.Worksheets["ProtectedSheet"];

                    Assert.IsTrue(ws.Protection.IsProtected);

                    Assert.AreEqual(
                        "Locked",
                        ws.Cells["A1"].Value);

                    Assert.AreEqual(
                        "Updated",
                        ws.Cells["B1"].Value);

                    Assert.IsTrue(
                        ws.Cells["A1"].Style.Locked);

                    Assert.IsFalse(
                        ws.Cells["B1"].Style.Locked);
                });
        }
    }
}
