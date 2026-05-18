using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.Encryption;

namespace EPPlusTest
{
    [TestClass]
    public class EncryptedPackageHandlerTest
    {
        [TestMethod]
        public void TestAgileEncryptionDecryption()
        {
            // 1. Create a simple valid XLSX package in memory using ExcelPackage
            byte[] packageData;
            using (var pck = new ExcelPackage())
            {
                var ws = pck.Workbook.Worksheets.Add("TestSheet");
                ws.Cells["A1"].Value = "Hello World";
                ws.Cells["A2"].Value = 12345;
                packageData = pck.GetAsByteArray();
            }

            // 2. Encrypt/Decrypt it using EncryptedPackageHandler
            var encryption = new ExcelEncryption()
            {
                Password = "SecretPassword",
                Version = EncryptionVersion.Agile,
                Algorithm = EncryptionAlgorithm.AES256
            };

#if Core
            var handler = new EncryptedPackageHandler();
            using (MemoryStream encryptedStream = handler.EncryptPackage(packageData, encryption))
            {
                Assert.IsNotNull(encryptedStream);
                byte[] encryptedData = encryptedStream.ToArray();
                Assert.IsTrue(encryptedData.Length > 0);

                using (var encryptedMemStream = new MemoryStream(encryptedData))
                using (MemoryStream decryptedStream = handler.DecryptPackage(encryptedMemStream, encryption))
                {
                    Assert.IsNotNull(decryptedStream);
                    decryptedStream.Position = 0;
                    using (var decryptedPck = new ExcelPackage(decryptedStream))
                    {
                        Assert.AreEqual(1, decryptedPck.Workbook.Worksheets.Count);
                        var ws = decryptedPck.Workbook.Worksheets["TestSheet"];
                        Assert.AreEqual("Hello World", ws.Cells["A1"].Value);
                        Assert.AreEqual(12345.0, Convert.ToDouble(ws.Cells["A2"].Value));
                    }
                }
            }
#else
            var handler = new EncryptedPackageHandler(null);
            var encryptedStream = new MemoryStream();
            using (var packageStream = new MemoryStream(packageData))
            {
                handler.EncryptPackage(packageStream, encryption, encryptedStream);
            }

            byte[] encryptedData = encryptedStream.ToArray();
            Assert.IsNotNull(encryptedData);
            Assert.IsTrue(encryptedData.Length > 0);

            var decryptedStream = new MemoryStream();
            using (var encryptedMemStream = new MemoryStream(encryptedData))
            {
                handler.DecryptPackage(encryptedMemStream, encryption, decryptedStream);
            }

            decryptedStream.Position = 0;
            using (var decryptedPck = new ExcelPackage(decryptedStream))
            {
                Assert.AreEqual(1, decryptedPck.Workbook.Worksheets.Count);
                var ws = decryptedPck.Workbook.Worksheets["TestSheet"];
                Assert.AreEqual("Hello World", ws.Cells["A1"].Value);
                Assert.AreEqual(12345.0, Convert.ToDouble(ws.Cells["A2"].Value));
            }
#endif
        }

        [TestMethod]
        public void TestStandardEncryptionDecryption()
        {
            // 1. Create a simple valid XLSX package in memory using ExcelPackage
            byte[] packageData;
            using (var pck = new ExcelPackage())
            {
                var ws = pck.Workbook.Worksheets.Add("TestSheet");
                ws.Cells["A1"].Value = "Standard Encryption Test";
                packageData = pck.GetAsByteArray();
            }

            // 2. Encrypt/Decrypt it using EncryptedPackageHandler
            var encryption = new ExcelEncryption()
            {
                Password = "StandardPassword",
                Version = EncryptionVersion.Standard,
                Algorithm = EncryptionAlgorithm.AES128
            };

#if Core
            var handler = new EncryptedPackageHandler();
            using (MemoryStream encryptedStream = handler.EncryptPackage(packageData, encryption))
            {
                Assert.IsNotNull(encryptedStream);
                byte[] encryptedData = encryptedStream.ToArray();
                Assert.IsTrue(encryptedData.Length > 0);

                using (var encryptedMemStream = new MemoryStream(encryptedData))
                using (MemoryStream decryptedStream = handler.DecryptPackage(encryptedMemStream, encryption))
                {
                    Assert.IsNotNull(decryptedStream);
                    decryptedStream.Position = 0;
                    using (var decryptedPck = new ExcelPackage(decryptedStream))
                    {
                        Assert.AreEqual(1, decryptedPck.Workbook.Worksheets.Count);
                        var ws = decryptedPck.Workbook.Worksheets["TestSheet"];
                        Assert.AreEqual("Standard Encryption Test", ws.Cells["A1"].Value);
                    }
                }
            }
#else
            var handler = new EncryptedPackageHandler(null);
            var encryptedStream = new MemoryStream();
            using (var packageStream = new MemoryStream(packageData))
            {
                handler.EncryptPackage(packageStream, encryption, encryptedStream);
            }

            byte[] encryptedData = encryptedStream.ToArray();
            Assert.IsNotNull(encryptedData);
            Assert.IsTrue(encryptedData.Length > 0);

            var decryptedStream = new MemoryStream();
            using (var encryptedMemStream = new MemoryStream(encryptedData))
            {
                handler.DecryptPackage(encryptedMemStream, encryption, decryptedStream);
            }

            decryptedStream.Position = 0;
            using (var decryptedPck = new ExcelPackage(decryptedStream))
            {
                Assert.AreEqual(1, decryptedPck.Workbook.Worksheets.Count);
                var ws = decryptedPck.Workbook.Worksheets["TestSheet"];
                Assert.AreEqual("Standard Encryption Test", ws.Cells["A1"].Value);
            }
#endif
        }
    }
}
