using System;
using System.Collections.Generic;
using ASCOM.Alpaca.Client.Configuration;
using ASCOM.Alpaca.Client.Devices.Methods;
using ASCOM.Alpaca.Client.Logger;
using ASCOM.Alpaca.Client.Request;
using ASCOM.Alpaca.Client.Responses;
using ASCOM.Alpaca.Client.Responses.Boolean;
using ASCOM.Alpaca.Client.Responses.Empty;
using ASCOM.Alpaca.Client.Responses.String;
using ASCOM.Alpaca.Client.Transactions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestSharp;

namespace ASCOM.Alpaca.Client.Devices
{
    public abstract class DeviceBase : IDeviceBase
    {
        protected readonly ILogger<DeviceBase> _logger;
        protected readonly ICommandSender _commandSender;
        protected readonly RequestBuilder _requestBuilder;
        protected readonly IClientTransactionIdGenerator _clientTransactionIdGenerator;
        protected abstract DeviceType DeviceType { get; }

        protected DeviceBase(DeviceConfiguration configuration, ILogger<DeviceBase> logger)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            
            _clientTransactionIdGenerator = new ClientTransactionIdGenerator();
            _requestBuilder = new RequestBuilder(DeviceType, configuration.DeviceNumber);
            _commandSender = new CommandSender(new RestClient(configuration.GetBaseUrl()));
        }
        
        protected DeviceBase(IOptionsSnapshot<DeviceConfiguration> configuration, ILogger<DeviceBase> logger)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            
            var configuration1 = configuration.Get(DeviceType.ToString()) ?? throw new ArgumentNullException(nameof(configuration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            
            _clientTransactionIdGenerator = new ClientTransactionIdGenerator();
            _requestBuilder = new RequestBuilder(DeviceType, configuration1.DeviceNumber);
            _commandSender = new CommandSender(new RestClient(configuration1.GetBaseUrl()));
        }
        
        protected DeviceBase(DeviceConfiguration configuration, ICommandSender commandSender, IClientTransactionIdGenerator clientTransactionIdGenerator, ILogger<DeviceBase> logger)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            
            _commandSender = commandSender ?? throw new ArgumentNullException(nameof(commandSender));
            _clientTransactionIdGenerator = clientTransactionIdGenerator ?? throw new ArgumentNullException(nameof(clientTransactionIdGenerator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _requestBuilder = new RequestBuilder(DeviceType, configuration.DeviceNumber);
        }

        public string Action(string actionName, string actionParameters)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Action", actionName},
                {"Parameters", actionParameters}
            };

            RestRequest request = _requestBuilder.BuildRestRequest(CommonMethod.Action, Method.PUT, parameters, _clientTransactionIdGenerator.GetTransactionId());
            _logger.LogDebug(request);
            
            var response = _commandSender.ExecuteRequest<StringResponse>(request);
            _logger.LogDebug(response);
            
            return response.HandleResponse<string, StringResponse>();
        }

        public void CommandBlind(string command, bool raw = false)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Command", command},
                {"Raw", raw.ToString()}
            };
            RestRequest request = _requestBuilder.BuildRestRequest(CommonMethod.CommandBlind, Method.PUT, parameters, _clientTransactionIdGenerator.GetTransactionId());
            _logger.LogDebug(request);
            
            var response = _commandSender.ExecuteRequest<MethodResponse>(request);
            _logger.LogDebug(response);

            response.HandleResponse();
        }

        public bool CommandBool(string command, bool raw = false)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Command", command},
                {"Raw", raw.ToString()}
            };
            RestRequest request = _requestBuilder.BuildRestRequest(CommonMethod.CommandBool, Method.PUT, parameters, _clientTransactionIdGenerator.GetTransactionId());
            _logger.LogDebug(request);
            
            var response = _commandSender.ExecuteRequest<BoolResponse>(request);
            _logger.LogDebug(response);

            return response.HandleResponse<bool, BoolResponse>();
        }

        public string CommandString(string command, bool raw = false)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Command", command},
                {"Raw", raw.ToString()}
            };
            RestRequest request = _requestBuilder.BuildRestRequest(CommonMethod.CommandString, Method.PUT, parameters, _clientTransactionIdGenerator.GetTransactionId());
            _logger.LogDebug(request);
            
            var response = _commandSender.ExecuteRequest<StringResponse>(request);
            _logger.LogDebug(response);

            return response.HandleResponse<string, StringResponse>();
        }

        public bool IsConnected()
        {
            RestRequest request = _requestBuilder.BuildRestRequest(CommonMethod.Connected, Method.GET, _clientTransactionIdGenerator.GetTransactionId());
            _logger.LogDebug(request);
            
            var response = _commandSender.ExecuteRequest<BoolResponse>(request);
            _logger.LogDebug(response);

            return response.HandleResponse<bool, BoolResponse>();
        }

        public void SetConnected(bool connected)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Connected", connected.ToString()}
            };
            RestRequest request = _requestBuilder.BuildRestRequest(CommonMethod.Connected, Method.PUT, parameters, _clientTransactionIdGenerator.GetTransactionId());
            _logger.LogDebug(request);
            
            var response = _commandSender.ExecuteRequest<MethodResponse>(request);
            _logger.LogDebug(response);

            response.HandleResponse();
        }

        public string GetDescription()
        {
            RestRequest request = _requestBuilder.BuildRestRequest(CommonMethod.Description, Method.GET, _clientTransactionIdGenerator.GetTransactionId());
            _logger.LogDebug(request);
            
            var response = _commandSender.ExecuteRequest<StringResponse>(request);
            _logger.LogDebug(response);

            return response.HandleResponse<string, StringResponse>();
        }

        public string GetDriverInfo()
        {
            RestRequest request = _requestBuilder.BuildRestRequest(CommonMethod.Driverinfo, Method.GET, _clientTransactionIdGenerator.GetTransactionId());
            _logger.LogDebug(request);
            
            var response = _commandSender.ExecuteRequest<StringResponse>(request);
            _logger.LogDebug(response);

            return response.HandleResponse<string, StringResponse>();
        }

        public string GetDriverVersion()
        {
            RestRequest request = _requestBuilder.BuildRestRequest(CommonMethod.DriverVersion, Method.GET, _clientTransactionIdGenerator.GetTransactionId());
            _logger.LogDebug(request);
            
            var response = _commandSender.ExecuteRequest<StringResponse>(request);
            _logger.LogDebug(response);

            return response.HandleResponse<string, StringResponse>();
        }

        public string GetName()
        {
            RestRequest request = _requestBuilder.BuildRestRequest(CommonMethod.Name, Method.GET, _clientTransactionIdGenerator.GetTransactionId());
            _logger.LogDebug(request);
            
             var response = _commandSender.ExecuteRequest<StringResponse>(request);
             _logger.LogDebug(response);

             return response.HandleResponse<string, StringResponse>();
        }

        public List<string> GetSupportedActions()
        {
            RestRequest request = _requestBuilder.BuildRestRequest(CommonMethod.SupportedActions, Method.GET, _clientTransactionIdGenerator.GetTransactionId());
            _logger.LogDebug(request);
            
            var response = _commandSender.ExecuteRequest<StringArrayResponse>(request);
            _logger.LogDebug(response);

            return response.HandleResponse<List<string>, StringArrayResponse>();
        }
    }
}