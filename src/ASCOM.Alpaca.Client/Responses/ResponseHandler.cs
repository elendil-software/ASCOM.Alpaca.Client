using ASCOM.Alpaca.Exceptions;
using ASCOM.Alpaca.Responses;
using ASCOM.Alpaca.Responses.Empty;

namespace ASCOM.Alpaca.Client.Responses
{
    internal static class ResponseHandler
    {
        public static T HandleResponse<T, TASCOMResponse>(this TASCOMResponse response) where TASCOMResponse : IValueResponse<T>
        {
            HandleError(response.ErrorNumber, response.ErrorMessage);
            return response.Value;
        }

        public static void HandleResponse(this MethodResponse response)
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
                    // Calculate the equivalent COM HResult error number from the supplied Alpaca error number so that comparison can
                    // be made with the original ASCOM COM exception HResult numbers that Windows clients expect in their exceptions
                    int ascomComErrorNumber = errorCode + ErrorCodes.ASCOMErrorNumberOffset;

                    CheckForActionNotImplemented(errorMessage, ascomComErrorNumber);
                    CheckForInvalidOperation(errorMessage, ascomComErrorNumber);
                    CheckForInvalidValue(errorMessage, ascomComErrorNumber);
                    CheckForInvalidWhileParked(errorMessage, ascomComErrorNumber);
                    CheckForInvalidWhileSlaved(errorMessage, ascomComErrorNumber);
                    CheckForNotConnected(errorMessage, ascomComErrorNumber);
                    CheckForNotImplemented(errorMessage, ascomComErrorNumber);
                    CheckForValueNotSet(errorMessage, ascomComErrorNumber);
                    
                    throw new DriverException(errorMessage, ascomComErrorNumber);
                }

                throw new DriverException(errorMessage, errorCode);
            }
        }

        private static void CheckForValueNotSet(string errorMessage, int ascomComErrorNumber)
        {
            if (ascomComErrorNumber == ErrorCodes.ValueNotSet)
            {
                throw new ValueNotSetException(errorMessage);
            }
        }

        private static void CheckForNotImplemented(string errorMessage, int ascomComErrorNumber)
        {
            if (ascomComErrorNumber == ErrorCodes.NotImplemented)
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

        private static void CheckForNotConnected(string errorMessage, int ascomComErrorNumber)
        {
            if (ascomComErrorNumber == ErrorCodes.NotConnected)
            {
                throw new NotConnectedException(errorMessage);
            }
        }

        private static void CheckForInvalidWhileSlaved(string errorMessage, int ascomComErrorNumber)
        {
            if (ascomComErrorNumber == ErrorCodes.InvalidWhileSlaved)
            {
                throw new SlavedException(errorMessage);
            }
        }

        private static void CheckForInvalidWhileParked(string errorMessage, int ascomComErrorNumber)
        {
            if (ascomComErrorNumber == ErrorCodes.InvalidWhileParked)
            {
                throw new ParkedException(errorMessage);
            }
        }

        private static void CheckForInvalidValue(string errorMessage, int ascomComErrorNumber)
        {
            if (ascomComErrorNumber == ErrorCodes.InvalidValue)
            {
                throw new InvalidValueException(errorMessage);
            }
        }

        private static void CheckForInvalidOperation(string errorMessage, int ascomComErrorNumber)
        {
            if (ascomComErrorNumber == ErrorCodes.InvalidOperationException)
            {
                throw new InvalidOperationException(errorMessage);
            }
        }

        private static void CheckForActionNotImplemented(string errorMessage, int ascomComErrorNumber)
        {
            if (ascomComErrorNumber == ErrorCodes.ActionNotImplementedException)
            {
                throw new ActionNotImplementedException(errorMessage);
            }
        }
    }
}