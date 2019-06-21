using System;
using System.Runtime.Serialization;

namespace ES.AscomAlpaca.Exceptions
{
    /// <summary>
    /// Represents errors that occur when a parameter received by the device has an invalid value
    /// </summary>
    [Serializable]
    public class AlpacaInvalidValueException : AlpacaDeviceException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaInvalidValueException" /> class.
        /// </summary>
        public AlpacaInvalidValueException() : base(ErrorCodes.InvalidValue)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaInvalidValueException" /> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public AlpacaInvalidValueException(string message) : base(message, ErrorCodes.InvalidValue)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaInvalidValueException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception</param>
        public AlpacaInvalidValueException(string message, Exception innerException) : base(message, ErrorCodes.InvalidValue, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaInvalidValueException" /> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        protected AlpacaInvalidValueException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}