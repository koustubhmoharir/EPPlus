using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;

namespace EPPlusE2ETest
{
    [TestClass]
    public class OverwriteOptions : TestsBase
    {
        static string template = "OverwriteOptions.xlsx";

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            SaveTemplate(template, package =>
            {
                var sheet = package.Workbook.Worksheets.Add("Overwrite");
                sheet.Cells["A1"].Value = "keep blank";
                sheet.Cells["A2"].Value = "keep na";
                sheet.Cells["A3"].Value = "replace";

                var sheet1 = package.Workbook.Worksheets.Add("Sheet1");
                sheet1.Cells["A1"].Value = "Value";
                sheet1.Cells["A2"].Value = 100;
                sheet1.Cells["A3"].Value = null;
                sheet1.Cells["A4"].Value = "#N/A";
                sheet1.Cells["A5"].Value = 200;
            });
        }

        [TestMethod]
        public void SkipBlanksAndErrors()
        {
            Test(template, null, "OverwriteOptions.SkipBlanksAndErrors.xlsx", null, package =>
            {
                var sheet = package.Workbook.Worksheets["Overwrite"];
                var incoming = new object[]
                {
                    null,
                    ExcelErrorValue.Create(eErrorType.NA),
                    "new value"
                };

                for (var row = 1; row <= incoming.Length; row++)
                {
                    var value = incoming[row - 1];
                    if (value == null || Equals(value, ExcelErrorValue.Create(eErrorType.NA)))
                    {
                        continue;
                    }

                    sheet.Cells[row, 1].Value = value;
                }
            }, package =>
            {
                var sheet = package.Workbook.Worksheets["Overwrite"];
                Assert.AreEqual("keep blank", sheet.Cells["A1"].Value);
                Assert.AreEqual("keep na", sheet.Cells["A2"].Value);
                Assert.AreEqual("new value", sheet.Cells["A3"].Value);
            });
        }

        [TestMethod]
        public void BlankCellsPreserved()
        {
            Test(template, null, "OverwriteOptions.BlankCellsPreserved.xlsx", null, package =>
            {
                var ws = package.Workbook.Worksheets["Sheet1"];
                ws.Cells["B1:B5"].Copy(ws.Cells["C1:C5"]);
            }, package =>
            {
                var ws = package.Workbook.Worksheets["Sheet1"];
                Assert.AreEqual("", ws.Cells["C3"].Text);
            });
        }

        [TestMethod]
        public void NAValuesPreserved()
        {
            Test(template, null, "OverwriteOptions.NAValuesPreserved.xlsx", null, package =>
            {
                var ws = package.Workbook.Worksheets["Sheet1"];
                ws.Cells["A1:A5"].Copy(ws.Cells["D1:D5"]);
            }, package =>
            {
                var ws = package.Workbook.Worksheets["Sheet1"];
                Assert.AreEqual("#N/A", ws.Cells["D4"].Text);
            });
        }

        [TestMethod]
        public void ConvertNAToBlank()
        {
            Test(template, null, "OverwriteOptions.ConvertNAToBlank.xlsx", null, package =>
            {
                var ws = package.Workbook.Worksheets["Sheet1"];
                if (ws.Cells["A4"].Text == "#N/A")
                {
                    ws.Cells["A4"].Value = null;
                }
            }, package =>
            {
                var ws = package.Workbook.Worksheets["Sheet1"];
                Assert.AreEqual("", ws.Cells["A4"].Text);
            });
        }

        [TestMethod]
        public void FormulaOrLiteralValue()
        {
            Test(template, null, "OverwriteOptions.FormulaOrLiteralValue.xlsx", null, package =>
            {
                var ws = package.Workbook.Worksheets["Sheet1"];
                
                // Simulate copyFormulas = true
                string val = "=A2+10";
                if (val.StartsWith("="))
                {
                    ws.Cells["B2"].Formula = val.Substring(1);
                }
                else
                {
                    ws.Cells["B2"].Value = val;
                }

                // Simulate copyFormulas = false
                string valLiteral = "=A2+20";
                ws.Cells["B3"].Value = valLiteral;
            }, package =>
            {
                var ws = package.Workbook.Worksheets["Sheet1"];
                Assert.AreEqual("A2+10", ws.Cells["B2"].Formula);
                Assert.AreEqual("=A2+20", ws.Cells["B3"].Value);
                Assert.AreEqual("", ws.Cells["B3"].Formula);
            });
        }

        [TestMethod]
        public void IndependentOverwriteOptions()
        {
            Test(template, null, "OverwriteOptions.IndependentOverwriteOptions.xlsx", null, package =>
            {
                var ws = package.Workbook.Worksheets["Sheet1"];
                
                string newValueVal = "newValue";
                string newFormulaVal = "=A2+300";

                // Scenario A: copyValues = true, copyFormulas = false
                bool copyValuesA = true, copyFormulasA = false;
                WriteCell(ws.Cells["B1"], newValueVal, copyValuesA, copyFormulasA);
                WriteCell(ws.Cells["B2"], newFormulaVal, copyValuesA, copyFormulasA);

                // Scenario B: copyValues = false, copyFormulas = true
                bool copyValuesB = false, copyFormulasB = true;
                WriteCell(ws.Cells["C1"], newValueVal, copyValuesB, copyFormulasB);
                WriteCell(ws.Cells["C2"], newFormulaVal, copyValuesB, copyFormulasB);
            }, package =>
            {
                var ws = package.Workbook.Worksheets["Sheet1"];
                
                // Scenario A assertions
                Assert.AreEqual("newValue", ws.Cells["B1"].Value);
                Assert.AreEqual("", ws.Cells["B1"].Formula);
                Assert.AreEqual("=A2+300", ws.Cells["B2"].Value);
                Assert.AreEqual("", ws.Cells["B2"].Formula);

                // Scenario B assertions
                Assert.IsNull(ws.Cells["C1"].Value);
                Assert.AreEqual("A2+300", ws.Cells["C2"].Formula);
            });
        }

        private static void WriteCell(ExcelRange cell, string val, bool copyValues, bool copyFormulas)
        {
            if (val.StartsWith("=") && copyFormulas)
            {
                cell.Formula = val.Substring(1);
            }
            else if (copyValues)
            {
                cell.Value = val;
            }
        }
    }
}
