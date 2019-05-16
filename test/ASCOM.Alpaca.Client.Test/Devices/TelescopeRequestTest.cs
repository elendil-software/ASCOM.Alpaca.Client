using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using ASCOM.Alpaca.Client.Devices;
using ASCOM.Alpaca.Client.Exceptions;
using ASCOM.Alpaca.Client.Request;
using ASCOM.Alpaca.Client.Transactions;
using ASCOM.Alpaca.Devices;
using ASCOM.Alpaca.Devices.Telescope;
using ASCOM.Alpaca.Responses;
using Moq;
using RestSharp;
using Xunit;

namespace ASCOM.Alpaca.Client.Test.Devices
{
    public class TelescopeRequestTest : DeviceRequestsTestBase
    {
        private readonly DeviceConfiguration _deviceConfiguration = new DeviceConfiguration { DeviceNumber = 5 };
        private readonly ClientTransactionIdGenerator _clientTransactionIdGenerator = new ClientTransactionIdGenerator();
        protected override DeviceType DeviceType { get; } = DeviceType.Telescope;
        
        [Fact]
        public void GetAlignmentMode_SendValidRequest()
        {
            //Arrange
            string commandName = "alignmentmode";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<AlignmentModeResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new AlignmentModeResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.GetAlignmentMode();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetAlignmentModeAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "alignmentmode"; 
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<AlignmentModeResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new AlignmentModeResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.GetAlignmentModeAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetAltitude_SendValidRequest()
        {
            //Arrange
            string commandName = "altitude";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.GetAltitude();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetAltitudeAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "altitude";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.GetAltitudeAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetApertureArea_SendValidRequest()
        {
            //Arrange
            string commandName = "aperturearea";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.GetApertureArea();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetApertureAreaAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "aperturearea";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.GetApertureAreaAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetApertureDiameter_SendValidRequest()
        {
            //Arrange
            string commandName = "aperturediameter";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.GetApertureDiameter();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetApertureDiameterAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "aperturediameter";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.GetApertureDiameterAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void IsAtHome_SendValidRequest()
        {
            //Arrange
            string commandName = "athome";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.IsAtHome();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task IsAtHomeAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "athome";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.IsAtHomeAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void IsAtPark_SendValidRequest()
        {
            //Arrange
            string commandName = "atpark";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.IsAtPark();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task IsAtParkAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "atpark";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.IsAtParkAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetAzimuth_SendValidRequest()
        {
            //Arrange
            string commandName = "azimuth";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.GetAzimuth();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetAzimuthAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "azimuth";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.GetAzimuthAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void CanFindHome_SendValidRequest()
        {
            //Arrange
            string commandName = "canfindhome";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.CanFindHome();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task CanFindHomeAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "canfindhome";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.CanFindHomeAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void CanPark_SendValidRequest()
        {
            //Arrange
            string commandName = "canpark";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.CanPark();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task CanParkAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "canpark";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.CanParkAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void CanPulseGuide_SendValidRequest()
        {
            //Arrange
            string commandName = "canpulseguide";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.CanPulseGuide();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task CanPulseGuideAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "canpulseguide";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.CanPulseGuideAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void CanSetDeclinationRate_SendValidRequest()
        {
            //Arrange
            string commandName = "cansetdeclinationrate";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.CanSetDeclinationRate();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task CanSetDeclinationRateAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "cansetdeclinationrate";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.CanSetDeclinationRateAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void CanSetGuideRates_SendValidRequest()
        {
            //Arrange
            string commandName = "cansetguiderates";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.CanSetGuideRates();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task CanSetGuideRatesAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "cansetguiderates";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.CanSetGuideRatesAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void CanSetPark_SendValidRequest()
        {
            //Arrange
            string commandName = "cansetpark";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.CanSetPark();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task CanSetParkAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "cansetpark";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.CanSetParkAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void CanSetPierSide_SendValidRequest()
        {
            //Arrange
            string commandName = "cansetpierside";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.CanSetPierSide();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task CanSetPierSideAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "cansetpierside";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.CanSetPierSideAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void CanSetRightAscensionRate_SendValidRequest()
        {
            //Arrange
            string commandName = "cansetrightascensionrate";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.CanSetRightAscensionRate();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task CanSetRightAscensionRateAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "cansetrightascensionrate";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.CanSetRightAscensionRateAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void CanSetTracking_SendValidRequest()
        {
            //Arrange
            string commandName = "cansettracking";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.CanSetTracking();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task CanSetTrackingAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "cansettracking";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.CanSetTrackingAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void CanSlew_SendValidRequest()
        {
            //Arrange
            string commandName = "canslew";
            string commandNameAsync = "canslewasync";
            List<IRestRequest> sentRequests = new List<IRestRequest>();
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequests.Add(request))
                .Returns(new BoolResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.CanSlew();
            
            //Assert
            Assert.Equal(Method.GET, sentRequests[0].Method);
            AssertCommonParameters(sentRequests[0].Parameters, _deviceConfiguration, commandName);
            Assert.Equal(Method.GET, sentRequests[1].Method);
            AssertCommonParameters(sentRequests[1].Parameters, _deviceConfiguration, commandNameAsync);
        }
        
        [Fact]
        public async Task CanSlewAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "canslew";
            string commandNameAsync = "canslewasync";
            List<IRestRequest> sentRequests = new List<IRestRequest>();
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequests.Add(request))
                .Returns(Task.FromResult(new BoolResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.CanSlewAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequests[0].Method);
            AssertCommonParameters(sentRequests[0].Parameters, _deviceConfiguration, commandName);
            Assert.Equal(Method.GET, sentRequests[1].Method);
            AssertCommonParameters(sentRequests[1].Parameters, _deviceConfiguration, commandNameAsync);
        }
        
        [Fact]
        public void CanSlewAltAz_SendValidRequest()
        {
            //Arrange
            string commandName = "canslewaltaz";
            string commandNameAsync = "canslewaltazasync";
            List<IRestRequest> sentRequests = new List<IRestRequest>();
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequests.Add(request))
                .Returns(new BoolResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.CanSlewAltAz();
            
            //Assert
            Assert.Equal(Method.GET, sentRequests[0].Method);
            AssertCommonParameters(sentRequests[0].Parameters, _deviceConfiguration, commandName);
            Assert.Equal(Method.GET, sentRequests[1].Method);
            AssertCommonParameters(sentRequests[1].Parameters, _deviceConfiguration, commandNameAsync);
        }
        
        [Fact]
        public async Task CanSlewAltAzAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "canslewaltaz";
            string commandNameAsync = "canslewaltazasync";
            List<IRestRequest> sentRequests = new List<IRestRequest>();
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequests.Add(request))
                .Returns(Task.FromResult(new BoolResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.CanSlewAltAzAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequests[0].Method);
            AssertCommonParameters(sentRequests[0].Parameters, _deviceConfiguration, commandName);
            Assert.Equal(Method.GET, sentRequests[1].Method);
            AssertCommonParameters(sentRequests[1].Parameters, _deviceConfiguration, commandNameAsync);
        }

        [Fact]
        public void CanSync_SendValidRequest()
        {
            //Arrange
            string commandName = "cansync";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.CanSync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task CanSyncAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "cansync";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.CanSyncAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void CanSyncAltAz_SendValidRequest()
        {
            //Arrange
            string commandName = "cansyncaltaz";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.CanSyncAltAz();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task CanSyncAltAzAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "cansyncaltaz";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.CanSyncAltAzAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetDeclination_SendValidRequest()
        {
            //Arrange
            string commandName = "declination";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.GetDeclination();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetDeclinationAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "declination";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.GetDeclinationAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetDeclinationRate_SendValidRequest()
        {
            //Arrange
            string commandName = "declinationrate";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.GetDeclinationRate();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetDeclinationRateAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "declinationrate";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.GetDeclinationRateAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void SetDeclinationRate_SendValidRequest()
        {
            //Arrange
            string commandName = "declinationrate";
            string declinationRateParameterName = "DeclinationRate";
            double declinationRateParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.SetDeclinationRate(declinationRateParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, declinationRateParameterName, declinationRateParameterValue);
        }
        
        [Fact]
        public async Task SetDeclinationRateAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "declinationrate";
            string declinationRateParameterName = "DeclinationRate";
            double declinationRateParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.SetDeclinationRateAsync(declinationRateParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, declinationRateParameterName, declinationRateParameterValue);
        }
        
        [Fact]
        public void DoesRefraction_SendValidRequest()
        {
            //Arrange
            string commandName = "doesrefraction";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.DoesRefraction();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task DoesRefractionAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "doesrefraction";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.DoesRefractionAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void SetDoesRefraction_SendValidRequest()
        {
            //Arrange
            string commandName = "doesrefraction";
            string doesRefractionParameterName = "DoesRefraction";
            bool doesRefractionParameterValue = true;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.SetDoesRefraction(doesRefractionParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, doesRefractionParameterName, doesRefractionParameterValue);
        }
        
        [Fact]
        public async Task SetDoesRefractionAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "doesrefraction";
            string doesRefractionParameterName = "DoesRefraction";
            bool doesRefractionParameterValue = true;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.SetDoesRefractionAsync(doesRefractionParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, doesRefractionParameterName, doesRefractionParameterValue);
        }
        
        [Fact]
        public void GetEquatorialSystem_SendValidRequest()
        {
            //Arrange
            string commandName = "equatorialsystem";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<EquatorialCoordinateTypeResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new EquatorialCoordinateTypeResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.GetEquatorialSystem();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetEquatorialSystemAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "equatorialsystem";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<EquatorialCoordinateTypeResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new EquatorialCoordinateTypeResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.GetEquatorialSystemAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetFocalLength_SendValidRequest()
        {
            //Arrange
            string commandName = "focallength";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.GetFocalLength();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetFocalLengthAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "focallength";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.GetFocalLengthAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetGuideRateDeclination_SendValidRequest()
        {
            //Arrange
            string commandName = "guideratedeclination";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.GetGuideRateDeclination();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetGuideRateDeclinationAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "guideratedeclination";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.GetGuideRateDeclinationAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void SetGuideRateDeclination_SendValidRequest()
        {
            //Arrange
            string commandName = "guideratedeclination";
            string guideRateParameterName = "GuideRateDeclination";
            double guideRateParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.SetGuideRateDeclination(guideRateParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, guideRateParameterName, guideRateParameterValue);
        }
        
        [Fact]
        public async Task SetGuideRateDeclinationAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "guideratedeclination";
            string guideRateParameterName = "GuideRateDeclination";
            double guideRateParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.SetGuideRateDeclinationAsync(guideRateParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, guideRateParameterName, guideRateParameterValue);
        }
        
        [Fact]
        public void GetGuideRateRightAscension_SendValidRequest()
        {
            //Arrange
            string commandName = "guideraterightascension";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.GetGuideRateRightAscension();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetGuideRateRightAscensionAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "guideraterightascension";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.GetGuideRateRightAscensionAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void SetGuideRateRightAscension_SendValidRequest()
        {
            //Arrange
            string commandName = "guideraterightascension";
            string guideRateParameterName = "GuideRateRightAscension";
            double guideRateParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.SetGuideRateRightAscension(guideRateParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, guideRateParameterName, guideRateParameterValue);
        }
        
        [Fact]
        public async Task SetGuideRateRightAscensionAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "guideraterightascension";
            string guideRateParameterName = "GuideRateRightAscension";
            double guideRateParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.SetGuideRateRightAscensionAsync(guideRateParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, guideRateParameterName, guideRateParameterValue);
        }
        
        [Fact]
        public void IsPulseGuiding_SendValidRequest()
        {
            //Arrange
            string commandName = "ispulseguiding";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.IsPulseGuiding();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task IsPulseGuidingAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "ispulseguiding";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.IsPulseGuidingAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetRightAscension_SendValidRequest()
        {
            //Arrange
            string commandName = "rightascension";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.GetRightAscension();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetRightAscensionAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "rightascension";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.GetRightAscensionAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetRightAscensionRate_SendValidRequest()
        {
            //Arrange
            string commandName = "rightascensionrate";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.GetRightAscensionRate();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetRightAscensionRateAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "rightascensionrate";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.GetRightAscensionRateAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void SetRightAscensionRate_SendValidRequest()
        {
            //Arrange
            string commandName = "rightascensionrate";
            string rightAscensionRateParameterName = "RightAscensionRate";
            double rightAscensionRateParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.SetRightAscensionRate(rightAscensionRateParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, rightAscensionRateParameterName, rightAscensionRateParameterValue);
        }
        
        [Fact]
        public async Task SetRightAscensionRateAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "rightascensionrate";
            string rightAscensionRateParameterName = "RightAscensionRate";
            double rightAscensionRateParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.SetRightAscensionRateAsync(rightAscensionRateParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, rightAscensionRateParameterName, rightAscensionRateParameterValue);
        }
        
        [Fact]
        public void GetSideOfPier_SendValidRequest()
        {
            //Arrange
            string commandName = "sideofpier";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<PierSideResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new PierSideResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.GetSideOfPier();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetSideOfPierAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "sideofpier";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<PierSideResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new PierSideResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.GetSideOfPierAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void SetSideOfPier_SendValidRequest()
        {
            //Arrange
            string commandName = "sideofpier";
            string sideOfPierParameterName = "SideOfPier";
            PierSide sideOfPierParameterValue = PierSide.West;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.SetSideOfPier(sideOfPierParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertEnumParameter(sentRequest.Parameters, sideOfPierParameterName, sideOfPierParameterValue);
        }
        
        [Fact]
        public async Task SetSideOfPierAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "sideofpier";
            string sideOfPierParameterName = "SideOfPier";
            PierSide sideOfPierParameterValue = PierSide.West;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.SetSideOfPierAsync(sideOfPierParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertEnumParameter(sentRequest.Parameters, sideOfPierParameterName, sideOfPierParameterValue);
        }
        
        [Fact]
        public void GetSiderealTime_SendValidRequest()
        {
            //Arrange
            string commandName = "siderealtime";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.GetSiderealTime();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetSiderealTimeAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "siderealtime";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.GetSiderealTimeAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetSiteElevation_SendValidRequest()
        {
            //Arrange
            string commandName = "siteelevation";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.GetSiteElevation();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetSiteElevationAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "siteelevation";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.GetSiteElevationAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void SetSiteElevation_SendValidRequest()
        {
            //Arrange
            string commandName = "siteelevation";
            string siteElevationParameterName = "SiteElevation";
            double siteElevationParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.SetSiteElevation(siteElevationParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, siteElevationParameterName, siteElevationParameterValue);
        }
        
        [Fact]
        public async Task SetSiteElevationAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "siteelevation";
            string siteElevationParameterName = "SiteElevation";
            double siteElevationParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.SetSiteElevationAsync(siteElevationParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, siteElevationParameterName, siteElevationParameterValue);
        }
        
        [Fact]
        public void GetSiteLatitude_SendValidRequest()
        {
            //Arrange
            string commandName = "sitelatitude";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.GetSiteLatitude();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetSiteLatitudeAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "sitelatitude";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.GetSiteLatitudeAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void SetSiteLatitude_SendValidRequest()
        {
            //Arrange
            string commandName = "sitelatitude";
            string latitudeParameterName = "SiteLatitude";
            double latitudeParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.SetSiteLatitude(latitudeParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, latitudeParameterName, latitudeParameterValue);
        }
        
        [Fact]
        public async Task SetSiteLatitudeAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "sitelatitude";
            string latitudeParameterName = "SiteLatitude";
            double latitudeParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.SetSiteLatitudeAsync(latitudeParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, latitudeParameterName, latitudeParameterValue);
        }
        
        [Fact]
        public void GetSiteLongitude_SendValidRequest()
        {
            //Arrange
            string commandName = "sitelongitude";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.GetSiteLongitude();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetSiteLongitudeAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "sitelongitude";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.GetSiteLongitudeAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void SetSiteLongitude_SendValidRequest()
        {
            //Arrange
            string commandName = "sitelongitude";
            string longitudeParameterName = "SiteLongitude";
            double longitudeParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.SetSiteLongitude(longitudeParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, longitudeParameterName, longitudeParameterValue);
        }
        
        [Fact]
        public async Task SetSiteLongitudeAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "sitelongitude";
            string longitudeParameterName = "SiteLongitude";
            double longitudeParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.SetSiteLongitudeAsync(longitudeParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, longitudeParameterName, longitudeParameterValue);
        }
        
        [Fact]
        public void IsSlewing_SendValidRequest()
        {
            //Arrange
            string commandName = "slewing";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.IsSlewing();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task IsSlewingAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "slewing";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.IsSlewingAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetSlewSettleTime_SendValidRequest()
        {
            //Arrange
            string commandName = "slewsettletime";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new IntResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.GetSlewSettleTime();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetSlewSettleTimeAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "slewsettletime";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new IntResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.GetSlewSettleTimeAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void SetSlewSettleTime_SendValidRequest()
        {
            //Arrange
            string commandName = "slewsettletime";
            string settleTimeParameterName = "SlewSettleTime";
            int settleTimeParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.SetSlewSettleTime(settleTimeParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, settleTimeParameterName, settleTimeParameterValue);
        }
        
        [Fact]
        public async Task SetSlewSettleTimeAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "slewsettletime";
            string settleTimeParameterName = "SlewSettleTime";
            int settleTimeParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.SetSlewSettleTimeAsync(settleTimeParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, settleTimeParameterName, settleTimeParameterValue);
        }
        
        [Fact]
        public void GetTargetDeclination_SendValidRequest()
        {
            //Arrange
            string commandName = "targetdeclination";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.GetTargetDeclination();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetTargetDeclinationAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "targetdeclination";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.GetTargetDeclinationAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void SetTargetDeclination_SendValidRequest()
        {
            //Arrange
            string commandName = "targetdeclination";
            string declinationParameterName = "TargetDeclination";
            double declinationParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.SetTargetDeclination(declinationParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, declinationParameterName, declinationParameterValue);
        }
        
        [Fact]
        public async Task SetTargetDeclinationAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "targetdeclination";
            string declinationParameterName = "TargetDeclination";
            double declinationParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.SetTargetDeclinationAsync(declinationParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, declinationParameterName, declinationParameterValue);
        }
        
        [Fact]
        public void GetTargetRightAscension_SendValidRequest()
        {
            //Arrange
            string commandName = "targetrightascension";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.GetTargetRightAscension();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetTargetRightAscensionAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "targetrightascension";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.GetTargetRightAscensionAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void SetTargetRightAscension_SendValidRequest()
        {
            //Arrange
            string commandName = "targetrightascension";
            string rightAscensionParameterName = "TargetRightAscension";
            double rightAscensionParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.SetTargetRightAscension(rightAscensionParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, rightAscensionParameterName, rightAscensionParameterValue);
        }
        
        [Fact]
        public async Task SetTargetRightAscensionAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "targetrightascension";
            string rightAscensionParameterName = "TargetRightAscension";
            double rightAscensionParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.SetTargetRightAscensionAsync(rightAscensionParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, rightAscensionParameterName, rightAscensionParameterValue);
        }
        
        [Fact]
        public void IsTracking_SendValidRequest()
        {
            //Arrange
            string commandName = "tracking";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.IsTracking();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task IsTrackingAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "tracking";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.IsTrackingAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void SetTracking_SendValidRequest()
        {
            //Arrange
            string commandName = "tracking";
            string trackingParameterName = "Tracking";
            bool trackingParameterValue = true;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.SetTracking(trackingParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, trackingParameterName, trackingParameterValue);
        }
        
        [Fact]
        public async Task SetTrackingAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "tracking";
            string trackingParameterName = "Tracking";
            bool trackingParameterValue = true;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.SetTrackingAsync(trackingParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, trackingParameterName, trackingParameterValue);
        }
        
        [Fact]
        public void GetTrackingRate_SendValidRequest()
        {
            //Arrange
            string commandName = "trackingrate";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DriveRateResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DriveRateResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.GetTrackingRate();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetTrackingRateAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "trackingrate";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DriveRateResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DriveRateResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.GetTrackingRateAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void SetTrackingRate_SendValidRequest()
        {
            //Arrange
            string commandName = "trackingrate";
            string trackingRateParameterName = "TrackingRate";
            DriveRate trackingRateParameterValue = DriveRate.DriveSidereal;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.SetTrackingRate(trackingRateParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertEnumParameter(sentRequest.Parameters, trackingRateParameterName, trackingRateParameterValue);
        }
        
        [Fact]
        public async Task SetTrackingRateAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "trackingrate";
            string trackingRateParameterName = "TrackingRate";
            DriveRate trackingRateParameterValue = DriveRate.DriveSidereal;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.SetTrackingRateAsync(trackingRateParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertEnumParameter(sentRequest.Parameters, trackingRateParameterName, trackingRateParameterValue);
        }
        
        [Fact]
        public void GetTrackingRates_SendValidRequest()
        {
            //Arrange
            string commandName = "trackingrates";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DriveRatesResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DriveRatesResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.GetTrackingRates();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetTrackingRatesAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "trackingrates";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DriveRatesResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DriveRatesResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.GetTrackingRatesAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetUtcDate_SendValidRequest()
        {
            //Arrange
            string commandName = "utcdate";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<StringResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new StringResponse { Value = "2019-04-26T16:02:33" });
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.GetUtcDate();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetUtcDateAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "utcdate";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<StringResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new StringResponse { Value = "2019-04-26T16:02:33" }));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.GetUtcDateAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void SetUtcDate_SendValidRequest()
        {
            //Arrange
            string commandName = "utcdate";
            string utcDateParameterName = "UTCDate";
            DateTime utcDateParameterValue = DateTime.Now.ToUniversalTime();
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.SetUtcDate(utcDateParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, utcDateParameterName, utcDateParameterValue.ToString("yyyy-MM-dd'T'HH:mm:ss.fffK", CultureInfo.InvariantCulture));
        }
        
        [Fact]
        public async Task SetUtcDateAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "utcdate";
            string utcDateParameterName = "UTCDate";
            DateTime utcDateParameterValue = DateTime.Now;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.SetUtcDateAsync(utcDateParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, utcDateParameterName, utcDateParameterValue.ToString("yyyy-MM-dd'T'HH:mm:ss.fffK", CultureInfo.InvariantCulture));
        }
        
        [Fact]
        public void AbortSlew_SendValidRequest()
        {
            //Arrange
            string commandName = "abortslew";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.AbortSlew();
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task AbortSlewAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "abortslew";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.AbortSlewAsync();
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetAxisRates_SendValidRequest()
        {
            //Arrange
            string commandName = "axisrates";
            string axisParameterName = "Axis";
            TelescopeAxis axisParameterValue = TelescopeAxis.Secondary;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<AxisRatesResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new AxisRatesResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.GetAxisRates(axisParameterValue);
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertEnumParameter(sentRequest.Parameters, axisParameterName, axisParameterValue);
        }
        
        [Fact]
        public async Task GetAxisRatesAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "axisrates";
            string axisParameterName = "Axis";
            TelescopeAxis axisParameterValue = TelescopeAxis.Secondary;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<AxisRatesResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new AxisRatesResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.GetAxisRatesAsync(axisParameterValue);
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertEnumParameter(sentRequest.Parameters, axisParameterName, axisParameterValue);
        }
        
        [Fact]
        public void CanMoveAxis_SendValidRequest()
        {
            //Arrange
            string commandName = "canmoveaxis";
            string axisParameterName = "Axis";
            TelescopeAxis axisParameterValue = TelescopeAxis.Secondary;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.CanMoveAxis(axisParameterValue);
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertEnumParameter(sentRequest.Parameters, axisParameterName, axisParameterValue);
        }
        
        [Fact]
        public async Task CanMoveAxisAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "canmoveaxis";
            string axisParameterName = "Axis";
            TelescopeAxis axisParameterValue = TelescopeAxis.Secondary;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.CanMoveAxisAsync(axisParameterValue);
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertEnumParameter(sentRequest.Parameters, axisParameterName, axisParameterValue);
        }
        
        [Fact]
        public void GetDestinationSideOfPier_SendValidRequest()
        {
            //Arrange
            string commandName = "destinationsideofpier";
            string rightAscensionParameterName = "RightAscension";
            double rightAscensionParameterValue = 2;
            string declinationParameterName = "Declination";
            double declinationParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<PierSideResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new PierSideResponse());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.GetDestinationSideOfPier(rightAscensionParameterValue, declinationParameterValue);
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, rightAscensionParameterName, rightAscensionParameterValue);
            AssertParameter(sentRequest.Parameters, declinationParameterName, declinationParameterValue);
        }
        
        [Fact]
        public async Task GetDestinationSideOfPierAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "destinationsideofpier";
            string rightAscensionParameterName = "RightAscension";
            double rightAscensionParameterValue = 2;
            string declinationParameterName = "Declination";
            double declinationParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<PierSideResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new PierSideResponse()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.GetDestinationSideOfPierAsync(rightAscensionParameterValue, declinationParameterValue);
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, rightAscensionParameterName, rightAscensionParameterValue);
            AssertParameter(sentRequest.Parameters, declinationParameterName, declinationParameterValue);
        }
        
        [Fact]
        public void FindHome_SendValidRequest()
        {
            //Arrange
            string commandName = "findhome";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.FindHome();
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task FindHomeAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "findhome";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.FindHomeAsync();
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void MoveAxis_SendValidRequest()
        {
            //Arrange
            string commandName = "moveaxis";
            string axisParameterName = "Axis";
            TelescopeAxis axisParameterValue = TelescopeAxis.Secondary;
            string rateParameterName = "Rate";
            double rateParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.MoveAxis(axisParameterValue, rateParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertEnumParameter(sentRequest.Parameters, axisParameterName, axisParameterValue);
            AssertParameter(sentRequest.Parameters, rateParameterName, rateParameterValue);
        }
        
        [Fact]
        public async Task MoveAxisAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "moveaxis";
            string axisParameterName = "Axis";
            TelescopeAxis axisParameterValue = TelescopeAxis.Secondary;
            string rateParameterName = "Rate";
            double rateParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.MoveAxisAsync(axisParameterValue, rateParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertEnumParameter(sentRequest.Parameters, axisParameterName, axisParameterValue);
            AssertParameter(sentRequest.Parameters, rateParameterName, rateParameterValue);
        }
        
        [Fact]
        public void Park_SendValidRequest()
        {
            //Arrange
            string commandName = "park";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.Park();
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task ParkAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "park";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.ParkAsync();
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void PulseGuide_SendValidRequest()
        {
            //Arrange
            string commandName = "pulseguide";
            string directionParameterName = "Direction";
            GuideDirection directionParameterValue = GuideDirection.West;
            string durationParameterName = "Duration";
            int durationParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.PulseGuide(directionParameterValue, durationParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertEnumParameter(sentRequest.Parameters, directionParameterName, directionParameterValue);
            AssertParameter(sentRequest.Parameters, durationParameterName, durationParameterValue);
        }
        
        [Fact]
        public async Task PulseGuideAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "pulseguide";
            string directionParameterName = "Direction";
            GuideDirection directionParameterValue = GuideDirection.West;
            string durationParameterName = "Duration";
            int durationParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.PulseGuideAsync(directionParameterValue, durationParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertEnumParameter(sentRequest.Parameters, directionParameterName, directionParameterValue);
            AssertParameter(sentRequest.Parameters, durationParameterName, durationParameterValue);
        }
        
        [Fact]
        public void SetPark_SendValidRequest()
        {
            //Arrange
            string commandName = "setpark";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.SetPark();
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task SetParkAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "setpark";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.SetParkAsync();
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void SlewToAltAz_SendValidRequest()
        {
            //Arrange
            string commandName = "slewtoaltaz";
            string commandNameAsync = "slewtoaltazasync";
            string altitudeParameterName = "Altitude";
            double altitudeParameterValue = 2;
            string azimuthParameterName = "Azimuth";
            double azimuthParameterValue = 2;
            List<IRestRequest> sentRequests = new List<IRestRequest>();
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequests.Add(request))
                .ReturnsInOrder(new Response { ErrorNumber = ErrorCodes.NotImplemented }, new Response());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.SlewToAltAz(altitudeParameterValue, azimuthParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequests[0].Method);
            AssertCommonParameters(sentRequests[0].Parameters, _deviceConfiguration, commandNameAsync);
            AssertParameter(sentRequests[0].Parameters, altitudeParameterName, altitudeParameterValue);
            AssertParameter(sentRequests[0].Parameters, azimuthParameterName, azimuthParameterValue);
            Assert.Equal(Method.PUT, sentRequests[1].Method);
            AssertCommonParameters(sentRequests[1].Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequests[1].Parameters, altitudeParameterName, altitudeParameterValue);
            AssertParameter(sentRequests[1].Parameters, azimuthParameterName, azimuthParameterValue);
        }

        [Fact]
        public async Task SlewToAltAzAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "slewtoaltaz";
            string commandNameAsync = "slewtoaltazasync";
            string altitudeParameterName = "Altitude";
            double altitudeParameterValue = 2;
            string azimuthParameterName = "Azimuth";
            double azimuthParameterValue = 2;
            List<IRestRequest> sentRequests = new List<IRestRequest>();
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequests.Add(request))
                .ReturnsInOrder(Task.FromResult(new Response { ErrorNumber = ErrorCodes.NotImplemented }), Task.FromResult(new Response()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);

            //Act
            await telescope.SlewToAltAzAsync(altitudeParameterValue, azimuthParameterValue);

            //Assert
            Assert.Equal(Method.PUT, sentRequests[0].Method);
            AssertCommonParameters(sentRequests[0].Parameters, _deviceConfiguration, commandNameAsync);
            AssertParameter(sentRequests[0].Parameters, altitudeParameterName, altitudeParameterValue);
            AssertParameter(sentRequests[0].Parameters, azimuthParameterName, azimuthParameterValue);
            Assert.Equal(Method.PUT, sentRequests[1].Method);
            AssertCommonParameters(sentRequests[1].Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequests[1].Parameters, altitudeParameterName, altitudeParameterValue);
            AssertParameter(sentRequests[1].Parameters, azimuthParameterName, azimuthParameterValue);
        }

        [Fact]
        public void SlewToCoordinates_SendValidRequest()
        {
            //Arrange
            string commandName = "slewtocoordinates";
            string commandNameAsync = "slewtocoordinatesasync";
            string rightAscensionParameterName = "RightAscension";
            double rightAscensionParameterValue = 2;
            string declinationParameterName = "Declination";
            double declinationParameterValue = 2;
            List<IRestRequest> sentRequests = new List<IRestRequest>();
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequests.Add(request))
                .ReturnsInOrder(new Response { ErrorNumber = ErrorCodes.NotImplemented }, new Response());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.SlewToCoordinates(rightAscensionParameterValue, declinationParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequests[0].Method);
            AssertCommonParameters(sentRequests[0].Parameters, _deviceConfiguration, commandNameAsync);
            AssertParameter(sentRequests[0].Parameters, rightAscensionParameterName, rightAscensionParameterValue);
            AssertParameter(sentRequests[0].Parameters, declinationParameterName, declinationParameterValue);
            Assert.Equal(Method.PUT, sentRequests[1].Method);
            AssertCommonParameters(sentRequests[1].Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequests[1].Parameters, rightAscensionParameterName, rightAscensionParameterValue);
            AssertParameter(sentRequests[1].Parameters, declinationParameterName, declinationParameterValue);
        }
        
        [Fact]
        public async Task SlewToCoordinatesAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "slewtocoordinates";
            string commandNameAsync = "slewtocoordinatesasync";
            string rightAscensionParameterName = "RightAscension";
            double rightAscensionParameterValue = 2;
            string declinationParameterName = "Declination";
            double declinationParameterValue = 2;
            List<IRestRequest> sentRequests = new List<IRestRequest>();
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequests.Add(request))
                .ReturnsInOrder(Task.FromResult(new Response { ErrorNumber = ErrorCodes.NotImplemented }), Task.FromResult(new Response()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.SlewToCoordinatesAsync(rightAscensionParameterValue, declinationParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequests[0].Method);
            AssertCommonParameters(sentRequests[0].Parameters, _deviceConfiguration, commandNameAsync);
            AssertParameter(sentRequests[0].Parameters, rightAscensionParameterName, rightAscensionParameterValue);
            AssertParameter(sentRequests[0].Parameters, declinationParameterName, declinationParameterValue);
            Assert.Equal(Method.PUT, sentRequests[1].Method);
            AssertCommonParameters(sentRequests[1].Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequests[1].Parameters, rightAscensionParameterName, rightAscensionParameterValue);
            AssertParameter(sentRequests[1].Parameters, declinationParameterName, declinationParameterValue);
        }

        [Fact]
        public void SlewToTarget_SendValidRequest()
        {
            //Arrange
            string commandName = "slewtotarget";
            string commandNameAsync = "slewtotargetasync";
            List<IRestRequest> sentRequests = new List<IRestRequest>();
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequests.Add(request))
                .ReturnsInOrder(new Response { ErrorNumber = ErrorCodes.NotImplemented }, new Response());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.SlewToTarget();
            
            //Assert
            Assert.Equal(Method.PUT, sentRequests[0].Method);
            AssertCommonParameters(sentRequests[0].Parameters, _deviceConfiguration, commandNameAsync);
            Assert.Equal(Method.PUT, sentRequests[1].Method);
            AssertCommonParameters(sentRequests[1].Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task SlewToTargetAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "slewtotarget";
            string commandNameAsync = "slewtotargetasync";
            List<IRestRequest> sentRequests = new List<IRestRequest>();
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequests.Add(request))
                .ReturnsInOrder(Task.FromResult(new Response { ErrorNumber = ErrorCodes.NotImplemented }), Task.FromResult(new Response()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.SlewToTargetAsync();
            
            //Assert
            Assert.Equal(Method.PUT, sentRequests[0].Method);
            AssertCommonParameters(sentRequests[0].Parameters, _deviceConfiguration, commandNameAsync);
            Assert.Equal(Method.PUT, sentRequests[1].Method);
            AssertCommonParameters(sentRequests[1].Parameters, _deviceConfiguration, commandName);
        }

        [Fact]
        public void SyncToAltAz_SendValidRequest()
        {
            //Arrange
            string commandName = "synctoaltaz";
            string altitudeParameterName = "Altitude";
            double altitudeParameterValue = 2;
            string azimuthParameterName = "Azimuth";
            double azimuthParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.SyncToAltAz(altitudeParameterValue, azimuthParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, altitudeParameterName, altitudeParameterValue);
            AssertParameter(sentRequest.Parameters, azimuthParameterName, azimuthParameterValue);
        }
        
        [Fact]
        public async Task SyncToAltAzAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "synctoaltaz";
            string altitudeParameterName = "Altitude";
            double altitudeParameterValue = 2;
            string azimuthParameterName = "Azimuth";
            double azimuthParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.SyncToAltAzAsync(altitudeParameterValue, azimuthParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, altitudeParameterName, altitudeParameterValue);
            AssertParameter(sentRequest.Parameters, azimuthParameterName, azimuthParameterValue);
        }
        
        [Fact]
        public void SyncToCoordinates_SendValidRequest()
        {
            //Arrange
            string commandName = "synctocoordinates";
            string rightAscensionParameterName = "RightAscension";
            double rightAscensionParameterValue = 2;
            string declinationParameterName = "Declination";
            double declinationParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.SyncToCoordinates(rightAscensionParameterValue, declinationParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, rightAscensionParameterName, rightAscensionParameterValue);
            AssertParameter(sentRequest.Parameters, declinationParameterName, declinationParameterValue);
        }
        
        [Fact]
        public async Task SyncToCoordinatesAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "synctocoordinates";
            string rightAscensionParameterName = "RightAscension";
            double rightAscensionParameterValue = 2;
            string declinationParameterName = "Declination";
            double declinationParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.SyncToCoordinatesAsync(rightAscensionParameterValue, declinationParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, rightAscensionParameterName, rightAscensionParameterValue);
            AssertParameter(sentRequest.Parameters, declinationParameterName, declinationParameterValue);
        }
        
        [Fact]
        public void SyncToTarget_SendValidRequest()
        {
            //Arrange
            string commandName = "synctotarget";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.SyncToTarget();
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task SyncToTargetAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "synctotarget";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.SyncToTargetAsync();
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void Unpark_SendValidRequest()
        {
            //Arrange
            string commandName = "unpark";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            telescope.Unpark();
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task UnparkAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "unpark";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var telescope = new Telescope(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await telescope.UnparkAsync();
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
    }
}

