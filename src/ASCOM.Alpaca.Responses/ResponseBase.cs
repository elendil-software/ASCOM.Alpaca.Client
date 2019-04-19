namespace ASCOM.Alpaca.Responses
{
    public abstract class ResponseBase : IResponse
    {
        public int ClientTransactionID { get; internal set; }
        public int ServerTransactionID { get; internal set; }
        public int ErrorNumber { get; internal set; }
        public string ErrorMessage { get; internal set; }
    }
}