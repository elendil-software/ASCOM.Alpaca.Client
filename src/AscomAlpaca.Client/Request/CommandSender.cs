using System;
using System.Net;
using System.Threading.Tasks;
using ES.AscomAlpaca.Client.Exceptions;
using ES.AscomAlpaca.Client.Logging;
using ES.AscomAlpaca.Client.Responses;
using RestSharp;

namespace ES.AscomAlpaca.Client.Request
{
    internal class CommandSender : ICommandSender
    {
        private readonly ILogger _logger;

        public CommandSender()
        {
        }

        public CommandSender(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IRestResponse ExecuteRequest(string baseUrl, IRestRequest request)
        {
            IRestResponse response = new RestClient(baseUrl).Execute(request);
            ThrowExceptionOnError(response);
            _logger?.LogDebug("Response : {Response}", response.Content);
            return response;
        }

        public TASCOMRemoteResponse ExecuteRequest<TASCOMRemoteResponse>(string baseUrl, IRestRequest request) where TASCOMRemoteResponse : IResponse, new()
        {
            IRestResponse<TASCOMRemoteResponse> response = new RestClient(baseUrl).Execute<TASCOMRemoteResponse>(request);
            ThrowExceptionOnError(response);
            _logger?.LogDebug("Response : {Response}", response.Content);
            return response.Data;
        }
        
        public async Task<IRestResponse> ExecuteRequestAsync(string baseUrl, IRestRequest request)
        {
            IRestResponse response = await new RestClient(baseUrl).ExecuteTaskAsync(request);
            ThrowExceptionOnError(response);
            _logger?.LogDebug("Response : {Response}", response.Content);
            return response;
        }
        
        public async Task<TASCOMRemoteResponse> ExecuteRequestAsync<TASCOMRemoteResponse>(string baseUrl, IRestRequest request) where TASCOMRemoteResponse : IResponse, new()
        {
            IRestResponse<TASCOMRemoteResponse> response = await new RestClient(baseUrl).ExecuteTaskAsync<TASCOMRemoteResponse>(request);
            ThrowExceptionOnError(response);
            _logger?.LogDebug("Response : {@Response}", response.Data);
            return response.Data;
        }

        private void ThrowExceptionOnError(IRestResponse response)
        {
            if (response.ResponseStatus != ResponseStatus.Completed && response.StatusCode == 0)
            {
                _logger?.LogError("Request not completed, response status : {ResponseStatus}, error message : {ErrorMessage}", response.ResponseStatus, response.ErrorMessage);
                throw new AlpacaClientException(response.ErrorMessage, response.ErrorException);
            }
            else if (response.StatusCode != HttpStatusCode.OK)
            {
                _logger?.LogError("{ErrorName} ({ErrorCode}), error message : {ErrorMessage}", response.StatusCode, (int)response.StatusCode, response.Content);
                throw new AlpacaServerException(response.Content);
            }
        }
    }
}