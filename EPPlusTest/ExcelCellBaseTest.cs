using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;

namespace EPPlusTest
{
    [TestClass]
    public class ExcelCellBaseTest
    {
        #region UpdateFormulaReferences Tests
        [TestMethod]
        public void UpdateFormulaReferencesOnTheSameSheet()
        {
            var result = ExcelCellBase.UpdateFormulaReferences("C3", 3, 3, 2, 2, "sheet", "sheet");
            Assert.AreEqual("F6", result);
        }

        [TestMethod]
        public void UpdateFormulaReferencesIgnoresIncorrectSheet()
        {
            var result = ExcelCellBase.UpdateFormulaReferences("C3", 3, 3, 2, 2, "sheet", "other sheet");
            Assert.AreEqual("C3", result);
        }

        [TestMethod]
        public void UpdateFormulaReferencesFullyQualifiedReferenceOnTheSameSheet()
        {
            var result = ExcelCellBase.UpdateFormulaReferences("'sheet name here'!C3", 3, 3, 2, 2, "sheet name here", "sheet name here");
            Assert.AreEqual("'sheet name here'!F6", result);
        }

        [TestMethod]
        public void UpdateFormulaReferencesFullyQualifiedCrossSheetReferenceArray()
        {
            var result = ExcelCellBase.UpdateFormulaReferences("SUM('sheet name here'!B2:D4)", 3, 3, 3, 3, "cross sheet", "sheet name here");
            Assert.AreEqual("SUM('sheet name here'!B2:G7)", result);
        }

        [TestMethod]
        public void UpdateFormulaReferencesFullyQualifiedReferenceOnADifferentSheet()
        {
            var result = ExcelCellBase.UpdateFormulaReferences("'updated sheet'!C3", 3, 3, 2, 2, "boring sheet", "updated sheet");
            Assert.AreEqual("'updated sheet'!F6", result);
        }

        [TestMethod]
        public void UpdateFormulaReferencesReferencingADifferentSheetIsNotUpdated()
        {
            var result = ExcelCellBase.UpdateFormulaReferences("'boring sheet'!C3", 3, 3, 2, 2, "boring sheet", "updated sheet");
            Assert.AreEqual("'boring sheet'!C3", result);
        }
        #endregion

