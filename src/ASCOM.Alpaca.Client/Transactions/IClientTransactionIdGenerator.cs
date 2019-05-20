namespace AscomAlpacaClient.Transactions
{
    /// <summary>
    /// Generate a client transaction ID.
    /// This identifier can be useful to associate events in device and client logs
    /// </summary>
    public interface IClientTransactionIdGenerator
    {
        /// <summary>
        /// Generate a client transaction ID.
        /// The client start to count at 1 and increment by one on each call for a given <paramref name="clientId"/>
        /// </summary>
        /// <returns>Generated client transaction ID</returns>
        int GetTransactionId(int clientId);
    }
}