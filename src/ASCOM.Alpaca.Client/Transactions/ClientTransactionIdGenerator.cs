namespace ASCOM.Alpaca.Client.Transactions
{
    public class ClientTransactionIdGenerator : IClientTransactionIdGenerator
    {
        private readonly object _lockObject = new object();
        private int _currentTransactionId;
        
        public int GetTransactionId()
        {
            lock (_lockObject)
            {
                _currentTransactionId++;
                return _currentTransactionId;
            }
        }
    }
}