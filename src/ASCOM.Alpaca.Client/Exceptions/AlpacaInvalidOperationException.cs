using System;
using System.Runtime.Serialization;
using AscomAlpacaClient.Errors;

namespace AscomAlpacaClient.Exceptions
{
    [Serializable]
    public class AlpacaInvalidOperationException : AlpacaDeviceException
    {
        public AlpacaInvalidOperationException() : base(ErrorCodes.InvalidOperationException)
        {
        }

        public AlpacaInvalidOperationException(string message) : base(message, ErrorCodes.InvalidOperationException)
        {
        }

        public AlpacaInvalidOperationException(string message, Exception innerException) : base(message, ErrorCodes.InvalidOperationException, innerException)
        {
        }

        protected AlpacaInvalidOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}