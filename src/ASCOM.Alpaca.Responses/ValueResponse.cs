namespace ASCOM.Alpaca.Responses
{
    public class ValueResponse<T> : ResponseBase, IValueResponse<T>
    {
        public T Value { get; set; }
    }
}