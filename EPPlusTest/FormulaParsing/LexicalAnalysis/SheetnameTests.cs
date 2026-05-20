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

            Assert.IsTrue(tokens.Any(t => t.TokenType == TokenType.WorksheetNameContent && t.Value == "Sheet''1"), "WorksheetNameContent should contain double single quotes");
        }
    }
}
