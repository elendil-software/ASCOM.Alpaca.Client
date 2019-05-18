using System.Collections.Generic;
using ASCOM.Alpaca.Client.Devices;

namespace ASCOM.Alpaca.Client.Responses
{
    /// <summary>
    /// Response that return the value as a collection of <see cref="AxisRate"/>
    /// </summary>
    public class AxisRatesResponse : Response, IValueResponse<IList<AxisRate>>
    {
        /// <summary>
        /// Axis rate collection returned by the device
        /// </summary>
        public IList<AxisRate> Value { get; set; }
    }
}