using ASCOM.Alpaca.Client.Devices;

namespace ASCOM.Alpaca.Client.Responses
{
    /// <summary>
    /// Response that return the value as a <see cref="SensorType"/>
    /// </summary>
    public class SensorTypeResponse : Response, IValueResponse<SensorType>
    {
        /// <summary>
        /// Sensor type returned by the device
        /// </summary>
        public SensorType Value { get; set; }
    }
}