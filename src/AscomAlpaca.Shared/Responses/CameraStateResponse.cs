using ES.AscomAlpaca.Devices;

namespace ES.AscomAlpaca.Responses
{
    /// <summary>
    /// Response that return the value as a <see cref="CameraState"/>
    /// </summary>
    public class CameraStateResponse : CommandResponse, IValueResponse<CameraState>
    {
        /// <summary>
        /// Camera state returned by the device
        /// </summary>
        public CameraState Value { get; set; }
    }
}