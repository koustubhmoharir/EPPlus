using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using System.Linq;

namespace EPPlusE2ETest
{
    [TestClass]
    public class DynamicMerging : TestsBase
    {
        static string template = "DynamicMerging.xlsx";

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            SaveTemplate(template, package =>
            {
                var ws = package.Workbook.Worksheets.Add("Data");

                ws.Cells["A1"].Value = "Department";
                ws.Cells["B1"].Value = "Employee";
                ws.Cells["C1"].Value = "Salary";

                ws.Cells["A2"].Value = "IT";
                ws.Cells["B2"].Value = "John";
                ws.Cells["C2"].Value = 1000;

                ws.Cells["A3"].Value = "IT";
                ws.Cells["B3"].Value = "Smith";
                ws.Cells["C3"].Value = 1200;

                ws.Cells["A4"].Value = "IT";
                ws.Cells["B4"].Value = "David";
                ws.Cells["C4"].Value = 1500;

                ws.Cells["A5"].Value = "HR";
                ws.Cells["B5"].Value = "Mary";
                ws.Cells["C5"].Value = 900;

                ws.Cells["A6"].Value = "HR";
                ws.Cells["B6"].Value = "Lisa";
                ws.Cells["C6"].Value = 1100;

                ws.Cells["A7"].Value = "Finance";
                ws.Cells["B7"].Value = "Tom";
                ws.Cells["C7"].Value = 2000;
            });
        }

        [TestMethod]
        public void MergeConsecutiveDuplicateValues()
        {
            Test(template, null,
                "DynamicMerging.MergeConsecutiveDuplicateValues.xlsx",
                null,
                package =>
                {
                    var ws = package.Workbook.Worksheets["Data"];

                    int startRow = 2;
                    string currentValue = ws.Cells[startRow, 1].Text;

                    for (int row = 3; row <= ws.Dimension.End.Row + 1; row++)
                    {
                        string value = row <= ws.Dimension.End.Row
                            ? ws.Cells[row, 1].Text
                            : string.Empty;

                        if (value != currentValue)
                        {
                            if (row - startRow > 1)
                            {
                                ws.Cells[startRow, 1, row - 1, 1].Merge = true;
                            }

                            startRow = row;
                            currentValue = value;
                        }
                    }
                },
                package =>
                {
                    var ws = package.Workbook.Worksheets["Data"];

                    Assert.IsTrue(ws.MergedCells.Contains("A2:A4"));
                    Assert.IsTrue(ws.MergedCells.Contains("A5:A6"));

                    Assert.AreEqual("IT", ws.Cells["A2"].Text);
                    Assert.AreEqual("HR", ws.Cells["A5"].Text);
                    Assert.AreEqual("Finance", ws.Cells["A7"].Text);
                });
        }
    }
}
