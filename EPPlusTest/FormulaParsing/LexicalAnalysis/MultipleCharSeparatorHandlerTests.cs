using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml.FormulaParsing.LexicalAnalysis;
using OfficeOpenXml.FormulaParsing.LexicalAnalysis.TokenSeparatorHandlers;
using System;

namespace EPPlusTest.FormulaParsing.LexicalAnalysis
{
    [TestClass]
    public class MultipleCharSeparatorHandlerTests
    {
        [TestMethod]
        public void Handle_ShouldReturnTrueForLessThanOrEqualTo()
        {
            var handler = new MultipleCharSeparatorHandler();
            var context = new TokenizerContext("<=");
            context.AddToken(new Token("<", TokenType.Operator));
            
            bool handled = handler.Handle('=', null, context, null);
            
            Assert.IsTrue(handled);
            Assert.AreEqual("<=", context.LastToken.Value);
            Assert.AreEqual(TokenType.Operator, context.LastToken.TokenType);
        }

        [TestMethod]
        public void Handle_ShouldReturnTrueForGreaterThanOrEqualTo()
        {
            var handler = new MultipleCharSeparatorHandler();
            var context = new TokenizerContext(">=");
            context.AddToken(new Token(">", TokenType.Operator));
            
            bool handled = handler.Handle('=', null, context, null);
            
            Assert.IsTrue(handled);
            Assert.AreEqual(">=", context.LastToken.Value);
            Assert.AreEqual(TokenType.Operator, context.LastToken.TokenType);
        }

        [TestMethod]
        public void Handle_ShouldReturnTrueForNotEqualTo()
        {
            var handler = new MultipleCharSeparatorHandler();
            var context = new TokenizerContext("<>");
            context.AddToken(new Token("<", TokenType.Operator));
            
            bool handled = handler.Handle('>', null, context, null);
            
            Assert.IsTrue(handled);
            Assert.AreEqual("<>", context.LastToken.Value);
            Assert.AreEqual(TokenType.Operator, context.LastToken.TokenType);
        }

        [TestMethod]
        public void Handle_ShouldReturnFalseForSingleOperator()
        {
            var handler = new MultipleCharSeparatorHandler();
            var context = new TokenizerContext("<");
            context.AppendToCurrentToken('<');
            
            // CurrentTokenHasValue will be true, so it should return false
            bool handled = handler.Handle('=', null, context, null);
            
            Assert.IsFalse(handled);
        }

        [TestMethod]
        public void Handle_ShouldReturnFalseIfLastTokenIsNotOperator()
        {
            var handler = new MultipleCharSeparatorHandler();
            var context = new TokenizerContext("1=");
            context.AddToken(new Token("1", TokenType.Integer));
            
            bool handled = handler.Handle('=', null, context, null);
            
            Assert.IsFalse(handled);
        }

        [TestMethod]
        public void Handle_ShouldReturnFalseIfCharIsNotPartOfMultipleCharOperator()
        {
            var handler = new MultipleCharSeparatorHandler();
            var context = new TokenizerContext("<+");
            context.AddToken(new Token("<", TokenType.Operator));
            
            bool handled = handler.Handle('+', null, context, null);
            
            Assert.IsFalse(handled);
        }
    }
}
