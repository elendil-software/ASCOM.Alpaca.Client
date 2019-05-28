using System;
using System.Runtime.Serialization;

namespace ES.AscomAlpaca.Exceptions
{
    
    /// <summary>
    /// Represents errors that occur during ASCOM Alpaca related application execution.
    /// </summary>
    /// <remarks>This exception is related to errors that can occur during execution on the server/device side</remarks>
    [Serializable]
    public class AlpacaDeviceException : AlpacaException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaDeviceException" /> class.
        /// </summary>
        public AlpacaDeviceException()
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaDeviceException" /> class with a specified error code.
        /// </summary>
        /// <param name="alpacaErrorCode">An error code in the <see cref="ErrorCodes"/> code range</param>
        public AlpacaDeviceException(int alpacaErrorCode) : base(alpacaErrorCode)
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaDeviceException" /> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public AlpacaDeviceException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaDeviceException" /> class with a specified error message and an error code
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="alpacaErrorCode">An error code in the <see cref="ErrorCodes"/> code range</param>
        public AlpacaDeviceException(string message, int alpacaErrorCode) : base(message, alpacaErrorCode)
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaDeviceException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception</param>
        public AlpacaDeviceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaDeviceException" /> class with a specified error message, an error code and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="alpacaErrorCode">An error code in the <see cref="ErrorCodes"/> code range</param>
        /// <param name="innerException">The exception that is the cause of the current exception</param>
        public AlpacaDeviceException(string message, int alpacaErrorCode, Exception innerException) : base(message, alpacaErrorCode, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaDeviceException" /> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        protected AlpacaDeviceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}