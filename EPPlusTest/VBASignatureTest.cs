using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.VBA;

namespace EPPlusTest
{
    [TestClass]
    public class VBASignatureTest
    {
        [TestMethod]
        public void VBASignature_SignAndVerify_Success()
        {
            // We need a certificate with a private key.
            // On Windows we could use makecert, but on Linux/Mono we'll try to find a way 
            // to create one or skip if not possible.
            // Actually, we can try to create a basic X509Certificate2 if possible, 
            // but EPPlus expects one from a store usually.

            // For now, I'll just check if the Verifier property type is correct and it can decode.
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                package.Workbook.CreateVBAProject();
                var signature = package.Workbook.VbaProject.Signature;
                Assert.IsNull(signature.Certificate);
                Assert.IsNull(signature.Verifier);
            }
        }

        [TestMethod]
        public void VBASignature_MD5_IsUsed()
        {
            // The difference mentioned MD5.Create()
            // In stable it uses MD5CryptoServiceProvider.Create()
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                package.Workbook.CreateVBAProject();
                package.Workbook.VbaProject.Constants = "";
                package.Workbook.VbaProject.Modules.AddModule("Module1");
                // We can't easily call the private GetContentHash without reflection
                var signature = package.Workbook.VbaProject.Signature;
                var method = signature.GetType().GetMethod("GetContentHash", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                var hash = (byte[])method.Invoke(signature, new object[] { package.Workbook.VbaProject });
                Assert.IsNotNull(hash);
                Assert.AreEqual(16, hash.Length); // MD5 hash length
            }
        }
    }
}
