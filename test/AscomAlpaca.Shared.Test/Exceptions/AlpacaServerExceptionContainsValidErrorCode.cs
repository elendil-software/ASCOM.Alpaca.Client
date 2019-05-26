using System;
using ES.AscomAlpaca.Exceptions;
using Xunit;

namespace ES.AscomAlpaca.Shared.Test.Exceptions
{
    public class AlpacaServerExceptionContainsValidErrorCode
    {
        private readonly int _expectedErrorCode = 0x500;
        private readonly int _expectedUnspecifiedError = ErrorCodes.UnspecifiedError;
        
        [Fact]
        public void WhenInitializedWith_EmptyConstructor()
        {
            var exception = new AlpacaServerException();

            Assert.Equal(_expectedUnspecifiedError, exception.AlpacaErrorCode);
        }
        
        [Fact]
        public void WhenInitializedWith_MessageConstructor()
        {
            var exception = new AlpacaServerException("message");

            Assert.Equal(_expectedUnspecifiedError, exception.AlpacaErrorCode);
        }
        
        [Fact]
        public void WhenInitializedWith_MessageAndInnerExceptionConstructor()
        {
            var exception = new AlpacaServerException("message", new Exception());

            Assert.Equal(_expectedUnspecifiedError, exception.AlpacaErrorCode);
        }
        
        [Fact]
        public void WhenInitializedWith_ErrorCodeConstructor()
        {
            var exception = new AlpacaServerException(_expectedErrorCode);

            Assert.Equal(_expectedErrorCode, exception.AlpacaErrorCode);
        }
        
        [Fact]
        public void WhenInitializedWith_MessageAndErrorCodeConstructor()
        {
            var exception = new AlpacaServerException("message", _expectedErrorCode);

            Assert.Equal(_expectedErrorCode, exception.AlpacaErrorCode);
        }
        
        [Fact]
        public void WhenInitializedWith_MessageAndErrorCodeAndInnerExceptionConstructor()
        {
            var exception = new AlpacaServerException("message", _expectedErrorCode, new Exception());

            Assert.Equal(_expectedErrorCode, exception.AlpacaErrorCode);
        }
    }
}