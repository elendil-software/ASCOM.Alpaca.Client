namespace ES.Ascom.Alpaca.Exceptions
{
    /// <summary>
    /// Error numbers that can be returned by ASCOM Alpaca devices.
    /// </summary>
    /// <remarks>
    /// The range 0x400 to 0x4FF is reserved for ASCOM Alpaca common errors. These errors code are
    /// implemented in provided exception like <see cref="AlpacaNotImplementedException"/>, <see cref="AlpacaNotConnectedException"/>, ...
    /// </remarks>
    /// <remarks>
    /// The range 0x400 to 0x4FF is reserved for any other error an ASCOM Alpaca device can return
    /// </remarks>
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
        /// <seealso cref="AlpacaNotConnectedException"/>
        public static readonly int NotConnected = 0x407;

        /// <summary>
        /// Invalid While Parked
        /// Indicate that the attempted operation is invalid because the mount is currently in a Parked state.
        /// </summary>
        /// <seealso cref="AlpacaParkedException"/>
        public static readonly int InvalidWhileParked = 0x408;

        /// <summary>
        /// Invalid While Slaved
        /// Indicate that the attempted operation is invalid because the mount is currently in a Slaved state.
        /// </summary>
        /// <seealso cref="AlpacaSlavedException" />
        public static readonly int InvalidWhileSlaved = 0x409;
        
        /// <summary>
        /// Invalid Operation
        /// Indicate that the requested operation can not be undertaken at this time.
        /// </summary>
        /// <seealso cref="AlpacaInvalidOperationException" />
        public static readonly int InvalidOperation = 0x40B;

        /// <summary>
        /// Action Not Implemented
        /// Indicate that the requested action is not implemented in this driver.
        /// </summary>
        /// <seealso cref="AlpacaNotImplementedException" />
        public static readonly int ActionNotImplemented = 0x40C;

        /// <summary>
        /// Default code used in exception if no error code has been specified
        /// </summary>
        public static readonly int UnspecifiedError = 0x4FF;

        /// <summary>
        /// The minimum value a custom device error can take
        /// </summary>
        public static readonly int CustomErrorMinValue = 0x500;
        /// <summary>
        /// The maximum value a custom device error can take
        /// </summary>
        public static readonly int CustomErrorMaxValue = 0xFFF;
        
    }
}