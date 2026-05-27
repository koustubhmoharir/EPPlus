using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml.FormulaParsing.LexicalAnalysis;
using OfficeOpenXml.FormulaParsing;

namespace EPPlusTest.FormulaParsing.LexicalAnalysis
{
    [TestClass]
    public class R1C1Tests
    {
        private SourceCodeTokenizer _tokenizer;
        private SourceCodeTokenizer _r1c1Tokenizer;

        [TestInitialize]
        public void Setup()
        {
            var context = ParsingContext.Create();
            _tokenizer = new SourceCodeTokenizer(context.Configuration.FunctionRepository, null, false);
            _r1c1Tokenizer = new SourceCodeTokenizer(context.Configuration.FunctionRepository, null, true);
        }

        [TestMethod]
        public void ShouldTokenizeAbsoluteR1C1AddressAsNameValueWhenR1C1IsDisabled()
        {
            var input = "R1C1";
            var tokens = _tokenizer.Tokenize(input);
            Assert.AreEqual(TokenType.NameValue, tokens.First().TokenType);
        }

        [TestMethod]
        public void ShouldTokenizeAbsoluteR1C1AddressAsR1C1WhenEnabled()
        {
            var input = "R1C1";
            var tokens = _r1c1Tokenizer.Tokenize(input);
            Assert.AreEqual(TokenType.ExcelAddressR1C1, tokens.First().TokenType);
        }

        [TestMethod]
        public void ShouldTokenizeRelativeR1C1AddressAsR1C1WhenEnabled()
        {
            var input = "R[1]C[1]";
            var tokens = _r1c1Tokenizer.Tokenize(input);
            Assert.AreEqual(TokenType.ExcelAddressR1C1, tokens.First().TokenType);
        }

        [TestMethod]
        public void ShouldTokenizeWorksheetR1C1AddressAsR1C1WhenEnabled()
        {
            var input = "'Sheet1'!R1C1";
            var tokens = _r1c1Tokenizer.Tokenize(input);
            Assert.AreEqual(TokenType.ExcelAddressR1C1, tokens.First().TokenType);
        }

        [TestMethod]
        public void ShouldTokenizeR1C1RangeAsR1C1WhenEnabled()
        {
            var input = "R1C1:R2C2";
            var tokens = _r1c1Tokenizer.Tokenize(input);
            Assert.AreEqual(TokenType.ExcelAddressR1C1, tokens.First().TokenType);
        }
    }
}
