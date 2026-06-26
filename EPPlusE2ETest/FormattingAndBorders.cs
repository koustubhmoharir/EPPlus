using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace EPPlusE2ETest
{
    [TestClass]
    public class FormattingAndBorders : TestsBase
    {
        static string template = "FormattingAndBorders.xlsx";

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            SaveTemplate(template, package =>
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");

                // Sample report data
                ws.Cells["A1"].Value = "Employee";
                ws.Cells["B1"].Value = "Department";
                ws.Cells["C1"].Value = "Location";

                ws.Cells["A2"].Value = "John";
                ws.Cells["B2"].Value = "IT";
                ws.Cells["C2"].Value = "Mumbai";

                ws.Cells["A3"].Value = "Mary";
                ws.Cells["B3"].Value = "HR";
                ws.Cells["C3"].Value = "Pune";

                var range = ws.Cells["A1:C3"];

                // Font
                range.Style.Font.Name = "Calibri";
                range.Style.Font.Bold = true;

                // Fill
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.LightBlue);

                // Alignment
                range.Style.HorizontalAlignment =
                    ExcelHorizontalAlignment.Center;

                // Borders
                range.Style.Border.Top.Style =
                    ExcelBorderStyle.Thin;

                range.Style.Border.Bottom.Style =
                    ExcelBorderStyle.Thin;

                range.Style.Border.Left.Style =
                    ExcelBorderStyle.Thin;

                range.Style.Border.Right.Style =
                    ExcelBorderStyle.Thin;

                ws.Cells[ws.Dimension.Address].AutoFitColumns();
            });
        }

        [TestMethod]
        public void CopyBordersOnly()
        {
            Test(template, null,
                "FormattingAndBorders.CopyBordersOnly.xlsx",
                null,
                package =>
                {
                    var ws = package.Workbook.Worksheets["Sheet1"];

                    ws.Cells["A1:C3"].Copy(ws.Cells["E1"]);

                    // Remove fill to visually focus on borders
                    ws.Cells["E1:G3"].Style.Fill.PatternType =
                        ExcelFillStyle.None;

                    ws.Cells["E:G"].AutoFitColumns();
                },
                package =>
                {
                    var ws = package.Workbook.Worksheets["Sheet1"];

                    Assert.AreEqual(
                        ExcelBorderStyle.Thin,
                        ws.Cells["E1"].Style.Border.Top.Style);

                    Assert.AreEqual(
                        ExcelBorderStyle.Thin,
                        ws.Cells["G3"].Style.Border.Bottom.Style);
                });
        }

        [TestMethod]
        public void CopyContentFormatsOnly()
        {
            Test(template, null,
                "FormattingAndBorders.CopyContentFormatsOnly.xlsx",
                null,
                package =>
                {
                    var ws = package.Workbook.Worksheets["Sheet1"];

                    ws.Cells["A1:C3"].Copy(ws.Cells["E1"]);

                    ws.Cells["E:G"].AutoFitColumns();
                },
                package =>
                {
                    var ws = package.Workbook.Worksheets["Sheet1"];

                    Assert.IsTrue(
                        ws.Cells["E1"].Style.Font.Bold);

                    Assert.AreEqual(
                        ExcelFillStyle.Solid,
                        ws.Cells["E1"].Style.Fill.PatternType);

                    Assert.AreEqual(
                        ExcelHorizontalAlignment.Center,
                        ws.Cells["E1"].Style.HorizontalAlignment);
                });
        }

        [TestMethod]
        public void CopyAllFormatting()
        {
            Test(template, null,
                "FormattingAndBorders.CopyAllFormatting.xlsx",
                null,
                package =>
                {
                    var ws = package.Workbook.Worksheets["Sheet1"];

                    ws.Cells["A1:C3"].Copy(ws.Cells["E1"]);

                    ws.Cells["E:G"].AutoFitColumns();
                },
                package =>
                {
                    var ws = package.Workbook.Worksheets["Sheet1"];

                    Assert.AreEqual("Employee", ws.Cells["E1"].Text);
                    Assert.AreEqual("Department", ws.Cells["F1"].Text);
                    Assert.AreEqual("Location", ws.Cells["G1"].Text);

                    Assert.AreEqual("John", ws.Cells["E2"].Text);
                    Assert.AreEqual("Mary", ws.Cells["E3"].Text);

                    Assert.IsTrue(
                        ws.Cells["E1"].Style.Font.Bold);

                    Assert.AreEqual(
                        ExcelFillStyle.Solid,
                        ws.Cells["E1"].Style.Fill.PatternType);

                    Assert.AreEqual(
                        ExcelHorizontalAlignment.Center,
                        ws.Cells["E1"].Style.HorizontalAlignment);

                    Assert.AreEqual(
                        ExcelBorderStyle.Thin,
                        ws.Cells["E1"].Style.Border.Top.Style);


             });
        }
        [TestMethod]
        public void CopyNumberFormatsOnly()
        {
            Test(template, null,
                "FormattingAndBorders.CopyNumberFormatsOnly.xlsx",
                null,
                package =>
                {
                    var ws = package.Workbook.Worksheets["Sheet1"];

                    // Sample values
                    ws.Cells["A6"].Value = 12345.67;
                    ws.Cells["B6"].Value = 0.25;
                    ws.Cells["C6"].Value = DateTime.Today;

                    // Different number formats
                    ws.Cells["A6"].Style.Numberformat.Format = "$#,##0.00";
                    ws.Cells["B6"].Style.Numberformat.Format = "0.00%";
                    ws.Cells["C6"].Style.Numberformat.Format = "dd-mmm-yyyy";

                    // Copy only number formats
                    ws.Cells["D6"].Value = ws.Cells["A6"].Value;
                    ws.Cells["E6"].Value = ws.Cells["B6"].Value;
                    ws.Cells["F6"].Value = ws.Cells["C6"].Value;

                    ws.Cells["D6"].Style.Numberformat.Format =
                        ws.Cells["A6"].Style.Numberformat.Format;

                    ws.Cells["E6"].Style.Numberformat.Format =
                        ws.Cells["B6"].Style.Numberformat.Format;

                    ws.Cells["F6"].Style.Numberformat.Format =
                        ws.Cells["C6"].Style.Numberformat.Format;

                    ws.Cells["A:F"].AutoFitColumns();
                },
                package =>
                {
                    var ws = package.Workbook.Worksheets["Sheet1"];

                    Assert.AreEqual(
                        "$#,##0.00",
                        ws.Cells["D6"].Style.Numberformat.Format);

                    Assert.AreEqual(
                        "0.00%",
                        ws.Cells["E6"].Style.Numberformat.Format);

                    Assert.AreEqual(
                        "dd-mmm-yyyy",
                        ws.Cells["F6"].Style.Numberformat.Format);
                });
        }

        [TestMethod]
        public void AutoFitAndCopyWidths()
        {
            Test(template, null,
                "FormattingAndBorders.AutoFitAndCopyWidths.xlsx",
                null,
                package =>
                {
                    var ws = package.Workbook.Worksheets.Add("AutoFitTest");

                    // Write text with different lengths
                    ws.Cells["A1"].Value = "Short";
                    ws.Cells["B1"].Value = "This is a very long text to test AutoFit functionality";
                    ws.Cells["C1"].Value = "Medium length";

                    // AutoFit
                    ws.Cells["A1:C1"].AutoFitColumns();

                    // Verify AutoFit produced reasonable widths
                    Assert.IsTrue(ws.Column(1).Width > 0);
                    Assert.IsTrue(ws.Column(2).Width > ws.Column(1).Width);
                    Assert.IsTrue(ws.Column(2).Width > ws.Column(3).Width);
                    Assert.IsTrue(ws.Column(3).Width > ws.Column(1).Width);

                    // Store AutoFit widths
                    double autoWidthA = ws.Column(1).Width;
                    double autoWidthB = ws.Column(2).Width;
                    double autoWidthC = ws.Column(3).Width;

                    // Change Column A width manually
                    ws.Column(1).Width = 35;

                    // Copy cells
                    ws.Cells["A1:C1"].Copy(ws.Cells["E1"]);

                    // Copy column widths
                    ws.Column(5).Width = ws.Column(1).Width;
                    ws.Column(6).Width = ws.Column(2).Width;
                    ws.Column(7).Width = ws.Column(3).Width;

                    // Save AutoFit widths for verification after reload
                    package.Workbook.Properties.SetCustomPropertyValue("AutoWidthA", autoWidthA);
                    package.Workbook.Properties.SetCustomPropertyValue("AutoWidthB", autoWidthB);
                    package.Workbook.Properties.SetCustomPropertyValue("AutoWidthC", autoWidthC);
                },
                package =>
                {
                    var ws = package.Workbook.Worksheets["AutoFitTest"];
                    Assert.IsNotNull(ws);

                    // Verify AutoFit widths persisted
                    double autoWidthA = Convert.ToDouble(package.Workbook.Properties.GetCustomPropertyValue("AutoWidthA"));
                    double autoWidthB = Convert.ToDouble(package.Workbook.Properties.GetCustomPropertyValue("AutoWidthB"));
                    double autoWidthC = Convert.ToDouble(package.Workbook.Properties.GetCustomPropertyValue("AutoWidthC"));

                    Assert.AreEqual(35, ws.Column(1).Width, 0.01);
                    Assert.AreEqual(autoWidthB, ws.Column(2).Width, 0.01);
                    Assert.AreEqual(autoWidthC, ws.Column(3).Width, 0.01);

                    // Verify copied widths
                    Assert.AreEqual(ws.Column(1).Width, ws.Column(5).Width, 0.01);
                    Assert.AreEqual(ws.Column(2).Width, ws.Column(6).Width, 0.01);
                    Assert.AreEqual(ws.Column(3).Width, ws.Column(7).Width, 0.01);

                    // Verify AutoFit relationship still holds
                    Assert.IsTrue(ws.Column(2).Width > ws.Column(3).Width);
                    Assert.IsTrue(ws.Column(3).Width > autoWidthA);
                });
        }

    }
}
