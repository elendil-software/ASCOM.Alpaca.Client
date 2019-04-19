using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASCOM.Alpaca.Client.Configuration;
using ASCOM.Alpaca.Client.Devices.Methods;
using ASCOM.Alpaca.Client.Logger;
using ASCOM.Alpaca.Client.Request;
using ASCOM.Alpaca.Client.Responses;
using ASCOM.Alpaca.Client.Transactions;
using ASCOM.Alpaca.Enums.Devices;
using ASCOM.Alpaca.Responses.Boolean;
using ASCOM.Alpaca.Responses.Empty;
using ASCOM.Alpaca.Responses.String;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace ASCOM.Alpaca.Client.Devices
{
    public abstract class DeviceBase : IDevice
    {
        protected readonly ILogger<DeviceBase> Logger;
        protected readonly ICommandSender CommandSender;
        protected readonly RequestBuilder RequestBuilder;
        protected readonly IClientTransactionIdGenerator ClientTransactionIdGenerator;
        protected readonly DeviceConfiguration Configuration;
        protected abstract DeviceType DeviceType { get; }
        public int DeviceNumber => Configuration.DeviceNumber;

        protected DeviceBase(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ICommandSender commandSender, ILogger<DeviceBase> logger)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            ClientTransactionIdGenerator = clientTransactionIdGenerator ?? throw new ArgumentNullException(nameof(clientTransactionIdGenerator));
            CommandSender = commandSender ?? throw new ArgumentNullException(nameof(commandSender));
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));

            RequestBuilder = new RequestBuilder(DeviceType, configuration.DeviceNumber, configuration.ClientId);
        }

        protected DeviceBase(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ICommandSender commandSender)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            ClientTransactionIdGenerator = clientTransactionIdGenerator ?? throw new ArgumentNullException(nameof(clientTransactionIdGenerator));
            CommandSender = commandSender ?? throw new ArgumentNullException(nameof(commandSender));
            
            RequestBuilder = new RequestBuilder(DeviceType, configuration.DeviceNumber, configuration.ClientId);
        }

        public string InvokeAction(string actionName, string actionParameters)
        {
            RestRequest request = BuildInvokeActionRequest(actionName, actionParameters);

            var response = CommandSender.ExecuteRequest<StringResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);
            
            return response.HandleResponse<string, StringResponse>();
        }
        
        public async Task<string> InvokeActionAsync(string actionName, string actionParameters)
        {
            RestRequest request = BuildInvokeActionRequest(actionName, actionParameters);

            var response = await CommandSender.ExecuteRequestAsync<StringResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);
            
            return response.HandleResponse<string, StringResponse>();
        }

        private RestRequest BuildInvokeActionRequest(string actionName, string actionParameters)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Action", actionName},
                {"Parameters", actionParameters}
            };

            return RequestBuilder.BuildRestRequest(CommonMethod.Action, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public void SendCommandBlind(string command, bool raw = false)
        {
            RestRequest request = BuildSendCommandBlindRequest(command, raw);

            var response = CommandSender.ExecuteRequest<MethodResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);

            response.HandleResponse();
        }
        
        public async Task SendCommandBlindAsync(string command, bool raw = false)
        {
            RestRequest request = BuildSendCommandBlindRequest(command, raw);

            var response = await CommandSender.ExecuteRequestAsync<MethodResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);

            response.HandleResponse();
        }

        private RestRequest BuildSendCommandBlindRequest(string command, bool raw)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Command", command},
                {"Raw", raw.ToString()}
            };

            return RequestBuilder.BuildRestRequest(CommonMethod.CommandBlind, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public bool SendCommandBool(string command, bool raw = false)
        {
            RestRequest request = BuildSendCommandBoolRequest(command, raw);

            var response = CommandSender.ExecuteRequest<BoolResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);

            return response.HandleResponse<bool, BoolResponse>();
        }
        
        public async Task<bool> SendCommandBoolAsync(string command, bool raw = false)
        {
            RestRequest request = BuildSendCommandBoolRequest(command, raw);

            var response = await CommandSender.ExecuteRequestAsync<BoolResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);

            return response.HandleResponse<bool, BoolResponse>();
        }

        private RestRequest BuildSendCommandBoolRequest(string command, bool raw)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Command", command},
                {"Raw", raw.ToString()}
            };

            return RequestBuilder.BuildRestRequest(CommonMethod.CommandBool, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }
      
        public string SendCommandString(string command, bool raw = false)
        {
            RestRequest request = BuildSendCommandStringRequest(command, raw);

            var response = CommandSender.ExecuteRequest<StringResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);

            return response.HandleResponse<string, StringResponse>();
        }
        
        public async Task<string> SendCommandStringAsync(string command, bool raw = false)
        {
            RestRequest request = BuildSendCommandStringRequest(command, raw);

            var response = await CommandSender.ExecuteRequestAsync<StringResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);

            return response.HandleResponse<string, StringResponse>();
        }

        private RestRequest BuildSendCommandStringRequest(string command, bool raw)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Command", command},
                {"Raw", raw.ToString()}
            };

            return RequestBuilder.BuildRestRequest(CommonMethod.CommandString, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public bool IsConnected()
        {
            RestRequest request = BuildIsConnectedRequest();

            var response = CommandSender.ExecuteRequest<BoolResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);

            return response.HandleResponse<bool, BoolResponse>();
        }
        
        public async Task<bool> IsConnectedAsync()
        {
            RestRequest request = BuildIsConnectedRequest();

            var response = await CommandSender.ExecuteRequestAsync<BoolResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);

            return response.HandleResponse<bool, BoolResponse>();
        }

        private RestRequest BuildIsConnectedRequest() => RequestBuilder.BuildRestRequest(CommonMethod.Connected, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
        
        public void SetConnected(bool connected)
        {
            RestRequest request = BuildSetConnectedRequest(connected);

            var response = CommandSender.ExecuteRequest<MethodResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);

            response.HandleResponse();
        }
        
        public async Task SetConnectedAsync(bool connected)
        {
            RestRequest request = BuildSetConnectedRequest(connected);

            var response = await CommandSender.ExecuteRequestAsync<MethodResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);

            response.HandleResponse();
        }

        private RestRequest BuildSetConnectedRequest(bool connected)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Connected", connected.ToString()}
            };

            return RequestBuilder.BuildRestRequest(CommonMethod.Connected, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public string GetDescription()
        {
            RestRequest request = BuildGetDescriptionRequest();

            var response = CommandSender.ExecuteRequest<StringResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);

            return response.HandleResponse<string, StringResponse>();
        }
        
        public async Task<string> GetDescriptionAsync()
        {
            RestRequest request = BuildGetDescriptionRequest();

            var response = await CommandSender.ExecuteRequestAsync<StringResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);

            return response.HandleResponse<string, StringResponse>();
        }

        private RestRequest BuildGetDescriptionRequest() => RequestBuilder.BuildRestRequest(CommonMethod.Description, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public string GetDriverInfo()
        {
            RestRequest request = BuildGetDriverInfoRequest();

            var response = CommandSender.ExecuteRequest<StringResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);

            return response.HandleResponse<string, StringResponse>();
        }
        
        public async Task<string> GetDriverInfoAsync()
        {
            RestRequest request = BuildGetDriverInfoRequest();

            var response = await CommandSender.ExecuteRequestAsync<StringResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);

            return response.HandleResponse<string, StringResponse>();
        }

        private RestRequest BuildGetDriverInfoRequest() => RequestBuilder.BuildRestRequest(CommonMethod.Driverinfo, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public string GetDriverVersion()
        {
            RestRequest request = BuildGetDriverVersionRequest();

            var response = CommandSender.ExecuteRequest<StringResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);

            return response.HandleResponse<string, StringResponse>();
        }
        
        public async Task<string> GetDriverVersionAsync()
        {
            RestRequest request = BuildGetDriverVersionRequest();

            var response = await CommandSender.ExecuteRequestAsync<StringResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);

            return response.HandleResponse<string, StringResponse>();
        }

        private RestRequest BuildGetDriverVersionRequest() => RequestBuilder.BuildRestRequest(CommonMethod.DriverVersion, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public string GetName()
        {
            RestRequest request = BuildGetNameRequest();

            var response = CommandSender.ExecuteRequest<StringResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);

            return response.HandleResponse<string, StringResponse>();
        }
        
        public async Task<string> GetNameAsync()
        {
            RestRequest request = BuildGetNameRequest();

            var response = await CommandSender.ExecuteRequestAsync<StringResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);

            return response.HandleResponse<string, StringResponse>();
        }

        private RestRequest BuildGetNameRequest() => RequestBuilder.BuildRestRequest(CommonMethod.Name, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
        
        public List<string> GetSupportedActions()
        {
            RestRequest request = BuildGetSupportedActionsRequest();

            var response = CommandSender.ExecuteRequest<StringArrayResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);

            return response.HandleResponse<List<string>, StringArrayResponse>();
        }
        
        public async Task<List<string>> GetSupportedActionsAsync()
        {
            RestRequest request = BuildGetSupportedActionsRequest();

            var response = await CommandSender.ExecuteRequestAsync<StringArrayResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);

            return response.HandleResponse<List<string>, StringArrayResponse>();
        }

        private RestRequest BuildGetSupportedActionsRequest() => RequestBuilder.BuildRestRequest(CommonMethod.SupportedActions, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
    }
}