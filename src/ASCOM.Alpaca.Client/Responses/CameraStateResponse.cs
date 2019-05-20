using AscomAlpacaClient.Devices;

namespace AscomAlpacaClient.Responses
{
    /// <summary>
    /// Response that return the value as a <see cref="CameraState"/>
    /// </summary>
    public class CameraStateResponse : Response, IValueResponse<CameraState>
    {
        /// <summary>
        /// Camera state returned by the device
        /// </summary>
        public CameraState Value { get; set; }
    }
}