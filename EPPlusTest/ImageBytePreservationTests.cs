using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace EPPlusTest
{
    [TestClass]
    public class ImageBytePreservationTests : TestBase
    {
        [TestMethod]
        public void ExistingPictureBytesSurviveLoadAndSave()
        {
            var sourceBytes = GetEmbeddedResourceBytes("EPPlusTest.Resources.Test1.jpg");
            var imagePath = Path.Combine(_clipartPath, "Test1.jpg");
            File.WriteAllBytes(imagePath, sourceBytes);

            var firstSave = CreateWorkbookWithFilePicture(new FileInfo(imagePath));
            var firstMedia = GetSingleMediaBytes(firstSave);

            CollectionAssert.AreEqual(sourceBytes, firstMedia);

            using (var pck = new ExcelPackage(new MemoryStream(firstSave), TempFolderHelper.Create()))
            {
                var secondSave = SavePackageToBytes(pck);
                var secondMedia = GetSingleMediaBytes(secondSave);

                CollectionAssert.AreEqual(firstMedia, secondMedia);
            }
        }

        [TestMethod]
        public void CopyWorksheetWithPicturePreservesSharedMediaBytes()
        {
            var sourceBytes = GetEmbeddedResourceBytes("EPPlusTest.Resources.Test1.jpg");
            var imagePath = Path.Combine(_clipartPath, "Test1.jpg");
            File.WriteAllBytes(imagePath, sourceBytes);

            byte[] saveAfterCopy;
            using (var pck = new ExcelPackage(TempFolderHelper.Create()))
            {
                var ws = pck.Workbook.Worksheets.Add("original");
                ws.Drawings.AddPicture("Pic1", new FileInfo(imagePath));
                pck.Workbook.Worksheets.Copy("original", "copy");
                saveAfterCopy = SavePackageToBytes(pck);
            }

            var copiedMedia = GetMediaEntries(saveAfterCopy);
            Assert.AreEqual(1, copiedMedia.Count);
            CollectionAssert.AreEqual(sourceBytes, copiedMedia.Values.Single());

            using (var pck = new ExcelPackage(new MemoryStream(saveAfterCopy), TempFolderHelper.Create()))
            {
                var original = pck.Workbook.Worksheets["original"];
                pck.Workbook.Worksheets.Delete(original);
                var afterDelete = SavePackageToBytes(pck);
                var mediaAfterDelete = GetMediaEntries(afterDelete);

                Assert.AreEqual(1, mediaAfterDelete.Count);
                CollectionAssert.AreEqual(sourceBytes, mediaAfterDelete.Values.Single());
            }
        }

        [TestMethod]
        public void BackgroundImageSetFromFilePreservesBytesWithoutDecoding()
        {
            var sourcePath = Path.Combine(_clipartPath, "Vector Drawing.wmf");
            var sourceBytes = File.ReadAllBytes(sourcePath);

            using (var pck = new ExcelPackage(TempFolderHelper.Create()))
            {
                var ws = pck.Workbook.Worksheets.Add("background");
                ws.BackgroundImage.SetFromFile(new FileInfo(sourcePath));
                CollectionAssert.AreEqual(sourceBytes, ws.BackgroundImage.ImageBytes);
                var saved = SavePackageToBytes(pck);
                var mediaEntries = GetMediaEntries(saved);

                Assert.AreEqual(1, mediaEntries.Count);
                CollectionAssert.AreEqual(sourceBytes, mediaEntries.Values.Single());
            }
        }

        [TestMethod]
        public void BackgroundImageDeleteReleasesSharedMedia()
        {
            var sourcePath = Path.Combine(_clipartPath, "Test1.jpg");
            var sourceBytes = File.ReadAllBytes(sourcePath);

            using (var pck = new ExcelPackage(TempFolderHelper.Create()))
            {
                var ws = pck.Workbook.Worksheets.Add("background");
                ws.BackgroundImage.SetFromFile(new FileInfo(sourcePath));

                var withBackground = SavePackageToBytes(pck);
                var mediaEntries = GetMediaEntries(withBackground);

                Assert.AreEqual(1, mediaEntries.Count);
                CollectionAssert.AreEqual(sourceBytes, mediaEntries.Values.Single());

                ws.BackgroundImage.SetImage(null);
                var withoutBackground = SavePackageToBytes(pck);
                var mediaAfterDelete = GetMediaEntries(withoutBackground);

                Assert.AreEqual(0, mediaAfterDelete.Count);
            }
        }

        private static byte[] SavePackageToBytes(ExcelPackage pck)
        {
            using (var ms = new MemoryStream())
            {
                pck.SaveAs(ms);
                return ms.ToArray();
            }
        }

        private static byte[] CreateWorkbookWithFilePicture(FileInfo imageFile)
        {
            using (var pck = new ExcelPackage(TempFolderHelper.Create()))
            {
                var ws = pck.Workbook.Worksheets.Add("sheet1");
                ws.Drawings.AddPicture("Pic1", imageFile);
                return SavePackageToBytes(pck);
            }
        }

        private static Dictionary<string, byte[]> GetMediaEntries(byte[] workbookBytes)
        {
            var result = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase);
            using (var ms = new MemoryStream(workbookBytes))
            using (var zip = new ZipArchive(ms, ZipArchiveMode.Read, leaveOpen: false))
            {
                foreach (var entry in zip.Entries.Where(e => e.FullName.StartsWith("xl/media/", StringComparison.OrdinalIgnoreCase)))
                {
                    using (var entryStream = entry.Open())
                    using (var entryBytes = new MemoryStream())
                    {
                        entryStream.CopyTo(entryBytes);
                        result.Add(entry.FullName, entryBytes.ToArray());
                    }
                }
            }

            return result;
        }

        private static byte[] GetSingleMediaBytes(byte[] workbookBytes)
        {
            var mediaEntries = GetMediaEntries(workbookBytes);
            Assert.AreEqual(1, mediaEntries.Count);
            return mediaEntries.Values.Single();
        }

    }
}
