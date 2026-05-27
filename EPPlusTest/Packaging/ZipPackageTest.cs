using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml.Packaging;

namespace EPPlusTest.Packaging
{
    [TestClass]
    public class ZipPackageTest
    {
        private ZipPackage CreatePackage(Stream stream = null, string tempFolder = null)
        {
            var type = typeof(ZipPackage);
            if (stream == null)
            {
                var ctorWithTemp = type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null, new[] { typeof(string) }, null);
                return (ZipPackage)ctorWithTemp.Invoke(new object[] { tempFolder });
            }
            else
            {
                // On .NET 9 / dotnetport, ZipPackage has a (Stream, string) internal constructor
                var ctor = type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null, new[] { typeof(Stream), typeof(string) }, null);
                return (ZipPackage)ctor.Invoke(new object[] { stream, tempFolder });
            }
        }

        private object CreatePart(ZipPackage package, Uri uri, string contentType)
        {
            var method = package.GetType().GetMethod("CreatePart", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null, new[] { typeof(Uri), typeof(string) }, null);
            return method.Invoke(package, new object[] { uri, contentType });
        }

        private bool PartExists(ZipPackage package, Uri uri)
        {
            var method = package.GetType().GetMethod("PartExists", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null, new[] { typeof(Uri) }, null);
            return (bool)method.Invoke(package, new object[] { uri });
        }

        private object GetPart(ZipPackage package, Uri uri)
        {
            var method = package.GetType().GetMethod("GetPart", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null, new[] { typeof(Uri) }, null);
            return method.Invoke(package, new object[] { uri });
        }

        private void DeletePart(ZipPackage package, Uri uri)
        {
            var method = package.GetType().GetMethod("DeletePart", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null, new[] { typeof(Uri) }, null);
            method.Invoke(package, new object[] { uri });
        }

        private Stream GetStream(object part)
        {
            // Prefer calling the GetStream() method as it handles initialization
            var method = part.GetType().GetMethod("GetStream", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null, Type.EmptyTypes, null);
            if (method != null)
            {
                return (Stream)method.Invoke(part, null);
            }

            // Fallback to property if method is missing
            var streamProp = part.GetType().GetProperty("Stream", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (streamProp != null)
            {
                return (Stream)streamProp.GetValue(part);
            }
            
            throw new InvalidOperationException("Could not find GetStream method or Stream property on ZipPackagePart");
        }

        [TestMethod]
        public void CreateZipPackageTest()
        {
            var package = CreatePackage();
            Assert.IsNotNull(package);
        }

        [TestMethod]
        public void AddPartTest()
        {
            var package = CreatePackage();
            {
                var uri = new Uri("/test/part.xml", UriKind.Relative);
                var part = CreatePart(package, uri, "text/xml");
                Assert.IsNotNull(part);
                
                var uriProp = part.GetType().GetProperty("Uri", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                Assert.AreEqual(uri, uriProp.GetValue(part, null));
                
                var contentTypeProp = part.GetType().GetProperty("ContentType", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                Assert.AreEqual("text/xml", contentTypeProp.GetValue(part, null));
                
                Assert.IsTrue(PartExists(package, uri));
            }
        }

        [TestMethod]
        public void DeletePartTest()
        {
            var package = CreatePackage();
            {
                var uri = new Uri("/test/part.xml", UriKind.Relative);
                CreatePart(package, uri, "text/xml");
                Assert.IsTrue(PartExists(package, uri));
                DeletePart(package, uri);
                Assert.IsFalse(PartExists(package, uri));
            }
        }

        [TestMethod]
        public void RelationshipTest()
        {
            var package = CreatePackage();
            {
                var uri1 = new Uri("/test/part1.xml", UriKind.Relative);
                var uri2 = new Uri("/test/part2.xml", UriKind.Relative);
                var part1 = CreatePart(package, uri1, "text/xml");
                var part2 = CreatePart(package, uri2, "text/xml");

                var createRelMethod = part1.GetType().GetMethod("CreateRelationship", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                var rel = createRelMethod.Invoke(part1, new object[] { uri2, TargetMode.Internal, "http://schema.test.com/rel" });
                Assert.IsNotNull(rel);
                
                var targetUriProp = rel.GetType().GetProperty("TargetUri", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                Assert.AreEqual(uri2, targetUriProp.GetValue(rel, null));

                var getRelsMethod = part1.GetType().GetMethod("GetRelationships", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                var rels = (System.Collections.IEnumerable)getRelsMethod.Invoke(part1, null);
                
                // In dotnetport, ZipPackageRelationshipCollection might not have a public Count property if it's internal or wrapped
                var countProp = rels.GetType().GetProperty("Count", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                if (countProp != null)
                {
                    Assert.AreEqual(1, (int)countProp.GetValue(rels, null));
                }
                else
                {
                    int count = 0;
                    foreach (var item in rels) count++;
                    Assert.AreEqual(1, count);
                }
            }
        }

        [TestMethod]
        public void SaveAndLoadTest()
        {
            byte[] buffer;
            using (var ms = new MemoryStream())
            {
                var package = CreatePackage();
                {
                    var uri = new Uri("/test/part.xml", UriKind.Relative);
                    var part = CreatePart(package, uri, "text/xml");
                    var stream = GetStream(part);

                    var bContent = Encoding.UTF8.GetBytes("<root>test</root>");
                    stream.Write(bContent, 0, bContent.Length);
                    stream.Flush();
                    
                    var saveMethod = package.GetType().GetMethod("Save", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null, new[] { typeof(Stream) }, null);
                    saveMethod.Invoke(package, new object[] { ms });
                }
                buffer = ms.ToArray();
            }

            using (var ms = new MemoryStream(buffer))
            {
                var package = CreatePackage(ms);
                {
                    var uri = new Uri("/test/part.xml", UriKind.Relative);
                    Assert.IsTrue(PartExists(package, uri));
                    var part = GetPart(package, uri);
                    
                    var contentTypeProp = part.GetType().GetProperty("ContentType", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                    Assert.AreEqual("text/xml", contentTypeProp.GetValue(part, null));
                    
                    var stream = GetStream(part);
                    // In dotnetport, part.Stream (MemoryStream) might need to be seeked to 0 if it was just loaded
                    if (stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);

                    using (var reader = new StreamReader(stream))
                    {
                        var content = reader.ReadToEnd();
                        Assert.AreEqual("<root>test</root>", content);
                    }
                }
            }
        }

        [TestMethod]
        public void TempFolderPartsUseDeleteOnCloseFiles()
        {
            var tempFolder = Path.Combine(Path.GetTempPath(), "EPPlus", "ZipPackageTest", Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(tempFolder);

            var package = CreatePackage(tempFolder: tempFolder);
            var uri = new Uri("/test/temp.xml", UriKind.Relative);
            var part = CreatePart(package, uri, "text/xml");
            var stream = GetStream(part);

            Assert.IsInstanceOfType(stream, typeof(FileStream));

            var fileStream = (FileStream)stream;
            var tempFile = fileStream.Name;
            StringAssert.StartsWith(Path.GetFullPath(tempFile), Path.GetFullPath(tempFolder));

            var content = Encoding.UTF8.GetBytes("<root>temp</root>");
            stream.Write(content, 0, content.Length);
            stream.Flush();

            var disposeMethod = package.GetType().GetMethod("Dispose", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            disposeMethod.Invoke(package, null);

            Assert.IsFalse(File.Exists(tempFile));
        }
    }
}
