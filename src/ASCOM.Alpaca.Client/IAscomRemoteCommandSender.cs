using ASCOM.Alpaca.Client.Responses;
using RestSharp;

namespace ASCOM.Alpaca.Client
{
    public interface IAscomRemoteCommandSender
    {
        bool IsInitialized { get; }

        void InitRestClient(string baseUrl);

        IRestResponse ExecuteRequest(RestRequest request);

        TASCOMRemoteResponse ExecuteRequest<TASCOMRemoteResponse>(RestRequest request) 
            where TASCOMRemoteResponse : IResponse, new();
    }
}