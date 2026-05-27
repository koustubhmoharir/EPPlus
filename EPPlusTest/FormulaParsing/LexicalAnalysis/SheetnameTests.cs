using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml.FormulaParsing.LexicalAnalysis;
using OfficeOpenXml.FormulaParsing;
using System.Linq;

namespace EPPlusTest.FormulaParsing.LexicalAnalysis
{
    [TestClass]
    public class SheetnameTests
    {
        [TestMethod]
        public void Tokenize_ShouldHandleEscapedSingleQuoteInSheetName()
        {
            var context = ParsingContext.Create();
            var tokenizer = new SourceCodeTokenizer(context.Configuration.FunctionRepository, null);
            var input = "'Sheet''1'!A1";
            var tokens = tokenizer.Tokenize(input).ToList();

            System.Console.WriteLine("Token count: " + tokens.Count);
            foreach (var token in tokens)
            {
                System.Console.WriteLine(token.TokenType + ": " + token.Value);
            }

            // In EPPlus, these are merged into a single ExcelAddress token
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(TokenType.ExcelAddress, tokens[0].TokenType);
            Assert.AreEqual("'Sheet''1'!A1", tokens[0].Value);
        }
    }
}
