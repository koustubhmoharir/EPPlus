using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;

namespace EPPlusTest
{
    [TestClass]
    [TestCategory("LinuxSmoke")]
    public class AutoFitLinuxSmokeTests
    {
        [TestMethod]
        public void AutoFitColumns_AdjustsWidthsForRepresentativeText()
        {
            if (!OperatingSystem.IsLinux())
            {
                Assert.Inconclusive("Linux smoke test.");
            }

            using (var package = new ExcelPackage(TempFolderHelper.Create()))
            {
                var worksheet = package.Workbook.Worksheets.Add("AutoFit");

                worksheet.Cells["A1"].Value = "Short";
                worksheet.Cells["B1"].Value = "A much longer value";
                worksheet.Cells["C1"].Value = "Styled text";
                worksheet.Cells["C1"].Style.Font.Bold = true;
                worksheet.Cells["C1"].Style.Font.Size = 14;
                worksheet.Cells["D1"].Value = "123456789012345";
                worksheet.Cells["D1"].Style.Font.Italic = true;
                worksheet.Cells["E1"].Value = "Rotated";
                worksheet.Cells["E1"].Style.TextRotation = 45;
                worksheet.Column(6).Hidden = true;
                worksheet.Cells["F1"].Value = "Hidden column";

                worksheet.Cells["A1:F1"].AutoFitColumns(5, 40);

                Assert.IsTrue(worksheet.Column(1).Width >= 5);
                Assert.IsTrue(worksheet.Column(2).Width > worksheet.Column(1).Width);
                Assert.IsTrue(worksheet.Column(3).Width > worksheet.Column(1).Width);
                Assert.IsTrue(worksheet.Column(4).Width > worksheet.Column(1).Width);
                Assert.IsTrue(worksheet.Column(5).Width > worksheet.Column(1).Width);
                Assert.IsTrue(worksheet.Column(2).Width <= 40);
                Assert.IsTrue(worksheet.Column(6).Hidden);
            }
        }

        [TestMethod]
        public void AutoFitColumns_IgnoresWrappedAndMergedCells()
        {
            if (!OperatingSystem.IsLinux())
            {
                Assert.Inconclusive("Linux smoke test.");
            }

            using (var package = new ExcelPackage(TempFolderHelper.Create()))
            {
                var worksheet = package.Workbook.Worksheets.Add("AutoFitIgnoredCells");

                worksheet.Cells["A1"].Value = "Anchor";
                worksheet.Cells["B1:C1"].Merge = true;
                worksheet.Cells["B1"].Value = "This merged cell should not drive auto-fit";
                worksheet.Cells["B1"].Style.WrapText = true;
                worksheet.Cells["D1"].Value = "Regular content that should drive auto-fit much more strongly than the anchor text";

                worksheet.Cells["A1:D1"].AutoFitColumns(4, 40);

                Assert.IsTrue(worksheet.Column(1).Width >= 4);
                Assert.AreEqual(4d, worksheet.Column(2).Width, 0.01d);
                Assert.IsTrue(worksheet.Column(4).Width >= 4);
            }
        }
    }
}
