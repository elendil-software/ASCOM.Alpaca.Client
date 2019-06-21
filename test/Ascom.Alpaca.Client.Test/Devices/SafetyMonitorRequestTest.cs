using System.Threading.Tasks;
using ES.Ascom.Alpaca.Client.Devices;
using ES.Ascom.Alpaca.Client.Request;
using ES.Ascom.Alpaca.Responses;
using Moq;
using RestSharp;
using Xunit;

namespace ES.Ascom.Alpaca.Client.Test.Devices
{
    public class SafetyMonitorRequestTest : DeviceRequestsTestBase
    {
        private readonly DeviceConfiguration _deviceConfiguration = new DeviceConfiguration { DeviceNumber = 5 };
        private readonly ClientTransactionIdGenerator _clientTransactionIdGenerator = new ClientTransactionIdGenerator();
        protected override DeviceType DeviceType { get; } = DeviceType.SafetyMonitor;
        
        [Fact]
        public void IsSafe_SendValidRequest()
        {
            //Arrange
            string commandName = "issafe";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new BoolResponse(false));
            var safetyMonitor = new SafetyMonitor(_deviceConfiguration, commandSenderMock.Object);

            //Act
            safetyMonitor.IsSafe();

            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }

        [Fact]
        public async Task IsSafeAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "issafe";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse(false)));
            var safetyMonitor = new SafetyMonitor(_deviceConfiguration, commandSenderMock.Object);

            //Act
            await safetyMonitor.IsSafeAsync();

            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }

    }
}

