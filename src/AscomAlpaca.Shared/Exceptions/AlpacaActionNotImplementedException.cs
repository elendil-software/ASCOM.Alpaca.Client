using System;
using System.Runtime.Serialization;

namespace ES.AscomAlpaca.Exceptions
{
    [Serializable]
    public class AlpacaActionNotImplementedException : AlpacaNotImplementedException
    {
        public AlpacaActionNotImplementedException() : base(ErrorCodes.ActionNotImplemented)
        {
        }

        public AlpacaActionNotImplementedException(string message) : base(message, ErrorCodes.ActionNotImplemented)
        {
        }

        public AlpacaActionNotImplementedException(string message, Exception innerException) : base(message, ErrorCodes.ActionNotImplemented, innerException)
        {
        }

        protected AlpacaActionNotImplementedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}