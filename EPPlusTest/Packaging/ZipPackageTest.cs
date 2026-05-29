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
        private ZipPackage CreatePackage(Stream stream = null)
        {
            var type = typeof(ZipPackage);
            if (stream == null)
            {
                var ctor = type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null, new[] { typeof(string) }, null);
                return (ZipPackage)ctor.Invoke(new object[] { null });
            }
            else
            {
                var ctor = type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null, new[] { typeof(Stream), typeof(string) }, null);
                return (ZipPackage)ctor.Invoke(new object[] { stream, null });
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
            var method = part.GetType().GetMethod("GetStream", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null, Type.EmptyTypes, null);
            return (Stream)method.Invoke(part, null);
        }

        [TestMethod]
        public void CreateZipPackageTest()
        {
            using (var package = CreatePackage())
            {
                Assert.IsNotNull(package);
            }
        }

        [TestMethod]
        public void AddPartTest()
        {
            using (var package = CreatePackage())
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
            using (var package = CreatePackage())
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
            using (var package = CreatePackage())
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
                var countProp = rels.GetType().GetProperty("Count", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                Assert.AreEqual(1, (int)countProp.GetValue(rels, null));
            }
        }

        [TestMethod]
        public void SaveAndLoadTest()
        {
            byte[] buffer;
            using (var ms = new MemoryStream())
            {
                using (var package = CreatePackage())
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
                using (var package = CreatePackage(ms))
                {
                    var uri = new Uri("/test/part.xml", UriKind.Relative);
                    Assert.IsTrue(PartExists(package, uri));
                    var part = GetPart(package, uri);

                    var contentTypeProp = part.GetType().GetProperty("ContentType", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                    Assert.AreEqual("text/xml", contentTypeProp.GetValue(part, null));

                    var stream = GetStream(part);
                    using (var reader = new StreamReader(stream))
                    {
                        var content = reader.ReadToEnd();
                        Assert.AreEqual("<root>test</root>", content);
                    }
                }
            }
        }
    }
}
