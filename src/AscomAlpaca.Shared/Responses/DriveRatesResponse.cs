using System.Collections.Generic;
using ES.AscomAlpaca.Devices;

namespace ES.AscomAlpaca.Responses
{
    /// <summary>
    /// Response that return the value as a collection of <see cref="DriveRate"/>
    /// </summary>
    public class DriveRatesResponse : CommandResponse, IValueResponse<IList<DriveRate>>
    {
        private DriveRatesResponse()
        {
        }

        public DriveRatesResponse(IList<DriveRate> value, uint clientTransactionId = 0, uint serverTransactionId = 0) : base(clientTransactionId, serverTransactionId)
        {
            Value = value ?? new List<DriveRate>();
        }

        public DriveRatesResponse(int errorNumber, string errorMessage, uint clientTransactionId = 0, uint serverTransactionId = 0) : 
            base(errorNumber, errorMessage, clientTransactionId, serverTransactionId)
        {
        }
        
        /// <summary>
        /// Drive rate collection returned by the device
        /// </summary>
        public IList<DriveRate> Value { get; private set; }
    }
}