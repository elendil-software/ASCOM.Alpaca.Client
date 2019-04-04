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
using RestSharp;

namespace ASCOM.Alpaca.Client.Devices
{
    public class FilterWheel : DeviceBase, IFilterWheel
    {
        protected override DeviceType DeviceType { get; } = DeviceType.FilterWheel;
        
        
        public FilterWheel(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ILogger<DeviceBase> logger) : base(configuration, clientTransactionIdGenerator, logger)
        {
        }

        public FilterWheel(DeviceConfiguration configuration, IClientTransactionIdGenerator clientTransactionIdGenerator, ILogger<DeviceBase> logger, ICommandSender commandSender) : base(configuration, clientTransactionIdGenerator, logger, commandSender)
        {
        }

        public List<int> GetFocusOffsets()
        {
            RestRequest request = RequestBuilder.BuildRestRequest(FilterWheelMethod.FocusOffsets, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
            Logger.LogDebug(request);
            
            var response = CommandSender.ExecuteRequest<IntArrayResponse>(request);
            Logger.LogDebug(response);

            return response.HandleResponse<List<int>, IntArrayResponse>();
        }

        public List<string> GetNames()
        {
            RestRequest request = RequestBuilder.BuildRestRequest(FilterWheelMethod.Names, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
            Logger.LogDebug(request);
            
            var response = CommandSender.ExecuteRequest<StringArrayResponse>(request);
            Logger.LogDebug(response);

            return response.HandleResponse<List<string>, StringArrayResponse>();
        }

        public int GetPosition()
        {
            RestRequest request = RequestBuilder.BuildRestRequest(FilterWheelMethod.Position, Method.GET, ClientTransactionIdGenerator.GetTransactionId());
            Logger.LogDebug(request);
            
            var response = CommandSender.ExecuteRequest<IntResponse>(request);
            Logger.LogDebug(response);

            return response.HandleResponse<int, IntResponse>();
        }

        public void SetPosition(int position)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Position", position.ToString(CultureInfo.InvariantCulture)}
            };
            
            RestRequest request = RequestBuilder.BuildRestRequest(FilterWheelMethod.Position, Method.PUT, parameters, ClientTransactionIdGenerator.GetTransactionId());
            Logger.LogDebug(request);
            
            var response = CommandSender.ExecuteRequest<MethodResponse>(request);
            Logger.LogDebug(response);

            response.HandleResponse();
        }
    }
}