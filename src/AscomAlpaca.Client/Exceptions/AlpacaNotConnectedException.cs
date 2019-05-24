using System;
using System.Runtime.Serialization;
using ES.AscomAlpaca.Client.Errors;

namespace ES.AscomAlpaca.Client.Exceptions
{
    [Serializable]
    public class AlpacaNotConnectedException : AlpacaDeviceException
    {
        public AlpacaNotConnectedException() : base(ErrorCodes.NotConnected)
        {
        }

        public AlpacaNotConnectedException(string message) : base(message,  ErrorCodes.NotConnected)
        {
        }

        public AlpacaNotConnectedException(string message, Exception innerException) : base(message,  ErrorCodes.NotConnected, innerException)
        {
        }

        protected AlpacaNotConnectedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}