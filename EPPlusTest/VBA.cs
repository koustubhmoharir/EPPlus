using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml.Utils;
using OfficeOpenXml;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Security.Cryptography;
using OfficeOpenXml.VBA;

namespace EPPlusTest
{
    [TestClass]
    public class VBA
    {
        [TestMethod]
        public void Compression()
        {
            //Compression/Decompression
            string value = "#aaabcdefaaaaghijaaaaaklaaamnopqaaaaaaaaaaaarstuvwxyzaaa";

            byte[] compValue = VBACompression.CompressPart(Encoding.GetEncoding(1252).GetBytes(value));
            string decompValue = Encoding.GetEncoding(1252).GetString(VBACompression.DecompressPart(compValue));
            Assert.AreEqual(value, decompValue);

            value = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            compValue = VBACompression.CompressPart(Encoding.GetEncoding(1252).GetBytes(value));
            decompValue = Encoding.GetEncoding(1252).GetString(VBACompression.DecompressPart(compValue));
            Assert.AreEqual(value, decompValue);
        }
        [TestMethod]
        public void WriteLongVBAModule()
        {
            var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create());
            package.Workbook.Worksheets.Add("VBASetData");
            package.Workbook.CreateVBAProject();
            package.Workbook.CodeModule.Code = "Private Sub Workbook_Open()\r\nCreateData\r\nEnd Sub";
            var module = package.Workbook.VbaProject.Modules.AddModule("Code");

            StringBuilder code = new StringBuilder("Public Sub CreateData()\r\n");
            for (int row = 1; row < 30; row++)
            {
                for (int col = 1; col < 30; col++)
                {
                    code.AppendLine(string.Format("VBASetData.Cells({0},{1}).Value=\"Cell {2}\"", row, col, new ExcelAddressBase(row, col, row, col).Address));
                }
            }
            code.AppendLine("End Sub");
            module.Code = code.ToString();

            //X509Store store = new X509Store(StoreLocation.CurrentUser);
            //store.Open(OpenFlags.ReadOnly);
            //package.Workbook.VbaProject.Signature.Certificate = store.Certificates[19];

            package.SaveAs(new FileInfo(@"c:\temp\vbaLong.xlsm"));
        }
        [TestMethod]
        public void CreateUnicodeWsName()
        {
            using (var package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                //ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Test");
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("测试");

                package.Workbook.CreateVBAProject();
                var sb = new StringBuilder();
                sb.AppendLine("Sub GetData()");
                sb.AppendLine("MsgBox (\"Hello,World\")");
                sb.AppendLine("End Sub");

                ExcelWorksheet worksheet2 = package.Workbook.Worksheets.Add("Sheet1");
                var stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("Private Sub Worksheet_Change(ByVal Target As Range)");
                stringBuilder.AppendLine("GetData");
                stringBuilder.AppendLine("End Sub");
                worksheet.CodeModule.Code = stringBuilder.ToString();

                package.SaveAs(new FileInfo(@"c:\temp\invvba.xlsm"));
            }
        }
        //Issue with chunk overwriting 4096 bytes
        [TestMethod]
        public void DecompressionChunkGreaterThan4k()
        {
            // This is a test for Issue 15026: VBA decompression encounters index out of range
            // on the decompression buffer.
            var workbookDir = Path.Combine(TestBase.GetBaseDirectory(), @"..\..\workbooks");
            var path = Path.Combine(workbookDir, "VBADecompressBug.xlsm");
            var f = new FileInfo(path);
            if (f.Exists)
            {
                using (var package = new ExcelPackage(f, EPPlusTest.TempFolderHelper.Create()))
                {
                    // Reading the Workbook.CodeModule.Code will cause an IndexOutOfRange if the problem hasn't been fixed.
                    Assert.IsTrue(package.Workbook.CodeModule.Code.Length > 0);
                }
            }
        }
    }
}
