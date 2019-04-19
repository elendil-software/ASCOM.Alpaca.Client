namespace ASCOM.Alpaca.Responses.String
{
    public class StringResponse : ResponseBase, IValueResponse<string>
    {
        public string Value { get; set; }
    }
}