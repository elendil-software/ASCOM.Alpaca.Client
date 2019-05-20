using System;
using AscomAlpacaClient.Errors;
using AscomAlpacaClient.Exceptions;
using Xunit;

namespace AscomAlpacaClient.Test.Exceptions
{
    public class AlpacaNotImplementedExceptionContainsValidErrorCode
    {
        private readonly int _expectedErrorCode = ErrorCodes.NotImplemented;
        
        [Fact]
        public void WhenInitializedWith_EmptyConstructor()
        {
            var exception = new AlpacaNotImplementedException();

            Assert.Equal(_expectedErrorCode, exception.AlpacaErrorCode);
        }
        
        [Fact]
        public void WhenInitializedWith_MessageConstructor()
        {
            var exception = new AlpacaNotImplementedException("message");

            Assert.Equal(_expectedErrorCode, exception.AlpacaErrorCode);
        }
        
        [Fact]
        public void WhenInitializedWith_MessageAndInnerExceptionConstructor()
        {
            var exception = new AlpacaNotImplementedException("message", new Exception());

            Assert.Equal(_expectedErrorCode, exception.AlpacaErrorCode);
        }
    }
}