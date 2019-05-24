using ES.AscomAlpaca.Client.Devices;

namespace ES.AscomAlpaca.Client.Responses
{
    /// <summary>
    /// Response that return the value as a <see cref="AlignmentMode"/>
    /// </summary>
    public class AlignmentModeResponse : Response, IValueResponse<AlignmentMode>
    {
        /// <summary>
        /// Alignment mode returned by the device
        /// </summary>
        public AlignmentMode Value { get; set; }
    }
}