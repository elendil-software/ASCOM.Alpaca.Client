using System.Threading.Tasks;
using ASCOM.Alpaca.Client.Devices;
using ASCOM.Alpaca.Client.Request;
using ASCOM.Alpaca.Client.Transactions;
using ASCOM.Alpaca.Devices;
using ASCOM.Alpaca.Responses;
using Moq;
using RestSharp;
using Xunit;

namespace ASCOM.Alpaca.Client.Test.Devices
{
    public class DeviceRequestTest : DeviceRequestsTestBase
    {
        private readonly DeviceConfiguration _deviceConfiguration = new DeviceConfiguration { DeviceNumber = 5 };
        private readonly ClientTransactionIdGenerator _clientTransactionIdGenerator = new ClientTransactionIdGenerator();
        protected override DeviceType DeviceType { get; } = DeviceType.FilterWheel;
            
        [Fact]
        public void InvokeAction_SendValidRequest()
        {
            //Arrange
            string commandName = "action";
            string actionNameParameterName = "Action";
            string actionNameParameterValue = "actionNameParameterValue";
            string actionParametersParameterName = "Parameters";
            string actionParametersParameterValue = "actionParametersParameterValue";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<StringResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new StringResponse());
            var device = new FilterWheel(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            device.InvokeAction(actionNameParameterValue, actionParametersParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, actionNameParameterName, actionNameParameterValue);
            AssertParameter(sentRequest.Parameters, actionParametersParameterName, actionParametersParameterValue);
        }
        
        [Fact]
        public async Task InvokeActionAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "action";
            string actionNameParameterName = "Action";
            string actionNameParameterValue = "actionNameParameterValue";
            string actionParametersParameterName = "Parameters";
            string actionParametersParameterValue = "actionParametersParameterValue";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<StringResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new StringResponse()));
            var device = new FilterWheel(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await device.InvokeActionAsync(actionNameParameterValue, actionParametersParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, actionNameParameterName, actionNameParameterValue);
            AssertParameter(sentRequest.Parameters, actionParametersParameterName, actionParametersParameterValue);
        }
        
        [Fact]
        public void SendCommandBlind_SendValidRequest()
        {
            //Arrange
            string commandName = "commandblind";
            string commandParameterName = "Command";
            string commandParameterValue = "commandParameterValue";
            string rawParameterName = "Raw";
            bool rawParameterValue = true;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var device = new FilterWheel(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            device.SendCommandBlind(commandParameterValue, rawParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, commandParameterName, commandParameterValue);
            AssertParameter(sentRequest.Parameters, rawParameterName, rawParameterValue);
        }
        
        [Fact]
        public async Task SendCommandBlindAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "commandblind";
            string commandParameterName = "Command";
            string commandParameterValue = "commandParameterValue";
            string rawParameterName = "Raw";
            bool rawParameterValue = true;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var device = new FilterWheel(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await device.SendCommandBlindAsync(commandParameterValue, rawParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, commandParameterName, commandParameterValue);
            AssertParameter(sentRequest.Parameters, rawParameterName, rawParameterValue);
        }
        
        [Fact]
        public void SendCommandBool_SendValidRequest()
        {
            //Arrange
            string commandName = "commandbool";
            string commandParameterName = "Command";
            string commandParameterValue = "commandParameterValue";
            string rawParameterName = "Raw";
            bool rawParameterValue = true;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var device = new FilterWheel(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            device.SendCommandBool(commandParameterValue, rawParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, commandParameterName, commandParameterValue);
            AssertParameter(sentRequest.Parameters, rawParameterName, rawParameterValue);
        }
        
        [Fact]
        public async Task SendCommandBoolAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "commandbool";
            string commandParameterName = "Command";
            string commandParameterValue = "commandParameterValue";
            string rawParameterName = "Raw";
            bool rawParameterValue = true;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var device = new FilterWheel(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await device.SendCommandBoolAsync(commandParameterValue, rawParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, commandParameterName, commandParameterValue);
            AssertParameter(sentRequest.Parameters, rawParameterName, rawParameterValue);
        }
        
        [Fact]
        public void SendCommandString_SendValidRequest()
        {
            //Arrange
            string commandName = "commandstring";
            string commandParameterName = "Command";
            string commandParameterValue = "commandParameterValue";
            string rawParameterName = "Raw";
            bool rawParameterValue = true;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<StringResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new StringResponse());
            var device = new FilterWheel(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            device.SendCommandString(commandParameterValue, rawParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, commandParameterName, commandParameterValue);
            AssertParameter(sentRequest.Parameters, rawParameterName, rawParameterValue);
        }
        
        [Fact]
        public async Task SendCommandStringAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "commandstring";
            string commandParameterName = "Command";
            string commandParameterValue = "commandParameterValue";
            string rawParameterName = "Raw";
            bool rawParameterValue = true;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<StringResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new StringResponse()));
            var device = new FilterWheel(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await device.SendCommandStringAsync(commandParameterValue, rawParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, commandParameterName, commandParameterValue);
            AssertParameter(sentRequest.Parameters, rawParameterName, rawParameterValue);
        }
        
        [Fact]
        public void IsConnected_SendValidRequest()
        {
            //Arrange
            string commandName = "connected";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var device = new FilterWheel(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            device.IsConnected();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task IsConnectedAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "connected";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var device = new FilterWheel(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await device.IsConnectedAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void SetConnected_SendValidRequest()
        {
            //Arrange
            string commandName = "connected";
            string connectedParameterName = "Connected";
            bool connectedParameterValue = true;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var device = new FilterWheel(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            device.SetConnected(connectedParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, connectedParameterName, connectedParameterValue);
        }
        
        [Fact]
        public async Task SetConnectedAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "connected";
            string connectedParameterName = "Connected";
            bool connectedParameterValue = true;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var device = new FilterWheel(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await device.SetConnectedAsync(connectedParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, connectedParameterName, connectedParameterValue);
        }
        
        [Fact]
        public void GetDescription_SendValidRequest()
        {
            //Arrange
            string commandName = "description";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<StringResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new StringResponse());
            var device = new FilterWheel(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            device.GetDescription();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetDescriptionAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "description";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<StringResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new StringResponse()));
            var device = new FilterWheel(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await device.GetDescriptionAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetDriverInfo_SendValidRequest()
        {
            //Arrange
            string commandName = "driverinfo";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<StringResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new StringResponse());
            var device = new FilterWheel(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            device.GetDriverInfo();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetDriverInfoAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "driverinfo";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<StringResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new StringResponse()));
            var device = new FilterWheel(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await device.GetDriverInfoAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetDriverVersion_SendValidRequest()
        {
            //Arrange
            string commandName = "driverversion";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<StringResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new StringResponse());
            var device = new FilterWheel(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            device.GetDriverVersion();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetDriverVersionAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "driverversion";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<StringResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new StringResponse()));
            var device = new FilterWheel(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await device.GetDriverVersionAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetName_SendValidRequest()
        {
            //Arrange
            string commandName = "name";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<StringResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new StringResponse());
            var device = new FilterWheel(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            device.GetName();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetNameAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "name";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<StringResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new StringResponse()));
            var device = new FilterWheel(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await device.GetNameAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetSupportedActions_SendValidRequest()
        {
            //Arrange
            string commandName = "supportedactions";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<StringListResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new StringListResponse());
            var device = new FilterWheel(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            device.GetSupportedActions();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetSupportedActionsAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "supportedactions";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<StringListResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new StringListResponse()));
            var device = new FilterWheel(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await device.GetSupportedActionsAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
    }
}