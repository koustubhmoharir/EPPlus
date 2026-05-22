using System;
using System.Globalization;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml.Utils;

namespace EPPlusTest.Utils
{
    [TestClass]
    public class ConvertUtilTest
    {
        private static MethodInfo GetMethod(string name)
        {
            return typeof(ConvertUtil).GetMethod(name, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        }

        private static object Invoke(string name, params object[] args)
        {
            var method = GetMethod(name);
            if (method == null) throw new Exception("Method not found: " + name);
            return method.Invoke(null, args);
        }

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
        public void TryParseNumericString2()
        {
            var method = typeof(ConvertUtil).GetMethod("TryParseNumericString", BindingFlags.Static | BindingFlags.NonPublic);
            
            double result;
            object[] args = new object[] { null, 0.0 };
            bool success = (bool)method.Invoke(null, args);
            Assert.IsFalse(success);
            Assert.AreEqual(0.0, (double)args[1]);

            double expected = 1442.0;
            args[0] = expected.ToString("e", CultureInfo.CurrentCulture);
            success = (bool)method.Invoke(null, args);
            Assert.IsTrue(success);
            Assert.AreEqual(expected, (double)args[1]);
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
        public void TryParseDateString2()
        {
            var method = typeof(ConvertUtil).GetMethod("TryParseDateString", BindingFlags.Static | BindingFlags.NonPublic);
            
            DateTime result;
            object[] args = new object[] { null, DateTime.MinValue };
            bool success = (bool)method.Invoke(null, args);
            Assert.IsFalse(success);
            Assert.AreEqual(DateTime.MinValue, (DateTime)args[1]);

            DateTime expected = new DateTime(2013, 1, 15);
            args[0] = expected.ToString("d", CultureInfo.CurrentCulture);
            success = (bool)method.Invoke(null, args);
            Assert.IsTrue(success);
            Assert.AreEqual(expected, (DateTime)args[1]);
        }

        [TestMethod]
        public void IsNumericTest()
        {
            Assert.IsTrue((bool)Invoke("IsNumeric", 1));
            Assert.IsTrue((bool)Invoke("IsNumeric", 1.0));
            Assert.IsTrue((bool)Invoke("IsNumeric", 1.0m));
            Assert.IsTrue((bool)Invoke("IsNumeric", DateTime.Now));
            Assert.IsTrue((bool)Invoke("IsNumeric", TimeSpan.Zero));
            Assert.IsTrue((bool)Invoke("IsNumeric", 1L));
            Assert.IsFalse((bool)Invoke("IsNumeric", "1"));
            Assert.IsFalse((bool)Invoke("IsNumeric", (object)null));
        }

        private T CallGetTypedCellValue<T>(object value)
        {
            var method = typeof(ConvertUtil).GetMethod("GetTypedCellValue", BindingFlags.Static | BindingFlags.Public);
            var genericMethod = method.MakeGenericMethod(typeof(T));
            return (T)genericMethod.Invoke(null, new object[] { value });
        }

        [TestMethod]
        public void GetTypedCellValue_BasicTypes()
        {
            Assert.AreEqual(1, CallGetTypedCellValue<int>(1));
            Assert.AreEqual(1.0, CallGetTypedCellValue<double>(1.0));
            Assert.AreEqual(1.0m, CallGetTypedCellValue<decimal>(1.0m));
        }

        [TestMethod]
        public void GetTypedCellValue_Nullable()
        {
            Assert.AreEqual(1, CallGetTypedCellValue<int?>(1));
            Assert.IsNull(CallGetTypedCellValue<int?>(null));
            Assert.IsNull(CallGetTypedCellValue<int?>(" "));
        }

        [TestMethod]
        public void GetTypedCellValue_DateTime()
        {
            var now = new DateTime(2026, 5, 18, 12, 0, 0);
            Assert.AreEqual(now, CallGetTypedCellValue<DateTime>(now));
            
            // Double to DateTime
            double oaDate = now.ToOADate();
            Assert.AreEqual(now, CallGetTypedCellValue<DateTime>(oaDate));
            
            // TimeSpan to DateTime
            var ts = TimeSpan.FromHours(1);
            Assert.AreEqual(new DateTime(ts.Ticks), CallGetTypedCellValue<DateTime>(ts));
        }

        [TestMethod]
        public void GetTypedCellValue_TimeSpan()
        {
            var ts = TimeSpan.FromHours(1);
            Assert.AreEqual(ts, CallGetTypedCellValue<TimeSpan>(ts));
            
            double oaTs = 0.5; // 12 hours
            var expectedTsFromOa = new TimeSpan(DateTime.FromOADate(0.5).Ticks);
            Assert.AreEqual(expectedTsFromOa, CallGetTypedCellValue<TimeSpan>(oaTs));
            
            var dtFromTs = new DateTime(ts.Ticks);
            Assert.AreEqual(ts, CallGetTypedCellValue<TimeSpan>(dtFromTs));
        }

        [TestMethod]
        public void InvariantCompareInfoTest()
        {
            var field = typeof(ConvertUtil).GetField("_invariantCompareInfo", BindingFlags.Static | BindingFlags.NonPublic);
            var ci = (CompareInfo)field.GetValue(null);
            Assert.IsNotNull(ci);
            Assert.AreEqual("", ci.Name);
        }
    }
}
