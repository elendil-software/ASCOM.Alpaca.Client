using System;
using System.Runtime.Serialization;

namespace ASCOM.Alpaca.Client.Exceptions
{
    [Serializable]
    public class AlpacaValueNotSetException : AlpacaDeviceException
    {
        public AlpacaValueNotSetException() : base(ErrorCodes.ValueNotSet)
        {
        }

        public AlpacaValueNotSetException(string message) : base(message, ErrorCodes.ValueNotSet)
        {
        }

        public AlpacaValueNotSetException(string message, Exception innerException) : base(message, ErrorCodes.ValueNotSet, innerException)
        {
        }

        protected AlpacaValueNotSetException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}