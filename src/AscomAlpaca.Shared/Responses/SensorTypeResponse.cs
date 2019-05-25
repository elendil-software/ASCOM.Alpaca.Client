using ES.AscomAlpaca.Devices;

namespace ES.AscomAlpaca.Responses
{
    /// <summary>
    /// Response that return the value as a <see cref="SensorType"/>
    /// </summary>
    public class SensorTypeResponse : CommandResponse, IValueResponse<SensorType>
    {
        private SensorTypeResponse()
        {
        }

        public SensorTypeResponse(SensorType value, uint clientTransactionId = 0, uint serverTransactionId = 0) : base(clientTransactionId, serverTransactionId)
        {
            Value = value;
        }

        public SensorTypeResponse(int errorNumber, string errorMessage, uint clientTransactionId = 0, uint serverTransactionId = 0) : 
            base(errorNumber, errorMessage, clientTransactionId, serverTransactionId)
        {
        }
        
        /// <summary>
        /// Sensor type returned by the device
        /// </summary>
        public SensorType Value { get; set; }
    }
}