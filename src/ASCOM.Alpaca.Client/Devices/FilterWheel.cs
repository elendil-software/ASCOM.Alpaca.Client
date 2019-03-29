using System.Collections.Generic;
using System.Globalization;
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
using Microsoft.Extensions.Options;
using RestSharp;

namespace ASCOM.Alpaca.Client.Devices
{
    public class FilterWheel : DeviceBase, IFilterWheel
    {
        protected override DeviceType DeviceType { get; } = DeviceType.FilterWheel;
        
        public FilterWheel(DeviceConfiguration configuration, ILogger<DeviceBase> logger = null) : base(configuration, logger)
        {
        }
        
        public FilterWheel(IOptionsSnapshot<DeviceConfiguration> configuration, ILogger<DeviceBase> logger = null) : base(configuration, logger)
        {
        }

        public FilterWheel(DeviceConfiguration configuration, ICommandSender commandSender, IClientTransactionIdGenerator clientTransactionIdGenerator, ILogger<DeviceBase> logger) : 
               base(configuration, commandSender, clientTransactionIdGenerator, logger)
        {
        }

        public List<int> GetFocusOffsets()
        {
            RestRequest request = _requestBuilder.BuildRestRequest(FilterWheelMethod.FocusOffsets, Method.GET, _clientTransactionIdGenerator.GetTransactionId());
            _logger.LogDebug(request);
            
            var response = _commandSender.ExecuteRequest<IntArrayResponse>(request);
            _logger.LogDebug(response);

            return response.HandleResponse<List<int>, IntArrayResponse>();
        }

        public List<string> GetNames()
        {
            RestRequest request = _requestBuilder.BuildRestRequest(FilterWheelMethod.Names, Method.GET, _clientTransactionIdGenerator.GetTransactionId());
            _logger.LogDebug(request);
            
            var response = _commandSender.ExecuteRequest<StringArrayResponse>(request);
            _logger.LogDebug(response);

            return response.HandleResponse<List<string>, StringArrayResponse>();
        }

        public int GetPosition()
        {
            RestRequest request = _requestBuilder.BuildRestRequest(FilterWheelMethod.Position, Method.GET, _clientTransactionIdGenerator.GetTransactionId());
            _logger.LogDebug(request);
            
            var response = _commandSender.ExecuteRequest<IntResponse>(request);
            _logger.LogDebug(response);

            return response.HandleResponse<int, IntResponse>();
        }

        public void SetPosition(int position)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Position", position.ToString(CultureInfo.InvariantCulture)}
            };
            
            RestRequest request = _requestBuilder.BuildRestRequest(FilterWheelMethod.Position, Method.PUT, parameters, _clientTransactionIdGenerator.GetTransactionId());
            _logger.LogDebug(request);
            
            var response = _commandSender.ExecuteRequest<MethodResponse>(request);
            _logger.LogDebug(response);

            response.HandleResponse();
        }
    }
}