using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml.FormulaParsing.Excel.Functions;

namespace EPPlusTest.Excel.Functions
{
    [TestClass]
    public class ExcelDoubleCellValueTests
    {
        [TestMethod]
        public void GetHashCode_ShouldReturnSameValue_ForEqualObjects()
        {
            var val1 = new ExcelDoubleCellValue(1.23);
            var val2 = new ExcelDoubleCellValue(1.23);
            
            Assert.AreEqual(val1, val2);
            Assert.AreEqual(val1.GetHashCode(), val2.GetHashCode());
        }

        [TestMethod]
        public void GetHashCode_ShouldReturnSameValue_ForEqualObjectsWithRow()
        {
            var val1 = new ExcelDoubleCellValue(1.23, 1);
            var val2 = new ExcelDoubleCellValue(1.23, 1);
            
            Assert.AreEqual(val1, val2);
            Assert.AreEqual(val1.GetHashCode(), val2.GetHashCode());
        }

        [TestMethod]
        public void Equals_ShouldReturnFalse_ForDifferentValues()
        {
            var val1 = new ExcelDoubleCellValue(1.23);
            var val2 = new ExcelDoubleCellValue(4.56);
            
            Assert.AreNotEqual(val1, val2);
        }
        
        [TestMethod]
        public void Equals_ShouldReturnTrue_ForSameValueDifferentRow()
        {
            var val1 = new ExcelDoubleCellValue(1.23, 1);
            var val2 = new ExcelDoubleCellValue(1.23, 2);
            
            Assert.AreEqual(val1, val2);
            // If they are equal, they MUST have the same hash code.
            Assert.AreEqual(val1.GetHashCode(), val2.GetHashCode());
        }
    }
}
