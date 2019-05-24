using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ES.AscomAlpaca.Exceptions
{
    [Serializable]
    public class AlpacaException : Exception
    {
        public int AlpacaErrorCode { get; protected set; }
        
        public AlpacaException()
        {
            AlpacaErrorCode = ErrorCodes.UnspecifiedError;
        }
        
        public AlpacaException(int alpacaErrorCode)
        {
            AlpacaErrorCode = alpacaErrorCode;
        }

        public AlpacaException(string message) : base(message)
        {
            AlpacaErrorCode = ErrorCodes.UnspecifiedError;
        }
        
        public AlpacaException(string message, int alpacaErrorCode) : base(message)
        {
            AlpacaErrorCode = alpacaErrorCode;
        }
               
        public AlpacaException(string message, Exception innerException) : base(message, innerException)
        {
            AlpacaErrorCode = ErrorCodes.UnspecifiedError;
        }

        public AlpacaException(string message, int alpacaErrorCode, Exception innerException) : base(message, innerException)
        {
            AlpacaErrorCode = alpacaErrorCode;
        }

        protected AlpacaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            AlpacaErrorCode = info.GetInt32(nameof(AlpacaErrorCode));
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(AlpacaErrorCode), AlpacaErrorCode);
            base.GetObjectData(info, context);
        }
    }
}