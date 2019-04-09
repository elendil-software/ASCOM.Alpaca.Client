using System;
using System.Net;
using System.Threading.Tasks;
using ASCOM.Alpaca.Client.Logger;
using ASCOM.Alpaca.Client.Responses;
using ASCOM.Alpaca.Exceptions;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace ASCOM.Alpaca.Client.Request
{
    public class CommandSender : ICommandSender
    {
        private readonly ILogger<CommandSender> _logger;

        public CommandSender()
        {
        }

        public CommandSender(ILogger<CommandSender> logger)
        {
          
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        
        public IRestResponse ExecuteRequest(string baseUrl, RestRequest request)
        {
            _logger?.LogDebug(baseUrl, request);
            IRestResponse response = new RestClient(baseUrl).Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response;
            }
            else
            {
                throw new DriverException(response.Content);
            }
        }

        public TASCOMRemoteResponse ExecuteRequest<TASCOMRemoteResponse>(string baseUrl, RestRequest request) where TASCOMRemoteResponse : IResponse, new()
        {
            _logger?.LogDebug(baseUrl, request);
            IRestResponse<TASCOMRemoteResponse> response = new RestClient(baseUrl).Execute<TASCOMRemoteResponse>(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response.Data;
            }
            else
            {
                throw new DriverException(response.Content);
            }
        }
        
        public async Task<IRestResponse> ExecuteRequestAsync(string baseUrl, RestRequest request)
        {
            _logger?.LogDebug(baseUrl, request);
            IRestResponse response = await new RestClient(baseUrl).ExecuteTaskAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response;
            }
            else
            {
                throw new DriverException(response.Content);
            }
        }

        public async Task<TASCOMRemoteResponse> ExecuteRequestAsync<TASCOMRemoteResponse>(string baseUrl, RestRequest request) where TASCOMRemoteResponse : IResponse, new()
        {
            _logger?.LogDebug(baseUrl, request);
            IRestResponse<TASCOMRemoteResponse> response = await new RestClient(baseUrl).ExecuteTaskAsync<TASCOMRemoteResponse>(request);
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