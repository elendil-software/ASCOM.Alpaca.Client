using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASCOM.Alpaca.Client.Configuration;
using ASCOM.Alpaca.Client.Devices.Methods;
using ASCOM.Alpaca.Client.Logging;
using ASCOM.Alpaca.Client.Request;
using ASCOM.Alpaca.Client.Responses;
using ASCOM.Alpaca.Client.Transactions;
using ASCOM.Alpaca.Devices;
using ASCOM.Alpaca.Responses;
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

            var response = CommandSender.ExecuteRequest<Response>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);

            response.HandleResponse();
        }
        
        public async Task SendCommandBlindAsync(string command, bool raw = false)
        {
            RestRequest request = BuildSendCommandBlindRequest(command, raw);

            var response = await CommandSender.ExecuteRequestAsync<Response>(Configuration.GetBaseUrl(), request);
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

        public bool IsConnected() => ExecuteRequest<bool, BoolResponse>(BuildIsConnectedRequest);
        public async Task<bool> IsConnectedAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsConnectedRequest);
        private RestRequest BuildIsConnectedRequest() => RequestBuilder.BuildRestRequest(CommonMethod.Connected, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
        
        public void SetConnected(bool connected) => ExecuteRequest(BuildSetConnectedRequest, connected);
        public async Task SetConnectedAsync(bool connected) => await ExecuteRequestAsync(BuildSetConnectedRequest, connected);
        private RestRequest BuildSetConnectedRequest(bool connected)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Connected", connected.ToString()}
            };

            return RequestBuilder.BuildRestRequest(CommonMethod.Connected, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public string GetDescription() => ExecuteRequest<string, StringResponse>(BuildGetDescriptionRequest);     
        public async Task<string> GetDescriptionAsync() => await ExecuteRequestAsync<string, StringResponse>(BuildGetDescriptionRequest);
        private RestRequest BuildGetDescriptionRequest() => RequestBuilder.BuildRestRequest(CommonMethod.Description, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public string GetDriverInfo() => ExecuteRequest<string, StringResponse>(BuildGetDriverInfoRequest);    
        public async Task<string> GetDriverInfoAsync() => await ExecuteRequestAsync<string, StringResponse>(BuildGetDriverInfoRequest);
        private RestRequest BuildGetDriverInfoRequest() => RequestBuilder.BuildRestRequest(CommonMethod.DriverInfo, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public string GetDriverVersion() => ExecuteRequest<string, StringResponse>(BuildGetDriverVersionRequest);
        public async Task<string> GetDriverVersionAsync() => await ExecuteRequestAsync<string, StringResponse>(BuildGetDriverVersionRequest);
        private RestRequest BuildGetDriverVersionRequest() => RequestBuilder.BuildRestRequest(CommonMethod.DriverVersion, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public string GetName() => ExecuteRequest<string, StringResponse>(BuildGetNameRequest);
        public async Task<string> GetNameAsync() => await ExecuteRequestAsync<string, StringResponse>(BuildGetNameRequest);
        private RestRequest BuildGetNameRequest() => RequestBuilder.BuildRestRequest(CommonMethod.Name, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public List<string> GetSupportedActions() => ExecuteRequest<List<string>, StringArrayResponse>(BuildGetSupportedActionsRequest);      
        public async Task<List<string>> GetSupportedActionsAsync() => await ExecuteRequestAsync<List<string>, StringArrayResponse>(BuildGetSupportedActionsRequest);
        private RestRequest BuildGetSupportedActionsRequest() => RequestBuilder.BuildRestRequest(CommonMethod.SupportedActions, Method.GET, ClientTransactionIdGenerator.GetTransactionId());



        protected void ExecuteRequest(Func<RestRequest> requestBuilder)
        {
            RestRequest request = requestBuilder();
            var response = CommandSender.ExecuteRequest<Response>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);
            response.HandleResponse();
        }

        protected async Task ExecuteRequestAsync(Func<RestRequest> requestBuilder)
        {
            RestRequest request = requestBuilder();
            var response = await CommandSender.ExecuteRequestAsync<Response>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);
            response.HandleResponse();
        }

        protected void ExecuteRequest<T1>(Func<T1, RestRequest> requestBuilder, T1 param1)
        {
            RestRequest request = requestBuilder(param1);
            var response = CommandSender.ExecuteRequest<Response>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);
            response.HandleResponse();
        }

        protected async Task ExecuteRequestAsync<T1>(Func<T1, RestRequest> requestBuilder, T1 arg)
        {
            RestRequest request = requestBuilder(arg);
            var response = await CommandSender.ExecuteRequestAsync<Response>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);
            response.HandleResponse();
        }
        
        protected void ExecuteRequest<T1, T2>(Func<T1, T2, RestRequest> requestBuilder, T1 arg1, T2 arg2)
        {
            RestRequest request = requestBuilder(arg1, arg2);
            var response = CommandSender.ExecuteRequest<Response>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);
            response.HandleResponse();
        }

        protected async Task ExecuteRequestAsync<T1, T2>(Func<T1, T2, RestRequest> requestBuilder, T1 arg1, T2 arg2)
        {
            RestRequest request = requestBuilder(arg1, arg2);
            var response = await CommandSender.ExecuteRequestAsync<Response>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);
            response.HandleResponse();
        }
        
        protected TResult ExecuteRequest<TResult, TAlpacaResponse, T1>(Func<T1, RestRequest> requestBuilder, T1 arg) where TAlpacaResponse : IValueResponse<TResult>, new()
        {
            RestRequest request = requestBuilder(arg);
            var response = CommandSender.ExecuteRequest<TAlpacaResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);
            return response.HandleResponse<TResult, TAlpacaResponse>();
        }

        protected async Task<TResult> ExecuteRequestAsync<TResult, TAlpacaResponse, T1>(Func<T1, RestRequest> requestBuilder, T1 arg) where TAlpacaResponse : IValueResponse<TResult>, new()
        {
            RestRequest request = requestBuilder(arg);
            var response = await CommandSender.ExecuteRequestAsync<TAlpacaResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);
            return response.HandleResponse<TResult, TAlpacaResponse>();
        }
        
        
        
        protected TResult ExecuteRequest<TResult, TAlpacaResponse, T1, T2>(Func<T1, T2, RestRequest> requestBuilder, T1 arg1, T2 arg2) where TAlpacaResponse : IValueResponse<TResult>, new()
        {
            RestRequest request = requestBuilder(arg1 , arg2);
            var response = CommandSender.ExecuteRequest<TAlpacaResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);
            return response.HandleResponse<TResult, TAlpacaResponse>();
        }

        protected async Task<TResult> ExecuteRequestAsync<TResult, TAlpacaResponse, T1, T2>(Func<T1, T2, RestRequest> requestBuilder, T1 arg1, T2 arg2) where TAlpacaResponse : IValueResponse<TResult>, new()
        {
            RestRequest request = requestBuilder(arg1 , arg2);
            var response = await CommandSender.ExecuteRequestAsync<TAlpacaResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);
            return response.HandleResponse<TResult, TAlpacaResponse>();
        }
        
        
        
        

        protected TResult ExecuteRequest<TResult, TAlpacaResponse>(Func<RestRequest> requestBuilder) where TAlpacaResponse : IValueResponse<TResult>, new()
        {
            RestRequest request = requestBuilder();
            var response = CommandSender.ExecuteRequest<TAlpacaResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);
            return response.HandleResponse<TResult, TAlpacaResponse>();
        }

        protected async Task<TResult> ExecuteRequestAsync<TResult, TAlpacaResponse>(Func<RestRequest> requestBuilder) where TAlpacaResponse : IValueResponse<TResult>, new()
        {
            RestRequest request = requestBuilder();
            var response = await CommandSender.ExecuteRequestAsync<TAlpacaResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);
            return response.HandleResponse<TResult, TAlpacaResponse>();
        }
    }
}