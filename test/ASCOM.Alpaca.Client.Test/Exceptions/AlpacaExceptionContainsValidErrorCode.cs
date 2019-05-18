using System;
using ASCOM.Alpaca.Client.Errors;
using ASCOM.Alpaca.Client.Exceptions;
using Xunit;

namespace ASCOM.Alpaca.Client.Test.Exceptions
{
    public class AlpacaExceptionContainsValidErrorCode
    {
        private readonly int _expectedErrorCode = 0x500;
        private readonly int _expectedUnspecifiedError = ErrorCodes.UnspecifiedError;
        
        [Fact]
        public void WhenInitializedWith_EmptyConstructor()
        {
            var exception = new AlpacaException();

            Assert.Equal(_expectedUnspecifiedError, exception.AlpacaErrorCode);
        }
        
        [Fact]
        public void WhenInitializedWith_MessageConstructor()
        {
            var exception = new AlpacaException("message");

            Assert.Equal(_expectedUnspecifiedError, exception.AlpacaErrorCode);
        }
        
        [Fact]
        public void WhenInitializedWith_MessageAndInnerExceptionConstructor()
        {
            var exception = new AlpacaException("message", new Exception());

            Assert.Equal(_expectedUnspecifiedError, exception.AlpacaErrorCode);
        }
        
        [Fact]
        public void WhenInitializedWith_ErrorCodeConstructor()
        {
            var exception = new AlpacaException(_expectedErrorCode);

            Assert.Equal(_expectedErrorCode, exception.AlpacaErrorCode);
        }
        
        [Fact]
        public void WhenInitializedWith_MessageAndErrorCodeConstructor()
        {
            var exception = new AlpacaException("message", _expectedErrorCode);

            Assert.Equal(_expectedErrorCode, exception.AlpacaErrorCode);
        }
        
        [Fact]
        public void WhenInitializedWith_MessageAndErrorCodeAndInnerExceptionConstructor()
        {
            var exception = new AlpacaException("message", _expectedErrorCode, new Exception());

            Assert.Equal(_expectedErrorCode, exception.AlpacaErrorCode);
        }
    }
}