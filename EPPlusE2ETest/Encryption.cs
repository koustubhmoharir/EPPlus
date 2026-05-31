using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace EPPlusE2ETest
{
    [TestClass]
    public class Encryption : TestsBase
    {
        static string password = "password";
        static string template = "Encryption.xlsx";

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            SaveTemplate(template, package =>
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                ws.Cells["A1"].Value = "Header1";
                ws.Cells["B1"].Value = "Header2";
                package.Encryption.Password = password;
                package.Encryption.Version = EncryptionVersion.Agile;
            });
        }

        [TestMethod]
        public void TabularData()
        {
            Test(template, password, "Encryption.TabularData.xlsx", password, package =>
            {
                var ws = package.Workbook.Worksheets["Sheet1"];
                ws.Cells["A2"].Value = 1.0;
                ws.Cells["B2"].Value = 2.0;
            }, package =>
            {
                var ws = package.Workbook.Worksheets["Sheet1"];

                Assert.AreEqual("Header1", ws.Cells["A1"].GetValue<string>());
                Assert.AreEqual("Header2", ws.Cells["B1"].GetValue<string>());
                Assert.AreEqual(1.0, ws.Cells["A2"].GetValue<double>());
                Assert.AreEqual(2.0, ws.Cells["B2"].GetValue<double>());
            });
        }
    }
}
