using System.Collections.Generic;
using ES.AscomAlpaca.Devices;

namespace ES.AscomAlpaca.Responses
{
    /// <summary>
    /// Response that return the value as a collection of <see cref="AxisRate"/>
    /// </summary>
    public class AxisRatesResponse : CommandResponse, IValueResponse<IList<AxisRate>>
    {
        private AxisRatesResponse()
        {
        }

        public AxisRatesResponse(IList<AxisRate> value, uint clientTransactionId = 0, uint serverTransactionId = 0) : base(clientTransactionId, serverTransactionId)
        {
            Value = value ?? new List<AxisRate>();
        }

        public AxisRatesResponse(int errorNumber, string errorMessage, uint clientTransactionId = 0, uint serverTransactionId = 0) : 
            base(errorNumber, errorMessage, clientTransactionId, serverTransactionId)
        {
        }
        
        /// <summary>
        /// Axis rate collection returned by the device
        /// </summary>
        public IList<AxisRate> Value  { get; private set; }
    }
}