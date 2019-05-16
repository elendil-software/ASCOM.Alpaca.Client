namespace ASCOM.Alpaca.Client.Transactions
{
    /// <summary>
    /// Generate a client transaction ID.
    /// This identifier can be useful to associate events in device and client logs
    /// </summary>
    public class ClientTransactionIdGenerator : IClientTransactionIdGenerator
    {
        private readonly object _lockObject = new object();
        private int _currentTransactionId;
        
        /// <summary>
        /// Generate a client transaction ID.
        /// The client should start this count at 1 and increment by one on each successive transaction.
        /// This will aid associating entries in device logs with corresponding entries in client side logs.
        /// </summary>
        /// <returns>Generated client transaction ID</returns>
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