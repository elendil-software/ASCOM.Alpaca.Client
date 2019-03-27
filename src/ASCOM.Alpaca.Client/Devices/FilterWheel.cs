using System.Collections.Generic;
using System.Globalization;
using ASCOM.Alpaca.Client.Logger;
using ASCOM.Alpaca.Client.Methods;
using ASCOM.Alpaca.Client.Responses;
using RestSharp;

namespace ASCOM.Alpaca.Client.Device
{
    public class FilterWheel : DeviceBase, IFilterWheel
    {
        public FilterWheel(DeviceType deviceType, int deviceNumber, int clientId, ICommandSender commandSender, IClientTransactionIdGenerator clientTransactionIdGenerator) : 
            base(deviceType, deviceNumber, clientId, commandSender, clientTransactionIdGenerator)
        {
        }

        public IntArrayResponse GetFocusOffsets()
        {
            RestRequest request = _requestBuilder.BuildRestRequest(FilterWheelMethod.FocusOffsets, Method.GET, _clientTransactionIdGenerator.GetTransactionId());
            _logger.LogInformation(request);
            
            var response = _commandSender.ExecuteRequest<IntArrayResponse>(request);
            _logger.LogInformation(response);

            return response;
        }

        public StringArrayResponse GetNames()
        {
            RestRequest request = _requestBuilder.BuildRestRequest(FilterWheelMethod.Names, Method.GET, _clientTransactionIdGenerator.GetTransactionId());
            _logger.LogInformation(request);
            
            var response = _commandSender.ExecuteRequest<StringArrayResponse>(request);
            _logger.LogInformation(response);

            return response;
        }

        public IntResponse GetPosition()
        {
            RestRequest request = _requestBuilder.BuildRestRequest(FilterWheelMethod.Position, Method.GET, _clientTransactionIdGenerator.GetTransactionId());
            _logger.LogInformation(request);
            
            var response = _commandSender.ExecuteRequest<IntResponse>(request);
            _logger.LogInformation(response);

            return response;
        }

        public MethodResponse SetPosition(int position)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Position", position.ToString(CultureInfo.InvariantCulture)}
            };
            
            RestRequest request = _requestBuilder.BuildRestRequest(FilterWheelMethod.Position, Method.PUT, parameters, _clientTransactionIdGenerator.GetTransactionId());
            _logger.LogInformation(request);
            
            var response = _commandSender.ExecuteRequest<MethodResponse>(request);
            _logger.LogInformation(response);

            return response;
        }
    }
}