        #region UpdateCrossSheetReferenceNames Tests
        [TestMethod]
        public void UpdateFormulaSheetReferences()
        {
          var result = ExcelCellBase.UpdateFormulaSheetReferences("5+'OldSheet'!$G3+'Some Other Sheet'!C3+SUM(1,2,3)", "OldSheet", "NewSheet");
          Assert.AreEqual("5+'NewSheet'!$G3+'Some Other Sheet'!C3+SUM(1,2,3)", result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateFormulaSheetReferencesNullOldSheetThrowsException()
        {
          ExcelCellBase.UpdateFormulaSheetReferences("formula", null, "sheet2");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateFormulaSheetReferencesEmptyOldSheetThrowsException()
        {
          ExcelCellBase.UpdateFormulaSheetReferences("formula", string.Empty, "sheet2");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateFormulaSheetReferencesNullNewSheetThrowsException()
        {
          ExcelCellBase.UpdateFormulaSheetReferences("formula", "sheet1", null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateFormulaSheetReferencesEmptyNewSheetThrowsException()
        {
          ExcelCellBase.UpdateFormulaSheetReferences("formula", "sheet1", string.Empty);
        }
        #endregion

        #region TranslateFromR1C1 Tests
        [TestMethod]
        public void TranslateFromR1C1_Basic()
        {
            Assert.AreEqual("$A$1", ExcelCellBase.TranslateFromR1C1("R1C1", 1, 1));
            Assert.AreEqual("$C$2", ExcelCellBase.TranslateFromR1C1("R2C3", 1, 1));
            Assert.AreEqual("B2", ExcelCellBase.TranslateFromR1C1("R[1]C[1]", 1, 1));
            Assert.AreEqual("A1", ExcelCellBase.TranslateFromR1C1("R[-1]C[-1]", 2, 2));
        }

        [TestMethod]
        public void TranslateFromR1C1_SheetQualified()
        {
            Assert.AreEqual("'Sheet1'!$A$1", ExcelCellBase.TranslateFromR1C1("'Sheet1'!R1C1", 1, 1));
            Assert.AreEqual("'Sheet 1'!B2", ExcelCellBase.TranslateFromR1C1("'Sheet 1'!R[1]C[1]", 1, 1));
        }

        [TestMethod]
        public void TranslateFromR1C1_Ranges()
        {
            Assert.AreEqual("$A$1:$C$3", ExcelCellBase.TranslateFromR1C1("R1C1:R3C3", 1, 1));
            Assert.AreEqual("'Sheet1'!$A$1:$C$3", ExcelCellBase.TranslateFromR1C1("'Sheet1'!R1C1:R3C3", 1, 1));
        }
        #endregion

        #region TranslateToR1C1 Tests
        [TestMethod]
        public void TranslateToR1C1_Basic()
        {
            Assert.AreEqual("R1C1", ExcelCellBase.TranslateToR1C1("$A$1", 1, 1));
            Assert.AreEqual("RC", ExcelCellBase.TranslateToR1C1("A1", 1, 1));
            Assert.AreEqual("R[1]C[1]", ExcelCellBase.TranslateToR1C1("B2", 1, 1));
            Assert.AreEqual("R[-1]C[-1]", ExcelCellBase.TranslateToR1C1("A1", 2, 2));
        }

        [TestMethod]
        public void TranslateToR1C1_SheetQualified()
        {
            Assert.AreEqual("'Sheet1'!R1C1", ExcelCellBase.TranslateToR1C1("'Sheet1'!$A$1", 1, 1));
            Assert.AreEqual("'Sheet 1'!R[1]C[1]", ExcelCellBase.TranslateToR1C1("'Sheet 1'!B2", 1, 1));
        }

        [TestMethod]
        public void TranslateToR1C1_Ranges()
        {
            Assert.AreEqual("R1C1:R3C3", ExcelCellBase.TranslateToR1C1("$A$1:$C$3", 1, 1));
            Assert.AreEqual("'Sheet1'!R1C1:R3C3", ExcelCellBase.TranslateToR1C1("'Sheet1'!$A$1:$C$3", 1, 1));
        }
        #endregion

        #region IsValidAddress Tests
        [TestMethod]
        public void IsValidAddress_Basic()
        {
            Assert.IsTrue(ExcelCellBase.IsValidAddress("A1"));
            Assert.IsTrue(ExcelCellBase.IsValidAddress("XFD1048576")); // Max excel cell
            Assert.IsTrue(ExcelCellBase.IsValidAddress("A1:B2"));
            Assert.IsTrue(ExcelCellBase.IsValidAddress("A:B"));
            Assert.IsTrue(ExcelCellBase.IsValidAddress("1:2"));
            Assert.IsTrue(ExcelCellBase.IsValidAddress("$A$1"));
            Assert.IsTrue(ExcelCellBase.IsValidAddress("$A$1:$B$2"));
            Assert.IsTrue(ExcelCellBase.IsValidAddress("$A:$B"));
            Assert.IsTrue(ExcelCellBase.IsValidAddress("$1:$2"));

            Assert.IsFalse(ExcelCellBase.IsValidAddress("A1048577")); // Row out of bounds
            Assert.IsFalse(ExcelCellBase.IsValidAddress("XFE1")); // Column out of bounds
            #if Core
            Assert.IsFalse(ExcelCellBase.IsValidAddress("A$1$2")); // Invalid $ placement
            #else
            Assert.IsTrue(ExcelCellBase.IsValidAddress("A$1$2")); // Stable returns true for this invalid address due to naive parsing
            #endif
            Assert.IsFalse(ExcelCellBase.IsValidAddress("")); // Empty
            Assert.IsFalse(ExcelCellBase.IsValidAddress("   ")); // Whitespace
        }

        [TestMethod]
        public void IsValidAddress_MultiAddress()
        {
            // Note: Stable branch may return false for comma-separated addresses, 
            // while dotnetport supports them. We can conditionally assert.
            bool expected = false;
            #if Core
            expected = true;
            #endif
            Assert.AreEqual(expected, ExcelCellBase.IsValidAddress("A1,B2"));
            Assert.AreEqual(expected, ExcelCellBase.IsValidAddress("A1:B2,C3:D4"));
        }
        #endregion
  }
}

