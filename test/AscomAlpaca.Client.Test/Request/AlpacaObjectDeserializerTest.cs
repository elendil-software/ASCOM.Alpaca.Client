using System.Collections.Generic;
using ES.AscomAlpaca.Client.Request;
using ES.AscomAlpaca.Responses;
using Xunit;

namespace ES.AscomAlpaca.Client.Test.Request
{
    public class AlpacaObjectDeserializerTest
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
        public void DeserializeObject_ReturnsExpected_CommandResponse(string jsonResponse, CommandResponse expectedDeserializedResponse)
        {
            //Arrange
            AlpacaObjectDeserializer alpacaObjectDeserializer = new AlpacaObjectDeserializer();
            
            //Act
            var response = alpacaObjectDeserializer.DeserializeObject<CommandResponse>(jsonResponse);

            //Assert
            Assert.Equal(expectedDeserializedResponse.ErrorMessage, response.ErrorMessage);
            Assert.Equal(expectedDeserializedResponse.ErrorNumber, response.ErrorNumber);
            Assert.Equal(expectedDeserializedResponse.ClientTransactionID, response.ClientTransactionID);
            Assert.Equal(expectedDeserializedResponse.ServerTransactionID, response.ServerTransactionID);
        }
        
        public static IEnumerable<object[]> ValueResponseTestCases
        {
            get
            {
                yield return new object[]
                {
                    "{\"Value\":\"StringResponseValue\",\"ClientTransactionID\":5,\"ServerTransactionID\":10,\"ErrorNumber\":0,\"ErrorMessage\":\"\"}",
                    new StringResponse("StringResponseValue", 5, 10), 
                };
                yield return new object[]
                {
                    "{\"ClientTransactionID\":5,\"ServerTransactionID\":10,\"ErrorNumber\":3210,\"ErrorMessage\":\"ERROR\"}",
                    new StringResponse(3210, "ERROR", 5, 10)
                };
            }
        }
        
        [Theory]
        [MemberData(nameof(ValueResponseTestCases))]
        public void ExecuteRequest_ReturnsExpectedResponse<TASCOMRemoteResponse>(string jsonResponse, TASCOMRemoteResponse expectedDeserializedResponse) where TASCOMRemoteResponse : IResponse
        {
            //Arrange
            AlpacaObjectDeserializer alpacaObjectDeserializer = new AlpacaObjectDeserializer();
            
            //Act
            var response = alpacaObjectDeserializer.DeserializeObject<TASCOMRemoteResponse>(jsonResponse);
            
            //Assert
            Assert.Equal(expectedDeserializedResponse.ErrorMessage, response.ErrorMessage);
            Assert.Equal(expectedDeserializedResponse.ErrorNumber, response.ErrorNumber);
            Assert.Equal(expectedDeserializedResponse.ClientTransactionID, response.ClientTransactionID);
            Assert.Equal(expectedDeserializedResponse.ServerTransactionID, response.ServerTransactionID);
            
            var expectedValue = expectedDeserializedResponse.GetType().GetProperty("Value").GetValue(expectedDeserializedResponse, null);
            var responseValue = response.GetType().GetProperty("Value").GetValue(response, null);
            Assert.Equal(expectedValue, responseValue);
        }
    }
}