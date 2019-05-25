using ES.AscomAlpaca.Client.Responses;
using ES.AscomAlpaca.Exceptions;
using ES.AscomAlpaca.Responses;
using Xunit;

namespace ES.AscomAlpaca.Client.Test.Responses
{
    public class ResponseHandlerTest
    {
        [Fact]
        public void GivenInvalidValueError_ResponseHandler_ThrowsAlpacaInvalidValueException()
        {
            var response = new StringResponse(ErrorCodes.InvalidValue, "Error");
            
            Assert.Throws<AlpacaInvalidValueException>(() => response.HandleResponse<string, StringResponse>());
        }
        
        [Fact]
        public void GivenNotConnectedError_ResponseHandler_ThrowsAlpacaNotConnectedException()
        {
            var response = new StringResponse(ErrorCodes.NotConnected, "Error");
            
            Assert.Throws<AlpacaNotConnectedException>(() => response.HandleResponse<string, StringResponse>());
        }
        
        [Fact]
        public void GivenNotImplementedError_ResponseHandler_ThrowsAlpacaNotImplementedException()
        {
            var response = new StringResponse(ErrorCodes.NotImplemented, "Error");
            
            Assert.Throws<AlpacaNotImplementedException>(() => response.HandleResponse<string, StringResponse>());
        }
        
        [Fact]
        public void GivenActionNotImplementedExceptionError_ResponseHandler_ThrowsAlpacaActionNotImplementedException()
        {
            var response = new StringResponse(ErrorCodes.ActionNotImplemented, "Error");
            
            Assert.Throws<AlpacaActionNotImplementedException>(() => response.HandleResponse<string, StringResponse>());
        }

        [Fact]
        public void GivenUnspecifiedErrorError_ResponseHandler_ThrowsAlpacaDeviceException()
        {
            var response = new StringResponse(ErrorCodes.UnspecifiedError, "Error");
            
            Assert.Throws<AlpacaDeviceException>(() => response.HandleResponse<string, StringResponse>());
        }

        [Fact]
        public void GivenInvalidOperationExceptionError_ResponseHandler_ThrowsAlpacaInvalidOperationException()
        {
            var response = new StringResponse(ErrorCodes.InvalidOperation, "Error");
            
            Assert.Throws<AlpacaInvalidOperationException>(() => response.HandleResponse<string, StringResponse>());
        }

        [Fact]
        public void GivenInvalidWhileParkedError_ResponseHandler_ThrowsAlpacaParkedException()
        {
            var response = new StringResponse(ErrorCodes.InvalidWhileParked, "Error");
            
            Assert.Throws<AlpacaParkedException>(() => response.HandleResponse<string, StringResponse>());
        }

        [Fact]
        public void GivenInvalidWhileSlavedError_ResponseHandler_ThrowsAlpacaSlavedException()
        {
            var response = new StringResponse(ErrorCodes.InvalidWhileSlaved, "Error");
            
            Assert.Throws<AlpacaSlavedException>(() => response.HandleResponse<string, StringResponse>());
        }

        [Fact]
        public void GivenValueNotSetError_ResponseHandler_ThrowsAlpacaValueNotSetException()
        {
            var response = new StringResponse(ErrorCodes.ValueNotSet, "Error");
            
            Assert.Throws<AlpacaValueNotSetException>(() => response.HandleResponse<string, StringResponse>());
        }
    }
}