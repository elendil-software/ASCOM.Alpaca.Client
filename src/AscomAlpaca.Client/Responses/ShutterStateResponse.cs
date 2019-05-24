using ES.AscomAlpaca.Client.Devices;

namespace ES.AscomAlpaca.Client.Responses
{
    /// <summary>
    /// Response that return the value as a <see cref="ShutterState"/>
    /// </summary>
    public class ShutterStateResponse : Response, IValueResponse<ShutterState>
    {
        /// <summary>
        /// Shutter state returned by the device
        /// </summary>
        public ShutterState Value { get; set; }
    }
}

