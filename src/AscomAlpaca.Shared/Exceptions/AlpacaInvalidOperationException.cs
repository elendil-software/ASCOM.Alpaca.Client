using System;
using System.Runtime.Serialization;

namespace ES.AscomAlpaca.Exceptions
{
    [Serializable]
    public class AlpacaInvalidOperationException : AlpacaDeviceException
    {
        public AlpacaInvalidOperationException() : base(ErrorCodes.InvalidOperation)
        {
        }
        protected AlpacaInvalidOperationException(int alpacaErrorCode) : base(alpacaErrorCode)
        {
        }

        public AlpacaInvalidOperationException(string message) : base(message, ErrorCodes.InvalidOperation)
        {
        }

        protected AlpacaInvalidOperationException(string message, int alpacaErrorCode) : base(message, alpacaErrorCode)
        {
        }
        public AlpacaInvalidOperationException(string message, Exception innerException) : base(message, ErrorCodes.InvalidOperation, innerException)
        {
        }
        protected AlpacaInvalidOperationException(string message, int alpacaErrorCode, Exception innerException) : base(message, alpacaErrorCode, innerException)
        {
        }

        protected AlpacaInvalidOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}