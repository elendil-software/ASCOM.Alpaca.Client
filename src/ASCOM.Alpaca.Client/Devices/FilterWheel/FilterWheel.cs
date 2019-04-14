using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using ASCOM.Alpaca.Client.Configuration;
using ASCOM.Alpaca.Client.Devices.Methods;
using ASCOM.Alpaca.Client.Logger;
using ASCOM.Alpaca.Client.Request;
using ASCOM.Alpaca.Client.Responses;
using ASCOM.Alpaca.Client.Responses.Empty;
using ASCOM.Alpaca.Client.Responses.Numeric;
using ASCOM.Alpaca.Client.Responses.String;
using ASCOM.Alpaca.Client.Transactions;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace ASCOM.Alpaca.Client.Devices.FilterWheel
{
    public class FilterWheel : DeviceBase, IFilterWheel
    {
        protected override DeviceType DeviceType { get; } = DeviceType.FilterWheel;

        public FilterWheel(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ICommandSender commandSender, ILogger<DeviceBase> logger = null) : 
            base(configuration, clientTransactionIdGenerator, commandSender, logger)
        {
        }

        public List<int> GetFocusOffsets()
        {
            RestRequest request = BuildGetFocusOffsetRequest();

            var response = CommandSender.ExecuteRequest<IntArrayResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);

            return response.HandleResponse<List<int>, IntArrayResponse>();
        }

        public async Task<List<int>> GetFocusOffsetsAsync()
        {
            RestRequest request = BuildGetFocusOffsetRequest();
            
            var response = await CommandSender.ExecuteRequestAsync<IntArrayResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);

            return response.HandleResponse<List<int>, IntArrayResponse>();
        }
        
        private RestRequest BuildGetFocusOffsetRequest() => RequestBuilder.BuildRestRequest(FilterWheelMethod.FocusOffsets, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public List<string> GetNames()
        {
            var request = BuildGetNamesRequest();

            var response = CommandSender.ExecuteRequest<StringArrayResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);

            return response.HandleResponse<List<string>, StringArrayResponse>();
        }
        
        public async Task<List<string>> GetNamesAsync()
        {
            var request = BuildGetNamesRequest();

            var response = await CommandSender.ExecuteRequestAsync<StringArrayResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);

            return response.HandleResponse<List<string>, StringArrayResponse>();
        }

        private RestRequest BuildGetNamesRequest() => RequestBuilder.BuildRestRequest(FilterWheelMethod.Names, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public int GetPosition()
        {
            var request = BuildGetPositionRequest();

            var response = CommandSender.ExecuteRequest<IntResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);

            return response.HandleResponse<int, IntResponse>();
        }

        public async Task<int> GetPositionAsync()
        {
            var request = BuildGetPositionRequest();

            var response = await CommandSender.ExecuteRequestAsync<IntResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);

            return response.HandleResponse<int, IntResponse>();
        }

        private RestRequest BuildGetPositionRequest() => RequestBuilder.BuildRestRequest(FilterWheelMethod.Position, Method.GET, ClientTransactionIdGenerator.GetTransactionId());

        public void SetPosition(int position)
        {
            RestRequest request = BuildSetPositionRequest(position);

            var response = CommandSender.ExecuteRequest<MethodResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);

            response.HandleResponse();
        }

        public async Task SetPositionAsync(int position)
        {
            RestRequest request = BuildSetPositionRequest(position);

            var response = await CommandSender.ExecuteRequestAsync<MethodResponse>(Configuration.GetBaseUrl(), request);
            Logger.LogDebug(response);

            response.HandleResponse();
        }
        
        private RestRequest BuildSetPositionRequest(int position)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Position", position.ToString(CultureInfo.InvariantCulture)}
            };

            return RequestBuilder.BuildRestRequest(FilterWheelMethod.Position, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
        }
    }
}