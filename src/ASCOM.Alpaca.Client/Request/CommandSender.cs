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
            ThrowExceptionOnError(response);
            return response;
        }

        public TASCOMRemoteResponse ExecuteRequest<TASCOMRemoteResponse>(string baseUrl, IRestRequest request) where TASCOMRemoteResponse : IResponse, new()
        {
            IRestResponse<TASCOMRemoteResponse> response = new RestClient(baseUrl).Execute<TASCOMRemoteResponse>(request);
            ThrowExceptionOnError(response);
            return response.Data;
        }
        
        public async Task<IRestResponse> ExecuteRequestAsync(string baseUrl, IRestRequest request)
        {
            IRestResponse response = await new RestClient(baseUrl).ExecuteTaskAsync(request);
            ThrowExceptionOnError(response);
            return response;
        }
        
        public async Task<TASCOMRemoteResponse> ExecuteRequestAsync<TASCOMRemoteResponse>(string baseUrl, IRestRequest request) where TASCOMRemoteResponse : IResponse, new()
        {
            IRestResponse<TASCOMRemoteResponse> response = await new RestClient(baseUrl).ExecuteTaskAsync<TASCOMRemoteResponse>(request);
            ThrowExceptionOnError(response);
            return response.Data;
        }

        private void ThrowExceptionOnError(IRestResponse response)
        {
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new AlpacaClientException(response.ErrorMessage, response.ErrorException);
            }
            else if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new AlpacaServerException(response.Content);
            }
        }
    }
}