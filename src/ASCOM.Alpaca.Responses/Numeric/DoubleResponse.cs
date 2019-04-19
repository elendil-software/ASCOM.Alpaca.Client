namespace ASCOM.Alpaca.Responses.Numeric
{
    public class DoubleResponse : ResponseBase, IValueResponse<double>
    {
        public double Value { get; internal set; }
    }
}