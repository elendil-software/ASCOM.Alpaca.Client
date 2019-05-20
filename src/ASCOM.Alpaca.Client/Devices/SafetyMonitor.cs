using System.Threading.Tasks;
using ASCOM.Alpaca.Client.Logging;
using ASCOM.Alpaca.Client.Request;
using ASCOM.Alpaca.Client.Responses;
using ASCOM.Alpaca.Client.Transactions;
using RestSharp;

namespace ASCOM.Alpaca.Client.Devices
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