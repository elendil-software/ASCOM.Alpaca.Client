using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using ASCOM.Alpaca.Client.Logging;
using ASCOM.Alpaca.Client.Request;
using ASCOM.Alpaca.Client.Responses;
using ASCOM.Alpaca.Client.Transactions;
using RestSharp;

namespace ASCOM.Alpaca.Client.Devices
{
    public sealed class FilterWheel : DeviceBase, IFilterWheel
    {
        public FilterWheel(DeviceConfiguration configuration) : base(configuration)
        {
        }

        public FilterWheel(DeviceConfiguration configuration, ILogger logger) : base(configuration, logger)
        {
        }

        public FilterWheel(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator) : base(configuration, clientTransactionIdGenerator)
        {
        }

        public FilterWheel(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ILogger logger) : base(configuration, clientTransactionIdGenerator, logger)
        {
        }

        internal FilterWheel(DeviceConfiguration configuration, ICommandSender commandSender) : base(configuration, commandSender)
        {
        }

        internal FilterWheel(DeviceConfiguration configuration, ICommandSender commandSender, IClientTransactionIdGenerator clientTransactionIdGenerator) : base(configuration, commandSender, clientTransactionIdGenerator)
        {
        }
        
        protected override DeviceType DeviceType { get; } = DeviceType.FilterWheel;

        public IList<int> GetFocusOffsets() => ExecuteRequest<IList<int>, IntListResponse>(BuildGetFocusOffsetRequest);
        public async Task<IList<int>> GetFocusOffsetsAsync() => await ExecuteRequestAsync<IList<int>, IntListResponse>(BuildGetFocusOffsetRequest);
        private IRestRequest BuildGetFocusOffsetRequest() => RequestBuilder.BuildRestRequest(FilterWheelMethod.FocusOffsets, Method.GET, GetClientTransactionId());

        public IList<string> GetNames() => ExecuteRequest<IList<string>, StringListResponse>(BuildGetNamesRequest);
        public async Task<IList<string>> GetNamesAsync() => await ExecuteRequestAsync<IList<string>, StringListResponse>(BuildGetNamesRequest);
        private IRestRequest BuildGetNamesRequest() => RequestBuilder.BuildRestRequest(FilterWheelMethod.Names, Method.GET, GetClientTransactionId());

        public int GetPosition() => ExecuteRequest<int, IntResponse>(BuildGetPositionRequest);
        public async Task<int> GetPositionAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetPositionRequest);
        private IRestRequest BuildGetPositionRequest() => RequestBuilder.BuildRestRequest(FilterWheelMethod.Position, Method.GET, GetClientTransactionId());

        public void SetPosition(int position) => ExecuteRequest(BuildSetPositionRequest, position);
        public async Task SetPositionAsync(int position) => await ExecuteRequestAsync(BuildSetPositionRequest, position);
        private IRestRequest BuildSetPositionRequest(int position)
        {
            var parameters = new Dictionary<string, object>
            {
                {FilterWheelRequestParameters.Position, position.ToString(CultureInfo.InvariantCulture)}
            };

            return RequestBuilder.BuildRestRequest(FilterWheelMethod.Position, Method.PUT, parameters, GetClientTransactionId());
        }
    }
}
