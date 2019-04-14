namespace ASCOM.Alpaca.Client.Devices.Telescope
{
    public enum TelescopeAxis
    {
        /// <summary>
        /// Primary axis (e.g., Right Ascension or Azimuth).
        /// </summary>
        AxisPrimary = 0,

        /// <summary>
        /// Secondary axis (e.g., Declination or Altitude).
        /// </summary>
        AxisSecondary = 1,

        /// <summary>
        /// Tertiary axis (e.g. imager rotator/de-rotator).
        /// </summary>
        AxisTertiary = 3
    }
}