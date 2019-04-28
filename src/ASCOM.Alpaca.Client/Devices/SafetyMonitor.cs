using System.Threading.Tasks;
using ASCOM.Alpaca.Client.Configuration;
using ASCOM.Alpaca.Client.Request;
using ASCOM.Alpaca.Client.Transactions;
using ASCOM.Alpaca.Devices;
using ASCOM.Alpaca.Responses;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace ASCOM.Alpaca.Client.Devices
{
    public class SafetyMonitor : DeviceBase, ISafetyMonitor
    {
        public SafetyMonitor(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ICommandSender commandSender, ILogger<DeviceBase> logger) : base(configuration, clientTransactionIdGenerator, commandSender, logger)
        {
        }

        public SafetyMonitor(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ICommandSender commandSender) : base(configuration, clientTransactionIdGenerator, commandSender)
        {
        }

        protected override DeviceType DeviceType { get; } = DeviceType.SafetyMonitor;
        
        public bool IsSafe() => ExecuteRequest<bool, BoolResponse>(BuildIsSafeRequest);
        public async Task<bool> IsSafeAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsSafeRequest);
        private RestRequest BuildIsSafeRequest() => RequestBuilder.BuildRestRequest(SafetyMonitorMethod.IsSafe, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
    }
}