namespace ASCOM.Alpaca.Responses.Numeric
{
    public class IntResponse : ResponseBase, IValueResponse<int>
    {
        public int Value { get; set; }
    }
}