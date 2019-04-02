using ASCOM.Alpaca.Client.Responses.Empty;

namespace ASCOM.Alpaca.Client.Responses
{
    internal static class ResponseHandler
    {
        /// <summary>
        /// Offset value that relates the ASCOM Alpaca reserved error number range to the ASCOM COM HResult error number range
        /// </summary>
        private const int ASCOM_ERROR_NUMBER_OFFSET = unchecked((int)0x80040000);
        /// <summary>
        /// Start of the Alpaca error code range 0x400 to 0xFFF
        /// </summary>
        private const int ALPACA_ERROR_CODE_BASE = 0x400;
        /// <summary>
        /// End of Alpaca error code range 0x400 to 0xFFF
        /// </summary>
        private const int ALPACA_ERROR_CODE_MAX = 0xFFF;
        
        
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
                if (errorCode >= ALPACA_ERROR_CODE_BASE && (errorCode <= ALPACA_ERROR_CODE_MAX))
                {
                    // Calculate the equivalent COM HResult error number from the supplied Alpaca error number so that comparison can
                    // be made with the original ASCOM COM exception HResult numbers that Windows clients expect in their exceptions
                    int ascomCOMErrorNumber = errorCode + ASCOM_ERROR_NUMBER_OFFSET;

                    if (ascomCOMErrorNumber == ErrorCodes.ActionNotImplementedException)
                    {
                        throw new ActionNotImplementedException(errorMessage);
                    }

                    if (ascomCOMErrorNumber == ErrorCodes.InvalidOperationException)
                    {
                        throw new InvalidOperationException(errorMessage);
                    }
                    
                    if (ascomCOMErrorNumber == ErrorCodes.InvalidValue)
                    {
                        throw new InvalidValueException(errorMessage);
                    }
                    
                    if (ascomCOMErrorNumber == ErrorCodes.InvalidWhileParked)
                    {
                        throw new ParkedException(errorMessage);
                    }
                    
                    if (ascomCOMErrorNumber == ErrorCodes.InvalidWhileSlaved)
                    {
                        throw new SlavedException(errorMessage);
                    }
                    
                    if (ascomCOMErrorNumber == ErrorCodes.NotConnected)
                    {
                        throw new NotConnectedException(errorMessage);
                    }
                    
                    if (ascomCOMErrorNumber == ErrorCodes.NotImplemented)
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
                    
                    if (ascomCOMErrorNumber == ErrorCodes.ValueNotSet)
                    {
                        throw new ValueNotSetException(errorMessage);
                    }
                    
                    throw new DriverException(errorMessage, ascomCOMErrorNumber);
                }

                throw new DriverException(errorMessage, errorCode);
            }
        }
    }
}