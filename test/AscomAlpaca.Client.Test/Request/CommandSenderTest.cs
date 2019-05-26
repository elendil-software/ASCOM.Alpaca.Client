using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using ES.AscomAlpaca.Client.Request;
using ES.AscomAlpaca.Exceptions;
using ES.AscomAlpaca.Responses;
using Moq;
using RestSharp;
using Xunit;

namespace ES.AscomAlpaca.Client.Test.Request
{
    public class CommandSenderTest
    {
        public static IEnumerable<object[]> CommandResponseTestCases
        {
            get
            {
                yield return new object[]
                {
                    "{\"ClientTransactionID\":5,\"ServerTransactionID\":10,\"ErrorNumber\":0,\"ErrorMessage\":\"\"}",
                    new CommandResponse(5, 10)
                };
                yield return new object[]
                {
                    "{\"ClientTransactionID\":5,\"ServerTransactionID\":10,\"ErrorNumber\":3210,\"ErrorMessage\":\"ERROR\"}",
                    new CommandResponse(3210, "ERROR", 5, 10)
                };
            }
        }
        
        [Theory]
        [MemberData(nameof(CommandResponseTestCases))]
        public void GivenValidRequest_ExecuteRequest_Returns_ExpectedCommandResponse(string jsonResponse, CommandResponse expectedDeserializedResponse)
        {
            //Arrange
            IRestResponse restResponse = new RestResponse();
            restResponse.Content = jsonResponse;
            restResponse.ResponseStatus = ResponseStatus.Completed;
            restResponse.StatusCode = HttpStatusCode.OK;
            CommandSender commandSender = InitCommandSender(jsonResponse, restResponse);

            //Act
            var response = commandSender.ExecuteRequest<CommandResponse>("", new RestRequest());

            //Assert
            Assert.Equal(expectedDeserializedResponse.ErrorMessage, response.ErrorMessage);
            Assert.Equal(expectedDeserializedResponse.ErrorNumber, response.ErrorNumber);
            Assert.Equal(expectedDeserializedResponse.ClientTransactionID, response.ClientTransactionID);
            Assert.Equal(expectedDeserializedResponse.ServerTransactionID, response.ServerTransactionID);
        }
        
        [Fact]
        public void GivenUnreachableServer_ExecuteRequest_ThrowsAlpacaException()
        {
            //Arrange
            IRestResponse restResponse = new RestResponse();
            restResponse.Content = "";
            restResponse.ResponseStatus = ResponseStatus.Error;
            restResponse.StatusCode = 0;
            CommandSender commandSender = InitCommandSender(restResponse.Content, restResponse);

            //Act/Assert
            Assert.Throws<AlpacaException>(() => commandSender.ExecuteRequest<CommandResponse>("", new RestRequest()));
        }
        
        [Fact]
        public void GivenTimeoutRequest_ExecuteRequest_ThrowsAlpacaException()
        {
            //Arrange
            IRestResponse restResponse = new RestResponse();
            restResponse.Content = "";
            restResponse.ResponseStatus = ResponseStatus.TimedOut;
            restResponse.StatusCode = 0;
            CommandSender commandSender = InitCommandSender(restResponse.Content, restResponse);

            //Act/Assert
            Assert.Throws<AlpacaException>(() => commandSender.ExecuteRequest<CommandResponse>("", new RestRequest()));
        }
        
