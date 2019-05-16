using System;
using System.Runtime.Serialization;

namespace ASCOM.Alpaca.Client.Exceptions
{
    [Serializable]
    public class AlpacaParkedException : AlpacaDeviceException
    {
        public AlpacaParkedException() : base(ErrorCodes.InvalidWhileParked)
        {
        }

        public AlpacaParkedException(string message) : base(message, ErrorCodes.InvalidWhileParked)
        {
        }

        public AlpacaParkedException(string message, Exception innerException) : base(message, ErrorCodes.InvalidWhileParked, innerException)
        {
        }

        protected AlpacaParkedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}