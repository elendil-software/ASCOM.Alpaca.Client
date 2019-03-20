namespace ASCOM.Alpaca.Client.Responses
{
    public class DoubleResponse : ResponseBase, IValueResponse<double>
    {
        public double Value { get; internal set; }
    }
}