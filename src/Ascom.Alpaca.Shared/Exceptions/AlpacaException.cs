using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ES.Ascom.Alpaca.Exceptions
{ 
    /// <summary>
    /// Represents errors that occur during ASCOM Alpaca related application execution.
    /// </summary>
    /// <remarks>
    /// This is the base class of any ASCOM Alpaca exception
    /// </remarks>
    /// <seealso cref="AlpacaDeviceException"/>
    /// <seealso cref="AlpacaNotImplementedException"/>
    /// <seealso cref="AlpacaActionNotImplementedException"/>
    /// <seealso cref="AlpacaInvalidOperationException"/>
    /// <seealso cref="AlpacaNotConnectedException"/>
    /// <seealso cref="AlpacaParkedException"/>
    /// <seealso cref="AlpacaSlavedException"/>
    /// <seealso cref="AlpacaInvalidValueException"/>
    /// <seealso cref="AlpacaValueNotSetException"/>
    [Serializable]
    public class AlpacaException : Exception
    {
        /// <summary>
        /// An error code in the <see cref="ErrorCodes"/> code range
        /// </summary>
        public int AlpacaErrorCode { get; protected set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaException" /> class.
        /// </summary>
        public AlpacaException()
        {
            AlpacaErrorCode = ErrorCodes.UnspecifiedError;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaException" /> class with a specified error code.
        /// </summary>
        /// <param name="alpacaErrorCode">An error code in the <see cref="ErrorCodes"/> code range</param>
        public AlpacaException(int alpacaErrorCode)
        {
            AlpacaErrorCode = alpacaErrorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaException" /> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public AlpacaException(string message) : base(message)
        {
            AlpacaErrorCode = ErrorCodes.UnspecifiedError;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaException" /> class with a specified error message and an error code
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="alpacaErrorCode">An error code in the <see cref="ErrorCodes"/> code range</param>
        public AlpacaException(string message, int alpacaErrorCode) : base(message)
        {
            AlpacaErrorCode = alpacaErrorCode;
        }
               
        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception</param>
        public AlpacaException(string message, Exception innerException) : base(message, innerException)
        {
            AlpacaErrorCode = ErrorCodes.UnspecifiedError;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaException" /> class with a specified error message, an error code and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="alpacaErrorCode">An error code in the <see cref="ErrorCodes"/> code range</param>
        /// <param name="innerException">The exception that is the cause of the current exception</param>
        public AlpacaException(string message, int alpacaErrorCode, Exception innerException) : base(message, innerException)
        {
            AlpacaErrorCode = alpacaErrorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlpacaException" /> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        protected AlpacaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            AlpacaErrorCode = info.GetInt32(nameof(AlpacaErrorCode));
        }

        /// <summary>Sets the <see cref="System.Runtime.Serialization.SerializationInfo" /> with information about the exception.</summary>
        /// <param name="info">The <see cref="System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown. </param>
        /// <param name="context">The <see cref="System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination. </param>
        /// <exception cref="System.ArgumentNullException">The <paramref name="info" /> parameter is a null reference</exception>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(AlpacaErrorCode), AlpacaErrorCode);
            base.GetObjectData(info, context);
        }
    }
}