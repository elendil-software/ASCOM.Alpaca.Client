using System;
using AscomAlpacaClient.Exceptions;

namespace AscomAlpacaClient.Errors
{
    /// <summary>
    /// Error numbers for use by drivers.
    /// </summary>
    public static class ErrorCodes
    {
        /// <summary>
        /// Reserved error code (0x400) for property or method not implemented.
        /// </summary>
        /// <seealso cref="AlpacaNotImplementedException"/>
        public static readonly int NotImplemented = 0x400;

        /// <summary>
        /// Reserved error code (0x401) for reporting an invalid value.
        /// </summary>
        /// <seealso cref="AlpacaInvalidValueException"/>
        public static readonly int InvalidValue = 0x401;

        /// <summary>
        /// Reserved error code (0x402) for reporting that a value has not been set.
        /// </summary>
        /// <seealso cref="AlpacaValueNotSetException"/>
        public static readonly int ValueNotSet = 0x402;

        /// <summary>
        /// Reserved error code (0x407) used to indicate that the communications channel is not connected.
        /// </summary>
        public static readonly int NotConnected = 0x407;

        /// <summary>
        /// Reserved error code (0x408) used to indicate that the attempted operation is invalid because the mount
        /// is currently in a Parked state.
        /// </summary>
        public static readonly int InvalidWhileParked = 0x408;

        /// <summary>
        /// Reserved error code (0x409) used to indicate that the attempted operation is invalid because the mount
        /// is currently in a Slaved state.
        /// </summary>
        public static readonly int InvalidWhileSlaved = 0x409;

        /// <summary>
        /// Reserved error code (0x40A) related to settings.
        /// </summary>
        public static readonly int SettingsProviderError = 0x40A;

        /// <summary>
        /// Reserved error code (0x40B) to indicate that the requested operation can not be undertaken at this time.
        /// </summary>
        public static readonly int InvalidOperationException = 0x40B;

        /// <summary>
        /// Reserved error code (0x40C) to indicate that the requested action is not implemented in this driver.
        /// </summary>
        /// <seealso cref="NotImplemented"/>
        [Obsolete("Replaced by NotImplemented")]
        public static readonly int ActionNotImplementedException = 0x40C;

        /// <summary>
        /// Reserved 'catch-all' error code (0x4FF) used when nothing else was specified.
        /// </summary>
        public static readonly int UnspecifiedError = 0x4FF;
    }
}