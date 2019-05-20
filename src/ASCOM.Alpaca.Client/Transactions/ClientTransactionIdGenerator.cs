using System.Collections.Generic;

namespace AscomAlpacaClient.Transactions
{
    /// <summary>
    /// Generate a client transaction ID.
    /// This identifier can be useful to associate events in device and client logs
    /// </summary>
    public class ClientTransactionIdGenerator : IClientTransactionIdGenerator
    {
        private readonly object _lockObject = new object();
        private readonly Dictionary<int, int> _generatedTransactionId = new Dictionary<int, int>();
        
        /// <summary>
        /// Generate a client transaction ID.
        /// The client start to count at 1 and increment by one on each call for a given <paramref name="clientId"/>
        /// </summary>
        /// <returns>Generated client transaction ID</returns>
        public int GetTransactionId(int clientId)
        {
            lock (_lockObject)
            {
                _generatedTransactionId.TryGetValue(clientId, out var currentValue);
                currentValue++;
                _generatedTransactionId[clientId] = currentValue;
                return currentValue;
            }
        }
    }
}