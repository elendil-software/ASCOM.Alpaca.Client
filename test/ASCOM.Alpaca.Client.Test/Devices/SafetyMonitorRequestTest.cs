using System.Threading.Tasks;
using AscomAlpacaClient.Devices;
using AscomAlpacaClient.Request;
using AscomAlpacaClient.Responses;
using AscomAlpacaClient.Transactions;
using Moq;
using RestSharp;
using Xunit;

namespace AscomAlpacaClient.Test.Devices
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
                .Returns(new BoolResponse());
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
                .Returns(Task.FromResult(new BoolResponse()));
            var safetyMonitor = new SafetyMonitor(_deviceConfiguration, commandSenderMock.Object);

            //Act
            await safetyMonitor.IsSafeAsync();

            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }

    }
}

