using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.Packaging.Ionic.Zip;

namespace EPPlusTest
{
    [TestClass]
    public class ComHelperTest
    {
        [TestMethod]
        public void TestComHelperMethods()
        {
            var helper = new ComHelper();
            
            // 1. GetZipLibraryVersion
            var version = helper.GetZipLibraryVersion();
            Assert.IsNotNull(version);
            Assert.IsTrue(version.Length > 0);

            // Create a valid zip (xlsx) file
            var validZipPath = Path.Combine(Path.GetTempPath(), "validZip.xlsx");
            if (File.Exists(validZipPath)) File.Delete(validZipPath);
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                package.Workbook.Worksheets.Add("Sheet1");
                package.SaveAs(new FileInfo(validZipPath));
            }

            // Create an invalid zip file
            var invalidZipPath = Path.Combine(Path.GetTempPath(), "invalidZip.txt");
            if (File.Exists(invalidZipPath)) File.Delete(invalidZipPath);
            File.WriteAllText(invalidZipPath, "This is not a zip file");

            try
            {
                // 2. IsZipFile
                Assert.IsTrue(helper.IsZipFile(validZipPath));
                Assert.IsFalse(helper.IsZipFile(invalidZipPath));

                // 3. IsZipFileWithExtract
                Assert.IsTrue(helper.IsZipFileWithExtract(validZipPath));
                Assert.IsFalse(helper.IsZipFileWithExtract(invalidZipPath));

                // 4. CheckZip on valid file
                Assert.IsTrue(helper.CheckZip(validZipPath));

                // 5. CheckZip on invalid file should throw ZipException
                Assert.ThrowsException<ZipException>(() => helper.CheckZip(invalidZipPath));

                // 6. CheckZipPassword
                Assert.IsTrue(helper.CheckZipPassword(validZipPath, "any_password")); // None of the entries are encrypted, so it returns true.

                // 7. FixZipDirectory
                helper.FixZipDirectory(validZipPath);
            }
            finally
            {
                if (File.Exists(validZipPath)) File.Delete(validZipPath);
                if (File.Exists(invalidZipPath)) File.Delete(invalidZipPath);
            }
        }
    }
}
