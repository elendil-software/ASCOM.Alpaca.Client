using System;
using System.Runtime.Serialization;

namespace ES.AscomAlpaca.Exceptions
{
    [Serializable]
    public class AlpacaParkedException : AlpacaInvalidOperationException
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