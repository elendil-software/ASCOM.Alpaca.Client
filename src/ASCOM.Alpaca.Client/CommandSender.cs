using System;
using System.Net;
using ASCOM.Alpaca.Client.Responses;
using RestSharp;

namespace ASCOM.Alpaca.Client
{
    public class CommandSender : ICommandSender
    {
        private RestClient _restClient;
        public bool IsInitialized => _restClient != null;

        public void InitRestClient(string baseUrl)
        {
            _restClient = new RestClient(baseUrl);
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
                throw new Exception(response.Content);
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
                throw new Exception(response.Content);
            }
        }
    }
}