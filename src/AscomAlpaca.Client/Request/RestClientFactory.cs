using RestSharp;

namespace ES.AscomAlpaca.Client.Request
{
    public class RestClientFactory : IRestClientFactory
    {
        public IRestClient Create(string baseUrl) => new RestClient(baseUrl);
    }
}