using System.Threading.Tasks;
using ASCOM.Alpaca.Client.Request;
using ASCOM.Alpaca.Client.Responses;
using ASCOM.Alpaca.Client.Transactions;
using RestSharp;

namespace ASCOM.Alpaca.Client.Devices
{
    public sealed class SafetyMonitor : DeviceBase, ISafetyMonitor
    {
        public SafetyMonitor(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ICommandSender commandSender) : base(configuration, clientTransactionIdGenerator, commandSender)
        {
        }

        protected override DeviceType DeviceType { get; } = DeviceType.SafetyMonitor;
        
        public bool IsSafe() => ExecuteRequest<bool, BoolResponse>(BuildIsSafeRequest);
        public async Task<bool> IsSafeAsync() => await ExecuteRequestAsync<bool, BoolResponse>(BuildIsSafeRequest);
        private IRestRequest BuildIsSafeRequest() => RequestBuilder.BuildRestRequest(SafetyMonitorMethod.IsSafe, Method.GET, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));
    }
}