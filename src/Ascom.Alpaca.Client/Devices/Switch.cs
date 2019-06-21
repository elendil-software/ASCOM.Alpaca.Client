using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using ES.AscomAlpaca.Client.Logging;
using ES.AscomAlpaca.Client.Request;
using ES.AscomAlpaca.Devices;
using ES.AscomAlpaca.Responses;
using RestSharp;

namespace ES.AscomAlpaca.Client.Devices
{
    /// <summary>
    /// Client implementation of an ASCOM Alpaca Switch device.
    /// <para>This class is meant to be use in a client application that need to control an ASCOM Alpaca Switch</para>
    /// </summary>
    public sealed class Switch : DeviceBase, ISwitch, ISwitchAsync
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Switch" /> class.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        public Switch(DeviceConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Switch" /> class.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        /// <param name="logger">Logger, can be useful for debugging</param>
        public Switch(DeviceConfiguration configuration, ILogger logger) : base(configuration, logger)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Switch" /> class.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        /// <param name="clientTransactionIdGenerator">Client Transaction ID Generator</param>
        public Switch(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator) : base(configuration, clientTransactionIdGenerator)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Switch" /> class.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        /// <param name="clientTransactionIdGenerator">Client Transaction ID Generator</param>
        /// <param name="logger">Logger, can be useful for debugging</param>
        public Switch(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ILogger logger) : base(configuration, clientTransactionIdGenerator, logger)
        {
        }

        internal Switch(DeviceConfiguration configuration, ICommandSender commandSender) : 
            base(configuration, commandSender)
        {
        }

        internal Switch(DeviceConfiguration configuration, ICommandSender commandSender, IClientTransactionIdGenerator clientTransactionIdGenerator) : 
            base(configuration, commandSender, clientTransactionIdGenerator)
        {
        }

        /// <inheritdoc/>
        protected override DeviceType DeviceType { get; } = DeviceType.Switch;
        
