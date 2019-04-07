using System.Threading.Tasks;
using ASCOM.Alpaca.Client.Responses;
using RestSharp;

namespace ASCOM.Alpaca.Client.Request
{
    public interface ICommandSender
    {
        IRestResponse ExecuteRequest(RestRequest request);

        TASCOMRemoteResponse ExecuteRequest<TASCOMRemoteResponse>(RestRequest request) where TASCOMRemoteResponse : IResponse, new();

        Task<IRestResponse> ExecuteRequestAsync(RestRequest request);

        Task<TASCOMRemoteResponse> ExecuteRequestAsync<TASCOMRemoteResponse>(RestRequest request) where TASCOMRemoteResponse : IResponse, new();
    }
}