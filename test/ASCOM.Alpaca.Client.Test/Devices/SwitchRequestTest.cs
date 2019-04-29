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
    public class SwitchRequestTest : DeviceRequestsTestBase
    {
        private readonly DeviceConfiguration _deviceConfiguration = new DeviceConfiguration { DeviceNumber = 5 };
        private readonly ClientTransactionIdGenerator _clientTransactionIdGenerator = new ClientTransactionIdGenerator();
        protected override DeviceType DeviceType { get; } = DeviceType.Switch;
        
        [Fact]
        public void GetMaxSwitch_SendValidRequest()
        {
            //Arrange
            string commandName = "maxswitch";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(new IntResponse());
            var switchDevice = new Switch(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            switchDevice.GetMaxSwitch();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetMaxSwitchAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "maxswitch";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new IntResponse()));
            var switchDevice = new Switch(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await switchDevice.GetMaxSwitchAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void CanWrite_SendValidRequest()
        {
            //Arrange
            string commandName = "canwrite";
            string idParameterName = "Id";
            int idParameterValue = 2;
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var switchDevice = new Switch(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            switchDevice.CanWrite(idParameterValue);
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, idParameterName, idParameterValue);
        }
        
        [Fact]
        public async Task CanWriteAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "canwrite";
            string idParameterName = "Id";
            int idParameterValue = 2;
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var switchDevice = new Switch(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await switchDevice.CanWriteAsync(idParameterValue);
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, idParameterName, idParameterValue);
        }
        
        [Fact]
        public void GetSwitch_SendValidRequest()
        {
            //Arrange
            string commandName = "getswitch";
            string idParameterName = "Id";
            int idParameterValue = 2;
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var switchDevice = new Switch(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            switchDevice.GetSwitch(idParameterValue);
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, idParameterName, idParameterValue);
        }
        
        [Fact]
        public async Task GetSwitchAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "getswitch";
            string idParameterName = "Id";
            int idParameterValue = 2;
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var switchDevice = new Switch(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await switchDevice.GetSwitchAsync(idParameterValue);
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, idParameterName, idParameterValue);
        }
        
        [Fact]
        public void SetSwitch_SendValidRequest()
        {
            //Arrange
            string commandName = "setswitch";
            string idParameterName = "Id";
            int idParameterValue = 2;
            string stateParameterName = "State";
            bool stateParameterValue = true;
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(new Response());
            var switchDevice = new Switch(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            switchDevice.SetSwitch(idParameterValue, stateParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, idParameterName, idParameterValue);
            AssertParameter(sentRequest.Parameters, stateParameterName, stateParameterValue);
        }
        
        [Fact]
        public async Task SetSwitchAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "setswitch";
            string idParameterName = "Id";
            int idParameterValue = 2;
            string stateParameterName = "State";
            bool stateParameterValue = true;
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var switchDevice = new Switch(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await switchDevice.SetSwitchAsync(idParameterValue, stateParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, idParameterName, idParameterValue);
            AssertParameter(sentRequest.Parameters, stateParameterName, stateParameterValue);
        }
        
        [Fact]
        public void GetSwitchDescription_SendValidRequest()
        {
            //Arrange
            string commandName = "getswitchdescription";
            string idParameterName = "Id";
            int idParameterValue = 2;
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<StringResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(new StringResponse());
            var switchDevice = new Switch(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            switchDevice.GetSwitchDescription(idParameterValue);
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, idParameterName, idParameterValue);
        }
        
        [Fact]
        public async Task GetSwitchDescriptionAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "getswitchdescription";
            string idParameterName = "Id";
            int idParameterValue = 2;
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<StringResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new StringResponse()));
            var switchDevice = new Switch(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await switchDevice.GetSwitchDescriptionAsync(idParameterValue);
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, idParameterName, idParameterValue);
        }
        
        [Fact]
        public void GetSwitchName_SendValidRequest()
        {
            //Arrange
            string commandName = "getswitchname";
            string idParameterName = "Id";
            int idParameterValue = 2;
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<StringResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(new StringResponse());
            var switchDevice = new Switch(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            switchDevice.GetSwitchName(idParameterValue);
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, idParameterName, idParameterValue);
        }
        
        [Fact]
        public async Task GetSwitchNameAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "getswitchname";
            string idParameterName = "Id";
            int idParameterValue = 2;
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<StringResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new StringResponse()));
            var switchDevice = new Switch(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await switchDevice.GetSwitchNameAsync(idParameterValue);
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, idParameterName, idParameterValue);
        }
        
        [Fact]
        public void SetSwitchName_SendValidRequest()
        {
            //Arrange
            string commandName = "setswitchname";
            string idParameterName = "Id";
            int idParameterValue = 2;
            string nameParameterName = "Name";
            string nameParameterValue = "nameParameterValue";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(new Response());
            var switchDevice = new Switch(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            switchDevice.SetSwitchName(idParameterValue, nameParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, idParameterName, idParameterValue);
            AssertParameter(sentRequest.Parameters, nameParameterName, nameParameterValue);
        }
        
        [Fact]
        public async Task SetSwitchNameAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "setswitchname";
            string idParameterName = "Id";
            int idParameterValue = 2;
            string nameParameterName = "Name";
            string nameParameterValue = "nameParameterValue";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var switchDevice = new Switch(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await switchDevice.SetSwitchNameAsync(idParameterValue, nameParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, idParameterName, idParameterValue);
            AssertParameter(sentRequest.Parameters, nameParameterName, nameParameterValue);
        }
        
        [Fact]
        public void GetSwitchValue_SendValidRequest()
        {
            //Arrange
            string commandName = "getswitchvalue";
            string idParameterName = "Id";
            int idParameterValue = 2;
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var switchDevice = new Switch(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            switchDevice.GetSwitchValue(idParameterValue);
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, idParameterName, idParameterValue);
        }
        
        [Fact]
        public async Task GetSwitchValueAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "getswitchvalue";
            string idParameterName = "Id";
            int idParameterValue = 2;
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var switchDevice = new Switch(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await switchDevice.GetSwitchValueAsync(idParameterValue);
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, idParameterName, idParameterValue);
        }
        
        [Fact]
        public void SetSwitchValue_SendValidRequest()
        {
            //Arrange
            string commandName = "setswitchvalue";
            string idParameterName = "Id";
            int idParameterValue = 2;
            string valueParameterName = "Value";
            double valueParameterValue = 2;
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(new Response());
            var switchDevice = new Switch(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            switchDevice.SetSwitchValue(idParameterValue, valueParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, idParameterName, idParameterValue);
            AssertParameter(sentRequest.Parameters, valueParameterName, valueParameterValue);
        }
        
        [Fact]
        public async Task SetSwitchValueAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "setswitchvalue";
            string idParameterName = "Id";
            int idParameterValue = 2;
            string valueParameterName = "Value";
            double valueParameterValue = 2;
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var switchDevice = new Switch(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await switchDevice.SetSwitchValueAsync(idParameterValue, valueParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, idParameterName, idParameterValue);
            AssertParameter(sentRequest.Parameters, valueParameterName, valueParameterValue);
        }
        
        [Fact]
        public void GetMinSwitchValue_SendValidRequest()
        {
            //Arrange
            string commandName = "minswitchvalue";
            string idParameterName = "Id";
            int idParameterValue = 2;
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var switchDevice = new Switch(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            switchDevice.GetMinSwitchValue(idParameterValue);
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, idParameterName, idParameterValue);
        }
        
        [Fact]
        public async Task GetMinSwitchValueAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "minswitchvalue";
            string idParameterName = "Id";
            int idParameterValue = 2;
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var switchDevice = new Switch(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await switchDevice.GetMinSwitchValueAsync(idParameterValue);
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, idParameterName, idParameterValue);
        }
        
        [Fact]
        public void GetMaxSwitchValue_SendValidRequest()
        {
            //Arrange
            string commandName = "maxswitchvalue";
            string idParameterName = "Id";
            int idParameterValue = 2;
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var switchDevice = new Switch(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            switchDevice.GetMaxSwitchValue(idParameterValue);
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, idParameterName, idParameterValue);
        }
        
        [Fact]
        public async Task GetMaxSwitchValueAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "maxswitchvalue";
            string idParameterName = "Id";
            int idParameterValue = 2;
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var switchDevice = new Switch(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await switchDevice.GetMaxSwitchValueAsync(idParameterValue);
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, idParameterName, idParameterValue);
        }
        
        [Fact]
        public void GetSwitchStep_SendValidRequest()
        {
            //Arrange
            string commandName = "switchstep";
            string idParameterName = "Id";
            int idParameterValue = 2;
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var switchDevice = new Switch(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            switchDevice.GetSwitchStep(idParameterValue);
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, idParameterName, idParameterValue);
        }
        
        [Fact]
        public async Task GetSwitchStepAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "switchstep";
            string idParameterName = "Id";
            int idParameterValue = 2;
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var switchDevice = new Switch(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await switchDevice.GetSwitchStepAsync(idParameterValue);
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, idParameterName, idParameterValue);
        }
    }
}

