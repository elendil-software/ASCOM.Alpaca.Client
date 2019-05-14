using System;
using System.Runtime.Serialization;

namespace ASCOM.Alpaca.Client.Exceptions
{
    [Serializable]
    public class AlpacaValueNotSetException : AlpacaDriverException
    {
        public AlpacaValueNotSetException() : base(ErrorCodes.ValueNotSet)
        {
        }

        public AlpacaValueNotSetException(string message) : base(message, ErrorCodes.ValueNotSet)
        {
        }

        public AlpacaValueNotSetException(string message, Exception innerException) : base(message, ErrorCodes.ValueNotSet, innerException)
        {
            AlpacaErrorCode = ErrorCodes.InvalidValue;
        }

        protected AlpacaValueNotSetException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}