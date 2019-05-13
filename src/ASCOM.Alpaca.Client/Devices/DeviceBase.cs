using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASCOM.Alpaca.Client.Logging;
using ASCOM.Alpaca.Client.Request;
using ASCOM.Alpaca.Client.Responses;
using ASCOM.Alpaca.Client.Transactions;
using ASCOM.Alpaca.Devices;
using ASCOM.Alpaca.Responses;
using ASCOM.Alpaca.Logging;
using RestSharp;

namespace ASCOM.Alpaca.Client.Devices
{
    public abstract class DeviceBase : IDevice
    {
        protected readonly ILogger Logger;
        protected readonly ICommandSender CommandSender;
        protected readonly IRequestBuilder RequestBuilder;
        protected readonly IClientTransactionIdGenerator ClientTransactionIdGenerator;
        protected readonly DeviceConfiguration Configuration;
        protected abstract DeviceType DeviceType { get; }
        public int DeviceNumber => Configuration.DeviceNumber;

        protected DeviceBase(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ICommandSender commandSender, ILogger logger)
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

        public string InvokeAction(string actionName, string actionParameters) => ExecuteRequest<string, StringResponse, string, string>(BuildInvokeActionRequest, actionName, actionParameters);
        public async Task<string> InvokeActionAsync(string actionName, string actionParameters) => await ExecuteRequestAsync<string, StringResponse, string, string>(BuildInvokeActionRequest, actionName, actionParameters);
        private IRestRequest BuildInvokeActionRequest(string actionName, string actionParameters)
        {
            var parameters = new Dictionary<string, object>
            {
                {DeviceRequestParameters.Action, actionName},
                {DeviceRequestParameters.Parameters, actionParameters}
            };

            return RequestBuilder.BuildRestRequest(DeviceMethod.Action, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public void SendCommandBlind(string command, bool raw = false) => ExecuteRequest(BuildSendCommandBlindRequest, command, raw);
        public async Task SendCommandBlindAsync(string command, bool raw = false) => await ExecuteRequestAsync(BuildSendCommandBlindRequest, command, raw);
        private IRestRequest BuildSendCommandBlindRequest(string command, bool raw)
        {
            var parameters = new Dictionary<string, object>
            {
                {DeviceRequestParameters.Command, command},
                {DeviceRequestParameters.Raw, raw.ToString()}
            };

            return RequestBuilder.BuildRestRequest(DeviceMethod.CommandBlind, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public bool SendCommandBool(string command, bool raw = false) => ExecuteRequest<bool, BoolResponse, string, bool>(BuildSendCommandBoolRequest, command, raw);
        public async Task<bool> SendCommandBoolAsync(string command, bool raw = false) => await ExecuteRequestAsync<bool, BoolResponse, string, bool>(BuildSendCommandBoolRequest, command, raw);
        private IRestRequest BuildSendCommandBoolRequest(string command, bool raw)
        {
            var parameters = new Dictionary<string, object>
            {
                {DeviceRequestParameters.Command, command},
                {DeviceRequestParameters.Raw, raw.ToString()}
            };

            return RequestBuilder.BuildRestRequest(DeviceMethod.CommandBool, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }
      
        public string SendCommandString(string command, bool raw = false) => ExecuteRequest<string, StringResponse, string, bool>(BuildSendCommandStringRequest, command, raw);
        
        public async Task<string> SendCommandStringAsync(string command, bool raw = false) => await ExecuteRequestAsync<string, StringResponse, string, bool>(BuildSendCommandStringRequest, command, raw);
        private IRestRequest BuildSendCommandStringRequest(string command, bool raw)
        {
            var parameters = new Dictionary<string, object>
            {
                {DeviceRequestParameters.Command, command},
                {DeviceRequestParameters.Raw, raw.ToString()}
            };

            return RequestBuilder.BuildRestRequest(DeviceMethod.CommandString, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public bool IsConnected() => ExecuteRequest<bool, BoolResponse>(BuildIsConnectedRequest);
        public async Task<bool> IsConnectedAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsConnectedRequest);
        private IRestRequest BuildIsConnectedRequest() => RequestBuilder.BuildRestRequest(DeviceMethod.Connected, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
        
        public void SetConnected(bool connected) => ExecuteRequest(BuildSetConnectedRequest, connected);
        public async Task SetConnectedAsync(bool connected) => await ExecuteRequestAsync(BuildSetConnectedRequest, connected);
        private IRestRequest BuildSetConnectedRequest(bool connected)
        {
            var parameters = new Dictionary<string, object>
            {
                {DeviceRequestParameters.Connected, connected.ToString()}
            };

            return RequestBuilder.BuildRestRequest(DeviceMethod.Connected, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }

        public string GetDescription() => ExecuteRequest<string, StringResponse>(BuildGetDescriptionRequest);     
        public async Task<string> GetDescriptionAsync() => await ExecuteRequestAsync<string, StringResponse>(BuildGetDescriptionRequest);
        private IRestRequest BuildGetDescriptionRequest() => RequestBuilder.BuildRestRequest(DeviceMethod.Description, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public string GetDriverInfo() => ExecuteRequest<string, StringResponse>(BuildGetDriverInfoRequest);    
        public async Task<string> GetDriverInfoAsync() => await ExecuteRequestAsync<string, StringResponse>(BuildGetDriverInfoRequest);
        private IRestRequest BuildGetDriverInfoRequest() => RequestBuilder.BuildRestRequest(DeviceMethod.DriverInfo, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public string GetDriverVersion() => ExecuteRequest<string, StringResponse>(BuildGetDriverVersionRequest);
        public async Task<string> GetDriverVersionAsync() => await ExecuteRequestAsync<string, StringResponse>(BuildGetDriverVersionRequest);
        private IRestRequest BuildGetDriverVersionRequest() => RequestBuilder.BuildRestRequest(DeviceMethod.DriverVersion, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public string GetName() => ExecuteRequest<string, StringResponse>(BuildGetNameRequest);
        public async Task<string> GetNameAsync() => await ExecuteRequestAsync<string, StringResponse>(BuildGetNameRequest);
        private IRestRequest BuildGetNameRequest() => RequestBuilder.BuildRestRequest(DeviceMethod.Name, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public IList<string> GetSupportedActions() => ExecuteRequest<IList<string>, StringArrayResponse>(BuildGetSupportedActionsRequest);      
        public async Task<IList<string>> GetSupportedActionsAsync() => await ExecuteRequestAsync<IList<string>, StringArrayResponse>(BuildGetSupportedActionsRequest);
        private IRestRequest BuildGetSupportedActionsRequest() => RequestBuilder.BuildRestRequest(DeviceMethod.SupportedActions, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        protected void ExecuteRequest(Func<IRestRequest> requestBuilder)
        {
            IRestRequest request = requestBuilder();
            Logger.LogDebug(request, Configuration.GetBaseUrl());
            var response = CommandSender.ExecuteRequest<Response>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);
            response.HandleResponse();
        }

        protected async Task ExecuteRequestAsync(Func<IRestRequest> requestBuilder)
        {
            IRestRequest request = requestBuilder();
            Logger.LogDebug(request, Configuration.GetBaseUrl());
            var response = await CommandSender.ExecuteRequestAsync<Response>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);
            response.HandleResponse();
        }

        protected void ExecuteRequest<T1>(Func<T1, IRestRequest> requestBuilder, T1 param1)
        {
            IRestRequest request = requestBuilder(param1);
            Logger.LogDebug(request, Configuration.GetBaseUrl());
            var response = CommandSender.ExecuteRequest<Response>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);
            response.HandleResponse();
        }

        protected async Task ExecuteRequestAsync<T1>(Func<T1, IRestRequest> requestBuilder, T1 arg)
        {
            IRestRequest request = requestBuilder(arg);
            Logger.LogDebug(request, Configuration.GetBaseUrl());
            var response = await CommandSender.ExecuteRequestAsync<Response>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);
            response.HandleResponse();
        }
        
        protected void ExecuteRequest<T1, T2>(Func<T1, T2, IRestRequest> requestBuilder, T1 arg1, T2 arg2)
        {
            IRestRequest request = requestBuilder(arg1, arg2);
            Logger.LogDebug(request, Configuration.GetBaseUrl());
            var response = CommandSender.ExecuteRequest<Response>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);
            response.HandleResponse();
        }

        protected async Task ExecuteRequestAsync<T1, T2>(Func<T1, T2, IRestRequest> requestBuilder, T1 arg1, T2 arg2)
        {
            IRestRequest request = requestBuilder(arg1, arg2);
            Logger.LogDebug(request, Configuration.GetBaseUrl());
            var response = await CommandSender.ExecuteRequestAsync<Response>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);
            response.HandleResponse();
        }
        
        protected TResult ExecuteRequest<TResult, TAlpacaResponse, T1>(Func<T1, IRestRequest> requestBuilder, T1 arg) where TAlpacaResponse : IValueResponse<TResult>, new()
        {
            IRestRequest request = requestBuilder(arg);
            Logger.LogDebug(request, Configuration.GetBaseUrl());
            var response = CommandSender.ExecuteRequest<TAlpacaResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);
            return response.HandleResponse<TResult, TAlpacaResponse>();
        }

        protected async Task<TResult> ExecuteRequestAsync<TResult, TAlpacaResponse, T1>(Func<T1, IRestRequest> requestBuilder, T1 arg) where TAlpacaResponse : IValueResponse<TResult>, new()
        {
            IRestRequest request = requestBuilder(arg);
            Logger.LogDebug(request, Configuration.GetBaseUrl());
            var response = await CommandSender.ExecuteRequestAsync<TAlpacaResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);
            return response.HandleResponse<TResult, TAlpacaResponse>();
        }
        
        protected TResult ExecuteRequest<TResult, TAlpacaResponse, T1, T2>(Func<T1, T2, IRestRequest> requestBuilder, T1 arg1, T2 arg2) where TAlpacaResponse : IValueResponse<TResult>, new()
        {
            IRestRequest request = requestBuilder(arg1 , arg2);
            Logger.LogDebug(request, Configuration.GetBaseUrl());
            var response = CommandSender.ExecuteRequest<TAlpacaResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);
            return response.HandleResponse<TResult, TAlpacaResponse>();
        }

        protected async Task<TResult> ExecuteRequestAsync<TResult, TAlpacaResponse, T1, T2>(Func<T1, T2, IRestRequest> requestBuilder, T1 arg1, T2 arg2) where TAlpacaResponse : IValueResponse<TResult>, new()
        {
            IRestRequest request = requestBuilder(arg1 , arg2);
            Logger.LogDebug(request, Configuration.GetBaseUrl());
            var response = await CommandSender.ExecuteRequestAsync<TAlpacaResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);
            return response.HandleResponse<TResult, TAlpacaResponse>();
        }
        
        protected TResult ExecuteRequest<TResult, TAlpacaResponse>(Func<IRestRequest> requestBuilder) where TAlpacaResponse : IValueResponse<TResult>, new()
        {
            IRestRequest request = requestBuilder();
            Logger.LogDebug(request, Configuration.GetBaseUrl());
            var response = CommandSender.ExecuteRequest<TAlpacaResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);
            return response.HandleResponse<TResult, TAlpacaResponse>();
        }

        protected async Task<TResult> ExecuteRequestAsync<TResult, TAlpacaResponse>(Func<IRestRequest> requestBuilder) where TAlpacaResponse : IValueResponse<TResult>, new()
        {
            IRestRequest request = requestBuilder();
            Logger.LogDebug(request, Configuration.GetBaseUrl());
            var response = await CommandSender.ExecuteRequestAsync<TAlpacaResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);
            return response.HandleResponse<TResult, TAlpacaResponse>();
        }
    }
}