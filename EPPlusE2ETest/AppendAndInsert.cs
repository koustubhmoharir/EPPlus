using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;

namespace EPPlusE2ETest
{
    [TestClass]
    public class AppendAndInsert : TestsBase
    {
        static string template = "AppendAndInsert.xlsx";

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            SaveTemplate(template, package =>
            {
                var sheet = package.Workbook.Worksheets.Add("Insert");
                sheet.Cells["A1"].Formula = "B2";
                sheet.Cells["B2"].Value = 1;
                sheet.Cells["C3:D3"].Merge = true;
                sheet.Names.Add("LocalRange", sheet.Cells["B2:C3"]);

                var shape = sheet.Drawings.AddShape("Shape1", eShapeStyle.Rect);
                shape.EditAs = eEditAs.TwoCell;
                shape.SetPosition(4, 0, 4, 0);

                var absShape = sheet.Drawings.AddShape("ShapeAbs", eShapeStyle.Rect);
                absShape.EditAs = eEditAs.Absolute;
                absShape.SetPosition(4, 0, 4, 0);

                var data = package.Workbook.Worksheets.Add("Data");
                data.Cells["A1"].Value = "Id";
                data.Cells["A2"].Value = 1;
                data.Cells["A3"].Value = 2;
                data.Cells["A4"].Value = 3;
            });
        }

        [TestMethod]
        public void AppendAndInsertRowsColumns()
        {
            Test(template, null, "AppendAndInsert.AppendAndInsertRowsColumns.xlsx", null, package =>
            {
                var sheet = package.Workbook.Worksheets["Insert"];
                sheet.InsertRow(2, 2);
                sheet.InsertColumn(2, 2);
            }, package =>
            {
                var sheet = package.Workbook.Worksheets["Insert"];

                // Assert formula shifted: A1 references B2 -> shifted by 2 rows/cols -> D4
                Assert.AreEqual("D4", sheet.Cells["A1"].Formula);

                // Assert merge shifted: C3:D3 -> shifted by 2 rows/cols -> E5:F5
                Assert.IsTrue(sheet.MergedCells.Contains("E5:F5"));

                // Assert named range shifted: B2:C3 -> shifted by 2 rows/cols -> D4:E5
                Assert.AreEqual("'Insert'!$D$4:$E$5", sheet.Names["LocalRange"].Address);

                // Assert drawings
                var shape = sheet.Drawings["Shape1"];
                var absShape = sheet.Drawings["ShapeAbs"];
                Assert.IsNotNull(shape);
                Assert.IsNotNull(absShape);

                // EPPlus does not natively shift drawings, so check they preserved original positions
                Assert.AreEqual(4, shape.From.Row);
                Assert.AreEqual(4, shape.From.Column);
                Assert.AreEqual(eEditAs.Absolute, absShape.EditAs);
            });
        }

        [TestMethod]
        public void AppendBelow()
        {
            Test(template, null, "AppendAndInsert.AppendBelow.xlsx", null, package =>
            {
                var ws = package.Workbook.Worksheets["Data"];
                int nextRow = ws.Dimension.End.Row + 1;
                ws.Cells[nextRow, 1].Value = 4;
                ws.Cells[nextRow + 1, 1].Value = 5;
            }, package =>
            {
                var ws = package.Workbook.Worksheets["Data"];
                Assert.AreEqual("4", ws.Cells["A5"].Text);
                Assert.AreEqual("5", ws.Cells["A6"].Text);
            });
        }

        [TestMethod]
        public void AppendRight()
        {
            Test(template, null, "AppendAndInsert.AppendRight.xlsx", null, package =>
            {
                var ws = package.Workbook.Worksheets["Data"];

                int nextCol = ws.Dimension.End.Column + 1;

                ws.Cells[1, nextCol].Value = "D";
                ws.Cells[1, nextCol + 1].Value = "E";
            }, package =>
            {
                var ws = package.Workbook.Worksheets["Data"];

                // Data sheet initially only has column A populated
                Assert.AreEqual("D", ws.Cells["B1"].Text);
                Assert.AreEqual("E", ws.Cells["C1"].Text);
            });
        }

        [TestMethod]
        public void InsertRowsWithPreGap()
        {
            Test(template, null, "AppendAndInsert.InsertRowsWithPreGap.xlsx", null, package =>
            {
                var ws = package.Workbook.Worksheets["Data"];
                ws.InsertRow(2, 2);
                ws.Cells["A2"].Value = "Export1";
                ws.Cells["A3"].Value = "Export2";
            }, package =>
            {
                var ws = package.Workbook.Worksheets["Data"];
                Assert.AreEqual("Id", ws.Cells["A1"].Text);
                Assert.AreEqual("Export1", ws.Cells["A2"].Text);
                Assert.AreEqual("Export2", ws.Cells["A3"].Text);
            });
        }

        [TestMethod]
        public void InsertColumnsWithPreGap()
        {
            Test(template, null, "AppendAndInsert.InsertColumnsWithPreGap.xlsx", null, package =>
            {
                var ws = package.Workbook.Worksheets["Data"];
                ws.InsertColumn(2, 2);
                ws.Cells["B1"].Value = "Export1";
                ws.Cells["C1"].Value = "Export2";
            }, package =>
            {
                var ws = package.Workbook.Worksheets["Data"];
                Assert.AreEqual("Id", ws.Cells["A1"].Text);
                Assert.AreEqual("Export1", ws.Cells["B1"].Text);
                Assert.AreEqual("Export2", ws.Cells["C1"].Text);
            });
        }

        [TestMethod]
        public void ExportWithPostGap()
        {
            Test(template, null, "AppendAndInsert.PostGap.xlsx", null, package =>
            {
                var ws = package.Workbook.Worksheets["Data"];

                // Create a gap similar to SheetKraft PostGap behavior
                ws.InsertRow(3, 2);

                ws.Cells["A5"].Value = "AfterGap";
            }, package =>
            {
                var ws = package.Workbook.Worksheets["Data"];

                Assert.AreEqual(string.Empty, ws.Cells["A3"].Text);
                Assert.AreEqual(string.Empty, ws.Cells["A4"].Text);
                Assert.AreEqual("AfterGap", ws.Cells["A5"].Text);
            });
        }
        [TestMethod]
        public void FullColumnAndRowAppendReferences()
        {
            Test(template, null, "AppendAndInsert.FullColumnAndRowAppendReferences.xlsx", null, package =>
            {
                var ws = package.Workbook.Worksheets["Data"];

                // Parse full column reference
                var fullCol = new ExcelAddress("A:A");
                Assert.IsTrue(fullCol.End.Row >= 1048576);

                // Parse full row reference
                var fullRow = new ExcelAddress("1:1");
                Assert.IsTrue(fullRow.End.Column >= 16384);
            }, package =>
            {
            });
        }
    }
}
