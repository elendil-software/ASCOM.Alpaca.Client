using RestSharp;

namespace ES.Ascom.Alpaca.Client.Request
{
    internal class RestClientFactory : IRestClientFactory
    {
        public IRestClient Create(string baseUrl) => new RestClient(baseUrl);
    }
}