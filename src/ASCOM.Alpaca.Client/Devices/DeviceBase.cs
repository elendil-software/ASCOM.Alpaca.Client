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
        protected readonly ILogger<DeviceBase> Logger;
        protected readonly ICommandSender CommandSender;
        protected readonly RequestBuilder RequestBuilder;
        protected readonly IClientTransactionIdGenerator ClientTransactionIdGenerator;
        private readonly DeviceConfiguration _configuration;
        protected abstract DeviceType DeviceType { get; }
        public int DeviceNumber => _configuration.DeviceNumber;

        protected DeviceBase(DeviceConfiguration configuration, ILogger<DeviceBase> logger)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            
            ClientTransactionIdGenerator = new ClientTransactionIdGenerator();
            RequestBuilder = new RequestBuilder(DeviceType, configuration.DeviceNumber);
            CommandSender = new CommandSender(new RestClient(configuration.GetBaseUrl()));
        }
        
        protected DeviceBase(IOptionsSnapshot<DeviceConfiguration> configuration, ILogger<DeviceBase> logger)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            
            _configuration = configuration.Get(DeviceType.ToString()) ?? throw new ArgumentNullException(nameof(configuration));
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            
            ClientTransactionIdGenerator = new ClientTransactionIdGenerator();
            RequestBuilder = new RequestBuilder(DeviceType, _configuration.DeviceNumber);
            CommandSender = new CommandSender(new RestClient(_configuration.GetBaseUrl()));
        }
        
        protected DeviceBase(DeviceConfiguration configuration, ICommandSender commandSender, IClientTransactionIdGenerator clientTransactionIdGenerator, ILogger<DeviceBase> logger)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            
            CommandSender = commandSender ?? throw new ArgumentNullException(nameof(commandSender));
            ClientTransactionIdGenerator = clientTransactionIdGenerator ?? throw new ArgumentNullException(nameof(clientTransactionIdGenerator));
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            RequestBuilder = new RequestBuilder(DeviceType, configuration.DeviceNumber);
        }

        public string Action(string actionName, string actionParameters)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Action", actionName},
                {"Parameters", actionParameters}
            };

            RestRequest request = RequestBuilder.BuildRestRequest(CommonMethod.Action, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
            Logger.LogDebug(request);
            
            var response = CommandSender.ExecuteRequest<StringResponse>(request);
            Logger.LogDebug(response);
            
            return response.HandleResponse<string, StringResponse>();
        }

        public void CommandBlind(string command, bool raw = false)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Command", command},
                {"Raw", raw.ToString()}
            };
            RestRequest request = RequestBuilder.BuildRestRequest(CommonMethod.CommandBlind, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
            Logger.LogDebug(request);
            
            var response = CommandSender.ExecuteRequest<MethodResponse>(request);
            Logger.LogDebug(response);

            response.HandleResponse();
        }

        public bool CommandBool(string command, bool raw = false)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Command", command},
                {"Raw", raw.ToString()}
            };
            RestRequest request = RequestBuilder.BuildRestRequest(CommonMethod.CommandBool, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
            Logger.LogDebug(request);
            
            var response = CommandSender.ExecuteRequest<BoolResponse>(request);
            Logger.LogDebug(response);

            return response.HandleResponse<bool, BoolResponse>();
        }

        public string CommandString(string command, bool raw = false)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Command", command},
                {"Raw", raw.ToString()}
            };
            RestRequest request = RequestBuilder.BuildRestRequest(CommonMethod.CommandString, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
            Logger.LogDebug(request);
            
            var response = CommandSender.ExecuteRequest<StringResponse>(request);
            Logger.LogDebug(response);

            return response.HandleResponse<string, StringResponse>();
        }

        public bool IsConnected()
        {
            RestRequest request = RequestBuilder.BuildRestRequest(CommonMethod.Connected, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
            Logger.LogDebug(request);
            
            var response = CommandSender.ExecuteRequest<BoolResponse>(request);
            Logger.LogDebug(response);

            return response.HandleResponse<bool, BoolResponse>();
        }

        public void SetConnected(bool connected)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Connected", connected.ToString()}
            };
            RestRequest request = RequestBuilder.BuildRestRequest(CommonMethod.Connected, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
            Logger.LogDebug(request);
            
            var response = CommandSender.ExecuteRequest<MethodResponse>(request);
            Logger.LogDebug(response);

            response.HandleResponse();
        }

        public string GetDescription()
        {
            RestRequest request = RequestBuilder.BuildRestRequest(CommonMethod.Description, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
            Logger.LogDebug(request);
            
            var response = CommandSender.ExecuteRequest<StringResponse>(request);
            Logger.LogDebug(response);

            return response.HandleResponse<string, StringResponse>();
        }

        public string GetDriverInfo()
        {
            RestRequest request = RequestBuilder.BuildRestRequest(CommonMethod.Driverinfo, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
            Logger.LogDebug(request);
            
            var response = CommandSender.ExecuteRequest<StringResponse>(request);
            Logger.LogDebug(response);

            return response.HandleResponse<string, StringResponse>();
        }

        public string GetDriverVersion()
        {
            RestRequest request = RequestBuilder.BuildRestRequest(CommonMethod.DriverVersion, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
            Logger.LogDebug(request);
            
            var response = CommandSender.ExecuteRequest<StringResponse>(request);
            Logger.LogDebug(response);

            return response.HandleResponse<string, StringResponse>();
        }

        public string GetName()
        {
            RestRequest request = RequestBuilder.BuildRestRequest(CommonMethod.Name, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
            Logger.LogDebug(request);
            
             var response = CommandSender.ExecuteRequest<StringResponse>(request);
             Logger.LogDebug(response);

             return response.HandleResponse<string, StringResponse>();
        }

        public List<string> GetSupportedActions()
        {
            RestRequest request = RequestBuilder.BuildRestRequest(CommonMethod.SupportedActions, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
            Logger.LogDebug(request);
            
            var response = CommandSender.ExecuteRequest<StringArrayResponse>(request);
            Logger.LogDebug(response);

            return response.HandleResponse<List<string>, StringArrayResponse>();
        }
    }
}