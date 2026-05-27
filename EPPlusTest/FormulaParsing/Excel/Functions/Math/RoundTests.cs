using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml.FormulaParsing;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using EPPlusTest.FormulaParsing.TestHelpers;
using OfficeOpenXml.FormulaParsing.ExcelUtilities;

namespace EPPlusTest.Excel.Functions
{
    [TestClass]
    public class RoundTests
    {
        private ParsingContext _parsingContext;

        [TestInitialize]
        public void Initialize()
        {
            _parsingContext = ParsingContext.Create();
            _parsingContext.Scopes.NewScope(RangeAddress.Empty);
        }

        [TestMethod]
        public void RoundShouldReturnCorrectResultForPositiveDigits()
        {
            var func = new Round();
            var args = FunctionsHelper.CreateArgs(2.3433, 3);
            var result = func.Execute(args, _parsingContext);
            Assert.AreEqual(2.343d, result.Result);
        }

        [TestMethod]
        public void RoundShouldUseAwayFromZeroRounding()
        {
            var func = new Round();
            // In Banker's rounding (default in .NET), 2.5 rounds to 2.
            // In Excel, 2.5 rounds to 3.
            var args = FunctionsHelper.CreateArgs(2.5, 0);
            var result = func.Execute(args, _parsingContext);
            Assert.AreEqual(3d, result.Result, "Should use AwayFromZero rounding for 2.5");

            args = FunctionsHelper.CreateArgs(3.5, 0);
            result = func.Execute(args, _parsingContext);
            Assert.AreEqual(4d, result.Result, "Should use AwayFromZero rounding for 3.5");
        }

        [TestMethod]
        public void RoundShouldHandleNegativeDigitsCorrectly()
        {
            var func = new Round();
            // ROUND(1234.56, -1) -> 1230
            var args = FunctionsHelper.CreateArgs(1234.56, -1);
            var result = func.Execute(args, _parsingContext);
            Assert.AreEqual(1230d, result.Result);

            // ROUND(1235, -1) -> 1240
            args = FunctionsHelper.CreateArgs(1235, -1);
            result = func.Execute(args, _parsingContext);
            Assert.AreEqual(1240d, result.Result, "Should round up for midpoint with negative digits");

            // ROUND(1234.56, -2) -> 1200
            args = FunctionsHelper.CreateArgs(1234.56, -2);
            result = func.Execute(args, _parsingContext);
            Assert.AreEqual(1200d, result.Result);
            
            // ROUND(1250, -2) -> 1300
            args = FunctionsHelper.CreateArgs(1250, -2);
            result = func.Execute(args, _parsingContext);
            Assert.AreEqual(1300d, result.Result);
        }

        [TestMethod]
        public void RoundShouldHandleNegativeNumbersCorrectly()
        {
            var func = new Round();
            // ROUND(-2.5, 0) -> -3
            var args = FunctionsHelper.CreateArgs(-2.5, 0);
            var result = func.Execute(args, _parsingContext);
            Assert.AreEqual(-3d, result.Result);

            // ROUND(-2.4, 0) -> -2
            args = FunctionsHelper.CreateArgs(-2.4, 0);
            result = func.Execute(args, _parsingContext);
            Assert.AreEqual(-2d, result.Result);

            // ROUND(-1235, -1) -> -1240
            args = FunctionsHelper.CreateArgs(-1235, -1);
            result = func.Execute(args, _parsingContext);
            Assert.AreEqual(-1240d, result.Result);
        }
    }
}
