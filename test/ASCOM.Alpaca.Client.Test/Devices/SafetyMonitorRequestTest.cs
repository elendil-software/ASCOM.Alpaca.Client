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
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var safetyMonitor = new SafetyMonitor(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);

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
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var safetyMonitor = new SafetyMonitor(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);

            //Act
            await safetyMonitor.IsSafeAsync();

            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }

    }
}

