using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;

namespace EPPlusTest
{
    [TestClass]
    public class ExcelRangeBaseTest : TestBase
    {
        [TestMethod]
        public void CopyCopiesCommentsFromSingleCellRanges()
        {
            InitBase();
            var pck = new ExcelPackage(EPPlusTest.TempFolderHelper.Create());
            var ws1 = pck.Workbook.Worksheets.Add("CommentCopying");
            var sourceExcelRange = ws1.Cells[3, 3];
            Assert.IsNull(sourceExcelRange.Comment);
            sourceExcelRange.AddComment("Testing comment 1", "test1");
            Assert.AreEqual("test1", sourceExcelRange.Comment.Author);
            Assert.AreEqual("Testing comment 1", sourceExcelRange.Comment.Text);
            var destinationExcelRange = ws1.Cells[5, 5];
            Assert.IsNull(destinationExcelRange.Comment);
            sourceExcelRange.Copy(destinationExcelRange);
            // Assert the original comment is intact.
            Assert.AreEqual("test1", sourceExcelRange.Comment.Author);
            Assert.AreEqual("Testing comment 1", sourceExcelRange.Comment.Text);
            // Assert the comment was copied.
            Assert.AreEqual("test1", destinationExcelRange.Comment.Author);
            Assert.AreEqual("Testing comment 1", destinationExcelRange.Comment.Text);
        }

        [TestMethod]
        public void CopyCopiesCommentsFromMultiCellRanges()
        {
            InitBase();
            var pck = new ExcelPackage(EPPlusTest.TempFolderHelper.Create());
            var ws1 = pck.Workbook.Worksheets.Add("CommentCopying");
            var sourceExcelRangeC3 = ws1.Cells[3, 3];
            var sourceExcelRangeD3 = ws1.Cells[3, 4];
            var sourceExcelRangeE3 = ws1.Cells[3, 5];
            Assert.IsNull(sourceExcelRangeC3.Comment);
            Assert.IsNull(sourceExcelRangeD3.Comment);
            Assert.IsNull(sourceExcelRangeE3.Comment);
            sourceExcelRangeC3.AddComment("Testing comment 1", "test1");
            sourceExcelRangeD3.AddComment("Testing comment 2", "test1");
            sourceExcelRangeE3.AddComment("Testing comment 3", "test1");
            Assert.AreEqual("test1", sourceExcelRangeC3.Comment.Author);
            Assert.AreEqual("Testing comment 1", sourceExcelRangeC3.Comment.Text);
            Assert.AreEqual("test1", sourceExcelRangeD3.Comment.Author);
            Assert.AreEqual("Testing comment 2", sourceExcelRangeD3.Comment.Text);
            Assert.AreEqual("test1", sourceExcelRangeE3.Comment.Author);
            Assert.AreEqual("Testing comment 3", sourceExcelRangeE3.Comment.Text);
            // Copy the full row to capture each cell at once.
            Assert.IsNull(ws1.Cells[5, 3].Comment);
            Assert.IsNull(ws1.Cells[5, 4].Comment);
            Assert.IsNull(ws1.Cells[5, 5].Comment);
            ws1.Cells["3:3"].Copy(ws1.Cells["5:5"]);
            // Assert the original comments are intact.
            Assert.AreEqual("test1", sourceExcelRangeC3.Comment.Author);
            Assert.AreEqual("Testing comment 1", sourceExcelRangeC3.Comment.Text);
            Assert.AreEqual("test1", sourceExcelRangeD3.Comment.Author);
            Assert.AreEqual("Testing comment 2", sourceExcelRangeD3.Comment.Text);
            Assert.AreEqual("test1", sourceExcelRangeE3.Comment.Author);
            Assert.AreEqual("Testing comment 3", sourceExcelRangeE3.Comment.Text);
            // Assert the comments were copied.
            var destinationExcelRangeC5 = ws1.Cells[5, 3];
            var destinationExcelRangeD5 = ws1.Cells[5, 4];
            var destinationExcelRangeE5 = ws1.Cells[5, 5];
            Assert.AreEqual("test1", destinationExcelRangeC5.Comment.Author);
            Assert.AreEqual("Testing comment 1", destinationExcelRangeC5.Comment.Text);
            Assert.AreEqual("test1", destinationExcelRangeD5.Comment.Author);
            Assert.AreEqual("Testing comment 2", destinationExcelRangeD5.Comment.Text);
            Assert.AreEqual("test1", destinationExcelRangeE5.Comment.Author);
            Assert.AreEqual("Testing comment 3", destinationExcelRangeE5.Comment.Text);
        }

        [TestMethod]
        public void SettingAddressHandlesMultiAddresses()
        {
            using (ExcelPackage package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");
                var name = package.Workbook.Names.Add("Test", worksheet.Cells[3, 3]);
                name.Address = "Sheet1!C3";
                name.Address = "Sheet1!D3";
                Assert.IsNull(name.Addresses);
                name.Address = "C3:D3,E3:F3";
                Assert.IsNotNull(name.Addresses);
                name.Address = "Sheet1!C3";
                Assert.IsNull(name.Addresses);
            }
        }

