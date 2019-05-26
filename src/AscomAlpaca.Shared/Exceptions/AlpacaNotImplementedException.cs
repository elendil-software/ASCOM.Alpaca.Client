using System;
using System.Runtime.Serialization;

namespace ES.AscomAlpaca.Exceptions
{
    [Serializable]
    public class AlpacaNotImplementedException : AlpacaDeviceException
    {
        public AlpacaNotImplementedException() : base(ErrorCodes.NotImplemented)
        {
        }
        
        protected AlpacaNotImplementedException(int alpacaErrorCode) : base(alpacaErrorCode)
        {
        }

        public AlpacaNotImplementedException(string message) : base(message, ErrorCodes.NotImplemented)
        {
        }
        
        protected AlpacaNotImplementedException(string message, int alpacaErrorCode) : base(message, alpacaErrorCode)
        {
        }

        public AlpacaNotImplementedException(string message, Exception innerException) : base(message, ErrorCodes.NotImplemented, innerException)
        {
        }
        
        protected AlpacaNotImplementedException(string message, int alpacaErrorCode, Exception innerException) : base(message, alpacaErrorCode, innerException)
        {
        }

        protected AlpacaNotImplementedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}