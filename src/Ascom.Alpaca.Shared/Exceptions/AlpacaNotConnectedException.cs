using System;
using System.Runtime.Serialization;

namespace ES.AscomAlpaca.Exceptions
{
    /// <summary>
    /// Represents errors that occur when an operation was attempted while the device was not connected
    /// </summary>
    [Serializable]
    public class AlpacaNotConnectedException : AlpacaInvalidOperationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaNotConnectedException" /> class.
        /// </summary>
        public AlpacaNotConnectedException() : base(ErrorCodes.NotConnected)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaNotConnectedException" /> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public AlpacaNotConnectedException(string message) : base(message,  ErrorCodes.NotConnected)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaNotConnectedException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception</param>
        public AlpacaNotConnectedException(string message, Exception innerException) : base(message,  ErrorCodes.NotConnected, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaNotConnectedException" /> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        protected AlpacaNotConnectedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}