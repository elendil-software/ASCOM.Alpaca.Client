using System.Threading.Tasks;
using ASCOM.Alpaca.Client.Responses;
using RestSharp;

namespace ASCOM.Alpaca.Client.Request
{
    public interface ICommandSender
    {
        IRestResponse ExecuteRequest(string baseUrl, RestRequest request);

        TASCOMRemoteResponse ExecuteRequest<TASCOMRemoteResponse>(string baseUrl, RestRequest request) where TASCOMRemoteResponse : IResponse, new();

        Task<IRestResponse> ExecuteRequestAsync(string baseUrl, RestRequest request);

        Task<TASCOMRemoteResponse> ExecuteRequestAsync<TASCOMRemoteResponse>(string baseUrl, RestRequest request) where TASCOMRemoteResponse : IResponse, new();
    }
}