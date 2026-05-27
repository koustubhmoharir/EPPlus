using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
#if Core
using OfficeOpenXml.Compatibility;
#endif

namespace EPPlusTest
{
    [TestClass]
    public class ExcelPackageTest : TestBase
    {
        private string GetSafeWorksheetPath(string filename)
        {
            return Path.Combine(_worksheetPath.TrimEnd('\\'), filename);
        }

        [TestMethod]
        public void TestExcelPackageConstructorDefault()
        {
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
#if Core
                Assert.IsNotNull(package.Stream);
#else
                Assert.IsNull(package.Stream);
#endif
                Assert.IsNotNull(package.Workbook);
                Assert.AreEqual(0, package.Workbook.Worksheets.Count);

                var ws = package.Workbook.Worksheets.Add("Sheet1");
                ws.Cells[1, 1].Value = "Default Constructor Test";
                
#if Core
                var bytes = package.GetAsByteArray();
#else
                byte[] bytes;
                using (var ms = new MemoryStream())
                {
                    package.SaveAs(ms);
                    bytes = ms.ToArray();
                }
#endif
                Assert.IsNotNull(bytes);
                Assert.IsTrue(bytes.Length > 0);
            }
        }

        [TestMethod]
        public void TestExcelPackageConstructorFileInfo()
        {
            var tempFile = new FileInfo(GetSafeWorksheetPath("ConstructorFileInfoTest_" + Guid.NewGuid() + ".xlsx"));
            try
            {
                if (tempFile.Exists)
                {
                    tempFile.Delete();
                }

                using (var package = new ExcelPackage(tempFile, EPPlusTest.TempFolderHelper.Create()))
                {
                    Assert.AreEqual(tempFile.FullName, package.File.FullName);
                    var ws = package.Workbook.Worksheets.Add("Sheet1");
                    ws.Cells[1, 1].Value = "FileInfo Test Data";
                    package.Save();
                }

                tempFile.Refresh();
                Assert.IsTrue(tempFile.Exists);

                using (var package = new ExcelPackage(tempFile, EPPlusTest.TempFolderHelper.Create()))
                {
                    Assert.AreEqual(1, package.Workbook.Worksheets.Count);
                    Assert.AreEqual("Sheet1", package.Workbook.Worksheets["Sheet1"].Name);
                    Assert.AreEqual("FileInfo Test Data", package.Workbook.Worksheets["Sheet1"].Cells[1, 1].Value);
                }
            }
            finally
            {
                tempFile.Refresh();
                if (tempFile.Exists)
                {
                    tempFile.Delete();
                }
            }
        }

        [TestMethod]
        public void TestExcelPackageConstructorStream()
        {
            byte[] packageBytes;
            using (var ms = new MemoryStream())
            {
                using (var package = new ExcelPackage(ms, EPPlusTest.TempFolderHelper.Create()))
                {
                    var ws = package.Workbook.Worksheets.Add("SheetFromStream");
                    ws.Cells["A1"].Value = "Stream Test Data";
                    package.Save();
                }
                packageBytes = ms.ToArray();
            }

            Assert.IsNotNull(packageBytes);
            Assert.IsTrue(packageBytes.Length > 0);

            using (var ms = new MemoryStream(packageBytes))
            using (var package = new ExcelPackage(ms, EPPlusTest.TempFolderHelper.Create()))
            {
                Assert.AreEqual(1, package.Workbook.Worksheets.Count);
                Assert.AreEqual("SheetFromStream", package.Workbook.Worksheets["SheetFromStream"].Name);
                Assert.AreEqual("Stream Test Data", package.Workbook.Worksheets["SheetFromStream"].Cells["A1"].Value);
            }
        }

