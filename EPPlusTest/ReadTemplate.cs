using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Style;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.ConditionalFormatting;
using System.Threading;
namespace EPPlusTest
{
    [TestClass]
    public class ReadTemplate //: TestBase
    {
        //[ClassInitialize()]
        //public static void ClassInit(TestContext testContext)
        //{
        //    //InitBase();
        //}
        //[ClassCleanup()]
        //public static void ClassCleanup()
        //{
        //    //SaveWorksheet("Worksheet.xlsx");
        //}
        [TestMethod]
        public void ReadBlankStream()
        {
            MemoryStream stream = new MemoryStream();
            using (ExcelPackage pck = new ExcelPackage(stream, EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = pck.Workbook.Worksheets.Add("Perf");
                pck.SaveAs(stream);
            }
            stream.Close();
        }
        [TestMethod]
        public void test()
        { 
            CreateXlsxSheet(@"C:\temp\bug\test4.xlsx", 4, 4);
            CreateXlsxSheet(@"C:\temp\bug\test25.xlsx", 25, 25); 
        }
        [TestMethod]
        public void VBAerror()
        {
            ExcelWorksheet ws;
            using (var p = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                p.Workbook.CreateVBAProject();
                ws = p.Workbook.Worksheets.Add("Градуировка");                
                using (var p2 = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
                {
                    p2.Workbook.CreateVBAProject();
                    var ws2 = p2.Workbook.Worksheets.Add("Градуировка2", ws);
                }
            }
        }

        public static byte[] ReadTemplateFile(string templateName)
        {
            byte[] templateFIle;
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                using (var sw = new System.IO.FileStream(templateName, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite))
                {
                    byte[] buffer = new byte[2048];
                    int bytesRead;
                    while ((bytesRead = sw.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, bytesRead);
                    }
                }
                ms.Position = 0;
                templateFIle = ms.ToArray();
            }
            return templateFIle;
        }

        private static void CreateXlsxSheet(string pFileName, int pRows, int pColumns) 
        {
            if (File.Exists(pFileName)) File.Delete(pFileName);

            using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(pFileName), EPPlusTest.TempFolderHelper.Create()))
            {
                ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add("Testsheet");

                // Fill with data
                for (int row = 1; row <= pRows; row++)
                {
                    for (int column = 1; column <= pColumns; column++)
                    {
                        if (column > 1 && row > 2)
                        {
                            using (ExcelRange range = excelWorksheet.Cells[row, column])
                            {
                                range.Style.Numberformat.Format = "0";
                                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            }
                            excelWorksheet.Cells[row, column].Value = row * column;
                        }
                    }
                }

                // Try to style the first column, begining with row 3 which has no content yet...
                using (ExcelRange range = excelWorksheet.Cells[ExcelCellBase.GetAddress(3, 1, pRows, 1)])
                {
                    ExcelStyle style = range.Style;
                }

                // now I would add data to the first column (left out here)...
                excelPackage.Save();
            } 
        }    
    }
}
