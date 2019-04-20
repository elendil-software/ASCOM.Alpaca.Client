namespace ASCOM.Alpaca.Responses.Numeric
{
    public class DoubleResponse : Response, IValueResponse<double>
    {
        public double Value { get; internal set; }
    }
}