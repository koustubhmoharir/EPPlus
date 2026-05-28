using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Vml;

namespace EPPlusTest
{
    [TestClass]
    public class ExcelHeaderFooterTest : TestBase
    {
        [TestMethod]
        public void TestHeaderFooterProperties()
        {
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                var hf = ws.HeaderFooter;

                Assert.IsFalse(hf.AlignWithMargins);
                hf.AlignWithMargins = true;
                Assert.IsTrue(hf.AlignWithMargins);
                hf.AlignWithMargins = false;
                Assert.IsFalse(hf.AlignWithMargins);

                Assert.IsFalse(hf.differentOddEven);
                hf.differentOddEven = true;
                Assert.IsTrue(hf.differentOddEven);
                hf.differentOddEven = false;
                Assert.IsFalse(hf.differentOddEven);

                Assert.IsFalse(hf.differentFirst);
                hf.differentFirst = true;
                Assert.IsTrue(hf.differentFirst);
                hf.differentFirst = false;
                Assert.IsFalse(hf.differentFirst);

                var scaleProp = typeof(ExcelHeaderFooter).GetProperty("ScaleWithDocument");
                if (scaleProp != null)
                {
                    bool defaultVal = (bool)scaleProp.GetValue(hf, null);
                    Assert.IsFalse(defaultVal);

                    scaleProp.SetValue(hf, true, null);
                    Assert.IsTrue((bool)scaleProp.GetValue(hf, null));

                    scaleProp.SetValue(hf, false, null);
                    Assert.IsFalse((bool)scaleProp.GetValue(hf, null));
                }
            }
        }

