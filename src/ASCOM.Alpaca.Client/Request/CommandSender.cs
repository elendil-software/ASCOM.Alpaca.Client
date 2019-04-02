using System;
using System.Net;
using ASCOM.Alpaca.Client.Responses;
using RestSharp;

namespace ASCOM.Alpaca.Client.Request
{
    public class CommandSender : ICommandSender
    {
        private readonly IRestClient _restClient;

        public CommandSender(IRestClient restClient)
        {
            _restClient = restClient ?? throw new ArgumentNullException(nameof(restClient));
        }
        
        public IRestResponse ExecuteRequest(RestRequest request)
        {
            IRestResponse response = _restClient.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response;
            }
            else
            {
                throw new DriverException(response.Content);
            }
        }

        public TASCOMRemoteResponse ExecuteRequest<TASCOMRemoteResponse>(RestRequest request) where TASCOMRemoteResponse : IResponse, new()
        {
            IRestResponse<TASCOMRemoteResponse> response = _restClient.Execute<TASCOMRemoteResponse>(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response.Data;
            }
            else
            {
                throw new DriverException(response.Content);
            }
        }
    }
}