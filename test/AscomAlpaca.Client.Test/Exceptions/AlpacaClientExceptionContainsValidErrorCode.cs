using System;
using ES.AscomAlpaca.Exceptions;
using Xunit;

namespace ES.AscomAlpaca.Client.Test.Exceptions
{
    public class AlpacaClientExceptionContainsValidErrorCode
    {
        private readonly int _expectedErrorCode = 0x500;
        private readonly int _expectedUnspecifiedError = ErrorCodes.UnspecifiedError;
        
        [Fact]
        public void WhenInitializedWith_EmptyConstructor()
        {
            var exception = new AlpacaClientException();

            Assert.Equal(_expectedUnspecifiedError, exception.AlpacaErrorCode);
        }
        
        [Fact]
        public void WhenInitializedWith_MessageConstructor()
        {
            var exception = new AlpacaClientException("message");

            Assert.Equal(_expectedUnspecifiedError, exception.AlpacaErrorCode);
        }
        
        [Fact]
        public void WhenInitializedWith_MessageAndInnerExceptionConstructor()
        {
            var exception = new AlpacaClientException("message", new Exception());

            Assert.Equal(_expectedUnspecifiedError, exception.AlpacaErrorCode);
        }
        
        [Fact]
        public void WhenInitializedWith_ErrorCodeConstructor()
        {
            var exception = new AlpacaClientException(_expectedErrorCode);

            Assert.Equal(_expectedErrorCode, exception.AlpacaErrorCode);
        }
        
        [Fact]
        public void WhenInitializedWith_MessageAndErrorCodeConstructor()
        {
            var exception = new AlpacaClientException("message", _expectedErrorCode);

            Assert.Equal(_expectedErrorCode, exception.AlpacaErrorCode);
        }
        
        [Fact]
        public void WhenInitializedWith_MessageAndErrorCodeAndInnerExceptionConstructor()
        {
            var exception = new AlpacaClientException("message", _expectedErrorCode, new Exception());

            Assert.Equal(_expectedErrorCode, exception.AlpacaErrorCode);
        }
    }
}