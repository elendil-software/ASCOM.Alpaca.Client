using System;
using System.Runtime.Serialization;

namespace ASCOM.Alpaca.Client.Exceptions
{
    [Serializable]
    public class AlpacaServerException : AlpacaException
    {
        public AlpacaServerException()
        {
        }
        
        public AlpacaServerException(int alpacaErrorCode) : base(alpacaErrorCode)
        {
        }
        
        public AlpacaServerException(string message) : base(message)
        {
        }

        public AlpacaServerException(string message, int alpacaErrorCode) : base(message, alpacaErrorCode)
        {
        }
        
        public AlpacaServerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public AlpacaServerException(string message, int alpacaErrorCode, Exception innerException) : base(message, alpacaErrorCode, innerException)
        {
        }

        protected AlpacaServerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}