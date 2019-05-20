using System.Threading.Tasks;
using AscomAlpacaClient.Responses;
using RestSharp;

namespace AscomAlpacaClient.Request
{
    public interface ICommandSender
    {
        IRestResponse ExecuteRequest(string baseUrl, IRestRequest request);

        TASCOMRemoteResponse ExecuteRequest<TASCOMRemoteResponse>(string baseUrl, IRestRequest request) where TASCOMRemoteResponse : IResponse, new();

        Task<IRestResponse> ExecuteRequestAsync(string baseUrl, IRestRequest request);

        Task<TASCOMRemoteResponse> ExecuteRequestAsync<TASCOMRemoteResponse>(string baseUrl, IRestRequest request) where TASCOMRemoteResponse : IResponse, new();
    }
}