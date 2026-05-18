using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPPlusTest.DotNetZip
{
    [TestClass]
    public class ZipDirEntryTest
    {
        private static readonly byte[] ZipBytes = Convert.FromBase64String("UEsDBBQAAAAAAJMzslwGOFcHBgAAAAYAAAAIAAAAdGVzdC50eHRGaWxlIDFQSwMEFAAAAAAAkzOyXLxpXp4GAAAABgAAAAgAAAB0ZXN0LnR4dEZpbGUgMlBLAQIUAxQAAAAAAJMzslwGOFcHBgAAAAYAAAAIAAAAAAAAAAAAAACAAQAAAAB0ZXN0LnR4dFBLAQIUAxQAAAAAAJMzsly8aV6eBgAAAAYAAAAIAAAAAAAAAAAAAACAASwAAAB0ZXN0LnR4dFBLBQYAAAAAAgACAGwAAABYAAAAAAA=");

        [TestMethod]
        public void ZipDirEntry_DuplicateFilesHandling_Rename()
        {
            using (var ms = new MemoryStream(ZipBytes))
            {
                var zipFileType = Type.GetType("OfficeOpenXml.Packaging.Ionic.Zip.ZipFile, EPPlus");
                Assert.IsNotNull(zipFileType, "ZipFile type not found");

                var readMethod = zipFileType.GetMethod("Read", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public, null, new[] { typeof(Stream) }, null);
                Assert.IsNotNull(readMethod, "Read method not found");

                using (var zf = (IDisposable)readMethod.Invoke(null, new object[] { ms }))
                {
                    var entriesProp = zipFileType.GetProperty("Entries", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    var entries = (System.Collections.ICollection)entriesProp.GetValue(zf, null);
                    
                    Assert.AreEqual(2, entries.Count);
                    
                    var containsEntryMethod = zipFileType.GetMethod("ContainsEntry", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new[] { typeof(string) }, null);
                    
                    Assert.IsTrue((bool)containsEntryMethod.Invoke(zf, new object[] { "test.txt" }));
                    Assert.IsTrue((bool)containsEntryMethod.Invoke(zf, new object[] { "test (copy 1).txt" }));
                }
            }
        }

        [TestMethod]
        public void ZipDirEntry_DuplicateFilesHandling_Ignore()
        {
            string tempFile = Path.GetTempFileName();
            try
            {
                File.WriteAllBytes(tempFile, ZipBytes);

                var zipFileType = Type.GetType("OfficeOpenXml.Packaging.Ionic.Zip.ZipFile, EPPlus");
                var zf = (IDisposable)Activator.CreateInstance(zipFileType, true);

                var ignoreProp = zipFileType.GetProperty("IgnoreDuplicateFiles", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                ignoreProp.SetValue(zf, true, null);

                var initMethod = zipFileType.GetMethod("Initialize", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new[] { typeof(string) }, null);
                initMethod.Invoke(zf, new object[] { tempFile });

                var entriesProp = zipFileType.GetProperty("Entries", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                var entries = (System.Collections.ICollection)entriesProp.GetValue(zf, null);
                
                Assert.AreEqual(1, entries.Count);
                
                var containsEntryMethod = zipFileType.GetMethod("ContainsEntry", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new[] { typeof(string) }, null);
                Assert.IsTrue((bool)containsEntryMethod.Invoke(zf, new object[] { "test.txt" }));

                zf.Dispose();
            }
            finally
            {
                if (File.Exists(tempFile))
                    File.Delete(tempFile);
            }
        }
    }
}
