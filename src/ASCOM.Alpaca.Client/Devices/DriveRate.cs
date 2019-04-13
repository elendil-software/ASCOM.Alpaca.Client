namespace ASCOM.Alpaca.Client.Devices
{
    public enum DriveRate
    {
        /// <summary>
        /// Sidereal tracking rate (15.041 arcseconds per second).
        /// </summary>
        driveSidereal = 0,

        /// <summary>
        /// Lunar tracking rate (14.685 arcseconds per second).
        /// </summary>
        driveLunar = 1,

        /// <summary>
        /// Solar tracking rate (15.0 arcseconds per second).
        /// </summary>
        driveSolar = 2,

        /// <summary>
        /// King tracking rate (15.0369 arcseconds per second).
        /// </summary>
        driveKing = 3
    }
}