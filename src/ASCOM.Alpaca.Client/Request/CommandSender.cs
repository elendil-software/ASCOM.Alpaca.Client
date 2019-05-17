using System.Net;
using System.Threading.Tasks;
using ASCOM.Alpaca.Client.Exceptions;
using ASCOM.Alpaca.Responses;
using RestSharp;

namespace ASCOM.Alpaca.Client.Request
{
    public class CommandSender : ICommandSender
    {
        public IRestResponse ExecuteRequest(string baseUrl, IRestRequest request)
        {
            IRestResponse response = new RestClient(baseUrl).Execute(request);
            CheckResponse(response, baseUrl);
            return response;
        }

        public TASCOMRemoteResponse ExecuteRequest<TASCOMRemoteResponse>(string baseUrl, IRestRequest request) where TASCOMRemoteResponse : IResponse, new()
        {
            IRestResponse<TASCOMRemoteResponse> response = new RestClient(baseUrl).Execute<TASCOMRemoteResponse>(request);
            CheckResponse(response, baseUrl);
            return response.Data;
        }
        
        public async Task<IRestResponse> ExecuteRequestAsync(string baseUrl, IRestRequest request)
        {
            IRestResponse response = await new RestClient(baseUrl).ExecuteTaskAsync(request);
            CheckResponse(response, baseUrl);
            return response;
        }
        
        public async Task<TASCOMRemoteResponse> ExecuteRequestAsync<TASCOMRemoteResponse>(string baseUrl, IRestRequest request) where TASCOMRemoteResponse : IResponse, new()
        {
            IRestResponse<TASCOMRemoteResponse> response = await new RestClient(baseUrl).ExecuteTaskAsync<TASCOMRemoteResponse>(request);
            CheckResponse(response, baseUrl);
            return response.Data;
        }

        private void CheckResponse(IRestResponse response, string baseUrl)
        {
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new AlpacaClientException(response.ErrorMessage, response.ErrorException);
            }
            else if (response.StatusCode != HttpStatusCode.OK)
            {
                //TODO : Add AlpacaServerException
                throw new AlpacaException(response.Content);
            }
        }
    }
}