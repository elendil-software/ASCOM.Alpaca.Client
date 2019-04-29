using System;
using System.Net;
using System.Threading.Tasks;
using ASCOM.Alpaca.Client.Logging;
using ASCOM.Alpaca.Exceptions;
using ASCOM.Alpaca.Responses;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace ASCOM.Alpaca.Client.Request
{
    public class CommandSender : ICommandSender
    {
        private readonly ILogger<CommandSender> _logger;

        public CommandSender() {}

        public CommandSender(ILogger<CommandSender> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        
        public IRestResponse ExecuteRequest(string baseUrl, IRestRequest request)
        {
            _logger?.LogDebug(baseUrl, request);
            IRestResponse response = new RestClient(baseUrl).Execute(request);
            CheckResponse(response, baseUrl);
            return response;
        }

        public TASCOMRemoteResponse ExecuteRequest<TASCOMRemoteResponse>(string baseUrl, IRestRequest request) where TASCOMRemoteResponse : IResponse, new()
        {
            _logger?.LogDebug(baseUrl, request);
            IRestResponse<TASCOMRemoteResponse> response = new RestClient(baseUrl).Execute<TASCOMRemoteResponse>(request);
            CheckResponse(response, baseUrl);
            return response.Data;
        }
        
        public async Task<IRestResponse> ExecuteRequestAsync(string baseUrl, IRestRequest request)
        {
            _logger?.LogDebug(baseUrl, request);
            IRestResponse response = await new RestClient(baseUrl).ExecuteTaskAsync(request);
            CheckResponse(response, baseUrl);
            return response;
        }
        
        public async Task<TASCOMRemoteResponse> ExecuteRequestAsync<TASCOMRemoteResponse>(string baseUrl, IRestRequest request) where TASCOMRemoteResponse : IResponse, new()
        {
            _logger?.LogDebug(baseUrl, request);
            IRestResponse<TASCOMRemoteResponse> response = await new RestClient(baseUrl).ExecuteTaskAsync<TASCOMRemoteResponse>(request);
            CheckResponse(response, baseUrl);
            return response.Data;
        }

        private void CheckResponse(IRestResponse response, string baseUrl)
        {
            if (response.StatusCode == 0)
            {
                throw new DriverException($"Unable to connect to {baseUrl}");
            }
            else if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new DriverException(response.Content);
            }
        }
    }
}