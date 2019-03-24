namespace ASCOM.Alpaca.Client.Responses
{
    public interface IValueResponse<T> : IResponse
    {
        T Value { get; }
    }
}