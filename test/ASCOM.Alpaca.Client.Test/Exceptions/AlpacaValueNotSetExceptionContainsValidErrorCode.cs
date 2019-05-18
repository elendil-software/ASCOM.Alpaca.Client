using System;
using ASCOM.Alpaca.Client.Errors;
using ASCOM.Alpaca.Client.Exceptions;
using Xunit;

namespace ASCOM.Alpaca.Client.Test.Exceptions
{
    public class AlpacaValueNotSetExceptionContainsValidErrorCode
    {
        private readonly int _expectedErrorCode = ErrorCodes.ValueNotSet;
        
        [Fact]
        public void WhenInitializedWith_EmptyConstructor()
        {
            var exception = new AlpacaValueNotSetException();

            Assert.Equal(_expectedErrorCode, exception.AlpacaErrorCode);
        }
        
        [Fact]
        public void WhenInitializedWith_MessageConstructor()
        {
            var exception = new AlpacaValueNotSetException("message");

            Assert.Equal(_expectedErrorCode, exception.AlpacaErrorCode);
        }
        
        [Fact]
        public void WhenInitializedWith_MessageAndInnerExceptionConstructor()
        {
            var exception = new AlpacaValueNotSetException("message", new Exception());

            Assert.Equal(_expectedErrorCode, exception.AlpacaErrorCode);
        }
    }
}