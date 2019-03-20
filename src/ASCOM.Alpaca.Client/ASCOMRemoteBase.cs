using System;
using System.Collections.Generic;
using ASCOM.Alpaca.Client.Responses;
using RestSharp;

namespace ASCOM.Alpaca.Client
{
    public abstract class AscomRemoteBase<T> where T : AscomRemoteParametersBase
    {
        protected IAscomRemoteCommandSender CommandSender;
        protected string DeviceType;
        public string DisplayName { get; protected set; }
        public T Parameters { get; set; }

        protected AscomRemoteBase(string deviceType, string displayName, T parameters, IAscomRemoteCommandSender commandSender)
        {
            CommandSender = commandSender ?? throw new ArgumentNullException(nameof(commandSender));
            DeviceType = deviceType ?? throw new ArgumentNullException(nameof(deviceType));
            DisplayName = displayName ?? throw new ArgumentNullException(nameof(displayName));
            Parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
        }

        public void Connect()
        {
            CommandSender.InitRestClient(Parameters.GetBaseUrl());

            RestRequest request = AscomRestRequestBuilder.BuildRestRequest("Connected", Method.PUT, DeviceType, Parameters.DeviceNumber, new Dictionary<string, object> { { "Connected", true } });
            var response = CommandSender.ExecuteRequest<BoolResponse>(request);
            ThrowExceptionIfResponseIsInvalid(response);
        }

        public void Disconnect()
        {
            if (IsConnected())
            {
                RestRequest request = AscomRestRequestBuilder.BuildRestRequest("Connected", Method.PUT, DeviceType, Parameters.DeviceNumber, new Dictionary<string, object> {{"Connected", false}});
                var response = CommandSender.ExecuteRequest<BoolResponse>(request);
                ThrowExceptionIfResponseIsInvalid(response);
            }
        }

        public bool IsConnected()
        {
            if (!CommandSender.IsInitialized)
            {
                return false;
            }

            RestRequest request = AscomRestRequestBuilder.BuildRestRequest("Connected", Method.GET, DeviceType, Parameters.DeviceNumber);
            var response = CommandSender.ExecuteRequest<BoolResponse>(request);
            ThrowExceptionIfResponseIsInvalid(response);
            return response.Value;
        }

        protected string GetDescription()
        {
            ThrowsNotConnectedExceptionIfNotConnected();
            RestRequest request = AscomRestRequestBuilder.BuildRestRequest("Description", Method.GET, DeviceType, Parameters.DeviceNumber);
            var response = CommandSender.ExecuteRequest<StringResponse>(request);
            ThrowExceptionIfResponseIsInvalid(response);
            return response.Value;
        }

        protected TASCOMRemoteResponse ExecuteGetRequest<TASCOMRemoteResponse>(string command) where TASCOMRemoteResponse : IResponse, new()
        {
            return ExecuteGetRequest<TASCOMRemoteResponse>(command, new Dictionary<string, object>());
        }

        protected TASCOMRemoteResponse ExecuteGetRequest<TASCOMRemoteResponse>(string command, Dictionary<string, object> parameters) where TASCOMRemoteResponse : IResponse, new()
        {
            ThrowsNotConnectedExceptionIfNotConnected();
            RestRequest request = AscomRestRequestBuilder.BuildRestRequest(command, Method.GET, DeviceType, Parameters.DeviceNumber, parameters);
            var response = CommandSender.ExecuteRequest<TASCOMRemoteResponse>(request);
            ThrowExceptionIfResponseIsInvalid(response);
            return response;
        }

        protected void ExecutePutRequest(string command)
        {
            ExecutePutRequest(command, new Dictionary<string, object>());
        }

        protected void ExecutePutRequest(string command, Dictionary<string, object> parameters)
        {
            ThrowsNotConnectedExceptionIfNotConnected();
            RestRequest request = AscomRestRequestBuilder.BuildRestRequest(command, Method.PUT, DeviceType, Parameters.DeviceNumber, parameters);
            var response = CommandSender.ExecuteRequest<MethodResponse>(request);
            ThrowExceptionIfResponseIsInvalid(response);
        }

        protected IRestResponse ExecuteGetRequest(string command)
        {
            ThrowsNotConnectedExceptionIfNotConnected();
            RestRequest request = AscomRestRequestBuilder.BuildRestRequest(command, Method.GET, DeviceType, Parameters.DeviceNumber);
            return CommandSender.ExecuteRequest(request);
        }

        protected void ThrowExceptionIfResponseIsInvalid(IResponse response)
        {
            if (response.ErrorNumber != 0 || !string.IsNullOrWhiteSpace(response.ErrorMessage))
            {
                throw new Exception($"ASCOM Error : {response.ErrorNumber} : {response.ErrorMessage}");
            }
        }

        protected void ThrowsNotConnectedExceptionIfNotConnected()
        {
            if (!IsConnected())
            {
                throw new Exception($"The ASCOM device {DisplayName} is not connected");
            }
        }
    }
}