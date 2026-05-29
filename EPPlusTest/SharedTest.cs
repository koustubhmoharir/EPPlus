using System;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPPlusTest.Packaging.DotNetZip
{
    [TestClass]
    public class SharedTest
    {
        private Type _sharedUtilitiesType;

        [TestInitialize]
        public void Setup()
        {
            var assembly = typeof(OfficeOpenXml.ExcelPackage).Assembly;
            _sharedUtilitiesType = assembly.GetType("OfficeOpenXml.Packaging.Ionic.Zip.SharedUtilities");
            Assert.IsNotNull(_sharedUtilitiesType, "Could not find SharedUtilities type.");
        }

        private object InvokeMethod(string methodName, params object[] args)
        {
            try
            {
                return _sharedUtilitiesType.InvokeMember(methodName, BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.InvokeMethod, null, null, args);
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
        }

        [TestMethod]
        public void GetFileLength_NonExistentFile_ThrowsFileNotFoundException()
        {
            var fileName = "this_file_does_not_exist_12345.txt";
            try
            {
                InvokeMethod("GetFileLength", fileName);
                Assert.Fail("Expected FileNotFoundException");
            }
            catch (FileNotFoundException ex)
            {
#if Core
                Assert.AreEqual(fileName, ex.FileName);
#else
                Assert.IsTrue(ex.Message.Contains(fileName) || ex.FileName == fileName);
#endif
            }
        }

        [TestMethod]
        public void StringToByteArray_And_StringFromBuffer_Encoding()
        {
            // The default encoding without parameter is IBM437 in stable, UTF-8 in Core
            string testString = "Test string with special chars: äöü";
            byte[] bytes = (byte[])InvokeMethod("StringToByteArray", testString);
            Assert.IsNotNull(bytes);

            var expectedEncoding = OfficeOpenXml.Packaging.Ionic.Zip.ZipEntry.DefaultEncoding;
            byte[] expectedBytes = expectedEncoding.GetBytes(testString);
            CollectionAssert.AreEqual(expectedBytes, bytes);
        }

        [TestMethod]
        public void ReadWithRetry_ReadsSuccessfully()
        {
            // Test that it reads fine for an un-locked file
            var tempFile = Path.GetTempFileName();
            try
            {
                File.WriteAllBytes(tempFile, new byte[] { 1, 2, 3, 4, 5 });
                using (var fs = File.OpenRead(tempFile))
                {
                    byte[] buffer = new byte[5];
                    int read = (int)InvokeMethod("ReadWithRetry", fs, buffer, 0, 5, tempFile);
                    Assert.AreEqual(5, read);
                    Assert.AreEqual(1, buffer[0]);
                }
            }
            finally
            {
                if (File.Exists(tempFile)) File.Delete(tempFile);
            }
        }
    }
}
