namespace ASCOM.Alpaca.Responses.Boolean
{
    public class BoolResponse : Response, IValueResponse<bool>
    {
        public bool Value { get; internal set; }
    }
}