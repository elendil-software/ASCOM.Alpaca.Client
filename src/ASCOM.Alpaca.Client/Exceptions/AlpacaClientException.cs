using System;
using System.Runtime.Serialization;

namespace ASCOM.Alpaca.Client.Exceptions
{
    [Serializable]
    public class AlpacaClientException : AlpacaException
    {
        public AlpacaClientException()
        {
        }
        
        public AlpacaClientException(int alpacaErrorCode) : base(alpacaErrorCode)
        {
        }
        
        public AlpacaClientException(string message) : base(message)
        {
        }

        public AlpacaClientException(string message, int alpacaErrorCode) : base(message, alpacaErrorCode)
        {
        }
        
        public AlpacaClientException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public AlpacaClientException(string message, int alpacaErrorCode, Exception innerException) : base(message, alpacaErrorCode, innerException)
        {
        }

        protected AlpacaClientException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}