using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml.FormulaParsing.Utilities;
using System;

namespace EPPlusTest.FormulaParsing.Utilities
{
    [TestClass]
    public class ExtensionMethodsTests
    {
        [TestMethod]
        public void IsNumeric_ShouldReturnTrueForInt()
        {
            object val = 1;
            Assert.IsTrue(val.IsNumeric());
        }

        [TestMethod]
        public void IsNumeric_ShouldReturnTrueForShort()
        {
            object val = (short)1;
            Assert.IsTrue(val.IsNumeric());
        }

        [TestMethod]
        public void IsNumeric_ShouldReturnTrueForLong()
        {
            object val = 1L;
            Assert.IsTrue(val.IsNumeric());
        }

        [TestMethod]
        public void IsNumeric_ShouldReturnTrueForFloat()
        {
            object val = 1.0f;
            Assert.IsTrue(val.IsNumeric());
        }

        [TestMethod]
        public void IsNumeric_ShouldReturnTrueForDouble()
        {
            object val = 1.0;
            Assert.IsTrue(val.IsNumeric());
        }

        [TestMethod]
        public void IsNumeric_ShouldReturnTrueForDecimal()
        {
            object val = 1.0m;
            Assert.IsTrue(val.IsNumeric());
        }

        [TestMethod]
        public void IsNumeric_ShouldReturnTrueForDateTime()
        {
            object val = DateTime.Now;
            Assert.IsTrue(val.IsNumeric());
        }

        [TestMethod]
        public void IsNumeric_ShouldReturnTrueForTimeSpan()
        {
            object val = TimeSpan.FromHours(1);
            Assert.IsTrue(val.IsNumeric());
        }

        [TestMethod]
        public void IsNumeric_ShouldReturnFalseForString()
        {
            object val = "1";
            Assert.IsFalse(val.IsNumeric());
        }

        [TestMethod]
        public void IsNumeric_ShouldReturnFalseForNull()
        {
            object val = null;
            Assert.IsFalse(val.IsNumeric());
        }

        [TestMethod]
        public void IsNotNullOrEmpty_ShouldNotThrowIfValueIsSet()
        {
            var arg = new ArgumentInfo<string>("test").Named("name");
            arg.IsNotNullOrEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsNotNullOrEmpty_ShouldThrowIfValueIsEmpty()
        {
            var arg = new ArgumentInfo<string>(string.Empty).Named("name");
            arg.IsNotNullOrEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsNotNullOrEmpty_ShouldThrowIfValueIsNull()
        {
            var arg = new ArgumentInfo<string>(null).Named("name");
            arg.IsNotNullOrEmpty();
        }

        [TestMethod]
        public void IsNotNull_ShouldNotThrowIfValueIsSet()
        {
            var arg = new ArgumentInfo<object>(new object()).Named("name");
            arg.IsNotNull();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsNotNull_ShouldThrowIfValueIsNull()
        {
            var arg = new ArgumentInfo<object>(null).Named("name");
            arg.IsNotNull();
        }
    }
}
