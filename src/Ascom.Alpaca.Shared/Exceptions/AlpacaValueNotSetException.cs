using System;
using System.Runtime.Serialization;

namespace ES.Ascom.Alpaca.Exceptions
{
    /// <summary>
    /// Represents errors that occur when  no value has yet been set for a property.
    /// </summary>
    [Serializable]
    public class AlpacaValueNotSetException : AlpacaDeviceException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaActionNotImplementedException" /> class.
        /// </summary>
        public AlpacaValueNotSetException() : base(ErrorCodes.ValueNotSet)
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaActionNotImplementedException" /> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public AlpacaValueNotSetException(string message) : base(message, ErrorCodes.ValueNotSet)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaActionNotImplementedException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception</param>
        public AlpacaValueNotSetException(string message, Exception innerException) : base(message, ErrorCodes.ValueNotSet, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaActionNotImplementedException" /> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        protected AlpacaValueNotSetException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}