using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EPPlusTest
{
    [TestClass]
    public class DTS_FailingTests : TestBase
    {

        [Ignore] // Hangs during AddPicture call on Mono. Likely an issue with libgdiplus or resource loading in Mono.
        [TestMethod]
        public void DeleteWorksheetWithReferencedImage()
        {
            var ms = new MemoryStream();
            using (var pck = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = pck.Workbook.Worksheets.Add("original");
                ws.Drawings.AddPicture("Pic1", GetEmbeddedResourceBytes("EPPlusTest.Resources.Test1.jpg"));
                pck.Workbook.Worksheets.Copy("original", "copy");
                pck.SaveAs(ms);
            }
            ms.Position = 0;

            using (var pck = new ExcelPackage(ms, EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = pck.Workbook.Worksheets["original"];
                pck.Workbook.Worksheets.Delete(ws);
                pck.Save();
            }
        }

        [Ignore] // Hangs during AddPicture call on Mono. Likely an issue with libgdiplus or resource loading in Mono.
        [TestMethod]
        public void CopyAndDeleteWorksheetWithImage()
        {
            using (var pck = new ExcelPackage(new MemoryStream(), EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = pck.Workbook.Worksheets.Add("original");
                ws.Drawings.AddPicture("Pic1", GetEmbeddedResourceBytes("EPPlusTest.Resources.Test1.jpg"));
                pck.Workbook.Worksheets.Copy("original", "copy");
                pck.Workbook.Worksheets.Delete(ws);
                pck.Save();
            }
        }

    }
}
