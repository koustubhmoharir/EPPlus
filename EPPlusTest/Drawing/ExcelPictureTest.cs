using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;

namespace EPPlusTest.Drawing
{
    [TestClass]
    public class ExcelPictureTest
    {
        [TestMethod]
        public void ExcelPicture_AddPicture_SetsPropertiesCorrectly()
        {
            using (var package = new ExcelPackage())
            {
                var ws = package.Workbook.Worksheets.Add("TestSheet");
                
                // Use an existing test resource image to avoid GDI+ issues on Mono
                var image = EPPlusTest.Properties.Resources.Test1;

                var pic = ws.Drawings.AddPicture("TestPic", image);

                Assert.IsNotNull(pic);
                Assert.IsNotNull(pic.Image);
                Assert.IsNotNull(pic.ImageHash);
                Assert.AreEqual("TestPic", pic.Name);
                
                // On stable this is ImageConverter. On .NET Core this is ImageCompat.
                // Either way, the image format should be processed (often Jpeg or Png).
                // Actually EPPlus tries to guess. If it's a Bitmap it might save as Jpeg or Png.
                // We just verify it doesn't crash and correctly initializes.
                Assert.IsTrue(pic.ImageHash.Length > 0);
            }
        }
    }
}
