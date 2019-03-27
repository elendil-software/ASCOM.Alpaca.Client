using System;
using System.Collections.Generic;
using ASCOM.Alpaca.Client.Logger;
using ASCOM.Alpaca.Client.Methods;
using ASCOM.Alpaca.Client.Request;
using ASCOM.Alpaca.Client.Responses;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace ASCOM.Alpaca.Client.Device
{
    public abstract class DeviceBase : ICommonMethods
    {
        protected readonly ILogger _logger;
        protected readonly ICommandSender _commandSender;
        protected readonly RequestBuilder _requestBuilder;
        protected readonly IClientTransactionIdGenerator _clientTransactionIdGenerator;
        
        protected DeviceBase(DeviceType deviceType, int deviceNumber, int clientId, ICommandSender commandSender, IClientTransactionIdGenerator clientTransactionIdGenerator)
        {
            _commandSender = commandSender ?? throw new ArgumentNullException(nameof(commandSender));
            _requestBuilder = new RequestBuilder(deviceType, deviceNumber, clientId);
        }

        public StringResponse Action(string actionName, string actionParameters)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Action", actionName},
                {"Parameters", actionParameters}
            };

            RestRequest request = _requestBuilder.BuildRestRequest(CommonMethod.Action, Method.PUT, parameters, _clientTransactionIdGenerator.GetTransactionId());
            _logger.LogInformation(request);
            
            var response = _commandSender.ExecuteRequest<StringResponse>(request);
            _logger.LogInformation(response);
            
            return response;
        }

        public MethodResponse CommandBlind(string command, bool raw = false)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Command", command},
                {"Raw", raw.ToString()}
            };
            RestRequest request = _requestBuilder.BuildRestRequest(CommonMethod.CommandBlind, Method.PUT, parameters, _clientTransactionIdGenerator.GetTransactionId());
            _logger.LogInformation(request);
            
            var response = _commandSender.ExecuteRequest<MethodResponse>(request);
            _logger.LogInformation(response);

            return response;
        }

        public BoolResponse CommandBool(string command, bool raw = false)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Command", command},
                {"Raw", raw.ToString()}
            };
            RestRequest request = _requestBuilder.BuildRestRequest(CommonMethod.CommandBool, Method.PUT, parameters, _clientTransactionIdGenerator.GetTransactionId());
            _logger.LogInformation(request);
            
            var response = _commandSender.ExecuteRequest<BoolResponse>(request);
            _logger.LogInformation(response);

            return response;
        }

        public StringResponse CommandString(string command, bool raw = false)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Command", command},
                {"Raw", raw.ToString()}
            };
            RestRequest request = _requestBuilder.BuildRestRequest(CommonMethod.CommandString, Method.PUT, parameters, _clientTransactionIdGenerator.GetTransactionId());
            _logger.LogInformation(request);
            
            var response = _commandSender.ExecuteRequest<StringResponse>(request);
            _logger.LogInformation(response);

            return response;
        }

        public BoolResponse IsConnected()
        {
            RestRequest request = _requestBuilder.BuildRestRequest(CommonMethod.Connected, Method.GET, _clientTransactionIdGenerator.GetTransactionId());
            _logger.LogInformation(request);
            
            var response = _commandSender.ExecuteRequest<BoolResponse>(request);
            _logger.LogInformation(response);

            return response;
        }

        public MethodResponse SetConnected(bool connected)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Connected ", connected.ToString()}
            };
            RestRequest request = _requestBuilder.BuildRestRequest(CommonMethod.Connected, Method.PUT, parameters, _clientTransactionIdGenerator.GetTransactionId());
            _logger.LogInformation(request);
            
            var response = _commandSender.ExecuteRequest<MethodResponse>(request);
            _logger.LogInformation(response);

            return response;
        }

        public StringResponse GetDescription()
        {
            RestRequest request = _requestBuilder.BuildRestRequest(CommonMethod.Description, Method.GET, _clientTransactionIdGenerator.GetTransactionId());
            _logger.LogInformation(request);
            
            var response = _commandSender.ExecuteRequest<StringResponse>(request);
            _logger.LogInformation(response);

            return response;
        }

        public StringResponse GetDriverInfo()
        {
            RestRequest request = _requestBuilder.BuildRestRequest(CommonMethod.Driverinfo, Method.GET, _clientTransactionIdGenerator.GetTransactionId());
            _logger.LogInformation(request);
            
            var response = _commandSender.ExecuteRequest<StringResponse>(request);
            _logger.LogInformation(response);

            return response;
        }

        public StringResponse GetDriverVersion()
        {
            RestRequest request = _requestBuilder.BuildRestRequest(CommonMethod.DriverVersion, Method.GET, _clientTransactionIdGenerator.GetTransactionId());
            _logger.LogInformation(request);
            
            var response = _commandSender.ExecuteRequest<StringResponse>(request);
            _logger.LogInformation(response);

            return response;
        }

        public StringResponse GetName()
        {
            RestRequest request = _requestBuilder.BuildRestRequest(CommonMethod.Name, Method.GET, _clientTransactionIdGenerator.GetTransactionId());
            _logger.LogInformation(request);
            
             var response = _commandSender.ExecuteRequest<StringResponse>(request);
             _logger.LogInformation(response);

             return response;
        }

        public StringArrayResponse GetSupportedActions()
        {
            RestRequest request = _requestBuilder.BuildRestRequest(CommonMethod.SupportedActions, Method.GET, _clientTransactionIdGenerator.GetTransactionId());
            _logger.LogInformation(request);
            
            var response = _commandSender.ExecuteRequest<StringArrayResponse>(request);
            _logger.LogInformation(response);

            return response;
        }
    }
}