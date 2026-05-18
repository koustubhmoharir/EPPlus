using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml.Utils;
using OfficeOpenXml.Compatibility;

namespace EPPlusTest.Utils
{
    [TestClass]
    public class ConvertUtilTest
    {
        [TestMethod]
        public void TryParseNumericString()
        {
            double result;
            object numericString = null;
            double expected = 0;
            Assert.IsFalse(ConvertUtil.TryParseNumericString(numericString, out result));
            Assert.AreEqual(expected, result);
            expected = 1442.0;
            numericString = expected.ToString("e", CultureInfo.CurrentCulture); // 1.442E+003
            Assert.IsTrue(ConvertUtil.TryParseNumericString(numericString, out result));
            Assert.AreEqual(expected, result);
            numericString = expected.ToString("f0", CultureInfo.CurrentCulture); // 1442
            Assert.IsTrue(ConvertUtil.TryParseNumericString(numericString, out result));
            Assert.AreEqual(expected, result);
            numericString = expected.ToString("f2", CultureInfo.CurrentCulture); // 1442.00
            Assert.IsTrue(ConvertUtil.TryParseNumericString(numericString, out result));
            Assert.AreEqual(expected, result);
            numericString = expected.ToString("n", CultureInfo.CurrentCulture); // 1,442.0
            Assert.IsTrue(ConvertUtil.TryParseNumericString(numericString, out result));
            Assert.AreEqual(expected, result);
            expected = -0.00526;
            numericString = expected.ToString("e", CultureInfo.CurrentCulture); // -5.26E-003
            Assert.IsTrue(ConvertUtil.TryParseNumericString(numericString, out result));
            Assert.AreEqual(expected, result);
            numericString = expected.ToString("f0", CultureInfo.CurrentCulture); // -0
            Assert.IsTrue(ConvertUtil.TryParseNumericString(numericString, out result));
            Assert.AreEqual(0.0, result);
            numericString = expected.ToString("f3", CultureInfo.CurrentCulture); // -0.005
            Assert.IsTrue(ConvertUtil.TryParseNumericString(numericString, out result));
            Assert.AreEqual(-0.005, result);
            numericString = expected.ToString("n6", CultureInfo.CurrentCulture); // -0.005260
            Assert.IsTrue(ConvertUtil.TryParseNumericString(numericString, out result));
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TryParseDateString()
        {
            DateTime result;
            object dateString = null;
            DateTime expected = DateTime.MinValue;
            Assert.IsFalse(ConvertUtil.TryParseDateString(dateString, out result));
            Assert.AreEqual(expected, result);
            expected = new DateTime(2013, 1, 15);
            dateString = expected.ToString("d", CultureInfo.CurrentCulture); // 1/15/2013
            Assert.IsTrue(ConvertUtil.TryParseDateString(dateString, out result));
            Assert.AreEqual(expected, result);
            dateString = expected.ToString("D", CultureInfo.CurrentCulture); // Tuesday, January 15, 2013
            Assert.IsTrue(ConvertUtil.TryParseDateString(dateString, out result));
            Assert.AreEqual(expected, result);
            dateString = expected.ToString("F", CultureInfo.CurrentCulture); // Tuesday, January 15, 2013 12:00:00 AM
            Assert.IsTrue(ConvertUtil.TryParseDateString(dateString, out result));
            Assert.AreEqual(expected, result);
            dateString = expected.ToString("g", CultureInfo.CurrentCulture); // 1/15/2013 12:00 AM
            Assert.IsTrue(ConvertUtil.TryParseDateString(dateString, out result));
            Assert.AreEqual(expected, result);
            expected = new DateTime(2013, 1, 15, 15, 26, 32);
            dateString = expected.ToString("F", CultureInfo.CurrentCulture); // Tuesday, January 15, 2013 3:26:32 PM
            Assert.IsTrue(ConvertUtil.TryParseDateString(dateString, out result));
            Assert.AreEqual(expected, result);
            dateString = expected.ToString("g", CultureInfo.CurrentCulture); // 1/15/2013 3:26 PM
            Assert.IsTrue(ConvertUtil.TryParseDateString(dateString, out result));
            Assert.AreEqual(new DateTime(2013, 1, 15, 15, 26, 0), result);
        }

        [TestMethod]
        public void IsNumericTest()
        {
            Assert.IsTrue(ConvertUtil.IsNumeric(1));
            Assert.IsTrue(ConvertUtil.IsNumeric(1.0));
            Assert.IsTrue(ConvertUtil.IsNumeric(1.0m));
            Assert.IsTrue(ConvertUtil.IsNumeric(DateTime.Now));
            Assert.IsTrue(ConvertUtil.IsNumeric(TimeSpan.Zero));
            Assert.IsTrue(ConvertUtil.IsNumeric(1L));
            Assert.IsFalse(ConvertUtil.IsNumeric("1"));
            Assert.IsFalse(ConvertUtil.IsNumeric(null));
        }

        [TestMethod]
        public void GetTypedCellValue_BasicTypes()
        {
            Assert.AreEqual(1, ConvertUtil.GetTypedCellValue<int>(1));
            Assert.AreEqual(1.0, ConvertUtil.GetTypedCellValue<double>(1.0));
            Assert.AreEqual(1.0m, ConvertUtil.GetTypedCellValue<decimal>(1.0m));
        }

        [TestMethod]
        public void GetTypedCellValue_Nullable()
        {
            Assert.AreEqual(1, ConvertUtil.GetTypedCellValue<int?>(1));
            Assert.IsNull(ConvertUtil.GetTypedCellValue<int?>(null));
            Assert.IsNull(ConvertUtil.GetTypedCellValue<int?>(" "));
        }

        [TestMethod]
        public void GetTypedCellValue_DateTime()
        {
            var now = new DateTime(2026, 5, 18, 12, 0, 0);
            Assert.AreEqual(now, ConvertUtil.GetTypedCellValue<DateTime>(now));
            
            // Double to DateTime
            double oaDate = now.ToOADate();
            Assert.AreEqual(now, ConvertUtil.GetTypedCellValue<DateTime>(oaDate));
            
            // TimeSpan to DateTime
            var ts = TimeSpan.FromHours(1);
            Assert.AreEqual(new DateTime(ts.Ticks), ConvertUtil.GetTypedCellValue<DateTime>(ts));
        }

        [TestMethod]
        public void GetTypedCellValue_TimeSpan()
        {
            var ts = TimeSpan.FromHours(1);
            Assert.AreEqual(ts, ConvertUtil.GetTypedCellValue<TimeSpan>(ts));
            
            double oaTs = 0.5; // 12 hours
            var expectedTsFromOa = new TimeSpan(DateTime.FromOADate(0.5).Ticks);
            Assert.AreEqual(expectedTsFromOa, ConvertUtil.GetTypedCellValue<TimeSpan>(oaTs));
            
            var dtFromTs = new DateTime(ts.Ticks);
            Assert.AreEqual(ts, ConvertUtil.GetTypedCellValue<TimeSpan>(dtFromTs));
        }

        [TestMethod]
        public void TextToInt()
        {
            var result = ConvertUtil.GetTypedCellValue<int>("204");
            Assert.AreEqual(204, result);
        }

        [TestMethod]
        public void DoubleToNullableInt()
        {
            var result = ConvertUtil.GetTypedCellValue<int?>(2D);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void StringToDecimal()
        {
            var decimalSign = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            var result = ConvertUtil.GetTypedCellValue<decimal>($"1{decimalSign}4");
            Assert.AreEqual((decimal)1.4, result);
        }

        [TestMethod]
        public void EmptyStringToNullableDecimal()
        {
            var result = ConvertUtil.GetTypedCellValue<decimal?>("");
            Assert.IsNull(result);
        }

        [TestMethod]
        public void BlankStringToNullableDecimal()
        {
            var result = ConvertUtil.GetTypedCellValue<decimal?>(" ");
            Assert.IsNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void EmptyStringToDecimal()
        {
            ConvertUtil.GetTypedCellValue<decimal>("");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void FloatingPointStringToInt()
        {
            ConvertUtil.GetTypedCellValue<int>("1.4");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void IntToDateTime()
        {
            ConvertUtil.GetTypedCellValue<DateTime>(122);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void IntToTimeSpan()
        {
            ConvertUtil.GetTypedCellValue<TimeSpan>(122);
        }

        [TestMethod]
        public void IntStringToTimeSpan()
        {
            Assert.AreEqual(TimeSpan.FromDays(122), ConvertUtil.GetTypedCellValue<TimeSpan>("122"));
        }

        [TestMethod]
        public void BoolToInt()
        {
            Assert.AreEqual(1, ConvertUtil.GetTypedCellValue<int>(true));
            Assert.AreEqual(0, ConvertUtil.GetTypedCellValue<int>(false));
        }

        [TestMethod]
        public void BoolToDecimal()
        {
            Assert.AreEqual(1m, ConvertUtil.GetTypedCellValue<decimal>(true));
            Assert.AreEqual(0m, ConvertUtil.GetTypedCellValue<decimal>(false));
        }

        [TestMethod]
        public void BoolToDouble()
        {
            Assert.AreEqual(1d, ConvertUtil.GetTypedCellValue<double>(true));
            Assert.AreEqual(0d, ConvertUtil.GetTypedCellValue<double>(false));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void BadTextToInt()
        {
            ConvertUtil.GetTypedCellValue<int>("text1");
        }

        [TestMethod]
        public void InvariantCompareInfoTest()
        {
            Assert.IsNotNull(ConvertUtil._invariantCompareInfo);
            Assert.AreEqual("", ConvertUtil._invariantCompareInfo.Name);
        }
    }
}
