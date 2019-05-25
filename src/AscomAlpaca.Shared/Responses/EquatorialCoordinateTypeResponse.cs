using ES.AscomAlpaca.Devices;

namespace ES.AscomAlpaca.Responses
{
    /// <summary>
    /// Response that return the value as a <see cref="EquatorialCoordinateType"/>
    /// </summary>
    public class EquatorialCoordinateTypeResponse : CommandResponse, IValueResponse<EquatorialCoordinateType>
    {
        public EquatorialCoordinateTypeResponse()
        {
        }

        public EquatorialCoordinateTypeResponse(EquatorialCoordinateType value, uint clientTransactionId = 0, uint serverTransactionId = 0) : base(clientTransactionId, serverTransactionId)
        {
            Value = value;
        }

        public EquatorialCoordinateTypeResponse(int errorNumber, string errorMessage, uint clientTransactionId = 0, uint serverTransactionId = 0) : 
            base(errorNumber, errorMessage, clientTransactionId, serverTransactionId)
        {
        }
        
        /// <summary>
        /// Equatorial coordinate type returned by the device
        /// </summary>
        public EquatorialCoordinateType Value { get; set; }
    }
}