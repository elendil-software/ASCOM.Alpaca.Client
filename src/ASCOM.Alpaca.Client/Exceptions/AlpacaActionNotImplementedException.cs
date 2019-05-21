using System;
using System.Runtime.Serialization;
using AscomAlpacaClient.Errors;

namespace AscomAlpacaClient.Exceptions
{
    [Serializable]
    public class AlpacaActionNotImplementedException : AlpacaDeviceException
    {
        public AlpacaActionNotImplementedException() : base(ErrorCodes.ActionNotImplemented)
        {
        }

        public AlpacaActionNotImplementedException(string message) : base(message, ErrorCodes.ActionNotImplemented)
        {
        }

        public AlpacaActionNotImplementedException(string message, Exception innerException) : base(message, ErrorCodes.ActionNotImplemented, innerException)
        {
        }

        protected AlpacaActionNotImplementedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}