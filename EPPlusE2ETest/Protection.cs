using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;

namespace EPPlusE2ETest
{
    [TestClass]
    public class Protection : TestsBase
    {
        static string template = "Protection.xlsx";

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            SaveTemplate(template, package =>
            {
                package.Workbook.Worksheets.Add("Protected");
            });
        }

        [TestMethod]
        public void SheetProtectionFlagsAndPassword()
        {
            Test(template, null, "Protection.SheetProtectionFlagsAndPassword.xlsx", null, package =>
            {
                var sheet = package.Workbook.Worksheets["Protected"];
                sheet.Protection.IsProtected = true;
                sheet.Protection.AllowEditObject = false;
                sheet.Protection.AllowEditScenarios = false;
                sheet.Protection.SetPassword("sheet-password");
            }, package =>
            {
                var sheet = package.Workbook.Worksheets["Protected"];
                Assert.IsTrue(sheet.Protection.IsProtected);
                Assert.IsFalse(sheet.Protection.AllowEditObject);
                Assert.IsFalse(sheet.Protection.AllowEditScenarios);
            });
        }

        [TestMethod]
        public void ConcurrentSheetProtectionAndWorkbookEncryption()
        {
            Test(template, null, "Protection.ConcurrentSheetAndWorkbook.xlsx", "workbook-password", package =>
            {
                var sheet = package.Workbook.Worksheets["Protected"];
                sheet.Protection.IsProtected = true;
                sheet.Protection.AllowEditObject = false;
                sheet.Protection.AllowEditScenarios = false;
                sheet.Protection.SetPassword("sheet-password");
                
                // Set workbook encryption
                package.Encryption.IsEncrypted = true;
                package.Encryption.Password = "workbook-password";
            }, package =>
            {
                var sheet = package.Workbook.Worksheets["Protected"];
                Assert.IsTrue(sheet.Protection.IsProtected);
                Assert.IsFalse(sheet.Protection.AllowEditObject);
                Assert.IsFalse(sheet.Protection.AllowEditScenarios);
                Assert.IsTrue(package.Encryption.IsEncrypted);
            });
        }
    }
}
