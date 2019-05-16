using System;
using System.Runtime.Serialization;

namespace ASCOM.Alpaca.Client.Exceptions
{
    [Serializable]
    public class AlpacaActionNotImplementedException : AlpacaDeviceException
    {
        public AlpacaActionNotImplementedException() : base(ErrorCodes.ActionNotImplementedException)
        {
        }

        public AlpacaActionNotImplementedException(string message) : base(message, ErrorCodes.ActionNotImplementedException)
        {
        }

        public AlpacaActionNotImplementedException(string message, Exception innerException) : base(message, ErrorCodes.ActionNotImplementedException, innerException)
        {
        }

        protected AlpacaActionNotImplementedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}