using ASCOM.Alpaca.Errors;
using ASCOM.Alpaca.Exceptions;
using ASCOM.Alpaca.Responses;

namespace ASCOM.Alpaca.Client.Responses
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
                // Handle ASCOM Alpaca reserved error numbers between 0x400 and 0xFFF by translating these to
                // the COM HResult error number range: 0x80040400 to 0x80040FFF and throwing the translated value as an exception
                if (errorCode >= ErrorCodes.AlpacaErrorCodeBase && errorCode <= ErrorCodes.AlpacaErrorCodeMax)
                {
                    CheckForActionNotImplemented(errorMessage, errorCode);
                    CheckForInvalidOperation(errorMessage, errorCode);
                    CheckForInvalidValue(errorMessage, errorCode);
                    CheckForInvalidWhileParked(errorMessage, errorCode);
                    CheckForInvalidWhileSlaved(errorMessage, errorCode);
                    CheckForNotConnected(errorMessage, errorCode);
                    CheckForNotImplemented(errorMessage, errorCode);
                    CheckForValueNotSet(errorMessage, errorCode);
                }

                throw new DriverException(errorMessage, errorCode);
            }
        }

        private static void CheckForValueNotSet(string errorMessage, int errorCode)
        {
            if (errorCode == ErrorCodes.ValueNotSet)
            {
                throw new ValueNotSetException(errorMessage);
            }
        }

        private static void CheckForNotImplemented(string errorMessage, int errorCode)
        {
            if (errorCode == ErrorCodes.NotImplemented)
            {
                if (errorMessage != null && errorMessage.ToLowerInvariant().Contains("property"))
                {
                    throw new PropertyNotImplementedException(errorMessage);
                }
                else
                {
                    throw new MethodNotImplementedException(errorMessage);
                }
            }
        }

        private static void CheckForNotConnected(string errorMessage, int errorCode)
        {
            if (errorCode == ErrorCodes.NotConnected)
            {
                throw new NotConnectedException(errorMessage);
            }
        }

        private static void CheckForInvalidWhileSlaved(string errorMessage, int errorCode)
        {
            if (errorCode == ErrorCodes.InvalidWhileSlaved)
            {
                throw new SlavedException(errorMessage);
            }
        }

        private static void CheckForInvalidWhileParked(string errorMessage, int errorCode)
        {
            if (errorCode == ErrorCodes.InvalidWhileParked)
            {
                throw new ParkedException(errorMessage);
            }
        }

        private static void CheckForInvalidValue(string errorMessage, int errorCode)
        {
            if (errorCode == ErrorCodes.InvalidValue)
            {
                throw new InvalidValueException(errorMessage);
            }
        }

        private static void CheckForInvalidOperation(string errorMessage, int errorCode)
        {
            if (errorCode == ErrorCodes.InvalidOperationException)
            {
                throw new InvalidOperationException(errorMessage);
            }
        }

        private static void CheckForActionNotImplemented(string errorMessage, int errorCode)
        {
            if (errorCode == ErrorCodes.ActionNotImplementedException)
            {
                throw new ActionNotImplementedException(errorMessage);
            }
        }
    }
}