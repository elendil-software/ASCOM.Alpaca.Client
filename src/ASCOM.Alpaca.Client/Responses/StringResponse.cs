namespace ASCOM.Alpaca.Client.Responses
{
    public class StringResponse : ResponseBase, IValueResponse<string>
    {
        public string Value { get; set; }
    }
}