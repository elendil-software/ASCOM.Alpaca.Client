using System;
using System.Collections.Generic;
using RestSharp;

namespace ASCOM.Alpaca.Client
{
    public static class RequestBuilder
    {
        public static RestRequest BuildRestRequest(Enum command, Method httpMethod, string deviceType, int deviceNumber)
        {
            return BuildRestRequest(command, httpMethod, deviceType, deviceNumber, new Dictionary<string, object>());
        }

        public static RestRequest BuildRestRequest(Enum command, Method httpMethod, string deviceType, int deviceNumber, Dictionary<string, object> parameters)
        {
            var request = new RestRequest("{deviceType}/{deviceNumber}/{command}", httpMethod);
            request.AddUrlSegment("deviceType", deviceType);
            request.AddUrlSegment("deviceNumber", deviceNumber.ToString());
            request.AddUrlSegment("command", command.ToString());

            foreach (var parameter in parameters)
            {
                request.AddParameter(parameter.Key, parameter.Value);
            }

            return request;
        }
    }
}