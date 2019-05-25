using ES.AscomAlpaca.Devices;

namespace ES.AscomAlpaca.Responses
{
    /// <summary>
    /// Response that return the value as a <see cref="CameraState"/>
    /// </summary>
    public class CameraStateResponse : CommandResponse, IValueResponse<CameraState>
    {
        public CameraStateResponse()
        {
        }

        public CameraStateResponse(CameraState value, uint clientTransactionId = 0, uint serverTransactionId = 0) : base(clientTransactionId, serverTransactionId)
        {
            Value = value;
        }

        public CameraStateResponse(int errorNumber, string errorMessage, uint clientTransactionId = 0, uint serverTransactionId = 0) : 
            base(errorNumber, errorMessage, clientTransactionId, serverTransactionId)
        {
        }
        
        /// <summary>
        /// Camera state returned by the device
        /// </summary>
        public CameraState Value { get; private set; }
    }
}