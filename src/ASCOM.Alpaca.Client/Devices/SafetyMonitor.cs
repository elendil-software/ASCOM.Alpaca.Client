using System.Threading.Tasks;
using AscomAlpacaClient.Logging;
using AscomAlpacaClient.Request;
using AscomAlpacaClient.Responses;
using AscomAlpacaClient.Transactions;
using RestSharp;

namespace AscomAlpacaClient.Devices
{
    public sealed class SafetyMonitor : DeviceBase, ISafetyMonitor
    {
        public SafetyMonitor(DeviceConfiguration configuration) : base(configuration)
        {
        }

        public SafetyMonitor(DeviceConfiguration configuration, ILogger logger) : base(configuration, logger)
        {
        }

        public SafetyMonitor(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator) : base(configuration, clientTransactionIdGenerator)
        {
        }

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

        protected override DeviceType DeviceType { get; } = DeviceType.SafetyMonitor;
        
        public bool IsSafe() => ExecuteRequest<bool, BoolResponse>(BuildIsSafeRequest);
        public async Task<bool> IsSafeAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsSafeRequest);
        private IRestRequest BuildIsSafeRequest() => RequestBuilder.BuildRestRequest(SafetyMonitorMethod.IsSafe, Method.GET, GetClientTransactionId());
    }
}