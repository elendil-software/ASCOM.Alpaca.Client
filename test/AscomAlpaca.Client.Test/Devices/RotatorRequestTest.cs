using System.Threading.Tasks;
using ES.AscomAlpaca.Client.Devices;
using ES.AscomAlpaca.Client.Request;
using ES.AscomAlpaca.Responses;
using Moq;
using RestSharp;
using Xunit;

namespace ES.AscomAlpaca.Client.Test.Devices
{
    public class RotatorRequestTest : DeviceRequestsTestBase
    {
        private readonly DeviceConfiguration _deviceConfiguration = new DeviceConfiguration { DeviceNumber = 5 };
        private readonly ClientTransactionIdGenerator _clientTransactionIdGenerator = new ClientTransactionIdGenerator();
        protected override DeviceType DeviceType { get; } = DeviceType.Rotator;
        
        [Fact]
        public void CanReverse_SendValidRequest()
        {
            //Arrange
            string commandName = "canreverse";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new BoolResponse(false));
            var rotator = new Rotator(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            rotator.CanReverse();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task CanReverseAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "canreverse";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse(false)));
            var rotator = new Rotator(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await rotator.CanReverseAsync();
            
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
                .Returns(new BoolResponse(false));
            var rotator = new Rotator(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            rotator.IsMoving();
            
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
                .Returns(Task.FromResult(new BoolResponse(false)));
            var rotator = new Rotator(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await rotator.IsMovingAsync();
            
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
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse(1.0));
            var rotator = new Rotator(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            rotator.GetPosition();
            
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
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse(1.0)));
            var rotator = new Rotator(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await rotator.GetPositionAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void IsReversed_SendValidRequest()
        {
            //Arrange
            string commandName = "reverse";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new BoolResponse(false));
            var rotator = new Rotator(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            rotator.IsReversed();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task IsReversedAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "reverse";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse(false)));
            var rotator = new Rotator(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await rotator.IsReversedAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void SetReversed_SendValidRequest()
        {
            //Arrange
            string commandName = "reverse";
            string reversedParameterName = "Reverse";
            bool reversedParameterValue = true;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<CommandResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new CommandResponse());
            var rotator = new Rotator(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            rotator.SetReversed(reversedParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, reversedParameterName, reversedParameterValue);
        }
        
        [Fact]
        public async Task SetReversedAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "reverse";
            string reversedParameterName = "Reverse";
            bool reversedParameterValue = true;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<CommandResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new CommandResponse()));
            var rotator = new Rotator(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await rotator.SetReversedAsync(reversedParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, reversedParameterName, reversedParameterValue);
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
                .Returns(new DoubleResponse(1.0));
            var rotator = new Rotator(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            rotator.GetStepSize();
            
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
                .Returns(Task.FromResult(new DoubleResponse(1.0)));
            var rotator = new Rotator(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await rotator.GetStepSizeAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetTargetPosition_SendValidRequest()
        {
            //Arrange
            string commandName = "targetposition";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse(1.0));
            var rotator = new Rotator(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            rotator.GetTargetPosition();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetTargetPositionAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "targetposition";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse(1.0)));
            var rotator = new Rotator(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await rotator.GetTargetPositionAsync();
            
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
            var rotator = new Rotator(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            rotator.Halt();
            
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
            var rotator = new Rotator(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await rotator.HaltAsync();
            
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
            double positionParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<CommandResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new CommandResponse());
            var rotator = new Rotator(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            rotator.Move(positionParameterValue);
            
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
            double positionParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<CommandResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new CommandResponse()));
            var rotator = new Rotator(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await rotator.MoveAsync(positionParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, positionParameterName, positionParameterValue);
        }
        
        [Fact]
        public void MoveAbsolute_SendValidRequest()
        {
            //Arrange
            string commandName = "moveabsolute";
            string positionParameterName = "Position";
            double positionParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<CommandResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new CommandResponse());
            var rotator = new Rotator(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            rotator.MoveAbsolute(positionParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, positionParameterName, positionParameterValue);
        }
        
        [Fact]
        public async Task MoveAbsoluteAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "moveabsolute";
            string positionParameterName = "Position";
            double positionParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<CommandResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new CommandResponse()));
            var rotator = new Rotator(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await rotator.MoveAbsoluteAsync(positionParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, positionParameterName, positionParameterValue);
        }
        
    }
}

