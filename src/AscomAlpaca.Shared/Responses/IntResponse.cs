namespace ES.AscomAlpaca.Responses
{
    /// <summary>
    /// Response that return the value as an integer
    /// </summary>
    public class IntResponse : CommandResponse, IValueResponse<int>
    {
        public IntResponse()
        {
        }

        public IntResponse(int value, uint clientTransactionId = 0, uint serverTransactionId = 0) : base(clientTransactionId, serverTransactionId)
        {
            Value = value;
        }

        public IntResponse(int errorNumber, string errorMessage, uint clientTransactionId = 0, uint serverTransactionId = 0) : 
            base(errorNumber, errorMessage, clientTransactionId, serverTransactionId)
        {
        }
        
        /// <summary>
        /// Integer value returned by the device
        /// </summary>
        public int Value { get; set; }
    }
}