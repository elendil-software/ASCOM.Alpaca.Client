using System.Collections.Generic;

namespace ES.AscomAlpaca.Responses
{
    /// <summary>
    /// Response that return the value as a collection of strings
    /// </summary>
    public class StringListResponse : CommandResponse, IValueResponse<IList<string>>
    {
        private StringListResponse()
        {
        }

        public StringListResponse(IList<string> value, uint clientTransactionId = 0, uint serverTransactionId = 0) : base(clientTransactionId, serverTransactionId)
        {
            Value = value ?? new List<string>();
        }

        public StringListResponse(int errorNumber, string errorMessage, uint clientTransactionId = 0, uint serverTransactionId = 0) : 
            base(errorNumber, errorMessage, clientTransactionId, serverTransactionId)
        {
        }
        
        /// <summary>
        /// String collection returned by the device
        /// </summary>
        public IList<string> Value  { get; private set; }
    }
}