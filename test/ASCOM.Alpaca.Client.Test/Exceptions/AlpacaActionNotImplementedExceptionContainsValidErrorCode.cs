using System;
using ASCOM.Alpaca.Client.Exceptions;
using Xunit;

namespace ASCOM.Alpaca.Client.Test.Exceptions
{
    public class AlpacaActionNotImplementedExceptionContainsValidErrorCode
    {
        private readonly int _expectedErrorCode = ErrorCodes.ActionNotImplementedException;
        
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