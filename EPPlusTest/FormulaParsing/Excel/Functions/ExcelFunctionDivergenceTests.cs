using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml.FormulaParsing.Excel.Functions;
using OfficeOpenXml.FormulaParsing.ExpressionGraph;
using OfficeOpenXml.FormulaParsing;
using EPPlusTest.FormulaParsing.TestHelpers;
using OfficeOpenXml;

namespace EPPlusTest.Excel.Functions
{
    [TestClass]
    public class ExcelFunctionDivergenceTests
    {
        private class ExcelFunctionTester : ExcelFunction
        {
            public override CompileResult Execute(IEnumerable<FunctionArgument> arguments, ParsingContext context)
            {
                throw new NotImplementedException();
            }

            public bool IsNumericPublic(object val)
            {
                return IsNumeric(val);
            }

            // Mocking the new ArgToAddress behavior from dotnetport
            public string ArgToAddressPublic(IEnumerable<FunctionArgument> arguments, int index)
            {
                var arg = arguments.ElementAt(index);
                if (arg.IsExcelRange)
                {
                    var address = arg.ValueAsRangeInfo.Address;
                    var property = address.GetType().GetProperty("FullAddress", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                    return (string)property.GetValue(address);
                }
                return ArgToString(arguments, index);
            }
        }

        private class MockRangeInfo : ExcelDataProvider.IRangeInfo
        {
            public ExcelAddressBase Address { get; set; }
            public bool IsEmpty { get; set; }
            public bool IsMulti { get; set; }
            public bool IsScalar { get; set; }
            public int GetNCells() => 1;
            public object GetValue(int row, int col) => null;
            public object GetOffset(int rowOffset, int colOffset) => null;
            public ExcelWorksheet Worksheet => null;

            public ExcelDataProvider.ICellInfo Current => null;
            object IEnumerator.Current => null;
            public void Dispose() { }
            public bool MoveNext() => false;
            public void Reset() { }
            public IEnumerator<ExcelDataProvider.ICellInfo> GetEnumerator() => null;
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        [TestMethod]
        public void IsNumeric_ShouldReturnTrueForNumericTypes()
        {
            var tester = new ExcelFunctionTester();
            Assert.IsTrue(tester.IsNumericPublic(1));
            Assert.IsTrue(tester.IsNumericPublic(1.0));
            Assert.IsTrue(tester.IsNumericPublic(1m));
            Assert.IsTrue(tester.IsNumericPublic(DateTime.Now));
            Assert.IsTrue(tester.IsNumericPublic(TimeSpan.FromHours(1)));
        }

        [TestMethod]
        public void IsNumeric_ShouldReturnFalseForNonNumericTypes()
        {
            var tester = new ExcelFunctionTester();
            Assert.IsFalse(tester.IsNumericPublic("1"));
            Assert.IsFalse(tester.IsNumericPublic(null));
            Assert.IsFalse(tester.IsNumericPublic(new object()));
        }

        [TestMethod]
        public void ArgToAddress_ShouldReturnAddressForRange()
        {
            var tester = new ExcelFunctionTester();
            var rangeInfo = new MockRangeInfo { Address = new ExcelAddressBase(1, 1, 2, 2) };
            var args = new List<FunctionArgument> { new FunctionArgument(rangeInfo) };

            var result = tester.ArgToAddressPublic(args, 0);

            Assert.AreEqual("A1:B2", result);
        }

        [TestMethod]
        public void ArgToAddress_ShouldReturnStringForNonRange()
        {
            var tester = new ExcelFunctionTester();
            var args = new List<FunctionArgument> { new FunctionArgument("SomeString") };

            var result = tester.ArgToAddressPublic(args, 0);

            Assert.AreEqual("SomeString", result);
        }
    }
}
