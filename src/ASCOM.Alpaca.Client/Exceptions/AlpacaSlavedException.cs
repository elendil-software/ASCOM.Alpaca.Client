using System;
using System.Runtime.Serialization;

namespace ASCOM.Alpaca.Client.Exceptions
{
    [Serializable]
    public class AlpacaSlavedException : AlpacaDriverException
    {
        public AlpacaSlavedException() : base(ErrorCodes.InvalidWhileSlaved)
        {
        }

        public AlpacaSlavedException(string message) : base(message, ErrorCodes.InvalidWhileSlaved)
        {
        }

        public AlpacaSlavedException(string message, Exception innerException) : base(message, ErrorCodes.InvalidWhileSlaved, innerException)
        {
        }

        protected AlpacaSlavedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}