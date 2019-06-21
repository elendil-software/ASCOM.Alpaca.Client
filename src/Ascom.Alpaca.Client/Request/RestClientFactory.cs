using RestSharp;

namespace ES.AscomAlpaca.Client.Request
{
    internal class RestClientFactory : IRestClientFactory
    {
        public IRestClient Create(string baseUrl) => new RestClient(baseUrl);
    }
}