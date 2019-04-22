namespace ASCOM.Alpaca.Devices.Telescope
{
    public enum PierSide
    {
        /// <summary>
        /// Normal pointing state - Mount on the East side of pier (looking West)
        /// </summary>
        East = 0,

        /// <summary>
        /// Unknown or indeterminate.
        /// </summary>
        Unknown = -1,

        /// <summary>
        /// Through the pole pointing state - Mount on the West side of pier (looking East)
        /// </summary>
        West = 1
    }
}