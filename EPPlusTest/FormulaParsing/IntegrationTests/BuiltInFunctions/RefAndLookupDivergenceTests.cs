using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing;

namespace EPPlusTest.FormulaParsing.IntegrationTests.BuiltInFunctions
{
    [TestClass]
    public class RefAndLookupDivergenceTests : FormulaParserTestBase
    {
        private ExcelPackage _package;
        private ExcelWorksheet _worksheet;

        [TestInitialize]
        public void Initialize()
        {
            _package = new ExcelPackage();
            _worksheet = _package.Workbook.Worksheets.Add("Test");
        }

        [TestCleanup]
        public void Cleanup()
        {
            _package.Dispose();
        }

        [TestMethod]
        public void Indirect_ShouldHandleStringAddress()
        {
            _worksheet.Cells["A1"].Value = 100d;
            _worksheet.Cells["A2"].Formula = "INDIRECT(\"A1\")";
            _worksheet.Calculate();
            Assert.AreEqual(100d, _worksheet.Cells["A2"].Value);
        }

        [TestMethod]
        public void Indirect_ShouldHandleWorksheetAddress()
        {
            var s2 = _package.Workbook.Worksheets.Add("Sheet2");
            s2.Cells["B1"].Value = 200d;
            _worksheet.Cells["A1"].Formula = "INDIRECT(\"Sheet2!B1\")";
            _worksheet.Calculate();
            Assert.AreEqual(200d, _worksheet.Cells["A1"].Value);
        }

        [TestMethod]
        public void Match_ShouldHandleRangeArgument()
        {
            _worksheet.Cells["A1"].Value = "Apple";
            _worksheet.Cells["A2"].Value = "Banana";
            _worksheet.Cells["A3"].Value = "Cherry";
            
            _worksheet.Cells["B1"].Formula = "MATCH(\"Banana\", A1:A3, 0)";
            _worksheet.Calculate();
            Assert.AreEqual(2, _worksheet.Cells["B1"].Value);
        }

        [TestMethod]
        public void Match_ShouldHandleStringAddressArgument()
        {
            _worksheet.Cells["A1"].Value = "Apple";
            _worksheet.Cells["A2"].Value = "Banana";
            _worksheet.Cells["A3"].Value = "Cherry";
            
            _worksheet.Cells["B1"].Formula = "MATCH(\"Cherry\", \"A1:A3\", 0)";
            _worksheet.Calculate();
            Assert.AreEqual(3, _worksheet.Cells["B1"].Value);
        }

        [TestMethod]
        public void Offset_ShouldReturnSingleCellValue()
        {
            _worksheet.Cells["A1"].Value = 1d;
            _worksheet.Cells["A2"].Value = 2d;
            _worksheet.Cells["B1"].Value = 3d;
            _worksheet.Cells["B2"].Value = 4d;

            _worksheet.Cells["C1"].Formula = "OFFSET(A1, 1, 1)";
            _worksheet.Calculate();
            Assert.AreEqual(4d, _worksheet.Cells["C1"].Value);
        }

        [TestMethod]
        public void Offset_ShouldReturnRangeValueForSum()
        {
            _worksheet.Cells["A1"].Value = 1d;
            _worksheet.Cells["A2"].Value = 2d;
            _worksheet.Cells["B1"].Value = 3d;
            _worksheet.Cells["B2"].Value = 4d;

            _worksheet.Cells["C1"].Formula = "SUM(OFFSET(A1, 0, 0, 2, 2))";
            _worksheet.Calculate();
            // 1 + 2 + 3 + 4 = 10
            Assert.AreEqual(10d, _worksheet.Cells["C1"].Value);
        }

        [TestMethod]
        public void Offset_ShouldHandleNegativeOffsets()
        {
            _worksheet.Cells["B2"].Value = 500d;
            _worksheet.Cells["C3"].Formula = "OFFSET(B2, -1, -1)";
            _worksheet.Cells["A1"].Value = 10d;
            _worksheet.Calculate();
            Assert.AreEqual(10d, _worksheet.Cells["C3"].Value);
        }
    }
}
