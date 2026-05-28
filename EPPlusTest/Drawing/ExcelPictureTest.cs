using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using System;
using System.IO;

namespace EPPlusTest.Drawing
{
    [TestClass]
    public class ExcelPictureTest : EPPlusTest.TestBase
    {
        [TestMethod]
        public void ExcelPicture_AddPicture_FromBytes_UsesRawImageData()
        {
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = package.Workbook.Worksheets.Add("TestSheet");
                var imageBytes = GetEmbeddedResourceBytes("EPPlusTest.Resources.Test1.jpg");

                var pic = ws.Drawings.AddPicture("TestPic", imageBytes);

                Assert.IsNotNull(pic);
                Assert.IsNotNull(pic.ImageHash);
                Assert.AreEqual("TestPic", pic.Name);

                pic.SetSize(50);
                using (var ms = new MemoryStream())
                {
                    package.SaveAs(ms);
                    CollectionAssert.AreEqual(imageBytes, GetSingleMediaBytes(ms.ToArray()));
                }
                Assert.IsTrue(pic.ImageHash.Length > 0);
            }
        }

        [TestMethod]
        public void ExcelPicture_AddPicture_FromStream_UsesRawImageData()
        {
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = package.Workbook.Worksheets.Add("TestSheet");
                var imageBytes = GetEmbeddedResourceBytes("EPPlusTest.Resources.Test1.jpg");

                using (var stream = new MemoryStream(imageBytes))
                {
                    var pic = ws.Drawings.AddPicture("TestPic", stream, "image/jpeg");

                    Assert.IsNotNull(pic);
                    Assert.IsNotNull(pic.ImageHash);
                    Assert.AreEqual("TestPic", pic.Name);
                    Assert.IsTrue(pic.ImageHash.Length > 0);
                }
            }
        }

        private static byte[] GetSingleMediaBytes(byte[] workbookBytes)
        {
            using (var ms = new MemoryStream(workbookBytes))
            using (var zip = new System.IO.Compression.ZipArchive(ms, System.IO.Compression.ZipArchiveMode.Read, leaveOpen: false))
            {
                foreach (var entry in zip.Entries)
                {
                    if (!entry.FullName.StartsWith("xl/media/", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    using (var entryStream = entry.Open())
                    using (var entryBytes = new MemoryStream())
                    {
                        entryStream.CopyTo(entryBytes);
                        return entryBytes.ToArray();
                    }
                }
            }

            throw new InvalidOperationException("No media entry found in workbook.");
        }
    }
}
