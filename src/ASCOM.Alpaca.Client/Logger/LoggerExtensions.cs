using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASCOM.Alpaca.Client.Methods;
using ASCOM.Alpaca.Client.Responses;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace ASCOM.Alpaca.Client.Logger
{
    internal static class LoggerExtensions
    {
        public static void LogInformation(this ILogger logger, RestRequest request)
        {
            string parametersString = string.Join(", ", request.Parameters.Select(p => $"{p.Name}={p.Value}").ToArray());
            
            logger?.LogInformation("Send command with parameters {Parameters}", parametersString);
        }

        public static void LogInformation<T>(this ILogger logger, IValueResponse<T> response)
        {
            logger?.LogInformation("Received response : ClientTransactionID={ClientTransactionID}, ServerTransactionID={ServerTransactionID}, Value={Value}, ErrorNumber={ErrorNumber}, ErrorMessage={ErrorMessage}", 
                                            response.ClientTransactionID, 
                                            response.ServerTransactionID, 
                                            response.Value, 
                                            response.ErrorNumber, 
                                            response.ErrorMessage);
        }
        
        public static void LogInformation(this ILogger logger, MethodResponse response)
        {
            logger?.LogInformation("Received response : ClientTransactionID={ClientTransactionID}, ServerTransactionID={ServerTransactionID}, ErrorNumber={ErrorNumber}, ErrorMessage={ErrorMessage}", 
                response.ClientTransactionID, 
                response.ServerTransactionID,
                response.ErrorNumber, 
                response.ErrorMessage);
        }
    }
}