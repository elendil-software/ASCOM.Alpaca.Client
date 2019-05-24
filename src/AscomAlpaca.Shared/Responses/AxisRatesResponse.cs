using System.Collections.Generic;
using ES.AscomAlpaca.Devices;

namespace ES.AscomAlpaca.Responses
{
    /// <summary>
    /// Response that return the value as a collection of <see cref="AxisRate"/>
    /// </summary>
    public class AxisRatesResponse : CommandResponse, IValueResponse<IList<AxisRate>>
    {
        /// <summary>
        /// Axis rate collection returned by the device
        /// </summary>
        public IList<AxisRate> Value { get; set; }
    }
}