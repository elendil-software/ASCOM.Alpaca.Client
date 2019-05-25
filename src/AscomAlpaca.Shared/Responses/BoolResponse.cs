namespace ES.AscomAlpaca.Responses
{
    /// <summary>
    /// Response that return the value as a boolean
    /// </summary>
    public class BoolResponse : CommandResponse, IValueResponse<bool>
    {
        private BoolResponse()
        {
        }

        public BoolResponse(bool value, uint clientTransactionId = 0, uint serverTransactionId = 0) : base(clientTransactionId, serverTransactionId)
        {
            Value = value;
        }

        public BoolResponse(int errorNumber, string errorMessage, uint clientTransactionId = 0, uint serverTransactionId = 0) : 
            base(errorNumber, errorMessage, clientTransactionId, serverTransactionId)
        {
        }
        
        /// <summary>
        /// boolean value returned by the device
        /// </summary>
        public bool Value { get; private set; }
    }
}