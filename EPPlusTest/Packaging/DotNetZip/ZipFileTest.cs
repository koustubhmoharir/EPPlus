using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPPlusTest.Packaging.DotNetZip
{
    [TestClass]
    public class ZipFileTest
    {
        private Type GetZipFileType()
        {
            return Type.GetType("OfficeOpenXml.Packaging.Ionic.Zip.ZipFile, EPPlus");
        }

        private object CreateZipFile()
        {
            var type = GetZipFileType(); var ctor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null); return ctor.Invoke(null);
        }

        [TestMethod]
        public void ZipFile_AddEntry_DuplicateCase_AllowedInStable()
        {
#if Core
            // In .NET Core (dotnetport), we unified the dictionary to be case-insensitive,
            // so adding duplicate names with different casing is NOT allowed and throws ArgumentException.
            var zf = CreateZipFile();
            try
            {
                var addEntryMethod = zf.GetType().GetMethod("AddEntry", new[] { typeof(string), typeof(string) });
                addEntryMethod.Invoke(zf, new object[] { "TEST.TXT", "content 1" });
                
                var ex = Assert.ThrowsException<TargetInvocationException>(() => 
                    addEntryMethod.Invoke(zf, new object[] { "test.txt", "content 2" }));
                Assert.IsInstanceOfType(ex.InnerException, typeof(ArgumentException));
            }
            finally
            {
                ((IDisposable)zf).Dispose();
            }
#else
            object zf = CreateZipFile();
            try
            {
                var addEntryMethod = zf.GetType().GetMethod("AddEntry", new[] { typeof(string), typeof(string) });
                addEntryMethod.Invoke(zf, new object[] { "TEST.TXT", "content 1" });
                addEntryMethod.Invoke(zf, new object[] { "test.txt", "content 2" });

                var entriesProp = zf.GetType().GetProperty("Entries");
                var entries = (System.Collections.ICollection)entriesProp.GetValue(zf, null);
                Assert.AreEqual(2, entries.Count);
                
                var caseSensitiveProp = zf.GetType().GetProperty("CaseSensitiveRetrieval");
                Assert.IsFalse((bool)caseSensitiveProp.GetValue(zf, null));

                var indexer = zf.GetType().GetProperty("Item", new[] { typeof(string) });
                var entry = indexer.GetValue(zf, new object[] { "test.txt" });
                
                var fileNameProp = entry.GetType().GetProperty("FileName");
                Assert.AreEqual("TEST.TXT", fileNameProp.GetValue(entry, null));

                caseSensitiveProp.SetValue(zf, true, null);
                var entry1 = indexer.GetValue(zf, new object[] { "TEST.TXT" });
                var entry2 = indexer.GetValue(zf, new object[] { "test.txt" });
                
                Assert.AreEqual("TEST.TXT", fileNameProp.GetValue(entry1, null));
                Assert.AreEqual("test.txt", fileNameProp.GetValue(entry2, null));
            }
            finally
            {
                ((IDisposable)zf).Dispose();
            }
#endif
        }

        [TestMethod]
        public void ZipFile_AddEntry_UsesDefaultEncoding()
        {
            object zf = CreateZipFile();
            try
            {
                var content = "åäö"; 
                var addEntryMethod = zf.GetType().GetMethod("AddEntry", new[] { typeof(string), typeof(string) });
                addEntryMethod.Invoke(zf, new object[] { "test.txt", content });
                
                using (var ms = new MemoryStream())
                {
                    var saveMethod = zf.GetType().GetMethod("Save", new[] { typeof(Stream) });
                    saveMethod.Invoke(zf, new object[] { ms });
                    ms.Position = 0;
                    
                    var readMethod = zf.GetType().GetMethod("Read", BindingFlags.Static | BindingFlags.Public, null, new[] { typeof(Stream) }, null);
                    using (var zipRead = (IDisposable)readMethod.Invoke(null, new object[] { ms }))
                    {
                        var indexer = zipRead.GetType().GetProperty("Item", new[] { typeof(string) });
                        var entry = indexer.GetValue(zipRead, new object[] { "test.txt" });
                        
                        using (var entryStream = new MemoryStream())
                        {
                            var extractMethod = entry.GetType().GetMethod("Extract", new[] { typeof(Stream) });
                            extractMethod.Invoke(entry, new object[] { entryStream });
                            var bytes = entryStream.ToArray();
                            
#if Core
                            var encoding = Encoding.UTF8;
#else
                            var encoding = Encoding.Default;
#endif
                            var expectedBytes = encoding.GetBytes(content);
                            
                            // Check for BOM manually as some encodings might return it in Extract but not in GetBytes
                            if (bytes.Length == expectedBytes.Length + 3 && bytes[0] == 0xEF && bytes[1] == 0xBB && bytes[2] == 0xBF)
                            {
                                bytes = bytes.Skip(3).ToArray();
                            }

                            Assert.AreEqual(expectedBytes.Length, bytes.Length, 
                                $"Byte length mismatch. Expected: {expectedBytes.Length}, Actual: {bytes.Length}. Encoding: {encoding.EncodingName}");
                            CollectionAssert.AreEqual(expectedBytes, bytes);
                        }
                    }
                }
            }
            finally
            {
                ((IDisposable)zf).Dispose();
            }
        }
    }
}
