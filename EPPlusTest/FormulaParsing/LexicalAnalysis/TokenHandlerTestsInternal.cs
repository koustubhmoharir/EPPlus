using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml.FormulaParsing.LexicalAnalysis;
using OfficeOpenXml.FormulaParsing;
using System.Reflection;

namespace EPPlusTest.FormulaParsing.LexicalAnalysis
{
    [TestClass]
    public class TokenHandlerTestsInternal
    {
        [TestMethod]
        public void CharIsTokenSeparator_ShouldReturnTrueForSingleQuote()
        {
            var context = ParsingContext.Create();
            var tokenFactory = new TokenFactory(context.Configuration.FunctionRepository, null);
            var separatorProvider = new TokenSeparatorProvider();
            var handler = new TokenHandler(new TokenizerContext("'"), tokenFactory, separatorProvider);

            var method = typeof(TokenHandler).GetMethod("CharIsTokenSeparator", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] args = new object[] { '\'', null };
            bool result = (bool)method.Invoke(handler, args);

            Assert.IsTrue(result, "CharIsTokenSeparator should return true for single quote");
            var token = (Token)args[1];
            Assert.IsNotNull(token);
            Assert.AreEqual(TokenType.WorksheetName, token.TokenType);
        }
    }
}
