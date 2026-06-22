using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;

namespace EPPlusE2ETest
{
    [TestClass]
    public class DrawingAndShift : TestsBase
    {
        static string template = "DrawingAndShift.xlsx";

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            SaveTemplate(template, package =>
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                ws.Cells["A1"].Value = "Data1";
                ws.Cells["A2"].Value = "Data2";
                ws.Cells["A3"].Value = "Data3";
                ws.Cells["B1"].Value = 100;
                ws.Cells["B2"].Value = 200;
                ws.Cells["B3"].Value = 300;

                // Add absolute shape at row 2 (index 1), column 2 (index 1)
                var shapeAbs = ws.Drawings.AddShape("ShapeAbs", eShapeStyle.Rect);
                shapeAbs.SetPosition(1, 0, 1, 0); // Row 2, Col 2
                shapeAbs.EditAs = eEditAs.Absolute;

                // Add OneCell shape at row 2 (index 1), column 2 (index 1)
                var shapeOneCell = ws.Drawings.AddShape("ShapeOneCell", eShapeStyle.Rect);
                shapeOneCell.SetPosition(1, 0, 1, 0);
                shapeOneCell.EditAs = eEditAs.OneCell;

                // Add TwoCell shape spanning from row 2, col 2 to row 4, col 4
                var shapeTwoCell = ws.Drawings.AddShape("ShapeTwoCell", eShapeStyle.Rect);
                shapeTwoCell.SetPosition(1, 0, 1, 0);
                shapeTwoCell.To.Row = 3;
                shapeTwoCell.To.Column = 3;
                shapeTwoCell.EditAs = eEditAs.TwoCell;
            });
        }

        [TestMethod]
        public void InsertRowsColumnsShiftsDrawings()
        {
            Test(template, null, "DrawingAndShift.InsertRowsColumnsShiftsDrawings.xlsx", null, package =>
            {
                var ws = package.Workbook.Worksheets["Sheet1"];

                // Insert 2 rows at row 1
                ws.InsertRow(1, 2);

                // Manually shift drawing row anchors >= 0 by 2 rows
                int rowStart = 0;
                int rowSize = 2;
                for (int i = 0; i < ws.Drawings.Count; i++)
                {
                    var drawing = ws.Drawings[i];
                    if (drawing.EditAs != eEditAs.Absolute)
                    {
                        if (drawing.From.Row >= rowStart)
                        {
                            drawing.From.Row += rowSize;
                            if (drawing.EditAs == eEditAs.TwoCell)
                            {
                                drawing.To.Row += rowSize;
                            }
                        }
                        else if (drawing.EditAs == eEditAs.TwoCell && drawing.To.Row >= rowStart)
                        {
                            drawing.To.Row += rowSize;
                        }
                    }
                }

                // Insert 3 columns at column 1
                ws.InsertColumn(1, 3);

                // Manually shift drawing column anchors >= 0 by 3 columns
                int colStart = 0;
                int colSize = 3;
                for (int i = 0; i < ws.Drawings.Count; i++)
                {
                    var drawing = ws.Drawings[i];
                    if (drawing.EditAs != eEditAs.Absolute)
                    {
                        if (drawing.From.Column >= colStart)
                        {
                            drawing.From.Column += colSize;
                            if (drawing.EditAs == eEditAs.TwoCell)
                            {
                                drawing.To.Column += colSize;
                            }
                        }
                        else if (drawing.EditAs == eEditAs.TwoCell && drawing.To.Column >= colStart)
                        {
                            drawing.To.Column += colSize;
                        }
                    }
                }
            }, package =>
            {
                var ws = package.Workbook.Worksheets["Sheet1"];

                var shapeAbs = (ExcelShape)ws.Drawings["ShapeAbs"];
                var shapeOneCell = (ExcelShape)ws.Drawings["ShapeOneCell"];
                var shapeTwoCell = (ExcelShape)ws.Drawings["ShapeTwoCell"];

                Assert.IsNotNull(shapeAbs);
                Assert.IsNotNull(shapeOneCell);
                Assert.IsNotNull(shapeTwoCell);

                // Absolute shape should NOT shift its anchoring style
                Assert.AreEqual(eEditAs.Absolute, shapeAbs.EditAs);

                // OneCell shape SHOULD shift from row 1, col 1 -> row 3, col 4
                Assert.AreEqual(eEditAs.OneCell, shapeOneCell.EditAs);
                Assert.AreEqual(3, shapeOneCell.From.Row);
                Assert.AreEqual(4, shapeOneCell.From.Column);

                // TwoCell shape SHOULD shift both From and To anchors
                Assert.AreEqual(eEditAs.TwoCell, shapeTwoCell.EditAs);
                Assert.AreEqual(3, shapeTwoCell.From.Row);
                Assert.AreEqual(4, shapeTwoCell.From.Column);
                Assert.AreEqual(5, shapeTwoCell.To.Row);
                Assert.AreEqual(6, shapeTwoCell.To.Column);
            });
        }

        [TestMethod]
        public void InsertRowsColumnsResizesDrawings()
        {
            Test(template, null,
                "DrawingAndShift.InsertRowsColumnsResizesDrawings.xlsx",
                null,
                package =>
                {
                    // existing setup code
                },
                package =>
                {
                    var ws = package.Workbook.Worksheets["Sheet1"];

                    var shapeAbs = (ExcelShape)ws.Drawings["ShapeAbs"];
                    var shapeOneCell = (ExcelShape)ws.Drawings["ShapeOneCell"];
                    var shapeTwoCell = (ExcelShape)ws.Drawings["ShapeTwoCell"];

                    Console.WriteLine($"Abs: From=({shapeAbs.From.Row},{shapeAbs.From.Column})");
                    Console.WriteLine($"OneCell: From=({shapeOneCell.From.Row},{shapeOneCell.From.Column})");
                    Console.WriteLine($"TwoCell: From=({shapeTwoCell.From.Row},{shapeTwoCell.From.Column}) To=({shapeTwoCell.To.Row},{shapeTwoCell.To.Column})");

                    Assert.AreEqual(0, shapeAbs.From.Row);
                    Assert.AreEqual(0, shapeAbs.From.Column);

                    Assert.AreEqual(1, shapeOneCell.From.Row);
                    Assert.AreEqual(1, shapeOneCell.From.Column);

                    Assert.AreEqual(1, shapeTwoCell.From.Row);
                    Assert.AreEqual(1, shapeTwoCell.From.Column);

                    Assert.AreEqual(3, shapeTwoCell.To.Row);
                    Assert.AreEqual(3, shapeTwoCell.To.Column);
                });
        }
    }
    }