        /// <inheritdoc/>
        public int GetMaxSwitch() => ExecuteRequest<int, IntResponse>(BuildGetMaxSwitchRequest); 
        /// <inheritdoc/>
        public async Task<int> GetMaxSwitchAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetMaxSwitchRequest); 
        private IRestRequest BuildGetMaxSwitchRequest() => RequestBuilder.BuildRestRequest(SwitchCommand.MaxSwitch, Method.GET, GetClientTransactionId());

        /// <inheritdoc/>
        public bool CanWrite(int id) => ExecuteRequest<bool, BoolResponse, int>(BuildCanWriteRequest, id);
        /// <inheritdoc/>
        public async Task<bool> CanWriteAsync(int id) => await ExecuteRequestAsync<bool, BoolResponse, int>(BuildCanWriteRequest, id);
        private IRestRequest BuildCanWriteRequest(int id) => RequestBuilder.BuildRestRequest(SwitchCommand.CanWrite, Method.GET, GetDefaultParameters(id), GetClientTransactionId());

        /// <inheritdoc/>
        public bool GetSwitch(int id) => ExecuteRequest<bool, BoolResponse, int>(BuildGetSwitchRequest, id);
        /// <inheritdoc/>
        public async Task<bool> GetSwitchAsync(int id) => await ExecuteRequestAsync<bool, BoolResponse, int>(BuildGetSwitchRequest, id);
        private IRestRequest BuildGetSwitchRequest(int id) => RequestBuilder.BuildRestRequest(SwitchCommand.GetSwitch, Method.GET, GetDefaultParameters(id), GetClientTransactionId());

        /// <inheritdoc/>
        public void SetSwitch(int id, bool state) => ExecuteRequest(BuildSetSwitchRequest, id, state);
        /// <inheritdoc/>
        public async Task SetSwitchAsync(int id, bool state) => await ExecuteRequestAsync(BuildSetSwitchRequest, id, state);
        private IRestRequest BuildSetSwitchRequest(int id, bool state)
        {
            var parameters = GetDefaultParameters(id);
            parameters.Add(SwitchCommandParameters.State, state.ToString());
            return RequestBuilder.BuildRestRequest(SwitchCommand.SetSwitch, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public string GetSwitchDescription(int id) => ExecuteRequest<string, StringResponse, int>(BuildGetSwitchDescriptionRequest, id);
        /// <inheritdoc/>
        public async Task<string> GetSwitchDescriptionAsync(int id) => await ExecuteRequestAsync<string, StringResponse, int>(BuildGetSwitchDescriptionRequest, id);
        private IRestRequest BuildGetSwitchDescriptionRequest(int id) => RequestBuilder.BuildRestRequest(SwitchCommand.GetSwitchDescription, Method.GET, GetDefaultParameters(id), GetClientTransactionId());

        /// <inheritdoc/>
        public string GetSwitchName(int id) => ExecuteRequest<string, StringResponse, int>(BuildGetSwitchNameRequest, id);
        /// <inheritdoc/>
        public async Task<string> GetSwitchNameAsync(int id) => await ExecuteRequestAsync<string, StringResponse, int>(BuildGetSwitchNameRequest, id);
        private IRestRequest BuildGetSwitchNameRequest(int id) => RequestBuilder.BuildRestRequest(SwitchCommand.GetSwitchName, Method.GET, GetDefaultParameters(id), GetClientTransactionId());

        /// <inheritdoc/>
        public void SetSwitchName(int id, string name) => ExecuteRequest(BuildSetSwitchNameRequest, id, name);
        /// <inheritdoc/>
        public async Task SetSwitchNameAsync(int id, string name) => await ExecuteRequestAsync(BuildSetSwitchNameRequest, id, name);
        private IRestRequest BuildSetSwitchNameRequest(int id, string name)
        {
            var parameters = GetDefaultParameters(id);
            parameters.Add(SwitchCommandParameters.Name, name);
            return RequestBuilder.BuildRestRequest(SwitchCommand.SetSwitchName, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public double GetSwitchValue(int id) => ExecuteRequest<double, DoubleResponse, int>(BuildGetSwitchValueRequest, id);
        /// <inheritdoc/>
        public async Task<double> GetSwitchValueAsync(int id) => await ExecuteRequestAsync<double, DoubleResponse, int>(BuildGetSwitchValueRequest, id);
        private IRestRequest BuildGetSwitchValueRequest(int id) => RequestBuilder.BuildRestRequest(SwitchCommand.GetSwitchValue, Method.GET, GetDefaultParameters(id), GetClientTransactionId());

        /// <inheritdoc/>
        public void SetSwitchValue(int id, double value) => ExecuteRequest(BuildSetSwitchValueRequest, id, value);
        /// <inheritdoc/>
        public async Task SetSwitchValueAsync(int id, double value) => await ExecuteRequestAsync(BuildSetSwitchValueRequest, id, value);
        private IRestRequest BuildSetSwitchValueRequest(int id, double value)
        {
            var parameters = GetDefaultParameters(id);
            parameters.Add(SwitchCommandParameters.Value, value.ToString(CultureInfo.InvariantCulture));
            return RequestBuilder.BuildRestRequest(SwitchCommand.SetSwitchValue, Method.PUT, parameters, GetClientTransactionId());
        }

        /// <inheritdoc/>
        public double GetMinSwitchValue(int id) => ExecuteRequest<double, DoubleResponse, int>(BuildGetMinSwitchValueRequest, id);
        /// <inheritdoc/>
        public async Task<double> GetMinSwitchValueAsync(int id) => await ExecuteRequestAsync<double, DoubleResponse, int>(BuildGetMinSwitchValueRequest, id);
        private IRestRequest BuildGetMinSwitchValueRequest(int id) => RequestBuilder.BuildRestRequest(SwitchCommand.MinSwitchValue, Method.GET, GetDefaultParameters(id), GetClientTransactionId());

        /// <inheritdoc/>
        public double GetMaxSwitchValue(int id) => ExecuteRequest<double, DoubleResponse, int>(BuildGetMaxSwitchValueRequest, id);
        /// <inheritdoc/>
        public async Task<double> GetMaxSwitchValueAsync(int id) => await ExecuteRequestAsync<double, DoubleResponse, int>(BuildGetMaxSwitchValueRequest, id);
        private IRestRequest BuildGetMaxSwitchValueRequest(int id) => RequestBuilder.BuildRestRequest(SwitchCommand.MaxSwitchValue, Method.GET, GetDefaultParameters(id), GetClientTransactionId());

        /// <inheritdoc/>
        public double GetSwitchStep(int id) => ExecuteRequest<double, DoubleResponse, int>(BuildGetSwitchStepRequest, id);
        /// <inheritdoc/>
        public async Task<double> GetSwitchStepAsync(int id) => await ExecuteRequestAsync<double, DoubleResponse, int>(BuildGetSwitchStepRequest, id);
        private IRestRequest BuildGetSwitchStepRequest(int id) => RequestBuilder.BuildRestRequest(SwitchCommand.SwitchStep, Method.GET, GetDefaultParameters(id), GetClientTransactionId());
        
        private Dictionary<string, object> GetDefaultParameters(int id)
        {
            var parameters = new Dictionary<string, object>
            {
                {SwitchCommandParameters.Id, id.ToString()}
            };

            return parameters;
        }
    }
}