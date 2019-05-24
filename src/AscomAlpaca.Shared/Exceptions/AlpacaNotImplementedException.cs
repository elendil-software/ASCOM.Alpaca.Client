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

        public AlpacaNotImplementedException(string message) : base(message, ErrorCodes.NotImplemented)
        {
        }

        public AlpacaNotImplementedException(string message, Exception innerException) : base(message, ErrorCodes.NotImplemented, innerException)
        {
        }

        protected AlpacaNotImplementedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}