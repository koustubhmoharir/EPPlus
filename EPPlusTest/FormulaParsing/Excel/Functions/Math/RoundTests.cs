using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml.FormulaParsing;
using OfficeOpenXml.FormulaParsing.Excel.Functions;
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
            var result2 = func.Execute(args, _parsingContext);
            Assert.AreEqual(1200d, result2.Result);
            
            // ROUND(1250, -2) -> 1300
            args = FunctionsHelper.CreateArgs(1250, -2);
            var result3 = func.Execute(args, _parsingContext);
            Assert.AreEqual(1300d, result3.Result);
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
            var result2 = func.Execute(args, _parsingContext);
            Assert.AreEqual(-2d, result2.Result);

            // ROUND(-1235, -1) -> -1240
            args = FunctionsHelper.CreateArgs(-1235, -1);
            var result3 = func.Execute(args, _parsingContext);
            Assert.AreEqual(-1240d, result3.Result);
        }

        [TestMethod]
        public void RoundPositiveToOnesDownLiteral()
        {
            Round round = new Round();
            double value1 = 123.45;
            int digits = 0;
            var result = round.Execute(new FunctionArgument[]
            {
                new FunctionArgument(value1),
                new FunctionArgument(digits)
            }, _parsingContext);
            Assert.AreEqual(123D, result.Result);
        }

        [TestMethod]
        public void RoundPositiveToOnesUpLiteral()
        {
            Round round = new Round();
            double value1 = 123.65;
            int digits = 0;
            var result = round.Execute(new FunctionArgument[]
            {
                new FunctionArgument(value1),
                new FunctionArgument(digits)
            }, _parsingContext);
            Assert.AreEqual(124D, result.Result);
        }

        [TestMethod]
        public void RoundPositiveToTenthsDownLiteral()
        {
            Round round = new Round();
            double value1 = 123.44;
            int digits = 1;
            var result = round.Execute(new FunctionArgument[]
            {
                new FunctionArgument(value1),
                new FunctionArgument(digits)
            }, _parsingContext);
            Assert.AreEqual(123.4D, result.Result);
        }

        [TestMethod]
        public void RoundPositiveToTenthsUpLiteral()
        {
            Round round = new Round();
            double value1 = 123.456;
            int digits = 1;
            var result = round.Execute(new FunctionArgument[]
            {
                new FunctionArgument(value1),
                new FunctionArgument(digits)
            }, _parsingContext);
            Assert.AreEqual(123.5D, result.Result);
        }

        [TestMethod]
        public void RoundPositiveToTensDownLiteral()
        {
            Round round = new Round();
            double value1 = 124;
            int digits = -1;
            var result = round.Execute(new FunctionArgument[]
            {
                new FunctionArgument(value1),
                new FunctionArgument(digits)
            }, _parsingContext);
            Assert.AreEqual(120D, result.Result);
        }

        [TestMethod]
        public void RoundPositiveToTensUpLiteral()
        {
            Round round = new Round();
            double value1 = 125;
            int digits = -1;
            var result = round.Execute(new FunctionArgument[]
            {
                new FunctionArgument(value1),
                new FunctionArgument(digits)
            }, _parsingContext);
            Assert.AreEqual(130D, result.Result);
        }

        [TestMethod]
        public void RoundNegativeToTensDownLiteral()
        {
            Round round = new Round();
            double value1 = -124;
            int digits = -1;
            var result = round.Execute(new FunctionArgument[]
            {
                new FunctionArgument(value1),
                new FunctionArgument(digits)
            }, _parsingContext);
            Assert.AreEqual(-120D, result.Result);
        }

        [TestMethod]
        public void RoundNegativeToTensUpLiteral()
        {
            Round round = new Round();
            double value1 = -125;
            int digits = -1;
            var result = round.Execute(new FunctionArgument[]
            {
                new FunctionArgument(value1),
                new FunctionArgument(digits)
            }, _parsingContext);
            Assert.AreEqual(-130D, result.Result);
        }

        [TestMethod]
        public void RoundNegativeToTenthsDownLiteral()
        {
            Round round = new Round();
            double value1 = -123.44;
            int digits = 1;
            var result = round.Execute(new FunctionArgument[]
            {
                new FunctionArgument(value1),
                new FunctionArgument(digits)
            }, _parsingContext);
            Assert.AreEqual(-123.4D, result.Result);
        }

        [TestMethod]
        public void RoundNegativeToTenthsUpLiteral()
        {
            Round round = new Round();
            double value1 = -123.456;
            int digits = 1;
            var result = round.Execute(new FunctionArgument[]
            {
                new FunctionArgument(value1),
                new FunctionArgument(digits)
            }, _parsingContext);
            Assert.AreEqual(-123.5D, result.Result);
        }

        [TestMethod]
        public void RoundNegativeMidwayLiteral()
        {
            Round round = new Round();
            double value1 = -123.5;
            int digits = 0;
            var result = round.Execute(new FunctionArgument[]
            {
                new FunctionArgument(value1),
                new FunctionArgument(digits)
            }, _parsingContext);
            Assert.AreEqual(-124D, result.Result);
        }

        [TestMethod]
        public void RoundPositiveMidwayLiteral()
        {
            Round round = new Round();
            double value1 = 123.5;
            int digits = 0;
            var result = round.Execute(new FunctionArgument[]
            {
                new FunctionArgument(value1),
                new FunctionArgument(digits)
            }, _parsingContext);
            Assert.AreEqual(124D, result.Result);
        }
    }
}
