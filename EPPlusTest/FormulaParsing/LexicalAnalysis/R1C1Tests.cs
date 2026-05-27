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

        [TestInitialize]
        public void Setup()
        {
            var context = ParsingContext.Create();
            _tokenizer = new SourceCodeTokenizer(context.Configuration.FunctionRepository, null);
        }

        [TestMethod]
        public void ShouldTokenizeAbsoluteR1C1AddressAsNameValueInStable()
        {
            var input = "R1C1";
            var tokens = _tokenizer.Tokenize(input);
            Assert.AreEqual(TokenType.NameValue, tokens.First().TokenType);
        }

        [TestMethod]
        public void ShouldTokenizeRelativeR1C1AddressAsExcelAddressInStable()
        {
            // Stable incorrectly identifies R[1]C[1] as a table reference because of the brackets
            var input = "R[1]C[1]";
            var tokens = _tokenizer.Tokenize(input);
            Assert.AreEqual(TokenType.ExcelAddress, tokens.First().TokenType);
        }

        [TestMethod]
        public void ShouldTokenizeWorksheetR1C1AddressAsInvalidInStable()
        {
            var input = "'Sheet1'!R1C1";
            var tokens = _tokenizer.Tokenize(input);
            Assert.AreEqual(TokenType.InvalidReference, tokens.First().TokenType);
        }
    }
}
