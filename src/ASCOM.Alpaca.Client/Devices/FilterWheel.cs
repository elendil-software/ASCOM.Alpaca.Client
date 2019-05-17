using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using ASCOM.Alpaca.Client.Request;
using ASCOM.Alpaca.Client.Transactions;
using ASCOM.Alpaca.Devices;
using ASCOM.Alpaca.Responses;
using RestSharp;

namespace ASCOM.Alpaca.Client.Devices
{
    public sealed class FilterWheel : DeviceBase, IFilterWheel
    {
        protected override DeviceType DeviceType { get; } = DeviceType.FilterWheel;

        public FilterWheel(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ICommandSender commandSender) :
            base(configuration, clientTransactionIdGenerator, commandSender)
        {
        }

        public IList<int> GetFocusOffsets() => ExecuteRequest<IList<int>, IntListResponse>(BuildGetFocusOffsetRequest);
        public async Task<IList<int>> GetFocusOffsetsAsync() => await ExecuteRequestAsync<IList<int>, IntListResponse>(BuildGetFocusOffsetRequest);
        private IRestRequest BuildGetFocusOffsetRequest() => RequestBuilder.BuildRestRequest(FilterWheelMethod.FocusOffsets, Method.GET, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));

        public IList<string> GetNames() => ExecuteRequest<IList<string>, StringListResponse>(BuildGetNamesRequest);
        public async Task<IList<string>> GetNamesAsync() => await ExecuteRequestAsync<IList<string>, StringListResponse>(BuildGetNamesRequest);
        private IRestRequest BuildGetNamesRequest() => RequestBuilder.BuildRestRequest(FilterWheelMethod.Names, Method.GET, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));

        public int GetPosition() => ExecuteRequest<int, IntResponse>(BuildGetPositionRequest);
        public async Task<int> GetPositionAsync() => await ExecuteRequestAsync<int, IntResponse>(BuildGetPositionRequest);
        private IRestRequest BuildGetPositionRequest() => RequestBuilder.BuildRestRequest(FilterWheelMethod.Position, Method.GET, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));

        public void SetPosition(int position) => ExecuteRequest(BuildSetPositionRequest, position);
        public async Task SetPositionAsync(int position) => await ExecuteRequestAsync(BuildSetPositionRequest, position);
        private IRestRequest BuildSetPositionRequest(int position)
        {
            var parameters = new Dictionary<string, object>
            {
                {FilterWheelRequestParameters.Position, position.ToString(CultureInfo.InvariantCulture)}
            };

            return RequestBuilder.BuildRestRequest(FilterWheelMethod.Position, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId(Configuration.ClientId));
        }
    }
}