        [TestMethod]
        public void TestHeaderFooterTextFormatting()
        {
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                var hf = ws.HeaderFooter;

                hf.OddHeader.LeftAlignedText = "Left text";
                hf.OddHeader.CenteredText = "Centered text";
                hf.OddHeader.RightAlignedText = "Right text";

                hf.OddFooter.LeftAlignedText = "Left footer";
                hf.OddFooter.CenteredText = "Centered footer";
                hf.OddFooter.RightAlignedText = "Right footer";

                Assert.AreEqual("Left text", hf.OddHeader.LeftAlignedText);
                Assert.AreEqual("Centered text", hf.OddHeader.CenteredText);
                Assert.AreEqual("Right text", hf.OddHeader.RightAlignedText);

                Assert.AreEqual("Left footer", hf.OddFooter.LeftAlignedText);
                Assert.AreEqual("Centered footer", hf.OddFooter.CenteredText);
                Assert.AreEqual("Right footer", hf.OddFooter.RightAlignedText);

                package.Save();
            }
        }

        [TestMethod]
        public void TestHeaderFooterInsertPictureBytes()
        {
            var sourceBytes = GetEmbeddedResourceBytes("EPPlusTest.Resources.Test1.jpg");
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                var hf = ws.HeaderFooter;

                hf.OddHeader.CenteredText = "Centred text ";

                var pic = hf.OddHeader.InsertPicture(sourceBytes, "image/jpeg", PictureAlignment.Centered);

                Assert.IsNotNull(pic);
                Assert.AreEqual("CH", pic.Id);
                Assert.IsTrue(hf.OddHeader.CenteredText.EndsWith(ExcelHeaderFooter.Image));
                CollectionAssert.AreEqual(sourceBytes, pic.ImageBytes);
                Assert.AreEqual(1, hf.Pictures.Count);

                package.Save();
            }
        }

        [TestMethod]
        public void TestHeaderFooterInsertPictureFileInfo()
        {
            string tempImagePath = Path.Combine(Path.GetTempPath(), "test_header_footer_image.jpg");
            try
            {
                File.WriteAllBytes(tempImagePath, GetEmbeddedResourceBytes("EPPlusTest.Resources.Test1.jpg"));

                using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
                {
                    var ws = package.Workbook.Worksheets.Add("Sheet1");
                    var hf = ws.HeaderFooter;

                    hf.OddHeader.LeftAlignedText = "Left text ";
                    var fileInfo = new FileInfo(tempImagePath);
                    var pic = hf.OddHeader.InsertPicture(fileInfo, PictureAlignment.Left);

                    Assert.IsNotNull(pic);
                    Assert.AreEqual("LH", pic.Id);
                    Assert.IsTrue(hf.OddHeader.LeftAlignedText.EndsWith(ExcelHeaderFooter.Image));
                    Assert.AreEqual(1, hf.Pictures.Count);

                    package.Save();
                }
            }
            finally
            {
                if (File.Exists(tempImagePath))
                {
                    File.Delete(tempImagePath);
                }
            }
        }

        [TestMethod]
        public void TestHeaderFooterInsertPictureStream()
        {
            var sourceBytes = GetEmbeddedResourceBytes("EPPlusTest.Resources.Test1.jpg");
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                var hf = ws.HeaderFooter;

                using (var stream = new MemoryStream(sourceBytes))
                {
                    var pic = hf.OddHeader.InsertPicture(stream, "image/jpeg", PictureAlignment.Right);

                    Assert.IsNotNull(pic);
                    Assert.AreEqual("RH", pic.Id);
                    CollectionAssert.AreEqual(sourceBytes, pic.ImageBytes);
                    Assert.AreEqual(1, hf.Pictures.Count);
                }

                package.Save();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestHeaderFooterInsertDuplicatePictureThrows()
        {
            var tempImagePath = CreateTempImageFile();
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                try
                {
                    var ws = package.Workbook.Worksheets.Add("Sheet1");
                    var hf = ws.HeaderFooter;

                    hf.OddHeader.InsertPicture(new FileInfo(tempImagePath), PictureAlignment.Right);

                    hf.OddHeader.InsertPicture(new FileInfo(tempImagePath), PictureAlignment.Right);
                }
                finally
                {
                    if (File.Exists(tempImagePath))
                    {
                        File.Delete(tempImagePath);
                    }
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void TestHeaderFooterInsertMissingFileInfoThrows()
        {
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                var hf = ws.HeaderFooter;

                var missingFile = new FileInfo(Path.Combine(Path.GetTempPath(), "non_existent_image_file_12345.png"));
                hf.OddHeader.InsertPicture(missingFile, PictureAlignment.Centered);
            }
        }

        [TestMethod]
        public void TestScaleWithDocumentPersistence()
        {
            var scaleProp = typeof(ExcelHeaderFooter).GetProperty("ScaleWithDocument");
            if (scaleProp == null)
            {
                return;
            }

            byte[] bin;
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                var hf = ws.HeaderFooter;

                scaleProp.SetValue(hf, true, null);

                using (var ms = new MemoryStream())
                {
                    package.SaveAs(ms);
                    bin = ms.ToArray();
                }
            }

            using (var ms = new MemoryStream(bin))
            using (var package = new ExcelPackage(ms, EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = package.Workbook.Worksheets["Sheet1"];
                var hf = ws.HeaderFooter;

                bool scaleVal = (bool)scaleProp.GetValue(hf, null);
                Assert.IsTrue(scaleVal);

                scaleProp.SetValue(hf, false, null);

                using (var ms2 = new MemoryStream())
                {
                    package.SaveAs(ms2);
                    bin = ms2.ToArray();
                }
            }

            using (var ms = new MemoryStream(bin))
            using (var package = new ExcelPackage(ms, EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = package.Workbook.Worksheets["Sheet1"];
                var hf = ws.HeaderFooter;

                bool scaleVal = (bool)scaleProp.GetValue(hf, null);
                Assert.IsFalse(scaleVal);
            }
        }

        private static string CreateTempImageFile()
        {
            var tempImagePath = Path.Combine(Path.GetTempPath(), "test_header_footer_image_" + Guid.NewGuid().ToString("N") + ".jpg");
            File.WriteAllBytes(tempImagePath, GetEmbeddedResourceBytes("EPPlusTest.Resources.Test1.jpg"));
            return tempImagePath;
        }

    }
}
