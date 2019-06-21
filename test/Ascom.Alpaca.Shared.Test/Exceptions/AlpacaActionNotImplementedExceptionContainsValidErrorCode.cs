using System;
using ES.Ascom.Alpaca.Exceptions;
using Xunit;

namespace ES.Ascom.Alpaca.Shared.Test.Exceptions
{
    public class AlpacaActionNotImplementedExceptionContainsValidErrorCode
    {
        private readonly int _expectedErrorCode = ErrorCodes.ActionNotImplemented;
        
        [Fact]
        public void WhenInitializedWith_EmptyConstructor()
        {
            var exception = new AlpacaActionNotImplementedException();

            Assert.Equal(_expectedErrorCode, exception.AlpacaErrorCode);
        }
        
        [Fact]
        public void WhenInitializedWith_MessageConstructor()
        {
            var exception = new AlpacaActionNotImplementedException("message");

            Assert.Equal(_expectedErrorCode, exception.AlpacaErrorCode);
        }
        
        [Fact]
        public void WhenInitializedWith_MessageAndInnerExceptionConstructor()
        {
            var exception = new AlpacaActionNotImplementedException("message", new Exception());

            Assert.Equal(_expectedErrorCode, exception.AlpacaErrorCode);
        }
    }
}