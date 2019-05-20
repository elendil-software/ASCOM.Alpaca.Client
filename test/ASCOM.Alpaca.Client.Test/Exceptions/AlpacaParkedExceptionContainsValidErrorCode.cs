using System;
using AscomAlpacaClient.Errors;
using AscomAlpacaClient.Exceptions;
using Xunit;

namespace AscomAlpacaClient.Test.Exceptions
{
    public class AlpacaParkedExceptionContainsValidErrorCode
    {
        private readonly int _expectedErrorCode = ErrorCodes.InvalidWhileParked;
        
        [Fact]
        public void WhenInitializedWith_EmptyConstructor()
        {
            var exception = new AlpacaParkedException();

            Assert.Equal(_expectedErrorCode, exception.AlpacaErrorCode);
        }
        
        [Fact]
        public void WhenInitializedWith_MessageConstructor()
        {
            var exception = new AlpacaParkedException("message");

            Assert.Equal(_expectedErrorCode, exception.AlpacaErrorCode);
        }
        
        [Fact]
        public void WhenInitializedWith_MessageAndInnerExceptionConstructor()
        {
            var exception = new AlpacaParkedException("message", new Exception());

            Assert.Equal(_expectedErrorCode, exception.AlpacaErrorCode);
        }
    }
}