        [TestMethod]
        public void ExcelNamedRangeLocalSheetIdTests()
        {
            using (ExcelPackage package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var sheet1 = package.Workbook.Worksheets.Add("Sheet1");
                var sheet2 = package.Workbook.Worksheets.Add("Sheet2");

                // 1. Global named range (workbook scope)
                var globalName = package.Workbook.Names.Add("GlobalRange", sheet1.Cells["A1:B2"]);
                Assert.AreEqual(-1, globalName.LocalSheetId);

                // 2. Local named range (worksheet scope) on first worksheet
                var localName1 = sheet1.Names.Add("LocalRange1", sheet1.Cells["A1:B2"]);
                Assert.AreEqual(0, localName1.LocalSheetId);

                // 3. Local named range (worksheet scope) on second worksheet
                var localName2 = sheet2.Names.Add("LocalRange2", sheet2.Cells["A1:B2"]);
                Assert.AreEqual(1, localName2.LocalSheetId);
            }
        }

        [TestMethod]
        public void GetValueTypedConversions()
        {
            using (ExcelPackage package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                
                // Int
                ws.Cells["A1"].Value = 42;
                Assert.AreEqual(42, ws.Cells["A1"].GetValue<int>());
                Assert.AreEqual(42L, ws.Cells["A1"].GetValue<long>());
                Assert.AreEqual(42.0, ws.Cells["A1"].GetValue<double>());
                
                // String to double/int
                ws.Cells["A2"].Value = "123.45";
#if Core
                Assert.AreEqual(123.45, ws.Cells["A2"].GetValue<double>());
#else
                Assert.AreEqual(0.0, ws.Cells["A2"].GetValue<double>());
#endif
                
                // DateTime
                var date = new DateTime(2023, 10, 1);
                ws.Cells["A3"].Value = date;
                Assert.AreEqual(date, ws.Cells["A3"].GetValue<DateTime>());
                
                // TimeSpan
                var ts = new TimeSpan(1, 2, 3);
                ws.Cells["A4"].Value = ts;
                Assert.AreEqual(ts, ws.Cells["A4"].GetValue<TimeSpan>());
                
                // Nullable conversions
                ws.Cells["A5"].Value = "";
                Assert.IsNull(ws.Cells["A5"].GetValue<int?>());
                
                ws.Cells["A6"].Value = 99;
                Assert.AreEqual(99, ws.Cells["A6"].GetValue<int?>());
            }
        }

        [TestMethod]
        public void LoadFromTextComprehensiveTests()
        {
            using (ExcelPackage package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                
                // Basic CSV loading
                var csv = "1,Hello,10.5\r\n2,World,20.5";
                var range = ws.Cells["A1"].LoadFromText(csv);
#if Core
                Assert.AreEqual(2, range.Rows);
#else
                Assert.AreEqual(3, range.Rows);
#endif
                Assert.AreEqual(3, range.Columns);
                Assert.AreEqual(1.0, ws.Cells["A1"].Value);
                Assert.AreEqual("Hello", ws.Cells["B1"].Value);
                Assert.AreEqual(10.5, ws.Cells["C1"].Value);
                Assert.AreEqual(2.0, ws.Cells["A2"].Value);
                Assert.AreEqual("World", ws.Cells["B2"].Value);
                Assert.AreEqual(20.5, ws.Cells["C2"].Value);
                
                // Custom delimiter and text qualifiers
                var csvQualifier = "\"1\";\"Hello, World\";\"30.5\"\r\n\"2\";\"Test\";\"40.5\"";
                var format = new ExcelTextFormat { Delimiter = ';', TextQualifier = '"' };
                var rangeQ = ws.Cells["A4"].LoadFromText(csvQualifier, format);

#if Core
                Assert.AreEqual(2, rangeQ.Rows);
#else
                Assert.AreEqual(3, rangeQ.Rows);
#endif
                Assert.AreEqual(3, rangeQ.Columns);
                Assert.AreEqual("1", ws.Cells["A4"].Value);
                Assert.AreEqual("Hello, World", ws.Cells["B4"].Value);
                Assert.AreEqual("30.5", ws.Cells["C4"].Value);
                Assert.AreEqual("2", ws.Cells["A5"].Value);
                Assert.AreEqual("Test", ws.Cells["B5"].Value);
                Assert.AreEqual("40.5", ws.Cells["C5"].Value);
            }
        }

        [TestMethod]
        public void ClearAndDeleteTests()
        {
            using (ExcelPackage package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                ws.Cells["A1"].Value = "Val1";
                ws.Cells["B1"].Value = "Val2";
                
                Assert.AreEqual("Val1", ws.Cells["A1"].Value);
                Assert.AreEqual("Val2", ws.Cells["B1"].Value);
                
                ws.Cells["A1:B1"].Clear();
                Assert.IsNull(ws.Cells["A1"].Value);
                Assert.IsNull(ws.Cells["B1"].Value);
            }
        }

        [TestMethod]
        public void GetDateTextFormattingTests()
        {
            using (ExcelPackage package = new ExcelPackage(EPPlusTest.TempFolderHelper.Create()))
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                var date = new DateTime(2023, 10, 5, 12, 30, 45);
                ws.Cells["B1"].Value = date;

#if Core
                ws.Cells["B1"].Style.Numberformat.Format = "d";
                Assert.AreEqual("5", ws.Cells["B1"].Text);

                ws.Cells["B1"].Style.Numberformat.Format = "M";
                Assert.AreEqual("10", ws.Cells["B1"].Text);

                ws.Cells["B1"].Style.Numberformat.Format = "m";
                Assert.AreEqual("10", ws.Cells["B1"].Text);

                ws.Cells["B1"].Style.Numberformat.Format = "yyyy";
                Assert.AreEqual("2023", ws.Cells["B1"].Text);
#else
                // In stable, standard ToString (or default translation) applies
                ws.Cells["B1"].Style.Numberformat.Format = "yyyy-MM-dd";
                Assert.AreEqual("2023-10-05", ws.Cells["B1"].Text);
#endif
            }
        }
    }
}
