using ES.AscomAlpaca.Devices;

namespace ES.AscomAlpaca.Responses
{
    /// <summary>
    /// Response that return the value as a <see cref="EquatorialCoordinateType"/>
    /// </summary>
    public class EquatorialCoordinateTypeResponse : CommandResponse, IValueResponse<EquatorialCoordinateType>
    {
        /// <summary>
        /// Equatorial coordinate type returned by the device
        /// </summary>
        public EquatorialCoordinateType Value { get; set; }
    }
}