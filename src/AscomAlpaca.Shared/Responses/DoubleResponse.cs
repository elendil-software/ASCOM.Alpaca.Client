namespace ES.AscomAlpaca.Responses
{
    /// <summary>
    /// Response that return the value as a double
    /// </summary>
    public class DoubleResponse : CommandResponse, IValueResponse<double>
    {
        public DoubleResponse()
        {
        }

        public DoubleResponse(double value, uint clientTransactionId = 0, uint serverTransactionId = 0) : base(clientTransactionId, serverTransactionId)
        {
            Value = value;
        }

        public DoubleResponse(int errorNumber, string errorMessage, uint clientTransactionId = 0, uint serverTransactionId = 0) : 
            base(errorNumber, errorMessage, clientTransactionId, serverTransactionId)
        {
        }
        
        /// <summary>
        /// double value returned by the device
        /// </summary>
        public double Value { get; private set; }
    }
}