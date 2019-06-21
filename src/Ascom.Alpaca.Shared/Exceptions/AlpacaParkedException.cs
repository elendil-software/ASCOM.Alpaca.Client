using System;
using System.Runtime.Serialization;

namespace ES.AscomAlpaca.Exceptions
{
    /// <summary>
    /// Represents errors that occur when an operation was attempted while the device was in a parked state.
    /// </summary>
    [Serializable]
    public class AlpacaParkedException : AlpacaInvalidOperationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaParkedException" /> class.
        /// </summary>
        public AlpacaParkedException() : base(ErrorCodes.InvalidWhileParked)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaParkedException" /> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public AlpacaParkedException(string message) : base(message, ErrorCodes.InvalidWhileParked)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaParkedException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception</param>
        public AlpacaParkedException(string message, Exception innerException) : base(message, ErrorCodes.InvalidWhileParked, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaParkedException" /> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        protected AlpacaParkedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}