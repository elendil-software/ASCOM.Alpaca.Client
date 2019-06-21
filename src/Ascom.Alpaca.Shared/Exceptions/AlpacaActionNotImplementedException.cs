using System;
using System.Runtime.Serialization;

namespace ES.Ascom.Alpaca.Exceptions
{
    /// <summary>
    /// Represents errors that occur when an unknown command is send through
    /// <see cref="!:https://ascom-standards.org/api/#/ASCOM%20Methods%20Common%20To%20All%20Devices/put__device_type___device_number__action">Action</see> command
    /// </summary>
    [Serializable]
    public class AlpacaActionNotImplementedException : AlpacaNotImplementedException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaActionNotImplementedException" /> class.
        /// </summary>
        public AlpacaActionNotImplementedException() : base(ErrorCodes.ActionNotImplemented)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaActionNotImplementedException" /> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public AlpacaActionNotImplementedException(string message) : base(message, ErrorCodes.ActionNotImplemented)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaActionNotImplementedException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception</param>
        public AlpacaActionNotImplementedException(string message, Exception innerException) : base(message, ErrorCodes.ActionNotImplemented, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaActionNotImplementedException" /> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        protected AlpacaActionNotImplementedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}