using RestSharp;

namespace ES.AscomAlpaca.Client.Request
{
    public interface IRestClientFactory
    {
        IRestClient Create(string baseUrl);
    }
}