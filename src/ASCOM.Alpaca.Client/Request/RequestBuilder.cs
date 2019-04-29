using System;
using System.Collections.Generic;
using ASCOM.Alpaca.Devices;
using RestSharp;

namespace ASCOM.Alpaca.Client.Request
{
    public class RequestBuilder
    {
        private readonly DeviceType _deviceType;
        private readonly int _deviceNumber;
        private readonly int _clientId = 1;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceType">One of the recognised ASCOM device types</param>
        /// <param name="deviceNumber">Zero based device number as set on the server (0 to 4294967295)</param>
        public RequestBuilder(DeviceType deviceType, int deviceNumber)
        {
            _deviceType = deviceType;
            _deviceNumber = deviceNumber;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceType">One of the recognised ASCOM device types</param>
        /// <param name="deviceNumber">Zero based device number as set on the server (0 to 4294967295)</param>
        /// <param name="clientId">Client's unique ID. (0 to 4294967295). The client should choose a value at start-up, e.g. a random value between 0 and 65535, and send this
        /// value on every transaction to help associate entries in device logs with this particular client.</param>
        public RequestBuilder(DeviceType deviceType, int deviceNumber, int clientId)
        {
            _deviceType = deviceType;
            _deviceNumber = deviceNumber;
            _clientId = clientId;
        }

        public RestRequest BuildRestRequest(Enum command, Method httpMethod, int clientTransactionId = 1234)
        {
            return BuildRestRequest(command, httpMethod, new Dictionary<string, object>(), clientTransactionId);
        }
        
        public RestRequest BuildRestRequest(Enum command, Method httpMethod, Dictionary<string, object> parameters, int clientTransactionId = 1234)
        {
            var request = new RestRequest("{deviceType}/{deviceNumber}/{command}", httpMethod);
            request.AddUrlSegment("deviceType", _deviceType.ToString().ToLower());
            request.AddUrlSegment("deviceNumber", _deviceNumber.ToString());
            request.AddUrlSegment("command", command.ToString().ToLower());
            
            request.AddParameter("ClientID", _clientId.ToString(), ParameterType.QueryString);
            request.AddParameter("ClientTransactionID", clientTransactionId.ToString(), ParameterType.QueryString);
            
            foreach (var parameter in parameters)
            {
                request.AddParameter(parameter.Key, parameter.Value);
            }

            return request;
        }
    }
}