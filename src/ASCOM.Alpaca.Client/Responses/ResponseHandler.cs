using AscomAlpacaClient.Errors;
using AscomAlpacaClient.Exceptions;

namespace AscomAlpacaClient.Responses
{
    internal static class ResponseHandler
    {
        public static T HandleResponse<T, TASCOMResponse>(this TASCOMResponse response) where TASCOMResponse : IValueResponse<T>
        {
            HandleError(response.ErrorNumber, response.ErrorMessage);
            return response.Value;
        }

        public static void HandleResponse(this IResponse response)
        {
            HandleError(response.ErrorNumber, response.ErrorMessage);
        }

        private static void HandleError(int errorCode, string errorMessage)
        {
            if (!string.IsNullOrWhiteSpace(errorMessage) || errorCode != 0)
            {
                ThrowExceptionIfActionNotImplemented(errorMessage, errorCode);
                ThrowExceptionIfInvalidOperation(errorMessage, errorCode);
                ThrowExceptionIfInvalidValue(errorMessage, errorCode);
                ThrowExceptionIfInvalidWhileParked(errorMessage, errorCode);
                ThrowExceptionIfInvalidWhileSlaved(errorMessage, errorCode);
                ThrowExceptionIfNotConnected(errorMessage, errorCode);
                ThrowExceptionIfNotImplemented(errorMessage, errorCode);
                ThrowExceptionIfValueNotSet(errorMessage, errorCode);

                throw new AlpacaDeviceException(errorMessage, errorCode);
            }
        }

        private static void ThrowExceptionIfValueNotSet(string errorMessage, int errorCode)
        {
            if (errorCode == ErrorCodes.ValueNotSet)
            {
                throw new AlpacaValueNotSetException(errorMessage);
            }
        }

        private static void ThrowExceptionIfNotImplemented(string errorMessage, int errorCode)
        {
            if (errorCode == ErrorCodes.NotImplemented)
            {
                throw new AlpacaNotImplementedException(errorMessage);
            }
        }

        private static void ThrowExceptionIfNotConnected(string errorMessage, int errorCode)
        {
            if (errorCode == ErrorCodes.NotConnected)
            {
                throw new AlpacaNotConnectedException(errorMessage);
            }
        }

        private static void ThrowExceptionIfInvalidWhileSlaved(string errorMessage, int errorCode)
        {
            if (errorCode == ErrorCodes.InvalidWhileSlaved)
            {
                throw new AlpacaSlavedException(errorMessage);
            }
        }

        private static void ThrowExceptionIfInvalidWhileParked(string errorMessage, int errorCode)
        {
            if (errorCode == ErrorCodes.InvalidWhileParked)
            {
                throw new AlpacaParkedException(errorMessage);
            }
        }

        private static void ThrowExceptionIfInvalidValue(string errorMessage, int errorCode)
        {
            if (errorCode == ErrorCodes.InvalidValue)
            {
                throw new AlpacaInvalidValueException(errorMessage);
            }
        }

        private static void ThrowExceptionIfInvalidOperation(string errorMessage, int errorCode)
        {
            if (errorCode == ErrorCodes.InvalidOperation)
            {
                throw new AlpacaInvalidOperationException(errorMessage);
            }
        }

        private static void ThrowExceptionIfActionNotImplemented(string errorMessage, int errorCode)
        {
            if (errorCode == ErrorCodes.ActionNotImplemented)
            {
                throw new AlpacaActionNotImplementedException(errorMessage);
            }
        }
    }
}