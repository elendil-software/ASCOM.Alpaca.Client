using ES.AscomAlpaca.Devices;

namespace ES.AscomAlpaca.Responses
{
    /// <summary>
    /// Response that return the value as a <see cref="PierSide"/>
    /// </summary>
    public class PierSideResponse : CommandResponse, IValueResponse<PierSide>
    {
        public PierSideResponse()
        {
        }

        public PierSideResponse(PierSide value, uint clientTransactionId = 0, uint serverTransactionId = 0) : base(clientTransactionId, serverTransactionId)
        {
            Value = value;
        }

        public PierSideResponse(int errorNumber, string errorMessage, uint clientTransactionId = 0, uint serverTransactionId = 0) : 
            base(errorNumber, errorMessage, clientTransactionId, serverTransactionId)
        {
        }
        
        /// <summary>
        /// Pier side returned by the device
        /// </summary>
        public PierSide Value { get; set; }
    }
}