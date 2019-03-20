namespace ASCOM.Alpaca.Client.Responses
{
    public class BoolResponse : ResponseBase, IValueResponse<bool>
    {
        public bool Value { get; internal set; }
    }
}