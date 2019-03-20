namespace ASCOM.Alpaca.Client.Responses
{
    public class IntResponse : ResponseBase, IValueResponse<int>
    {
        public int Value { get; set; }
    }
}