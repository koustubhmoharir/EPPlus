using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml.FormulaParsing.LexicalAnalysis;
using OfficeOpenXml.FormulaParsing.LexicalAnalysis.TokenSeparatorHandlers;
using System.Linq;

namespace EPPlusTest.FormulaParsing.LexicalAnalysis
{
    [TestClass]
    public class SheetnameHandlerTests
    {
        private class FakeIndexProvider : ITokenIndexProvider
        {
            public int Index { get; set; }
            public void MoveIndexPointerForward() { Index++; }
        }

        [TestMethod]
        public void Handle_ShouldHandleEscapedSingleQuote()
        {
            var handler = new SheetnameHandler();
            var input = "'Sheet''1'";
            var context = new TokenizerContext(input);
            var indexProvider = new FakeIndexProvider();
            
            var tokenSeparator = new Token("'", TokenType.WorksheetName);
            
            // 1. First '
            indexProvider.Index = 0;
            bool handled = handler.Handle('\'', tokenSeparator, context, indexProvider);
            Assert.IsTrue(handled);
            Assert.IsTrue(context.IsInSheetName);
            Assert.AreEqual(1, context.Result.Count);
            Assert.AreEqual("'", context.Result[0].Value);
            Assert.AreEqual(string.Empty, context.CurrentToken);
            
            // simulate chars S h e e t
            context.AppendToCurrentToken('S');
            context.AppendToCurrentToken('h');
            context.AppendToCurrentToken('e');
            context.AppendToCurrentToken('e');
            context.AppendToCurrentToken('t');
            
            // 2. First ' of ''
            indexProvider.Index = 6;
            handled = handler.Handle('\'', tokenSeparator, context, indexProvider);
            Assert.IsTrue(handled);
            Assert.AreEqual(7, indexProvider.Index); // MoveIndexPointerForward was called
            Assert.AreEqual("Sheet''", context.CurrentToken);
            
            // simulate char 1
            context.AppendToCurrentToken('1');
            
            // 3. Last '
            indexProvider.Index = 9;
            handled = handler.Handle('\'', tokenSeparator, context, indexProvider);
            Assert.IsTrue(handled);
            Assert.IsFalse(context.IsInSheetName);
            Assert.AreEqual(3, context.Result.Count);
            Assert.AreEqual("Sheet''1", context.Result[1].Value);
            Assert.AreEqual(TokenType.WorksheetNameContent, context.Result[1].TokenType);
            Assert.AreEqual("'", context.Result[2].Value);
        }

        [TestMethod]
        public void Handle_ShouldToggleIsInSheetName()
        {
            var handler = new SheetnameHandler();
            var context = new TokenizerContext("'Sheet1'");
            var indexProvider = new FakeIndexProvider();
            var tokenSeparator = new Token("'", TokenType.WorksheetName);

            // Open
            handler.Handle('\'', tokenSeparator, context, indexProvider);
            Assert.IsTrue(context.IsInSheetName);

            // Close
            indexProvider.Index = 7;
            handler.Handle('\'', tokenSeparator, context, indexProvider);
            Assert.IsFalse(context.IsInSheetName);
        }
    }
}
