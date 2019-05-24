using System.Collections.Generic;
using ES.AscomAlpaca.Devices;

namespace ES.AscomAlpaca.Responses
{
    /// <summary>
    /// Response that return the value as a collection of <see cref="DriveRate"/>
    /// </summary>
    public class DriveRatesResponse : CommandResponse, IValueResponse<IList<DriveRate>>
    {
        /// <summary>
        /// Drive rate collection returned by the device
        /// </summary>
        public IList<DriveRate> Value { get; set; }
    }
}