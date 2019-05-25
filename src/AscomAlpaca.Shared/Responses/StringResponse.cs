namespace ES.AscomAlpaca.Responses
{
    /// <summary>
    /// Response that return the value as a string
    /// </summary>
    public class StringResponse : CommandResponse, IValueResponse<string>
    {
        private StringResponse()
        {
        }

        public StringResponse(string value, uint clientTransactionId = 0, uint serverTransactionId = 0) : base(clientTransactionId, serverTransactionId)
        {
            Value = value ?? "";
        }

        public StringResponse(int errorNumber, string errorMessage, uint clientTransactionId = 0, uint serverTransactionId = 0) : 
            base(errorNumber, errorMessage, clientTransactionId, serverTransactionId)
        {
        }
        
        /// <summary>
        /// String value returned by the device
        /// </summary>
        public string Value { get; private set; }
    }
}