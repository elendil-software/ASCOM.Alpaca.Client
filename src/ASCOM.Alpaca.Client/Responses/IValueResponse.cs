namespace ASCOM.Alpaca.Client.Responses
{
    public interface IValueResponse<out T> : IResponse
    {
        T Value { get; }
    }
}