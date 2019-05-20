using System;
using System.Runtime.Serialization;

namespace AscomAlpacaClient.Exceptions
{
    [Serializable]
    public class AlpacaDeviceException : AlpacaException
    {
        public AlpacaDeviceException()
        {
        }
        
        public AlpacaDeviceException(int alpacaErrorCode) : base(alpacaErrorCode)
        {
        }
        
        public AlpacaDeviceException(string message) : base(message)
        {
        }

        public AlpacaDeviceException(string message, int alpacaErrorCode) : base(message, alpacaErrorCode)
        {
        }
        
        public AlpacaDeviceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public AlpacaDeviceException(string message, int alpacaErrorCode, Exception innerException) : base(message, alpacaErrorCode, innerException)
        {
        }

        protected AlpacaDeviceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}