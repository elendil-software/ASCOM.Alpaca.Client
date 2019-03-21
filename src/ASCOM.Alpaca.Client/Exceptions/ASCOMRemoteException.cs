using System;
using System.Runtime.Serialization;

namespace ASCOM.Alpaca.Client.Exceptions
{
    [Serializable]
    public class ASCOMRemoteException : Exception
    {
        public ASCOMRemoteException()
        {
        }

        public ASCOMRemoteException(string message) : base(message)
        {
        }

        public ASCOMRemoteException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ASCOMRemoteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}