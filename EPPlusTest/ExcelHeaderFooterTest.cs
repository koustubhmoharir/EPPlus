using System;
using System.IO;
using System.Drawing;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Vml;

namespace EPPlusTest
{
    [TestClass]
    public class ExcelHeaderFooterTest
    {
        [TestMethod]
        public void TestHeaderFooterProperties()
        {
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                var hf = ws.HeaderFooter;

                // Test AlignWithMargins
                Assert.IsFalse(hf.AlignWithMargins);
                hf.AlignWithMargins = true;
                Assert.IsTrue(hf.AlignWithMargins);
                hf.AlignWithMargins = false;
                Assert.IsFalse(hf.AlignWithMargins);

                // Test differentOddEven
                Assert.IsFalse(hf.differentOddEven);
                hf.differentOddEven = true;
                Assert.IsTrue(hf.differentOddEven);
                hf.differentOddEven = false;
                Assert.IsFalse(hf.differentOddEven);

                // Test differentFirst
                Assert.IsFalse(hf.differentFirst);
                hf.differentFirst = true;
                Assert.IsTrue(hf.differentFirst);
                hf.differentFirst = false;
                Assert.IsFalse(hf.differentFirst);

                // Test ScaleWithDocument (reflection support for dotnetport vs stable parity)
                var scaleProp = typeof(ExcelHeaderFooter).GetProperty("ScaleWithDocument");
                if (scaleProp != null)
                {
                    bool defaultVal = (bool)scaleProp.GetValue(hf, null);
                    Assert.IsFalse(defaultVal); // In EPPlus, GetXmlNodeBool default should be false if attribute is missing
                    
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

                // Set text formatting
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
        public void TestHeaderFooterInsertPictureImage()
        {
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                var hf = ws.HeaderFooter;

                // Set some initial text
                hf.OddHeader.CenteredText = "Centred text ";
                
                Image img = Properties.Resources.Test1;
                var pic = hf.OddHeader.InsertPicture(img, PictureAlignment.Centered);

                Assert.IsNotNull(pic);
                Assert.AreEqual("CH", pic.Id);
                Assert.IsTrue(hf.OddHeader.CenteredText.EndsWith(ExcelHeaderFooter.Image));
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
                Image img = Properties.Resources.Test1;
                img.Save(tempImagePath, System.Drawing.Imaging.ImageFormat.Jpeg);

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
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestHeaderFooterInsertDuplicatePictureThrows()
        {
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                var hf = ws.HeaderFooter;

                Image img = Properties.Resources.Test1;
                hf.OddHeader.InsertPicture(img, PictureAlignment.Right);
                
                // Inserting another picture at the same alignment should throw InvalidOperationException
                hf.OddHeader.InsertPicture(img, PictureAlignment.Right);
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
                // Property not present (stable branch), skip this test
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

                // Set back to false and verify persistence
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
    }
}
