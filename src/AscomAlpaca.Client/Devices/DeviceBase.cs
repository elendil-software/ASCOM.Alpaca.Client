using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ES.AscomAlpaca.Client.Logging;
using ES.AscomAlpaca.Client.Request;
using ES.AscomAlpaca.Client.Responses;
using ES.AscomAlpaca.Devices;
using ES.AscomAlpaca.Responses;
using RestSharp;

namespace ES.AscomAlpaca.Client.Devices
{
    /// <summary>
    /// Base class of any client device implementation.
    /// <para>It defines the common methods that every device has to implement</para>
    /// </summary>
    public abstract class DeviceBase : IDevice, IDeviceAsync
    {
        private readonly IClientTransactionIdGenerator _clientTransactionIdGenerator;
        /// <summary>
        /// Command sender. It is used to send the request to the device
        /// </summary>
        protected readonly ICommandSender CommandSender;
        /// <summary>
        /// Request builder. It is used to prepare the request
        /// </summary>
        protected readonly IRequestBuilder RequestBuilder;
        /// <summary>
        /// Device configuration.
        /// <para>Contains all required settings to send request to the device</para>
        /// </summary>
        protected readonly DeviceConfiguration Configuration;
        /// <summary>
        /// Device type represented by the implementing class
        /// </summary>
        protected abstract DeviceType DeviceType { get; }
        /// <summary>
        /// Gets the device number
        /// <para>
        /// This number come from the <see cref="DeviceConfiguration"/> passed to the constructor
        /// </para>
        /// </summary>
        public int DeviceNumber => Configuration.DeviceNumber;
        
        /// <summary>
        /// Initializes a new device instance.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        protected DeviceBase(DeviceConfiguration configuration)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            CommandSender = new CommandSender();
            
            RequestBuilder = new RequestBuilder(DeviceType, configuration.DeviceNumber, configuration.ClientId);
        }
        
        /// <summary>
        /// Initializes a new device instance.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        /// <param name="logger">Logger, can be useful for debugging</param>
        protected DeviceBase(DeviceConfiguration configuration, ILogger logger)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            CommandSender = new CommandSender(logger);
            