        [TestMethod]
        public void TestExcelPackageConstructorFileInfoTemplate()
        {
            var templateFile = new FileInfo(GetSafeWorksheetPath("Template_" + Guid.NewGuid() + ".xlsx"));
            var newFile = new FileInfo(GetSafeWorksheetPath("NewFromTemplate_" + Guid.NewGuid() + ".xlsx"));
            try
            {
                // Create template
                using (var package = new ExcelPackage(templateFile, EPPlusTest.TempFolderHelper.Create()))
                {
                    var ws = package.Workbook.Worksheets.Add("TemplateSheet");
                    ws.Cells["B2"].Value = "Template Value";
                    package.Save();
                }

                // Create from template
                using (var package = new ExcelPackage(newFile, templateFile, EPPlusTest.TempFolderHelper.Create()))
                {
                    Assert.AreEqual(1, package.Workbook.Worksheets.Count);
                    Assert.AreEqual("TemplateSheet", package.Workbook.Worksheets["TemplateSheet"].Name);
                    Assert.AreEqual("Template Value", package.Workbook.Worksheets["TemplateSheet"].Cells["B2"].Value);

                    var ws2 = package.Workbook.Worksheets.Add("NewSheet");
                    ws2.Cells["C3"].Value = "New Value";
                    package.Save();
                }

                newFile.Refresh();
                Assert.IsTrue(newFile.Exists);

                // Verify new file
                using (var package = new ExcelPackage(newFile, EPPlusTest.TempFolderHelper.Create()))
                {
                    Assert.AreEqual(2, package.Workbook.Worksheets.Count);
                    Assert.AreEqual("TemplateSheet", package.Workbook.Worksheets["TemplateSheet"].Name);
                    Assert.AreEqual("Template Value", package.Workbook.Worksheets["TemplateSheet"].Cells["B2"].Value);
                    Assert.AreEqual("NewSheet", package.Workbook.Worksheets["NewSheet"].Name);
                    Assert.AreEqual("New Value", package.Workbook.Worksheets["NewSheet"].Cells["C3"].Value);
                }

                // Verify template remains unchanged
                using (var package = new ExcelPackage(templateFile, EPPlusTest.TempFolderHelper.Create()))
                {
                    Assert.AreEqual(1, package.Workbook.Worksheets.Count);
                }
            }
            finally
            {
                templateFile.Refresh();
                if (templateFile.Exists) templateFile.Delete();
                newFile.Refresh();
                if (newFile.Exists) newFile.Delete();
            }
        }

        [TestMethod]
        public void TestExcelPackageConstructorStreamTemplate()
        {
            byte[] templateBytes;
            using (var ms = new MemoryStream())
            {
                using (var package = new ExcelPackage(ms, EPPlusTest.TempFolderHelper.Create()))
                {
                    var ws = package.Workbook.Worksheets.Add("TemplateSheet");
                    ws.Cells["A1"].Value = "Stream Template Value";
                    package.Save();
                }
                templateBytes = ms.ToArray();
            }

            using (var templateStream = new MemoryStream(templateBytes))
            using (var outputStream = new MemoryStream())
            {
                using (var package = new ExcelPackage(outputStream, templateStream, EPPlusTest.TempFolderHelper.Create()))
                {
                    Assert.AreEqual(1, package.Workbook.Worksheets.Count);
                    Assert.AreEqual("Stream Template Value", package.Workbook.Worksheets["TemplateSheet"].Cells["A1"].Value);

                    var ws = package.Workbook.Worksheets.Add("ExtraSheet");
                    ws.Cells["B2"].Value = "Extra Value";
                    package.Save();
                }

                byte[] outputBytes = outputStream.ToArray();
                using (var ms = new MemoryStream(outputBytes))
                using (var package = new ExcelPackage(ms, EPPlusTest.TempFolderHelper.Create()))
                {
                    Assert.AreEqual(2, package.Workbook.Worksheets.Count);
                    Assert.AreEqual("Stream Template Value", package.Workbook.Worksheets["TemplateSheet"].Cells["A1"].Value);
                    Assert.AreEqual("Extra Value", package.Workbook.Worksheets["ExtraSheet"].Cells["B2"].Value);
                }
            }
        }

