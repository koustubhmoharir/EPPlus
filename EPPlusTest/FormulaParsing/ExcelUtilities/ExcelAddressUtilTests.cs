using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml.FormulaParsing.ExcelUtilities;

namespace EPPlusTest.FormulaParsing.ExcelUtilities
{
    [TestClass]
    public class ExcelAddressUtilTests
    {
        [TestMethod]
        public void IsValidName_ShouldReturnFalse_IfNameIsEmpty()
        {
            Assert.IsFalse(ExcelAddressUtil.IsValidName(""));
            Assert.IsFalse(ExcelAddressUtil.IsValidName(null));
        }

        [TestMethod]
        public void IsValidName_ShouldReturnFalse_IfFirstCharIsInvalid()
        {
            Assert.IsFalse(ExcelAddressUtil.IsValidName("1Name"));
            Assert.IsFalse(ExcelAddressUtil.IsValidName("!Name"));
            Assert.IsFalse(ExcelAddressUtil.IsValidName(" Name"));
        }

        [TestMethod]
        public void IsValidName_ShouldReturnTrue_IfFirstCharIsLetterOrUnderscore()
        {
            Assert.IsTrue(ExcelAddressUtil.IsValidName("aName"));
            Assert.IsTrue(ExcelAddressUtil.IsValidName("_Name"));
        }

        [TestMethod]
        public void IsValidName_ShouldReturnTrue_IfFirstCharIsBackslashAndLengthGreaterThan2()
        {
            Assert.IsTrue(ExcelAddressUtil.IsValidName("\\abc"));
        }

        [TestMethod]
        public void IsValidName_ShouldReturnFalse_IfFirstCharIsBackslashAndLengthIs2OrLess()
        {
            Assert.IsFalse(ExcelAddressUtil.IsValidName("\\"));
            Assert.IsFalse(ExcelAddressUtil.IsValidName("\\a"));
        }

        [TestMethod]
        public void IsValidName_ShouldReturnFalse_IfContainsInvalidChars()
        {
            Assert.IsFalse(ExcelAddressUtil.IsValidName("Name!"));
            Assert.IsFalse(ExcelAddressUtil.IsValidName("Name@"));
            Assert.IsFalse(ExcelAddressUtil.IsValidName("Name#"));
            Assert.IsFalse(ExcelAddressUtil.IsValidName("Name$"));
            Assert.IsFalse(ExcelAddressUtil.IsValidName("Name "));
            Assert.IsFalse(ExcelAddressUtil.IsValidName("Name,"));
        }

        [TestMethod]
        public void IsValidName_ShouldReturnFalse_IfIsAValidCellAddress()
        {
            Assert.IsFalse(ExcelAddressUtil.IsValidName("A1"));
            Assert.IsFalse(ExcelAddressUtil.IsValidName("XFD1048576"));
        }

        [TestMethod]
        public void IsValidName_ShouldReturnTrue_IfIsValid()
        {
            Assert.IsTrue(ExcelAddressUtil.IsValidName("ValidName"));
            Assert.IsTrue(ExcelAddressUtil.IsValidName("_ValidName"));
            Assert.IsTrue(ExcelAddressUtil.IsValidName("Valid_Name_123"));
        }

        [TestMethod]
        public void GetValidName_ShouldReturnOriginal_IfEmpty()
        {
            Assert.AreEqual("", ExcelAddressUtil.GetValidName(""));
            Assert.IsNull(ExcelAddressUtil.GetValidName(null));
        }

        [TestMethod]
        public void GetValidName_ShouldFixFirstChar()
        {
            Assert.AreEqual("_Name", ExcelAddressUtil.GetValidName("1Name"));
        }

        [TestMethod]
        public void GetValidName_ShouldReplaceInvalidChars()
        {
            Assert.AreEqual("Name_", ExcelAddressUtil.GetValidName("Name!"));
            Assert.AreEqual("Name_With_Spaces", ExcelAddressUtil.GetValidName("Name With Spaces"));
            Assert.AreEqual("Complex_Name_With_Multiple_Invalid_Chars", ExcelAddressUtil.GetValidName("Complex!Name@With#Multiple$Invalid%Chars"));
        }
    }
}
