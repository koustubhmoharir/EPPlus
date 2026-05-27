using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml.Packaging.Ionic.Zip;

namespace EPPlusTest.Packaging.DotNetZip
{
#if NET9_0
    [TestClass]
    public class ZipEntryExtractTest
    {
        [TestMethod]
        public void ZipEntry_Extract_WritesFileAndReleasesHandle()
        {
            var root = Path.Combine(Path.GetTempPath(), "ZipEntryExtractTest_" + Guid.NewGuid().ToString("N"));
            var sourceDir = Path.Combine(root, "source");
            var extractDir = Path.Combine(root, "extract");
            Directory.CreateDirectory(sourceDir);
            Directory.CreateDirectory(extractDir);

            var sourceFile = Path.Combine(sourceDir, "payload.txt");
            var zipPath = Path.Combine(root, "payload.zip");
            var content = "payload-" + Guid.NewGuid().ToString("N");

            try
            {
                File.WriteAllText(sourceFile, content);

                using (var zip = new ZipFile())
                {
                    zip.AddFile(sourceFile, string.Empty);
                    zip.Save(zipPath);
                }

                using (var zip = ZipFile.Read(zipPath))
                {
                    var entry = zip["payload.txt"];
                    Assert.IsNotNull(entry, "Expected the zip entry to be present.");

                    entry.Extract(extractDir);
                }

                var extractedPath = Path.Combine(extractDir, "payload.txt");
                Assert.IsTrue(File.Exists(extractedPath), "Expected extracted file to exist.");
                Assert.AreEqual(content, File.ReadAllText(extractedPath));

                using (File.Open(extractedPath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                }
            }
            finally
            {
                if (Directory.Exists(root))
                {
                    Directory.Delete(root, true);
                }
            }
        }

        [TestMethod]
        public void ZipEntry_Extract_OverwritesExistingFileAndReleasesHandle()
        {
            var root = Path.Combine(Path.GetTempPath(), "ZipEntryExtractTest_" + Guid.NewGuid().ToString("N"));
            var sourceDir = Path.Combine(root, "source");
            var extractDir = Path.Combine(root, "extract");
            Directory.CreateDirectory(sourceDir);
            Directory.CreateDirectory(extractDir);

            var sourceFile = Path.Combine(sourceDir, "payload.txt");
            var zipPath = Path.Combine(root, "payload.zip");
            var content = "payload-" + Guid.NewGuid().ToString("N");
            var extractedPath = Path.Combine(extractDir, "payload.txt");

            try
            {
                File.WriteAllText(sourceFile, content);
                File.WriteAllText(extractedPath, "stale-content");

                using (var zip = new ZipFile())
                {
                    zip.AddFile(sourceFile, string.Empty);
                    zip.Save(zipPath);
                }

                using (var zip = ZipFile.Read(zipPath))
                {
                    var entry = zip["payload.txt"];
                    Assert.IsNotNull(entry, "Expected the zip entry to be present.");

                    entry.Extract(extractDir, ExtractExistingFileAction.OverwriteSilently);
                }

                Assert.IsTrue(File.Exists(extractedPath), "Expected extracted file to exist.");
                Assert.AreEqual(content, File.ReadAllText(extractedPath));

                using (File.Open(extractedPath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                }
            }
            finally
            {
                if (Directory.Exists(root))
                {
                    Directory.Delete(root, true);
                }
            }
        }
    }
#else
    [TestClass]
    public class ZipEntryExtractTest
    {
        [TestMethod]
        public void ZipEntry_Extract_IsNotSupportedOnMono()
        {
            Assert.Inconclusive("ZipEntry.Extract(string) rewrites paths with backslashes before Path.GetDirectoryName, which is not compatible with Mono on Linux.");
        }
    }
#endif
}
