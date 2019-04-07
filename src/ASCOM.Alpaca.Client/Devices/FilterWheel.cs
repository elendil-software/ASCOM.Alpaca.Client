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

namespace ASCOM.Alpaca.Client.Devices
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

            var response = CommandSender.ExecuteRequest<IntArrayResponse>(_configuration.GetBaseUrl(), request);


            return response.HandleResponse<List<int>, IntArrayResponse>();
        }

        public async Task<List<int>> GetFocusOffsetsAsync()
        {
            RestRequest request = BuildGetFocusOffsetRequest();
            
            var response = await CommandSender.ExecuteRequestAsync<IntArrayResponse>(_configuration.GetBaseUrl(), request);


            return response.HandleResponse<List<int>, IntArrayResponse>();
        }
        
        private RestRequest BuildGetFocusOffsetRequest()
        {
            RestRequest request =
                RequestBuilder.BuildRestRequest(FilterWheelMethod.FocusOffsets, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
            
            return request;
        }

        public List<string> GetNames()
        {
            var request = BuildGetNamesRequest();

            var response = CommandSender.ExecuteRequest<StringArrayResponse>(_configuration.GetBaseUrl(), request);


            return response.HandleResponse<List<string>, StringArrayResponse>();
        }
        
        public async Task<List<string>> GetNamesAsync()
        {
            var request = BuildGetNamesRequest();

            var response = await CommandSender.ExecuteRequestAsync<StringArrayResponse>(_configuration.GetBaseUrl(), request);


            return response.HandleResponse<List<string>, StringArrayResponse>();
        }

        private RestRequest BuildGetNamesRequest()
        {
            RestRequest request = RequestBuilder.BuildRestRequest(FilterWheelMethod.Names, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
            
            return request;
        }

        public int GetPosition()
        {
            var request = BuildGetPositionRequest();

            var response = CommandSender.ExecuteRequest<IntResponse>(_configuration.GetBaseUrl(), request);


            return response.HandleResponse<int, IntResponse>();
        }

        public async Task<int> GetPositionAsync()
        {
            var request = BuildGetPositionRequest();

            var response = await CommandSender.ExecuteRequestAsync<IntResponse>(_configuration.GetBaseUrl(), request);


            return response.HandleResponse<int, IntResponse>();
        }

        private RestRequest BuildGetPositionRequest()
        {
            RestRequest request = RequestBuilder.BuildRestRequest(FilterWheelMethod.Position, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
            
            return request;
        }

        public void SetPosition(int position)
        {
            RestRequest request = BuildSetPositionRequest(position);

            var response = CommandSender.ExecuteRequest<MethodResponse>(_configuration.GetBaseUrl(), request);


            response.HandleResponse();
        }

        public async Task SetPositionAsync(int position)
        {
            RestRequest request = BuildSetPositionRequest(position);

            var response = await CommandSender.ExecuteRequestAsync<MethodResponse>(_configuration.GetBaseUrl(), request);


            response.HandleResponse();
        }
        
        private RestRequest BuildSetPositionRequest(int position)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Position", position.ToString(CultureInfo.InvariantCulture)}
            };

            RestRequest request =
                RequestBuilder.BuildRestRequest(FilterWheelMethod.Position, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
            
            return request;
        }
    }
}