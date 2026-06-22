using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;

namespace EPPlusE2ETest
{
    [TestClass]
    public class RowsColumnsAndOutline : TestsBase
    {
        static string template = "RowsColumnsAndOutline.xlsx";

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            SaveTemplate(template, package =>
            {
                var sheet = package.Workbook.Worksheets.Add("OutlineTest");
                sheet.Cells["A1"].Value = "Outline Data";

                // Setup sheet for FooterRowsCopyAndDelete
                var wsRows = package.Workbook.Worksheets.Add("FooterRows");
                // Footer rows at top (Rows 1-2)
                wsRows.Cells["A1:B1"].Merge = true;
                wsRows.Cells["A1"].Value = "Subtotal";
                wsRows.Row(1).Height = 25;

                wsRows.Cells["A2:B2"].Merge = true;
                wsRows.Cells["A2"].Value = "Grand Total";
                wsRows.Cells["C2"].Formula = "=SUM(C$3:C$5)";
                wsRows.Row(2).Height = 30;

                // Data rows (Rows 3-5)
                wsRows.Cells["C3"].Value = 10.0;
                wsRows.Cells["C4"].Value = 20.0;
                wsRows.Cells["C5"].Value = 30.0;

                // Setup sheet for FooterColumnsCopyAndDelete
                var wsCols = package.Workbook.Worksheets.Add("FooterCols");
                // Footer columns at left (Cols 1-2)
                wsCols.Cells["A1:A2"].Merge = true;
                wsCols.Cells["A1"].Value = "Subtotal";
                wsCols.Column(1).Width = 15;

                wsCols.Cells["B1:B2"].Merge = true;
                wsCols.Cells["B1"].Value = "Grand Total";
                wsCols.Cells["B3"].Formula = "=SUM($C3:$E3)";
                wsCols.Column(2).Width = 20;

                // Data columns (Cols 3-5)
                wsCols.Cells["C3"].Value = 100.0;
                wsCols.Cells["D3"].Value = 200.0;
                wsCols.Cells["E3"].Value = 300.0;
            });
        }

        [TestMethod]
        public void OutlineLevels()
        {
            Test(template, null, "RowsColumnsAndOutline.OutlineLevels.xlsx", null, package =>
            {
                var sheet = package.Workbook.Worksheets["OutlineTest"];
                
                // Set outline levels (SheetKraft sets level as input level - 1)
                sheet.Row(2).OutlineLevel = 1;
                sheet.Row(3).OutlineLevel = 2;
                
                sheet.Column(2).OutlineLevel = 1;
                sheet.Column(3).OutlineLevel = 3;
            }, package =>
            {
                var sheet = package.Workbook.Worksheets["OutlineTest"];
                Assert.AreEqual(1, sheet.Row(2).OutlineLevel);
                Assert.AreEqual(2, sheet.Row(3).OutlineLevel);
                Assert.AreEqual(1, sheet.Column(2).OutlineLevel);
                Assert.AreEqual(3, sheet.Column(3).OutlineLevel);
            });
        }

        [TestMethod]
        public void FooterRowsCopyAndDelete()
        {
            Test(template, null, "RowsColumnsAndOutline.FooterRowsCopyAndDelete.xlsx", null, package =>
            {
                var sheet = package.Workbook.Worksheets["FooterRows"];
                
                // 1. Copy footer rows 1-2 from top to bottom (rows 6-7)
                sheet.Cells["A1:C2"].Copy(sheet.Cells["A6:C7"]);
                sheet.Row(6).Height = sheet.Row(1).Height;
                sheet.Row(7).Height = sheet.Row(2).Height;
                
                // 2. Delete the original footer rows 1-2 from top
                sheet.DeleteRow(1, 2);
            }, package =>
            {
                var sheet = package.Workbook.Worksheets["FooterRows"];

                // Data shifted to rows 1-3
                Assert.AreEqual(10.0, Convert.ToDouble(sheet.Cells["C1"].Value));
                Assert.AreEqual(20.0, Convert.ToDouble(sheet.Cells["C2"].Value));
                Assert.AreEqual(30.0, Convert.ToDouble(sheet.Cells["C3"].Value));

                // Footer shifted to rows 4-5
                Assert.AreEqual("Subtotal", sheet.Cells["A4"].Value);
                Assert.AreEqual("Grand Total", sheet.Cells["A5"].Value);

                // Merges should shift correctly to A4:B4 and A5:B5
                Assert.IsTrue(sheet.MergedCells.Contains("A4:B4"));
                Assert.IsTrue(sheet.MergedCells.Contains("A5:B5"));

                // Row heights should shift correctly
                Assert.AreEqual(25d, sheet.Row(4).Height);
                Assert.AreEqual(30d, sheet.Row(5).Height);

                // Formula in C5 should adjust to =SUM(C1:C3)
                Assert.AreEqual("=SUM(C$1:C$3)", sheet.Cells["C5"].Formula);
            });
        }

        [TestMethod]
        public void FooterColumnsCopyAndDelete()
        {
            Test(template, null, "RowsColumnsAndOutline.FooterColumnsCopyAndDelete.xlsx", null, package =>
            {
                var sheet = package.Workbook.Worksheets["FooterCols"];
                
                // 1. Copy footer columns 1-2 from left to right (columns 6-7)
                sheet.Cells[1, 1, 3, 2].Copy(sheet.Cells[1, 6, 3, 7]);
                sheet.Column(6).Width = sheet.Column(1).Width;
                sheet.Column(7).Width = sheet.Column(2).Width;
                
                // 2. Delete original footer columns 1-2 from left
                sheet.DeleteColumn(1, 2);
            }, package =>
            {
                var sheet = package.Workbook.Worksheets["FooterCols"];

                // Data shifted to columns 1-3 (C-E -> A-C)
                Assert.AreEqual(100.0, Convert.ToDouble(sheet.Cells["A3"].Value));
                Assert.AreEqual(200.0, Convert.ToDouble(sheet.Cells["B3"].Value));
                Assert.AreEqual(300.0, Convert.ToDouble(sheet.Cells["C3"].Value));

                // Footer shifted to columns 4-5 (F-G -> D-E)
                Assert.AreEqual("Subtotal", sheet.Cells["D1"].Value);
                Assert.AreEqual("Grand Total", sheet.Cells["E1"].Value);

                // Merges should shift correctly to D1:D2 and E1:E2 (representing D1:D2 and E1:E2)
                Assert.IsTrue(sheet.MergedCells.Contains("D1:D2"));
                Assert.IsTrue(sheet.MergedCells.Contains("E1:E2"));

                // Column widths should shift correctly
                Assert.AreEqual(15d, sheet.Column(4).Width, 0.1);
                Assert.AreEqual(20d, sheet.Column(5).Width, 0.1);

                // Formula in E3 should adjust to =SUM(A3:C3)
                Assert.AreEqual("=SUM($A3:$C3)", sheet.Cells["E3"].Formula);
            });
        }
    }
}