        [TestMethod]
        public void TestExcelPackageSaveAsFileInfo()
        {
            var destFile = new FileInfo(GetSafeWorksheetPath("SaveAsDest_" + Guid.NewGuid() + ".xlsx"));
            try
            {
                using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
                {
                    var ws = package.Workbook.Worksheets.Add("SaveAsSheet");
                    ws.Cells["A1"].Value = "Saved As Value";
                    package.SaveAs(destFile);
                }

                destFile.Refresh();
                Assert.IsTrue(destFile.Exists);

                using (var package = new ExcelPackage(destFile, EPPlusTest.TempFolderHelper.Create()))
                {
                    Assert.AreEqual(1, package.Workbook.Worksheets.Count);
                    Assert.AreEqual("Saved As Value", package.Workbook.Worksheets["SaveAsSheet"].Cells["A1"].Value);
                }
            }
            finally
            {
                destFile.Refresh();
                if (destFile.Exists) destFile.Delete();
            }
        }

        [TestMethod]
        public void TestExcelPackageSaveAsStream()
        {
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = package.Workbook.Worksheets.Add("SaveAsStreamSheet");
                ws.Cells["A1"].Value = "Stream Saved Value";

                using (var output = new MemoryStream())
                {
                    package.SaveAs(output);
                    byte[] bytes = output.ToArray();
                    Assert.IsTrue(bytes.Length > 0);

                    using (var ms = new MemoryStream(bytes))
                    using (var package2 = new ExcelPackage(ms, EPPlusTest.TempFolderHelper.Create()))
                    {
                        Assert.AreEqual(1, package2.Workbook.Worksheets.Count);
                        Assert.AreEqual("Stream Saved Value", package2.Workbook.Worksheets["SaveAsStreamSheet"].Cells["A1"].Value);
                    }
                }
            }
        }

        [TestMethod]
        public void TestExcelPackageEncryptionSupport()
        {
            // On dotnetport branch (.NET 9), encryption is supported and should successfully save and load
            var file = new FileInfo(GetSafeWorksheetPath("EncryptedPackage_" + Guid.NewGuid() + ".xlsx"));
            try
            {
                using (var package = new ExcelPackage(file, EPPlusTest.TempFolderHelper.Create()))
                {
                    package.Workbook.Worksheets.Add("SecureSheet");
                    package.Encryption.Password = "StrongPassword";
                    package.Encryption.IsEncrypted = true;
                    package.Save();
                }

                file.Refresh();
                Assert.IsTrue(file.Exists);

                // Attempt to open with wrong password should fail
                try
                {
                    using (var package = new ExcelPackage(file, "WrongPassword", EPPlusTest.TempFolderHelper.Create()))
                    {
                        var name = package.Workbook.Worksheets["SecureSheet"].Name;
                        Assert.Fail("Opening encrypted workbook with wrong password should have failed");
                    }
                }
                catch (Exception)
                {
                    // Expected failure
                }

                // Successfully open with correct password
                using (var package = new ExcelPackage(file, "StrongPassword", EPPlusTest.TempFolderHelper.Create()))
                {
                    Assert.AreEqual(1, package.Workbook.Worksheets.Count);
                    Assert.AreEqual("SecureSheet", package.Workbook.Worksheets["SecureSheet"].Name);
                }
            }
            finally
            {
                file.Refresh();
                if (file.Exists) file.Delete();
            }
        }

#if Core
        [TestMethod]
        public void TestExcelPackageCompatibilitySettingsIsWorksheets1Based()
        {
            // This tests the dotnetport specific CompatibilitySettings logic.
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                // Default is false on dotnetport (.NET 9) under Core conditional if not configured, 
                // but let's test toggling it.
                package.Compatibility.IsWorksheets1Based = false;
                Assert.IsFalse(package.Compatibility.IsWorksheets1Based);

                var ws0 = package.Workbook.Worksheets.Add("ZeroIndexed");
                // Assert that the worksheets list behaves as 0-indexed or 1-indexed.
                // In EPPlus, when IsWorksheets1Based is false, we can access the first worksheet using index 0.
                Assert.AreEqual(ws0, package.Workbook.Worksheets[0]);

                package.Compatibility.IsWorksheets1Based = true;
                Assert.IsTrue(package.Compatibility.IsWorksheets1Based);
                // When 1-based, we access the first worksheet using index 1.
                Assert.AreEqual(ws0, package.Workbook.Worksheets[1]);
            }
        }
#endif
    }
}
