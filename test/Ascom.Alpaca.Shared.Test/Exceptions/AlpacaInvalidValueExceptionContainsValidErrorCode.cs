using System;
using ES.Ascom.Alpaca.Exceptions;
using Xunit;

namespace ES.Ascom.Alpaca.Shared.Test.Exceptions
{
    public class AlpacaInvalidValueExceptionContainsValidErrorCode
    {
        private readonly int _expectedErrorCode = ErrorCodes.InvalidValue;
        
        [Fact]
        public void WhenInitializedWith_EmptyConstructor()
        {
            var exception = new AlpacaInvalidValueException();

            Assert.Equal(_expectedErrorCode, exception.AlpacaErrorCode);
        }
        
        [Fact]
        public void WhenInitializedWith_MessageConstructor()
        {
            var exception = new AlpacaInvalidValueException("message");

            Assert.Equal(_expectedErrorCode, exception.AlpacaErrorCode);
        }
        
        [Fact]
        public void WhenInitializedWith_MessageAndInnerExceptionConstructor()
        {
            var exception = new AlpacaInvalidValueException("message", new Exception());

            Assert.Equal(_expectedErrorCode, exception.AlpacaErrorCode);
        }
    }
}