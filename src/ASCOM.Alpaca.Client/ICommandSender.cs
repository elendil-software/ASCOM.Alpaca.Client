using ASCOM.Alpaca.Client.Responses;
using RestSharp;

namespace ASCOM.Alpaca.Client
{
    public interface ICommandSender
    {
        IRestResponse ExecuteRequest(RestRequest request);

        TASCOMRemoteResponse ExecuteRequest<TASCOMRemoteResponse>(RestRequest request) where TASCOMRemoteResponse : IResponse, new();
    }
}