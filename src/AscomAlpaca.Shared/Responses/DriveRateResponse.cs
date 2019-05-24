using ES.AscomAlpaca.Devices;

namespace ES.AscomAlpaca.Responses
{
    /// <summary>
    /// Response that return the value as a <see cref="DriveRate"/>
    /// </summary>
    public class DriveRateResponse : Response, IValueResponse<DriveRate>
    {
        /// <summary>
        /// Drive rate returned by the device
        /// </summary>
        public DriveRate Value { get; set; }
    }
}