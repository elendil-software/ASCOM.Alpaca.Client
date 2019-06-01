using System.Threading.Tasks;
using ES.AscomAlpaca.Client.Logging;
using ES.AscomAlpaca.Client.Request;
using ES.AscomAlpaca.Devices;
using ES.AscomAlpaca.Responses;
using RestSharp;

namespace ES.AscomAlpaca.Client.Devices
{
    /// <summary>
    /// Client implementation of an ASCOM Alpaca Safety Monitor device.
    /// <para>This class is meant to be use in a client application that need to control an ASCOM Alpaca Safety Monitor</para>
    /// </summary>
    public sealed class SafetyMonitor : DeviceBase, ISafetyMonitor, ISafetyMonitorAsync
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SafetyMonitor" /> class.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        public SafetyMonitor(DeviceConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SafetyMonitor" /> class.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        /// <param name="logger">Logger, can be useful for debugging</param>
        public SafetyMonitor(DeviceConfiguration configuration, ILogger logger) : base(configuration, logger)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SafetyMonitor" /> class.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        /// <param name="clientTransactionIdGenerator">Client Transaction ID Generator</param>
        public SafetyMonitor(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator) : base(configuration, clientTransactionIdGenerator)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SafetyMonitor" /> class.
        /// </summary>
        /// <param name="configuration">Device configuration</param>
        /// <param name="clientTransactionIdGenerator">Client Transaction ID Generator</param>
        /// <param name="logger">Logger, can be useful for debugging</param>
        public SafetyMonitor(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ILogger logger) : base(configuration, clientTransactionIdGenerator, logger)
        {
        }

        internal SafetyMonitor(DeviceConfiguration configuration, ICommandSender commandSender) : 
            base(configuration, commandSender)
        {
        }

        internal SafetyMonitor(DeviceConfiguration configuration, ICommandSender commandSender, IClientTransactionIdGenerator clientTransactionIdGenerator) : 
            base(configuration, commandSender, clientTransactionIdGenerator)
        {
        }

        /// <inheritdoc/>
        protected override DeviceType DeviceType { get; } = DeviceType.SafetyMonitor;
        
        /// <inheritdoc/>
        public bool IsSafe() => ExecuteRequest<bool, BoolResponse>(BuildIsSafeRequest);
        /// <inheritdoc/>
        public async Task<bool> IsSafeAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsSafeRequest);
        private IRestRequest BuildIsSafeRequest() => RequestBuilder.BuildRestRequest(SafetyMonitorCommand.IsSafe, Method.GET, GetClientTransactionId());
    }
}