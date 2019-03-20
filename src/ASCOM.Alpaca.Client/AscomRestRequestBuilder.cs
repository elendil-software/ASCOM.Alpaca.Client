using System.Collections.Generic;
using RestSharp;

namespace ASCOM.Alpaca.Client
{
    public static class AscomRestRequestBuilder
    {

        public static RestRequest BuildRestRequest(string command, Method method, string deviceType, int deviceNumber)
        {
            return BuildRestRequest(command, method, deviceType, deviceNumber, new Dictionary<string, object>());
        }

        public static RestRequest BuildRestRequest(string command, Method method, string deviceType, int deviceNumber, Dictionary<string, object> parameters)
        {
            var request = new RestRequest("{deviceType}/{deviceNumber}/{command}", method);
            request.AddUrlSegment("deviceType", deviceType);
            request.AddUrlSegment("deviceNumber", deviceNumber.ToString());
            request.AddUrlSegment("command", command);

            foreach (var parameter in parameters)
            {
                request.AddParameter(parameter.Key, parameter.Value);
            }

            return request;
        }
    }
}