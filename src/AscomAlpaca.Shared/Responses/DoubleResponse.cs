namespace ES.AscomAlpaca.Responses
{
    /// <summary>
    /// Response that return the value as a double
    /// </summary>
    public class DoubleResponse : CommandResponse, IValueResponse<double>
    {
        /// <summary>
        /// double value returned by the device
        /// </summary>
        public double Value { get; set; }
    }
}