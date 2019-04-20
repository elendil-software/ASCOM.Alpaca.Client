namespace ASCOM.Alpaca.Responses.Numeric
{
    public class IntResponse : Response, IValueResponse<int>
    {
        public int Value { get; set; }
    }
}