        [Fact]
        public void GivenRequestCompletedOnError_ExecuteRequest_ThrowsAlpacaException()
        {
            //Arrange
            IRestResponse restResponse = new RestResponse();
            restResponse.Content = "";
            restResponse.ResponseStatus = ResponseStatus.Completed;
            restResponse.StatusCode = HttpStatusCode.BadRequest;
            CommandSender commandSender = InitCommandSender(restResponse.Content, restResponse);

            //Act/Assert
            Assert.Throws<AlpacaException>(() => commandSender.ExecuteRequest<CommandResponse>("", new RestRequest()));
        }
        
        
        
//        [Fact]
//        public void GivenValidRequest_ExecuteRequest_Returns_ExpectedCommandResponse()
//        {
//            //Arrange
//            IRestResponse restResponse = new RestResponse();
//            restResponse.Content = jsonResponse;
//            restResponse.ResponseStatus = ResponseStatus.Completed;
//            restResponse.StatusCode = HttpStatusCode.OK;
//            CommandSender commandSender = InitCommandSender(jsonResponse, restResponse);
//
//            //Act
//            var response = commandSender.ExecuteRequest<CommandResponse>("", new RestRequest());
//
//            //Assert
//            Assert.Equal(expectedDeserializedResponse.ErrorMessage, response.ErrorMessage);
//            Assert.Equal(expectedDeserializedResponse.ErrorNumber, response.ErrorNumber);
//            Assert.Equal(expectedDeserializedResponse.ClientTransactionID, response.ClientTransactionID);
//            Assert.Equal(expectedDeserializedResponse.ServerTransactionID, response.ServerTransactionID);
//        }
//        
//        
//        public static IEnumerable<object[]> ValueResponseTestCases
//        {
//            get
//            {
//                yield return new object[]
//                {
//                    "{\"Value\":\"StringResponseValue\",\"ClientTransactionID\":5,\"ServerTransactionID\":10,\"ErrorNumber\":0,\"ErrorMessage\":\"\"}",
//                    new StringResponse("StringResponseValue", 5, 10), 
//                };
//                yield return new object[]
//                {
//                    "{\"ClientTransactionID\":5,\"ServerTransactionID\":10,\"ErrorNumber\":3210,\"ErrorMessage\":\"ERROR\"}",
//                    new StringResponse(3210, "ERROR", 5, 10)
//                };
//            }
//        }
//        
//        [Theory]
//        [MemberData(nameof(ValueResponseTestCases))]
//        public void ExecuteRequest_ReturnsExpectedResponse<TASCOMRemoteResponse>(string jsonResponse, TASCOMRemoteResponse expectedDeserializedResponse) where TASCOMRemoteResponse : IResponse
//        {
//            //Arrange
//            CommandSender commandSender = InitCommandSender(jsonResponse);
//
//            //Act
//            MethodInfo method = typeof(CommandSender).GetMethods().FirstOrDefault(m => m.IsGenericMethod && m.Name == "ExecuteRequest");
//            MethodInfo generic = method.MakeGenericMethod(expectedDeserializedResponse.GetType());
//            //Invoke ExecuteRequest<TASCOMRemoteResponse>(string baseUrl, IRestRequest request)
//            var responseObject = generic.Invoke(commandSender, new object[] { "", new RestRequest()}); 
//            var response = (TASCOMRemoteResponse) responseObject;
//            
//            //Assert
//            Assert.Equal(expectedDeserializedResponse.ErrorMessage, response.ErrorMessage);
//            Assert.Equal(expectedDeserializedResponse.ErrorNumber, response.ErrorNumber);
//            Assert.Equal(expectedDeserializedResponse.ClientTransactionID, response.ClientTransactionID);
//            Assert.Equal(expectedDeserializedResponse.ServerTransactionID, response.ServerTransactionID);
//            
//            var expectedValue = expectedDeserializedResponse.GetType().GetProperty("Value").GetValue(expectedDeserializedResponse, null);
//            var responseValue = response.GetType().GetProperty("Value").GetValue(response, null);
//            Assert.Equal(expectedValue, responseValue);
//        }
        
        
        private static CommandSender InitCommandSender(string jsonResponse, IRestResponse restResponse)
        {
            var restClientMock = new Mock<IRestClient>();
            restClientMock.Setup(x => x.Execute(It.IsAny<IRestRequest>())).Returns(restResponse);
            
            var restClientFactoryMock = new Mock<IRestClientFactory>();
            restClientFactoryMock.Setup(x => x.Create(It.IsAny<string>())).Returns(restClientMock.Object);
            
            return new CommandSender(restClientFactoryMock.Object);
        }
    }
}