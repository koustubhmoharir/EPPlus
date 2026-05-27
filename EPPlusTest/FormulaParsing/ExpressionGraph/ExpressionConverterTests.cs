using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml.FormulaParsing.ExpressionGraph;
using OfficeOpenXml.FormulaParsing.Excel.Operators;
using System.Globalization;
using System.Threading;
using OfficeOpenXml;

namespace EPPlusTest.FormulaParsing.ExpressionGraph
{
    [TestClass]
    public class ExpressionConverterTests
    {
        private IExpressionConverter _converter;

        [TestInitialize]
        public void Setup()
        {
            _converter = new ExpressionConverter();
        }

        [TestMethod]
        public void InstanceShouldReturnAnInstance()
        {
            Assert.IsNotNull(ExpressionConverter.Instance);
            Assert.IsInstanceOfType(ExpressionConverter.Instance, typeof(ExpressionConverter));
        }

        [TestMethod]
        public void ToStringExpressionShouldConvertIntegerExpressionToStringExpression()
        {
            var integerExpression = new IntegerExpression("2");
            var result = _converter.ToStringExpression(integerExpression);
            Assert.IsInstanceOfType(result, typeof(StringExpression));
            Assert.AreEqual("2", result.Compile().Result);
        }

        [TestMethod]
        public void ToStringExpressionShouldCopyOperatorToStringExpression()
        {
            var integerExpression = new IntegerExpression("2");
            integerExpression.Operator = Operator.Plus;
            var result = _converter.ToStringExpression(integerExpression);
            Assert.AreEqual(integerExpression.Operator, result.Operator);
        }

        [TestMethod]
        public void ToStringExpressionShouldConvertDecimalExpressionToStringExpression()
        {
            var decimalExpression = new DecimalExpression("2.5");
            var result = _converter.ToStringExpression(decimalExpression);
            Assert.IsInstanceOfType(result, typeof(StringExpression));
            Assert.AreEqual($"2{CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator}5", result.Compile().Result);
        }

        [TestMethod]
        public void FromCompileResultShouldCreateIntegerExpressionIfCompileResultIsInteger()
        {
            var compileResult = new CompileResult(1, DataType.Integer);
            var result = _converter.FromCompileResult(compileResult);
            Assert.IsInstanceOfType(result, typeof(IntegerExpression));
            Assert.AreEqual(1d, result.Compile().Result);
        }

        [TestMethod]
        public void FromCompileResultShouldCreateIntegerExpressionIfCompileResultIsIntegerString()
        {
            var compileResult = new CompileResult("1", DataType.Integer);
            var result = _converter.FromCompileResult(compileResult);
            Assert.IsInstanceOfType(result, typeof(IntegerExpression));
            Assert.AreEqual(1d, result.Compile().Result);
        }

        [TestMethod]
        public void FromCompileResultShouldCreateStringExpressionIfCompileResultIsString()
        {
            var compileResult = new CompileResult("abc", DataType.String);
            var result = _converter.FromCompileResult(compileResult);
            Assert.IsInstanceOfType(result, typeof(StringExpression));
            Assert.AreEqual("abc", result.Compile().Result);
        }

        [TestMethod]
        public void FromCompileResultShouldCreateDecimalExpressionIfCompileResultIsDecimal()
        {
            var compileResult = new CompileResult(2.5d, DataType.Decimal);
            var result = _converter.FromCompileResult(compileResult);
            Assert.IsInstanceOfType(result, typeof(DecimalExpression));
            Assert.AreEqual(2.5d, result.Compile().Result);
        }

        [TestMethod]
        public void FromCompileResultShouldCreateDecimalExpressionIfCompileResultIsDecimalString()
        {
            var compileResult = new CompileResult("2.5", DataType.Decimal);
            var result = _converter.FromCompileResult(compileResult);
            Assert.IsInstanceOfType(result, typeof(DecimalExpression));
            Assert.AreEqual(2.5d, result.Compile().Result);
        }

        [TestMethod]
        public void FromCompileResultShouldCreateBooleanExpressionIfCompileResultIsBoolean()
        {
            var compileResult = new CompileResult(true, DataType.Boolean);
            var result = _converter.FromCompileResult(compileResult);
            Assert.IsInstanceOfType(result, typeof(BooleanExpression));
            Assert.IsTrue((bool)result.Compile().Result);
        }

        [TestMethod]
        public void FromCompileResultShouldCreateBooleanExpressionIfCompileResultIsBooleanString()
        {
            var compileResult = new CompileResult("true", DataType.Boolean);
            var result = _converter.FromCompileResult(compileResult);
            Assert.IsInstanceOfType(result, typeof(BooleanExpression));
            Assert.IsTrue((bool)result.Compile().Result);
        }

        [TestMethod]
        public void FromCompileResultShouldCreateExcelErrorExpressionIfCompileResultIsExcelError()
        {
            var compileResult = new CompileResult(ExcelErrorValue.Div0, DataType.ExcelError);
            var result = _converter.FromCompileResult(compileResult);
            Assert.IsInstanceOfType(result, typeof(ExcelErrorExpression));
            Assert.AreEqual(ExcelErrorValue.Div0, result.Compile().Result);
        }

        [TestMethod]
        public void FromCompileResultShouldCreateExcelErrorExpressionIfCompileResultIsExcelErrorString()
        {
            var compileResult = new CompileResult("#DIV/0!", DataType.ExcelError);
            var result = _converter.FromCompileResult(compileResult);
            Assert.IsInstanceOfType(result, typeof(ExcelErrorExpression));
            Assert.AreEqual(ExcelErrorValue.Div0, result.Compile().Result);
        }

        [TestMethod]
        public void FromCompileResultShouldCreateIntegerExpressionIfCompileResultIsEmpty()
        {
            var compileResult = new CompileResult(null, DataType.Empty);
            var result = _converter.FromCompileResult(compileResult);
            Assert.IsInstanceOfType(result, typeof(IntegerExpression));
            Assert.AreEqual(0d, result.Compile().Result);
        }

        [TestMethod]
        public void FromCompileResultShouldCreateDecimalExpressionIfCompileResultIsDate()
        {
            var compileResult = new CompileResult(44000d, DataType.Date);
            var result = _converter.FromCompileResult(compileResult);
            // On stable this returns null. We expect DecimalExpression on dotnetport.
#if Core
            Assert.IsInstanceOfType(result, typeof(DecimalExpression));
            Assert.AreEqual(44000d, result.Compile().Result);
#else
            Assert.IsNull(result);
#endif
        }

        [TestMethod]
        public void FromCompileResultShouldCreateDecimalExpressionIfCompileResultIsTime()
        {
            var compileResult = new CompileResult(0.5d, DataType.Time);
            var result = _converter.FromCompileResult(compileResult);
            // On stable this returns null. We expect DecimalExpression on dotnetport.
#if Core
            Assert.IsInstanceOfType(result, typeof(DecimalExpression));
            Assert.AreEqual(0.5d, result.Compile().Result);
#else
            Assert.IsNull(result);
#endif
        }
    }
}
