using System;
using System.Runtime.Serialization;

namespace ASCOM.Alpaca.Client.Exceptions
{
    [Serializable]
    public class AlpacaParkedException : AlpacaDriverException
    {
        public AlpacaParkedException() : base(ErrorCodes.InvalidWhileParked)
        {
        }

        public AlpacaParkedException(string message) : base(message, ErrorCodes.InvalidWhileParked)
        {
        }

        public AlpacaParkedException(string message, Exception innerException) : base(message, ErrorCodes.InvalidWhileParked, innerException)
        {
            AlpacaErrorCode = ErrorCodes.InvalidValue;
        }

        protected AlpacaParkedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}