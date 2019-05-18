using System;
using System.Runtime.Serialization;
using ASCOM.Alpaca.Client.Errors;

namespace ASCOM.Alpaca.Client.Exceptions
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