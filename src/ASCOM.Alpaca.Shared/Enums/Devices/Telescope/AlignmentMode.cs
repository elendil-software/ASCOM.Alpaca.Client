namespace ASCOM.Alpaca.Enums.Devices.Telescope
{
    public enum AlignmentMode
    {
        /// <summary>
        /// Altitude-Azimuth alignment.
        /// </summary>
        AltAz = 0,

        /// <summary>
        /// Polar(equatorial) mount other than German equatorial.
        /// </summary>
        Polar = 1,

        /// <summary>
        /// German equatorial mount.
        /// </summary>
        GermanPolar = 2
    }
}