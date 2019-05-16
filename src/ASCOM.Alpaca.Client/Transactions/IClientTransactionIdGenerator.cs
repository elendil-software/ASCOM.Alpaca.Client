namespace ASCOM.Alpaca.Client.Transactions
{
    /// <summary>
    /// Generate a client transaction ID.
    /// This identifier can be useful to associate events in device and client logs
    /// </summary>
    public interface IClientTransactionIdGenerator
    {
        /// <summary>
        /// Generate a client transaction ID.
        /// The client should start this count at 1 and increment by one on each successive transaction.
        /// This will aid associating entries in device logs with corresponding entries in client side logs.
        /// </summary>
        /// <returns>Generated client transaction ID</returns>
        int GetTransactionId();
    }
}