namespace ASCOM.Alpaca.Responses.String
{
    public class StringResponse : Response, IValueResponse<string>
    {
        public string Value { get; set; }
    }
}