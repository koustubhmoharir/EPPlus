using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;

namespace EPPlusE2ETest
{
    [TestClass]
    public class FormulasAndCells : TestsBase
    {
        static string template = "FormulasAndCells.xlsx";

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            SaveTemplate(template, package =>
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                ws.Cells["A1"].Value = 10.0;
                ws.Cells["A2"].Value = 20.0;
                ws.Cells["A3"].Value = 30.0;
                
                ws.Cells["B1"].Value = 1.0;
                ws.Cells["B2"].Value = 2.0;
                ws.Cells["B3"].Value = 3.0;
            });
        }

        [TestMethod]
        public void StandardFormula()
        {
            Test(template, null, "FormulasAndCells.StandardFormula.xlsx", null, package =>
            {
                var ws = package.Workbook.Worksheets["Sheet1"];
                ws.Cells["A4"].Formula = "=SUM(A1:A3)";
            }, package =>
            {
                var ws = package.Workbook.Worksheets["Sheet1"];
                Assert.AreEqual("=SUM(A1:A3)", ws.Cells["A4"].Formula);
            });
        }

        [TestMethod]
        public void ArrayFormulaAndClear()
        {
            Test(template, null, "FormulasAndCells.ArrayFormulaAndClear.xlsx", null, package =>
            {
                var ws = package.Workbook.Worksheets["Sheet1"];
                // Create an array formula on C1:C3
                ws.Cells["C1:C3"].CreateArrayFormula("=A1:A3*B1:B3");

                // Get array formula range and check it
                var arrayRange = ws.GetArrayFormulaRange(1, 3);
                Assert.IsNotNull(arrayRange);
                Assert.AreEqual("C1:C3", arrayRange.Address);

                // Clear it
                ws.Cells[arrayRange.Start.Row, arrayRange.Start.Column].Clear(true);
            }, package =>
            {
                var ws = package.Workbook.Worksheets["Sheet1"];
                var cell = ws.Cells["C1"];
                Assert.AreEqual("", cell.Formula);
                Assert.IsNull(cell.Value);
            });
        }

        [TestMethod]
        public void FormulaR1C1Fill()
        {
            Test(template, null, "FormulasAndCells.FormulaR1C1Fill.xlsx", null, package =>
            {
                var ws = package.Workbook.Worksheets["Sheet1"];
                
                // Set initial R1C1 formula
                ws.Cells["C1"].FormulaR1C1 = "=RC[-2]+RC[-1]";
                
                // Copy R1C1 formula down to C2 and C3
                string r1c1 = ws.Cells["C1"].FormulaR1C1;
                ws.Cells["C2"].FormulaR1C1 = r1c1;
                ws.Cells["C3"].FormulaR1C1 = r1c1;
            }, package =>
            {
                var ws = package.Workbook.Worksheets["Sheet1"];
                
                // In A1-style, these should have been translated correctly
                Assert.AreEqual("A1+B1", ws.Cells["C1"].Formula);
                Assert.AreEqual("A2+B2", ws.Cells["C2"].Formula);
                Assert.AreEqual("A3+B3", ws.Cells["C3"].Formula);
            });
        }
    }
}
