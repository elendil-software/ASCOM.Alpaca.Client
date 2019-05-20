using System;
using System.Runtime.Serialization;
using AscomAlpacaClient.Errors;

namespace AscomAlpacaClient.Exceptions
{
    [Serializable]
    public class AlpacaInvalidValueException : AlpacaDeviceException
    {
        public AlpacaInvalidValueException() : base(ErrorCodes.InvalidValue)
        {
        }

        public AlpacaInvalidValueException(string message) : base(message, ErrorCodes.InvalidValue)
        {
        }

        public AlpacaInvalidValueException(string message, Exception innerException) : base(message, ErrorCodes.InvalidValue, innerException)
        {
        }

        protected AlpacaInvalidValueException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}