using ES.AscomAlpaca.Client.Exceptions;

namespace ES.AscomAlpaca.Client.Errors
{
    /// <summary>
    /// Error numbers for use by drivers.
    /// </summary>
    public static class ErrorCodes
    {
        /// <summary>
        /// Property or method not implemented
        /// </summary>
        /// <seealso cref="AlpacaNotImplementedException"/>
        public static readonly int NotImplemented = 0x400;

        /// <summary>
        /// Invalid value
        /// </summary>
        /// <seealso cref="AlpacaInvalidValueException"/>
        public static readonly int InvalidValue = 0x401;

        /// <summary>
        /// Value not set
        /// </summary>
        /// <seealso cref="AlpacaValueNotSetException"/>
        public static readonly int ValueNotSet = 0x402;

        /// <summary>
        /// Not connected
        /// Indicates the action can not be executed because the device is not connected 
        /// </summary>
        public static readonly int NotConnected = 0x407;

        /// <summary>
        /// Invalid While Parked
        /// Indicate that the attempted operation is invalid because the mount is currently in a Parked state.
        /// </summary>
        public static readonly int InvalidWhileParked = 0x408;

        /// <summary>
        /// Invalid While Slaved
        /// Indicate that the attempted operation is invalid because the mount is currently in a Slaved state.
        /// </summary>
        public static readonly int InvalidWhileSlaved = 0x409;
        
        /// <summary>
        /// Invalid Operation
        /// Indicate that the requested operation can not be undertaken at this time.
        /// </summary>
        public static readonly int InvalidOperation = 0x40B;

        /// <summary>
        /// Action Not Implemented
        /// Indicate that the requested action is not implemented in this driver.
        /// </summary>
        public static readonly int ActionNotImplemented = 0x40C;

        /// <summary>
        /// Default code used in exception if no error code has been specified
        /// </summary>
        public static readonly int UnspecifiedError = 0x4FF;
    }
}