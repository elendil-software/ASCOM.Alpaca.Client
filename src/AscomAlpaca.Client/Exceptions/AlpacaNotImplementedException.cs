using System;
using System.Runtime.Serialization;
using ES.AscomAlpaca.Client.Errors;

namespace ES.AscomAlpaca.Client.Exceptions
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