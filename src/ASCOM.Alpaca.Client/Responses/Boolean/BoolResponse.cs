namespace ASCOM.Alpaca.Client.Responses.Boolean
{
    public class BoolResponse : ResponseBase, IValueResponse<bool>
    {
        public bool Value { get; internal set; }
    }
}