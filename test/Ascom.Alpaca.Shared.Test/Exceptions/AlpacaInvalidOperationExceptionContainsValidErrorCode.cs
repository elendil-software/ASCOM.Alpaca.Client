using System;
using ES.Ascom.Alpaca.Exceptions;
using Xunit;

namespace ES.Ascom.Alpaca.Shared.Test.Exceptions
{
    public class AlpacaInvalidOperationExceptionContainsValidErrorCode
    {
        private readonly int _expectedErrorCode = ErrorCodes.InvalidOperation;
        
        [Fact]
        public void WhenInitializedWith_EmptyConstructor()
        {
            var exception = new AlpacaInvalidOperationException();

            Assert.Equal(_expectedErrorCode, exception.AlpacaErrorCode);
        }
        
        [Fact]
        public void WhenInitializedWith_MessageConstructor()
        {
            var exception = new AlpacaInvalidOperationException("message");

            Assert.Equal(_expectedErrorCode, exception.AlpacaErrorCode);
        }
        
        [Fact]
        public void WhenInitializedWith_MessageAndInnerExceptionConstructor()
        {
            var exception = new AlpacaInvalidOperationException("message", new Exception());

            Assert.Equal(_expectedErrorCode, exception.AlpacaErrorCode);
        }
    }
}