using System.Collections.Generic;

namespace ES.AscomAlpaca.Responses
{
    /// <summary>
    /// Response that return the value as a collection of integer
    /// </summary>
    public class IntListResponse : CommandResponse, IValueResponse<IList<int>>
    {
        public IntListResponse()
        {
        }

        public IntListResponse(IList<int> value, uint clientTransactionId = 0, uint serverTransactionId = 0) : base(clientTransactionId, serverTransactionId)
        {
            Value = value ?? new List<int>();
        }

        public IntListResponse(int errorNumber, string errorMessage, uint clientTransactionId = 0, uint serverTransactionId = 0) : 
            base(errorNumber, errorMessage, clientTransactionId, serverTransactionId)
        {
        }
        
        /// <summary>
        /// Integer collection returned by the device
        /// </summary>
        public IList<int> Value  { get; private set; }
    }
}