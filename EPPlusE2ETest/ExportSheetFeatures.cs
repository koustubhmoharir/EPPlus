using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;

namespace EPPlusE2ETest
{
    [TestClass]
    public class ExportSheetFeatures : TestsBase
    {
        static string template = "ExportSheetFeatures.xlsx";
        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            SaveTemplate(template, package =>
            {
                // Sheet1
                var sheet1 = package.Workbook.Worksheets.Add("Sheet1");
                sheet1.Cells["A1"].Value = "Header";
                sheet1.Cells["A2"].Value = 100;
                sheet1.Cells["B2"].Formula = "A2*2";

                sheet1.Cells["A1:B1"].Style.Font.Bold = true;

                // Sheet2
                var sheet2 = package.Workbook.Worksheets.Add("Sheet2");
                sheet2.Cells["A1"].Value = "Do Not Export";

                // SalesData
                var sales = package.Workbook.Worksheets.Add("SalesData");
                sales.Cells["A1"].Value = "Monthly Report";

                // FormulaSheet
                var formula = package.Workbook.Worksheets.Add("FormulaSheet");
                formula.Cells["A1"].Value = 10;
                formula.Cells["A2"].Value = 20;
                formula.Cells["A3"].Value = 30;
                formula.Cells["A4"].Value = 40;
                formula.Cells["A5"].Value = 50;
                formula.Cells["A6"].Formula = "SUM(A1:A5)";

                // Active sheet scenario
                package.Workbook.Worksheets.Add("Summary");
                package.Workbook.Worksheets.Add("Dashboard");
            });
        }
        [TestMethod]
        public void ExportWorksheetCopy()
        {
            Test(template, null,
                "ExportSheetFeatures.ExportWorksheetCopy.xlsx",
                null,
                package =>
                {
                    var sourceSheet = package.Workbook.Worksheets["Sheet1"];

                    package.Workbook.Worksheets.Add(
                        "ExportedSheet",
                        sourceSheet);
                },
                package =>
                {
                    var sourceSheet = package.Workbook.Worksheets["Sheet1"];
                    var exportedSheet = package.Workbook.Worksheets["ExportedSheet"];

                    Assert.IsNotNull(sourceSheet);
                    Assert.IsNotNull(exportedSheet);

                    Assert.AreEqual(
                        sourceSheet.Cells["A1"].Value,
                        exportedSheet.Cells["A1"].Value);

                    Assert.AreEqual(
                        sourceSheet.Dimension.End.Row,
                        exportedSheet.Dimension.End.Row);

                    Assert.AreEqual(
                        sourceSheet.Dimension.End.Column,
                        exportedSheet.Dimension.End.Column);
                });
        }

        [TestMethod]
        public void RenameWorksheetDuringExport()
        {
            Test(template, null,
                "ExportSheetFeatures.RenameWorksheetDuringExport.xlsx",
                null,
                package =>
                {
                    var sheet = package.Workbook.Worksheets["SalesData"];
                    sheet.Name = "RevenueReport";
                },
                package =>
                {
                    Assert.IsNull(package.Workbook.Worksheets["SalesData"]);
                    Assert.IsNotNull(package.Workbook.Worksheets["RevenueReport"]);

                    Assert.AreEqual(
                        "Monthly Report",
                        package.Workbook.Worksheets["RevenueReport"]
                            .Cells["A1"].Value);
                });
        }

        [TestMethod]
        public void BuiltInFormulaPreserved()
        {
            Test(template, null,
                "ExportSheetFeatures.BuiltInFormulaPreserved.xlsx",
                null,
                package =>
                {
                    // No modification required
                    // Formula already exists in template
                },
                package =>
                {
                    var ws = package.Workbook.Worksheets["FormulaSheet"];

                    Assert.AreEqual(
                        "SUM(A1:A5)",
                        ws.Cells["A6"].Formula);
                });
        }

        [TestMethod]
        public void ActiveSheetSelection()
        {
            Test(template, null,
                "ExportSheetFeatures.ActiveSheetSelection.xlsx",
                null,
                package =>
                {
                    var dashboard =
                        package.Workbook.Worksheets["Dashboard"];

                    dashboard.Select();
                },
                package =>
                {
                    var dashboard =
                        package.Workbook.Worksheets["Dashboard"];

                    Assert.IsNotNull(dashboard);

                    // Workbook should contain the sheet
                    Assert.AreEqual(
                        "Dashboard",
                        dashboard.Name);
                });
        }

    }

}
