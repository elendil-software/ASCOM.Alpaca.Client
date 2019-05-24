using System.Threading.Tasks;
using ES.AscomAlpaca.Client.Devices;
using ES.AscomAlpaca.Client.Request;
using ES.AscomAlpaca.Client.Responses;
using ES.AscomAlpaca.Responses;
using Moq;
using RestSharp;
using Xunit;

namespace ES.AscomAlpaca.Client.Test.Devices
{
    public class FocuserRequestTest : DeviceRequestsTestBase
    {
        private readonly DeviceConfiguration _deviceConfiguration = new DeviceConfiguration { DeviceNumber = 5 };
        private readonly ClientTransactionIdGenerator _clientTransactionIdGenerator = new ClientTransactionIdGenerator();
        protected override DeviceType DeviceType { get; } = DeviceType.Focuser;
        
        [Fact]
        public void IsAbsolute_SendValidRequest()
        {
            //Arrange
            string commandName = "absolute";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var focuser = new Focuser(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            focuser.IsAbsolute();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task IsAbsoluteAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "absolute";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var focuser = new Focuser(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await focuser.IsAbsoluteAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void IsMoving_SendValidRequest()
        {
            //Arrange
            string commandName = "ismoving";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var focuser = new Focuser(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            focuser.IsMoving();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task IsMovingAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "ismoving";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var focuser = new Focuser(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await focuser.IsMovingAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetMaxIncrement_SendValidRequest()
        {
            //Arrange
            string commandName = "maxincrement";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new IntResponse());
            var focuser = new Focuser(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            focuser.GetMaxIncrement();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetMaxIncrementAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "maxincrement";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new IntResponse()));
            var focuser = new Focuser(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await focuser.GetMaxIncrementAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetMaxStep_SendValidRequest()
        {
            //Arrange
            string commandName = "maxstep";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new IntResponse());
            var focuser = new Focuser(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            focuser.GetMaxStep();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetMaxStepAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "maxstep";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new IntResponse()));
            var focuser = new Focuser(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await focuser.GetMaxStepAsync();
            
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
            var focuser = new Focuser(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            focuser.GetPosition();
            
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
            var focuser = new Focuser(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await focuser.GetPositionAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetStepSize_SendValidRequest()
        {
            //Arrange
            string commandName = "stepsize";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var focuser = new Focuser(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            focuser.GetStepSize();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetStepSizeAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "stepsize";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var focuser = new Focuser(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await focuser.GetStepSizeAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void IsTempComp_SendValidRequest()
        {
            //Arrange
            string commandName = "tempcomp";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var focuser = new Focuser(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            focuser.IsTempComp();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task IsTempCompAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "tempcomp";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var focuser = new Focuser(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await focuser.IsTempCompAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void SetTempComp_SendValidRequest()
        {
            //Arrange
            string commandName = "tempcomp";
            string tempCompParameterName = "TempComp";
            bool tempCompParameterValue = true;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<CommandResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new CommandResponse());
            var focuser = new Focuser(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            focuser.SetTempComp(tempCompParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, tempCompParameterName, tempCompParameterValue);
        }
        
        [Fact]
        public async Task SetTempCompAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "tempcomp";
            string tempCompParameterName = "TempComp";
            bool tempCompParameterValue = true;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<CommandResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new CommandResponse()));
            var focuser = new Focuser(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await focuser.SetTempCompAsync(tempCompParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, tempCompParameterName, tempCompParameterValue);
        }
        
        [Fact]
        public void IsTempCompAvailable_SendValidRequest()
        {
            //Arrange
            string commandName = "tempcompavailable";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var focuser = new Focuser(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            focuser.IsTempCompAvailable();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task IsTempCompAvailableAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "tempcompavailable";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var focuser = new Focuser(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await focuser.IsTempCompAvailableAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetTemperature_SendValidRequest()
        {
            //Arrange
            string commandName = "temperature";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var focuser = new Focuser(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            focuser.GetTemperature();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetTemperatureAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "temperature";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var focuser = new Focuser(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await focuser.GetTemperatureAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void Halt_SendValidRequest()
        {
            //Arrange
            string commandName = "halt";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<CommandResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new CommandResponse());
            var focuser = new Focuser(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            focuser.Halt();
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task HaltAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "halt";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<CommandResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new CommandResponse()));
            var focuser = new Focuser(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await focuser.HaltAsync();
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void Move_SendValidRequest()
        {
            //Arrange
            string commandName = "move";
            string positionParameterName = "Position";
            int positionParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<CommandResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new CommandResponse());
            var focuser = new Focuser(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            focuser.Move(positionParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, positionParameterName, positionParameterValue);
        }
        
        [Fact]
        public async Task MoveAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "move";
            string positionParameterName = "Position";
            int positionParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<CommandResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new CommandResponse()));
            var focuser = new Focuser(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await focuser.MoveAsync(positionParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, positionParameterName, positionParameterValue);
        }
        
    }
}

