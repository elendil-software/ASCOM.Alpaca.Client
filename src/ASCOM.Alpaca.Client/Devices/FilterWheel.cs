using System.Collections.Generic;
using System.Globalization;
using ASCOM.Alpaca.Client.Logger;
using ASCOM.Alpaca.Client.Methods;
using ASCOM.Alpaca.Client.Configuration;
using ASCOM.Alpaca.Client.Request;
using ASCOM.Alpaca.Client.Responses;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestSharp;

namespace ASCOM.Alpaca.Client.Device
{
    public class FilterWheel : DeviceBase, IFilterWheel
    {
        protected override DeviceType DeviceType { get; } = DeviceType.FilterWheel;
        
        public FilterWheel(IOptionsSnapshot<DeviceConfiguration> configuration, ILogger<DeviceBase> logger) : base(configuration, logger)
        {
        }

        public FilterWheel(DeviceConfiguration configuration, ILogger<DeviceBase> logger) : base(configuration, logger)
        {
        }

        public FilterWheel(DeviceConfiguration configuration, ICommandSender commandSender, IClientTransactionIdGenerator clientTransactionIdGenerator, ILogger<DeviceBase> logger) : 
               base(configuration, commandSender, clientTransactionIdGenerator, logger)
        {
        }

        public IntArrayResponse GetFocusOffsets()
        {
            RestRequest request = _requestBuilder.BuildRestRequest(FilterWheelMethod.FocusOffsets, Method.GET, _clientTransactionIdGenerator.GetTransactionId());
            _logger.LogDebug(request);
            
            var response = _commandSender.ExecuteRequest<IntArrayResponse>(request);
            _logger.LogDebug(response);

            return response;
        }

        public StringArrayResponse GetNames()
        {
            RestRequest request = _requestBuilder.BuildRestRequest(FilterWheelMethod.Names, Method.GET, _clientTransactionIdGenerator.GetTransactionId());
            _logger.LogDebug(request);
            
            var response = _commandSender.ExecuteRequest<StringArrayResponse>(request);
            _logger.LogDebug(response);

            return response;
        }

        public IntResponse GetPosition()
        {
            RestRequest request = _requestBuilder.BuildRestRequest(FilterWheelMethod.Position, Method.GET, _clientTransactionIdGenerator.GetTransactionId());
            _logger.LogDebug(request);
            
            var response = _commandSender.ExecuteRequest<IntResponse>(request);
            _logger.LogDebug(response);

            return response;
        }

        public MethodResponse SetPosition(int position)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Position", position.ToString(CultureInfo.InvariantCulture)}
            };
            
            RestRequest request = _requestBuilder.BuildRestRequest(FilterWheelMethod.Position, Method.PUT, parameters, _clientTransactionIdGenerator.GetTransactionId());
            _logger.LogDebug(request);
            
            var response = _commandSender.ExecuteRequest<MethodResponse>(request);
            _logger.LogDebug(response);

            return response;
        }
    }
}