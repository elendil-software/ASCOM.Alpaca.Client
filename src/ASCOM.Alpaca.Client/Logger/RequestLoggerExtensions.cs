using System.Collections.Generic;
using System.Linq;
using ASCOM.Alpaca.Client.Responses;
using ASCOM.Alpaca.Client.Responses.Empty;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace ASCOM.Alpaca.Client.Logger
{
    internal static class RequestLoggerExtensions
    {
        public static void LogDebug(this ILogger logger, RestRequest request)
        {
            var requestParametersName = new List<string> {"deviceType", "deviceNumber", "command"};
            
            string parametersString = string.Join(", ", request.Parameters.Where(p => !requestParametersName.Contains(p.Name)).Select(p => $"{p.Name}={p.Value}").ToArray());
            string requestString = string.Join("/", request.Parameters.Where(p => requestParametersName.Contains(p.Name)).Select(p => p.Value).ToArray());
            
            logger?.LogDebug("Send request {Request} ({Method}) with parameters {Parameters}", requestString, request.Method, parametersString);
        }

        public static void LogDebug<T>(this ILogger logger, IValueResponse<T> response)
        {
            logger?.LogDebug("Received response : ClientTransactionID={ClientTransactionID}, ServerTransactionID={ServerTransactionID}, Value={Value}, ErrorNumber={ErrorNumber}, ErrorMessage={ErrorMessage}", 
                                            response.ClientTransactionID, 
                                            response.ServerTransactionID, 
                                            response.Value, 
                                            response.ErrorNumber, 
                                            response.ErrorMessage);
        }
        
        public static void LogDebug(this ILogger logger, MethodResponse response)
        {
            logger?.LogDebug("Received response : ClientTransactionID={ClientTransactionID}, ServerTransactionID={ServerTransactionID}, ErrorNumber={ErrorNumber}, ErrorMessage={ErrorMessage}", 
                response.ClientTransactionID, 
                response.ServerTransactionID,
                response.ErrorNumber, 
                response.ErrorMessage);
        }
    }
}