using System;
using System.Runtime.Serialization;
using ASCOM.Alpaca.Client.Errors;

namespace ASCOM.Alpaca.Client.Exceptions
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