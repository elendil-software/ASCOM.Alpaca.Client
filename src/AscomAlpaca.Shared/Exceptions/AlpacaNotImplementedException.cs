using System;
using System.Runtime.Serialization;

namespace ES.AscomAlpaca.Exceptions
{
    /// <summary>
    /// Represents errors that occur when an operation was attempted and the device does not implement such operation.
    /// </summary>
    [Serializable]
    public class AlpacaNotImplementedException : AlpacaDeviceException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaNotImplementedException" /> class.
        /// </summary>
        public AlpacaNotImplementedException() : base(ErrorCodes.NotImplemented)
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaNotImplementedException" /> class with a specified error code.
        /// </summary>
        /// <param name="alpacaErrorCode">An error code in the <see cref="ErrorCodes"/> code range</param>
        protected AlpacaNotImplementedException(int alpacaErrorCode) : base(alpacaErrorCode)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaNotImplementedException" /> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public AlpacaNotImplementedException(string message) : base(message, ErrorCodes.NotImplemented)
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaNotImplementedException" /> class with a specified error message and an error code
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="alpacaErrorCode">An error code in the <see cref="ErrorCodes"/> code range</param>
        protected AlpacaNotImplementedException(string message, int alpacaErrorCode) : base(message, alpacaErrorCode)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaNotImplementedException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception</param>
        public AlpacaNotImplementedException(string message, Exception innerException) : base(message, ErrorCodes.NotImplemented, innerException)
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaNotImplementedException" /> class with a specified error message, an error code and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="alpacaErrorCode">An error code in the <see cref="ErrorCodes"/> code range</param>
        /// <param name="innerException">The exception that is the cause of the current exception</param>
        protected AlpacaNotImplementedException(string message, int alpacaErrorCode, Exception innerException) : base(message, alpacaErrorCode, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaNotImplementedException" /> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        protected AlpacaNotImplementedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}