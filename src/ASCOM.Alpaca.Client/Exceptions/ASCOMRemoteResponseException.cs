using System;
using System.Runtime.Serialization;

namespace ASCOM.Alpaca.Client.Exceptions
{
    [Serializable]
    public class ASCOMRemoteResponseException : Exception
    {
        public int ErrorNumber { get; }
        
        public ASCOMRemoteResponseException()
        {
        }

        public ASCOMRemoteResponseException(string message) : base(message)
        {
        }

        public ASCOMRemoteResponseException(string message, Exception innerException) : base(message, innerException)
        {
        }
        
        public ASCOMRemoteResponseException(int errorNumber)
        {
            ErrorNumber = errorNumber;
        }

        public ASCOMRemoteResponseException(string message, int errorNumber) : base(message)
        {
            ErrorNumber = errorNumber;
        }

        public ASCOMRemoteResponseException(string message, int errorNumber, Exception innerException) : base(message, innerException)
        {
            ErrorNumber = errorNumber;
        }

        protected ASCOMRemoteResponseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}