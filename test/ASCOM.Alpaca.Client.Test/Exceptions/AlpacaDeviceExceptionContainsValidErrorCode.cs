using System;
using AscomAlpacaClient.Errors;
using AscomAlpacaClient.Exceptions;
using Xunit;

namespace AscomAlpacaClient.Test.Exceptions
{
    public class AlpacaDeviceExceptionContainsValidErrorCode
    {
        private readonly int _expectedErrorCode = 0x500;
        private readonly int _expectedUnspecifiedError = ErrorCodes.UnspecifiedError;
        
        [Fact]
        public void WhenInitializedWith_EmptyConstructor()
        {
            var exception = new AlpacaDeviceException();

            Assert.Equal(_expectedUnspecifiedError, exception.AlpacaErrorCode);
        }
        
        [Fact]
        public void WhenInitializedWith_MessageConstructor()
        {
            var exception = new AlpacaDeviceException("message");

            Assert.Equal(_expectedUnspecifiedError, exception.AlpacaErrorCode);
        }
        
        [Fact]
        public void WhenInitializedWith_MessageAndInnerExceptionConstructor()
        {
            var exception = new AlpacaDeviceException("message", new Exception());

            Assert.Equal(_expectedUnspecifiedError, exception.AlpacaErrorCode);
        }
        
        [Fact]
        public void WhenInitializedWith_ErrorCodeConstructor()
        {
            var exception = new AlpacaDeviceException(_expectedErrorCode);

            Assert.Equal(_expectedErrorCode, exception.AlpacaErrorCode);
        }
        
        [Fact]
        public void WhenInitializedWith_MessageAndErrorCodeConstructor()
        {
            var exception = new AlpacaDeviceException("message", _expectedErrorCode);

            Assert.Equal(_expectedErrorCode, exception.AlpacaErrorCode);
        }
        
        [Fact]
        public void WhenInitializedWith_MessageAndErrorCodeAndInnerExceptionConstructor()
        {
            var exception = new AlpacaDeviceException("message", _expectedErrorCode, new Exception());

            Assert.Equal(_expectedErrorCode, exception.AlpacaErrorCode);
        }
    }
}