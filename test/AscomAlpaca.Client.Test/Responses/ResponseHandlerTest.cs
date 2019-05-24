using ES.AscomAlpaca.Client.Errors;
using ES.AscomAlpaca.Client.Exceptions;
using ES.AscomAlpaca.Client.Responses;
using Xunit;

namespace ES.AscomAlpaca.Client.Test.Responses
{
    public class ResponseHandlerTest
    {
        [Fact]
        public void GivenInvalidValueError_ResponseHandler_ThrowsAlpacaInvalidValueException()
        {
            var response = new StringResponse {ErrorMessage = "Error", ErrorNumber = ErrorCodes.InvalidValue};
            
            Assert.Throws<AlpacaInvalidValueException>(() => response.HandleResponse<string, StringResponse>());
        }
        
        [Fact]
        public void GivenNotConnectedError_ResponseHandler_ThrowsAlpacaNotConnectedException()
        {
            var response = new StringResponse {ErrorMessage = "Error", ErrorNumber = ErrorCodes.NotConnected};
            
            Assert.Throws<AlpacaNotConnectedException>(() => response.HandleResponse<string, StringResponse>());
        }
        
        [Fact]
        public void GivenNotImplementedError_ResponseHandler_ThrowsAlpacaNotImplementedException()
        {
            var response = new StringResponse {ErrorMessage = "Error", ErrorNumber = ErrorCodes.NotImplemented};
            
            Assert.Throws<AlpacaNotImplementedException>(() => response.HandleResponse<string, StringResponse>());
        }
        
        [Fact]
        public void GivenActionNotImplementedExceptionError_ResponseHandler_ThrowsAlpacaActionNotImplementedException()
        {
            var response = new StringResponse {ErrorMessage = "Error", ErrorNumber = ErrorCodes.ActionNotImplemented};
            
            Assert.Throws<AlpacaActionNotImplementedException>(() => response.HandleResponse<string, StringResponse>());
        }

        [Fact]
        public void GivenUnspecifiedErrorError_ResponseHandler_ThrowsAlpacaDeviceException()
        {
            var response = new StringResponse {ErrorMessage = "Error", ErrorNumber = ErrorCodes.UnspecifiedError};
            
            Assert.Throws<AlpacaDeviceException>(() => response.HandleResponse<string, StringResponse>());
        }

        [Fact]
        public void GivenInvalidOperationExceptionError_ResponseHandler_ThrowsAlpacaInvalidOperationException()
        {
            var response = new StringResponse {ErrorMessage = "Error", ErrorNumber = ErrorCodes.InvalidOperation};
            
            Assert.Throws<AlpacaInvalidOperationException>(() => response.HandleResponse<string, StringResponse>());
        }

        [Fact]
        public void GivenInvalidWhileParkedError_ResponseHandler_ThrowsAlpacaParkedException()
        {
            var response = new StringResponse {ErrorMessage = "Error", ErrorNumber = ErrorCodes.InvalidWhileParked};
            
            Assert.Throws<AlpacaParkedException>(() => response.HandleResponse<string, StringResponse>());
        }

        [Fact]
        public void GivenInvalidWhileSlavedError_ResponseHandler_ThrowsAlpacaSlavedException()
        {
            var response = new StringResponse {ErrorMessage = "Error", ErrorNumber = ErrorCodes.InvalidWhileSlaved};
            
            Assert.Throws<AlpacaSlavedException>(() => response.HandleResponse<string, StringResponse>());
        }

        [Fact]
        public void GivenValueNotSetError_ResponseHandler_ThrowsAlpacaValueNotSetException()
        {
            var response = new StringResponse {ErrorMessage = "Error", ErrorNumber = ErrorCodes.ValueNotSet};
            
            Assert.Throws<AlpacaValueNotSetException>(() => response.HandleResponse<string, StringResponse>());
        }
    }
}