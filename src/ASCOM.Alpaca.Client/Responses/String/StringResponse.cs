namespace ASCOM.Alpaca.Client.Responses.String
{
    public class StringResponse : ResponseBase, IValueResponse<string>
    {
        public string Value { get; set; }
    }
}