using System;
using System.Runtime.Serialization;

namespace ASCOM.Alpaca.Client.Exceptions
{
    [Serializable]
    public class AlpacaDriverException : AlpacaException
    {
        public AlpacaDriverException()
        {
        }
        
        public AlpacaDriverException(int alpacaErrorCode) : base(alpacaErrorCode)
        {
        }
        
        public AlpacaDriverException(string message) : base(message)
        {
        }

        public AlpacaDriverException(string message, int alpacaErrorCode) : base(message, alpacaErrorCode)
        {
        }
        
        public AlpacaDriverException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public AlpacaDriverException(string message, int alpacaErrorCode, Exception innerException) : base(message, alpacaErrorCode, innerException)
        {
        }

        protected AlpacaDriverException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}