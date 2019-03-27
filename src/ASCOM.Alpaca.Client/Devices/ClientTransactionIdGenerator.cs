namespace ASCOM.Alpaca.Client.Device
{
    public class ClientTransactionIdGenerator : IClientTransactionIdGenerator
    {
        private readonly object lockObject = new object();
        private int _currentTransactionId = 0;
        
        public int GetTransactionId()
        {
            lock (lockObject)
            {
                _currentTransactionId++;
                return _currentTransactionId;
            }
        }
    }
}