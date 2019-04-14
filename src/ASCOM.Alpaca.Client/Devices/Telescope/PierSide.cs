namespace ASCOM.Alpaca.Client.Devices.Telescope
{
    public enum PierSide
    {
        /// <summary>
        /// Normal pointing state - Mount on the East side of pier (looking West)
        /// </summary>
        pierEast = 0,

        /// <summary>
        /// Unknown or indeterminate.
        /// </summary>
        pierUnknown = -1,

        /// <summary>
        /// Through the pole pointing state - Mount on the West side of pier (looking East)
        /// </summary>
        pierWest = 1
    }
}