            RequestBuilder = new RequestBuilder(DeviceType, configuration.DeviceNumber, configuration.ClientId);
        }
        
        /// <summary>
        /// Initializes a new device instance.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        /// <param name="clientTransactionIdGenerator">Client Transaction ID Generator</param>
        protected DeviceBase(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _clientTransactionIdGenerator = clientTransactionIdGenerator ?? throw new ArgumentNullException(nameof(clientTransactionIdGenerator));
            CommandSender = new CommandSender();
            
            RequestBuilder = new RequestBuilder(DeviceType, configuration.DeviceNumber, configuration.ClientId);
        }
        
        /// <summary>
        /// Initializes a new device instance.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        /// <param name="clientTransactionIdGenerator">Client Transaction ID Generator</param>
        /// <param name="logger">Logger, can be useful for debugging</param>
        protected DeviceBase(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ILogger logger)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _clientTransactionIdGenerator = clientTransactionIdGenerator ?? throw new ArgumentNullException(nameof(clientTransactionIdGenerator));
            CommandSender = new CommandSender(logger);
            
            RequestBuilder = new RequestBuilder(DeviceType, configuration.DeviceNumber, configuration.ClientId);
        }

        /// <summary>
        /// Initializes a new device instance.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        /// <param name="commandSender">Command sender</param>
        protected DeviceBase(DeviceConfiguration configuration, ICommandSender commandSender)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            CommandSender = commandSender ?? throw new ArgumentNullException(nameof(commandSender));
            
            RequestBuilder = new RequestBuilder(DeviceType, configuration.DeviceNumber, configuration.ClientId);
        }

        /// <summary>
        /// Initializes a new device instance.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        /// <param name="commandSender">Command sender</param>
        /// <param name="clientTransactionIdGenerator">Client Transaction ID Generator</param>
        protected DeviceBase(DeviceConfiguration configuration, ICommandSender commandSender, IClientTransactionIdGenerator clientTransactionIdGenerator)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            CommandSender = commandSender ?? throw new ArgumentNullException(nameof(commandSender));
            _clientTransactionIdGenerator = clientTransactionIdGenerator ?? throw new ArgumentNullException(nameof(clientTransactionIdGenerator));

            RequestBuilder = new RequestBuilder(DeviceType, configuration.DeviceNumber, configuration.ClientId);
        }

        /// <inheritdoc/>
        public string InvokeAction(string actionName, string actionParameters) => ExecuteRequest<string, StringResponse, string, string>(BuildInvokeActionRequest, actionName, actionParameters);
        /// <inheritdoc/>
        public async Task<string> InvokeActionAsync(string actionName, string actionParameters) => await ExecuteRequestAsync<string, StringResponse, string, string>(BuildInvokeActionRequest, actionName, actionParameters);
        private IRestRequest BuildInvokeActionRequest(string actionName, string actionParameters)
        {
            var parameters = new Dictionary<string, object>
            {
                {DeviceRequestParameters.Action, actionName},
                {DeviceRequestParameters.Parameters, actionParameters}
            };

            return RequestBuilder.BuildRestRequest(DeviceMethod.Action, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public void SendCommandBlind(string command, bool raw = false) => ExecuteRequest(BuildSendCommandBlindRequest, command, raw);
        /// <inheritdoc/>
        public async Task SendCommandBlindAsync(string command, bool raw = false) => await ExecuteRequestAsync(BuildSendCommandBlindRequest, command, raw);
        private IRestRequest BuildSendCommandBlindRequest(string command, bool raw)
        {
            var parameters = new Dictionary<string, object>
            {
                {DeviceRequestParameters.Command, command},
                {DeviceRequestParameters.Raw, raw.ToString()}
            };

            return RequestBuilder.BuildRestRequest(DeviceMethod.CommandBlind, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public bool SendCommandBool(string command, bool raw = false) => ExecuteRequest<bool, BoolResponse, string, bool>(BuildSendCommandBoolRequest, command, raw);
        /// <inheritdoc/>
        public async Task<bool> SendCommandBoolAsync(string command, bool raw = false) => await ExecuteRequestAsync<bool, BoolResponse, string, bool>(BuildSendCommandBoolRequest, command, raw);
        private IRestRequest BuildSendCommandBoolRequest(string command, bool raw)
        {
            var parameters = new Dictionary<string, object>
            {
                {DeviceRequestParameters.Command, command},
                {DeviceRequestParameters.Raw, raw.ToString()}
            };

            return RequestBuilder.BuildRestRequest(DeviceMethod.CommandBool, Method.PUT, parameters, GetClientTransactionId());
        }
      
        /// <inheritdoc/>
        public string SendCommandString(string command, bool raw = false) => ExecuteRequest<string, StringResponse, string, bool>(BuildSendCommandStringRequest, command, raw);
        /// <inheritdoc/>
        public async Task<string> SendCommandStringAsync(string command, bool raw = false) => await ExecuteRequestAsync<string, StringResponse, string, bool>(BuildSendCommandStringRequest, command, raw);
        private IRestRequest BuildSendCommandStringRequest(string command, bool raw)
        {
            var parameters = new Dictionary<string, object>
            {
                {DeviceRequestParameters.Command, command},
                {DeviceRequestParameters.Raw, raw.ToString()}
            };

            return RequestBuilder.BuildRestRequest(DeviceMethod.CommandString, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public bool IsConnected() => ExecuteRequest<bool, BoolResponse>(BuildIsConnectedRequest);
        /// <inheritdoc/>
        public async Task<bool> IsConnectedAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsConnectedRequest);
        private IRestRequest BuildIsConnectedRequest() => RequestBuilder.BuildRestRequest(DeviceMethod.Connected, Method.GET, GetClientTransactionId());
        
        /// <inheritdoc/>
        public void SetConnected(bool connected) => ExecuteRequest(BuildSetConnectedRequest, connected);
        /// <inheritdoc/>
        public async Task SetConnectedAsync(bool connected) => await ExecuteRequestAsync(BuildSetConnectedRequest, connected);
        private IRestRequest BuildSetConnectedRequest(bool connected)
        {
            var parameters = new Dictionary<string, object>
            {
                {DeviceRequestParameters.Connected, connected.ToString()}
            };

            return RequestBuilder.BuildRestRequest(DeviceMethod.Connected, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public string GetDescription() => ExecuteRequest<string, StringResponse>(BuildGetDescriptionRequest);     
        /// <inheritdoc/>
        public async Task<string> GetDescriptionAsync() => await ExecuteRequestAsync<string, StringResponse>(BuildGetDescriptionRequest);
        private IRestRequest BuildGetDescriptionRequest() => RequestBuilder.BuildRestRequest(DeviceMethod.Description, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public string GetDriverInfo() => ExecuteRequest<string, StringResponse>(BuildGetDriverInfoRequest);    
        /// <inheritdoc/>
        public async Task<string> GetDriverInfoAsync() => await ExecuteRequestAsync<string, StringResponse>(BuildGetDriverInfoRequest);
        private IRestRequest BuildGetDriverInfoRequest() => RequestBuilder.BuildRestRequest(DeviceMethod.DriverInfo, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public string GetDriverVersion() => ExecuteRequest<string, StringResponse>(BuildGetDriverVersionRequest);
        /// <inheritdoc/>
        public async Task<string> GetDriverVersionAsync() => await ExecuteRequestAsync<string, StringResponse>(BuildGetDriverVersionRequest);
        private IRestRequest BuildGetDriverVersionRequest() => RequestBuilder.BuildRestRequest(DeviceMethod.DriverVersion, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public int GetInterfaceVersion() => ExecuteRequest<int, IntResponse>(BuildGetInterfaceVersionRequest);
        /// <inheritdoc/>
        public async Task<int> GetInterfaceVersionAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetNameRequest);
        private IRestRequest BuildGetInterfaceVersionRequest() => RequestBuilder.BuildRestRequest(DeviceMethod.InterfaceVersion, Method.GET, GetClientTransactionId());
        
        /// <inheritdoc/>
        public string GetName() => ExecuteRequest<string, StringResponse>(BuildGetNameRequest);
        /// <inheritdoc/>
        public async Task<string> GetNameAsync() => await ExecuteRequestAsync<string, StringResponse>(BuildGetNameRequest);
        private IRestRequest BuildGetNameRequest() => RequestBuilder.BuildRestRequest(DeviceMethod.Name, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public IList<string> GetSupportedActions() => ExecuteRequest<IList<string>, StringListResponse>(BuildGetSupportedActionsRequest);      
        /// <inheritdoc/>
        public async Task<IList<string>> GetSupportedActionsAsync() => await ExecuteRequestAsync<IList<string>, StringListResponse>(BuildGetSupportedActionsRequest);
        private IRestRequest BuildGetSupportedActionsRequest() => RequestBuilder.BuildRestRequest(DeviceMethod.SupportedActions, Method.GET, GetClientTransactionId());

        protected void ExecuteRequest(Func<IRestRequest> requestBuilder, int? timeout = null)
        {
            IRestRequest request = requestBuilder();
            request.SetTimeout(timeout);
            var response = CommandSender.ExecuteRequest<CommandResponse>(Configuration.GetBaseUrl(), request);
            response.HandleResponse();
        }

        protected async Task ExecuteRequestAsync(Func<IRestRequest> requestBuilder, int? timeout = null)
        {
            IRestRequest request = requestBuilder();
            request.SetTimeout(timeout);
            var response = await CommandSender.ExecuteRequestAsync<CommandResponse>(Configuration.GetBaseUrl(), request);
            response.HandleResponse();
        }

        protected void ExecuteRequest<T1>(Func<T1, IRestRequest> requestBuilder, T1 param1, int? timeout = null)
        {
            IRestRequest request = requestBuilder(param1);
            request.SetTimeout(timeout);
            var response = CommandSender.ExecuteRequest<CommandResponse>(Configuration.GetBaseUrl(), request);
            response.HandleResponse();
        }

        protected async Task ExecuteRequestAsync<T1>(Func<T1, IRestRequest> requestBuilder, T1 arg, int? timeout = null)
        {
            IRestRequest request = requestBuilder(arg);
            request.SetTimeout(timeout);
            var response = await CommandSender.ExecuteRequestAsync<CommandResponse>(Configuration.GetBaseUrl(), request);
            response.HandleResponse();
        }
        
        protected void ExecuteRequest<T1, T2>(Func<T1, T2, IRestRequest> requestBuilder, T1 arg1, T2 arg2, int? timeout = null)
        {
            IRestRequest request = requestBuilder(arg1, arg2);
            request.SetTimeout(timeout);
            var response = CommandSender.ExecuteRequest<CommandResponse>(Configuration.GetBaseUrl(), request);
            response.HandleResponse();
        }

        protected async Task ExecuteRequestAsync<T1, T2>(Func<T1, T2, IRestRequest> requestBuilder, T1 arg1, T2 arg2, int? timeout = null)
        {
            IRestRequest request = requestBuilder(arg1, arg2);
            request.SetTimeout(timeout);
            var response = await CommandSender.ExecuteRequestAsync<CommandResponse>(Configuration.GetBaseUrl(), request);
            response.HandleResponse();
        }
        
        protected TResult ExecuteRequest<TResult, TAlpacaResponse, T1>(Func<T1, IRestRequest> requestBuilder, T1 arg, int? timeout = null) where TAlpacaResponse : IValueResponse<TResult>
        {
            IRestRequest request = requestBuilder(arg);
            request.SetTimeout(timeout);
            var response = CommandSender.ExecuteRequest<TAlpacaResponse>(Configuration.GetBaseUrl(), request);
            return response.HandleResponse<TResult, TAlpacaResponse>();
        }

        protected async Task<TResult> ExecuteRequestAsync<TResult, TAlpacaResponse, T1>(Func<T1, IRestRequest> requestBuilder, T1 arg, int? timeout = null) where TAlpacaResponse : IValueResponse<TResult>
        {
            IRestRequest request = requestBuilder(arg);
            request.SetTimeout(timeout);
            var response = await CommandSender.ExecuteRequestAsync<TAlpacaResponse>(Configuration.GetBaseUrl(), request);
            return response.HandleResponse<TResult, TAlpacaResponse>();
        }
        
        protected TResult ExecuteRequest<TResult, TAlpacaResponse, T1, T2>(Func<T1, T2, IRestRequest> requestBuilder, T1 arg1, T2 arg2, int? timeout = null) where TAlpacaResponse : IValueResponse<TResult>
        {
            IRestRequest request = requestBuilder(arg1 , arg2);
            request.SetTimeout(timeout);
            var response = CommandSender.ExecuteRequest<TAlpacaResponse>(Configuration.GetBaseUrl(), request);
            return response.HandleResponse<TResult, TAlpacaResponse>();
        }

        protected async Task<TResult> ExecuteRequestAsync<TResult, TAlpacaResponse, T1, T2>(Func<T1, T2, IRestRequest> requestBuilder, T1 arg1, T2 arg2, int? timeout = null) where TAlpacaResponse : IValueResponse<TResult>
        {
            IRestRequest request = requestBuilder(arg1 , arg2);
            request.SetTimeout(timeout);
            var response = await CommandSender.ExecuteRequestAsync<TAlpacaResponse>(Configuration.GetBaseUrl(), request);
            return response.HandleResponse<TResult, TAlpacaResponse>();
        }
        
        protected TResult ExecuteRequest<TResult, TAlpacaResponse>(Func<IRestRequest> requestBuilder, int? timeout = null) where TAlpacaResponse : IValueResponse<TResult>
        {
            IRestRequest request = requestBuilder();
            request.SetTimeout(timeout);
            var response = CommandSender.ExecuteRequest<TAlpacaResponse>(Configuration.GetBaseUrl(), request);
            return response.HandleResponse<TResult, TAlpacaResponse>();
        }

        protected async Task<TResult> ExecuteRequestAsync<TResult, TAlpacaResponse>(Func<IRestRequest> requestBuilder, int? timeout = null) where TAlpacaResponse : IValueResponse<TResult>
        {
            IRestRequest request = requestBuilder();
            request.SetTimeout(timeout);
            var response = await CommandSender.ExecuteRequestAsync<TAlpacaResponse>(Configuration.GetBaseUrl(), request);
            return response.HandleResponse<TResult, TAlpacaResponse>();
        }

        /// <summary>
        /// Get a client transaction ID for the current device.
        /// <para>If <see cref="_clientTransactionIdGenerator"/> is not set, -1 will be returned</para>
        /// </summary>
        /// <returns>a client transaction ID</returns>
        protected int GetClientTransactionId()
        {
            if (_clientTransactionIdGenerator == null)
            {
                return -1;
            }

            return _clientTransactionIdGenerator.GetTransactionId(Configuration.ClientId);
        }
    }
}