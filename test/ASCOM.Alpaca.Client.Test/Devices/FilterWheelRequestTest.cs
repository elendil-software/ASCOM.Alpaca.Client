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
    public class FilterWheelRequestTest : DeviceRequestsTestBase
    {
        private readonly DeviceConfiguration _deviceConfiguration = new DeviceConfiguration { DeviceNumber = 5 };
        private readonly ClientTransactionIdGenerator _clientTransactionIdGenerator = new ClientTransactionIdGenerator();
        protected override DeviceType DeviceType { get; } = DeviceType.FilterWheel;
        
        [Fact]
        public void GetFocusOffsets_SendValidRequest()
        {
            //Arrange
            string commandName = "focusoffsets";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<IntListResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new IntListResponse());
            var filterWheel = new FilterWheel(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            filterWheel.GetFocusOffsets();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetFocusOffsetsAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "focusoffsets";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<IntListResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new IntListResponse()));
            var filterWheel = new FilterWheel(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await filterWheel.GetFocusOffsetsAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetNames_SendValidRequest()
        {
            //Arrange
            string commandName = "names";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<StringListResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new StringListResponse());
            var filterWheel = new FilterWheel(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            filterWheel.GetNames();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetNamesAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "names";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<StringListResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new StringListResponse()));
            var filterWheel = new FilterWheel(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await filterWheel.GetNamesAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetPosition_SendValidRequest()
        {
            //Arrange
            string commandName = "position";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new IntResponse());
            var filterWheel = new FilterWheel(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            filterWheel.GetPosition();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetPositionAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "position";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new IntResponse()));
            var filterWheel = new FilterWheel(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await filterWheel.GetPositionAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void SetPosition_SendValidRequest()
        {
            //Arrange
            string commandName = "position";
            string positionParameterName = "Position";
            int positionParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var filterWheel = new FilterWheel(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            filterWheel.SetPosition(positionParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, positionParameterName, positionParameterValue);
        }
        
        [Fact]
        public async Task SetPositionAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "position";
            string positionParameterName = "Position";
            int positionParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var filterWheel = new FilterWheel(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await filterWheel.SetPositionAsync(positionParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, positionParameterName, positionParameterValue);
        }
        
    }
}

