using System;
using System.Collections.Generic;
using ASCOM.Alpaca.Client;
using ASCOM.Alpaca.Client.Device;
using ASCOM.Alpaca.Client.Methods;
using ASCOM.Alpaca.Client.Request;
using ASCOM.Alpaca.Client.Responses;
using RestSharp;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var parameters = new AscomRemoteParametersBase();
            IRestClient restClient = new RestClient(parameters.GetBaseUrl());
            var commandSender = new CommandSender(restClient);
            //var requestBuilder = new RequestBuilder(DeviceType.telescope, 1);
            
            FilterWheel filterWheel = new FilterWheel(0, 1, commandSender, new ClientTransactionIdGenerator());

            var isConnectedResponse = filterWheel.IsConnected();
            Console.WriteLine($"isConnectedResponse : {isConnectedResponse.Value}");

            var connectResponse = filterWheel.SetConnected(true);
            
            var namesResponse = filterWheel.GetNames();
            Console.WriteLine($"namesResponse : {namesResponse.Value}");
            
            var positionResponse = filterWheel.GetPosition();
            Console.WriteLine($"positionResponse : {namesResponse.Value}");
            
            var setPositionResponse = filterWheel.SetPosition(2);
            
            positionResponse = filterWheel.GetPosition();
            Console.WriteLine($"positionResponse : {namesResponse.Value}");
            
            Console.ReadKey();
        }
    }
}