using System;
using System.Runtime.Serialization;

namespace ES.Ascom.Alpaca.Exceptions
{
    /// <summary>
    /// Represents errors that occur when a command has been rejected by the device.
    /// </summary>
    [Serializable]
    public class AlpacaInvalidOperationException : AlpacaDeviceException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaInvalidOperationException" /> class.
        /// </summary>
        public AlpacaInvalidOperationException() : base(ErrorCodes.InvalidOperation)
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaInvalidOperationException" /> class with a specified error code.
        /// </summary>
        /// <param name="alpacaErrorCode">An error code in the <see cref="ErrorCodes"/> code range</param>
        protected AlpacaInvalidOperationException(int alpacaErrorCode) : base(alpacaErrorCode)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaInvalidOperationException" /> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public AlpacaInvalidOperationException(string message) : base(message, ErrorCodes.InvalidOperation)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaInvalidOperationException" /> class with a specified error message and an error code
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="alpacaErrorCode">An error code in the <see cref="ErrorCodes"/> code range</param>
        protected AlpacaInvalidOperationException(string message, int alpacaErrorCode) : base(message, alpacaErrorCode)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaInvalidOperationException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception</param>
        public AlpacaInvalidOperationException(string message, Exception innerException) : base(message, ErrorCodes.InvalidOperation, innerException)
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaInvalidOperationException" /> class with a specified error message, an error code and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="alpacaErrorCode">An error code in the <see cref="ErrorCodes"/> code range</param>
        /// <param name="innerException">The exception that is the cause of the current exception</param>
        protected AlpacaInvalidOperationException(string message, int alpacaErrorCode, Exception innerException) : base(message, alpacaErrorCode, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaInvalidOperationException" /> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        protected AlpacaInvalidOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}