using System.Threading.Tasks;
using ASCOM.Alpaca.Client.Devices;
using ASCOM.Alpaca.Client.Request;
using ASCOM.Alpaca.Client.Responses;
using ASCOM.Alpaca.Client.Transactions;
using Moq;
using RestSharp;
using Xunit;

namespace ASCOM.Alpaca.Client.Test.Devices
{
    public class CameraRequestTest : DeviceRequestsTestBase
    {
        private readonly DeviceConfiguration _deviceConfiguration = new DeviceConfiguration { DeviceNumber = 5 };
        private readonly ClientTransactionIdGenerator _clientTransactionIdGenerator = new ClientTransactionIdGenerator();
        protected override DeviceType DeviceType { get; } = DeviceType.Camera;
        
         [Fact]
        public void GetBayerOffsetX_SendValidRequest()
        {
            //Arrange
            string commandName = "bayeroffsetx";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new IntResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.GetBayerOffsetX();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetBayerOffsetXAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "bayeroffsetx";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new IntResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.GetBayerOffsetXAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetBayerOffsetY_SendValidRequest()
        {
            //Arrange
            string commandName = "bayeroffsety";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new IntResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.GetBayerOffsetY();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetBayerOffsetYAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "bayeroffsety";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new IntResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.GetBayerOffsetYAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetBinX_SendValidRequest()
        {
            //Arrange
            string commandName = "binx";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new IntResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.GetBinX();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetBinXAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "binx";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new IntResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.GetBinXAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void SetBinX_SendValidRequest()
        {
            //Arrange
            string commandName = "binx";
            string binXParameterName = "BinX";
            int binXParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.SetBinX(binXParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, binXParameterName, binXParameterValue);
        }
        
        [Fact]
        public async Task SetBinXAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "binx";
            string binXParameterName = "BinX";
            int binXParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.SetBinXAsync(binXParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, binXParameterName, binXParameterValue);
        }
        
        [Fact]
        public void GetBinY_SendValidRequest()
        {
            //Arrange
            string commandName = "biny";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new IntResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.GetBinY();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetBinYAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "biny";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new IntResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.GetBinYAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void SetBinY_SendValidRequest()
        {
            //Arrange
            string commandName = "biny";
            string binYParameterName = "BinY";
            int binYParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.SetBinY(binYParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, binYParameterName, binYParameterValue);
        }
        
        [Fact]
        public async Task SetBinYAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "biny";
            string binYParameterName = "BinY";
            int binYParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.SetBinYAsync(binYParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, binYParameterName, binYParameterValue);
        }
        
        [Fact]
        public void GetCameraState_SendValidRequest()
        {
            //Arrange
            string commandName = "camerastate";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<CameraStateResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new CameraStateResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.GetCameraState();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetCameraStateAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "camerastate";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<CameraStateResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new CameraStateResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.GetCameraStateAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetCameraXSize_SendValidRequest()
        {
            //Arrange
            string commandName = "cameraxsize";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new IntResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.GetCameraXSize();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetCameraXSizeAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "cameraxsize";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new IntResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.GetCameraXSizeAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetCameraYSize_SendValidRequest()
        {
            //Arrange
            string commandName = "cameraysize";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new IntResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.GetCameraYSize();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetCameraYSizeAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "cameraysize";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new IntResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.GetCameraYSizeAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void CanAbortExposure_SendValidRequest()
        {
            //Arrange
            string commandName = "canabortexposure";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.CanAbortExposure();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task CanAbortExposureAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "canabortexposure";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.CanAbortExposureAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void CanAsymmetricBin_SendValidRequest()
        {
            //Arrange
            string commandName = "canasymmetricbin";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.CanAsymmetricBin();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task CanAsymmetricBinAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "canasymmetricbin";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.CanAsymmetricBinAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void CanFastReadout_SendValidRequest()
        {
            //Arrange
            string commandName = "canfastreadout";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.CanFastReadout();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task CanFastReadoutAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "canfastreadout";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.CanFastReadoutAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void CanGetCoolerPower_SendValidRequest()
        {
            //Arrange
            string commandName = "cangetcoolerpower";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.CanGetCoolerPower();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task CanGetCoolerPowerAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "cangetcoolerpower";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.CanGetCoolerPowerAsync();
            
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
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.CanPulseGuide();
            
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
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.CanPulseGuideAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void CanSetCCDTemperature_SendValidRequest()
        {
            //Arrange
            string commandName = "cansetccdtemperature";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.CanSetCCDTemperature();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task CanSetCCDTemperatureAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "cansetccdtemperature";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.CanSetCCDTemperatureAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void CanStopExposure_SendValidRequest()
        {
            //Arrange
            string commandName = "canstopexposure";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.CanStopExposure();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task CanStopExposureAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "canstopexposure";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.CanStopExposureAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetCCDTemperature_SendValidRequest()
        {
            //Arrange
            string commandName = "ccdtemperature";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.GetCCDTemperature();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetCCDTemperatureAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "ccdtemperature";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.GetCCDTemperatureAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void IsCoolerOn_SendValidRequest()
        {
            //Arrange
            string commandName = "cooleron";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.IsCoolerOn();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task IsCoolerOnAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "cooleron";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.IsCoolerOnAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void SetCoolerOn_SendValidRequest()
        {
            //Arrange
            string commandName = "cooleron";
            string coolerOnParameterName = "CoolerOn";
            bool coolerOnParameterValue = true;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.SetCoolerOn(coolerOnParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, coolerOnParameterName, coolerOnParameterValue);
        }
        
        [Fact]
        public async Task SetCoolerOnAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "cooleron";
            string coolerOnParameterName = "CoolerOn";
            bool coolerOnParameterValue = true;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.SetCoolerOnAsync(coolerOnParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, coolerOnParameterName, coolerOnParameterValue);
        }
        
        [Fact]
        public void GetCoolerPower_SendValidRequest()
        {
            //Arrange
            string commandName = "coolerpower";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.GetCoolerPower();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetCoolerPowerAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "coolerpower";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.GetCoolerPowerAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetElectronPerADU_SendValidRequest()
        {
            //Arrange
            string commandName = "electronsperadu";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.GetElectronPerADU();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetElectronPerADUAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "electronsperadu";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.GetElectronPerADUAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetExposureMax_SendValidRequest()
        {
            //Arrange
            string commandName = "exposuremax";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.GetExposureMax();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetExposureMaxAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "exposuremax";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.GetExposureMaxAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetExposureMin_SendValidRequest()
        {
            //Arrange
            string commandName = "exposuremin";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.GetExposureMin();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetExposureMinAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "exposuremin";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.GetExposureMinAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetExposureResolution_SendValidRequest()
        {
            //Arrange
            string commandName = "exposureresolution";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.GetExposureResolution();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetExposureResolutionAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "exposureresolution";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.GetExposureResolutionAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void IsFastReadout_SendValidRequest()
        {
            //Arrange
            string commandName = "fastreadout";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.IsFastReadout();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task IsFastReadoutAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "fastreadout";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.IsFastReadoutAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void SetFastReadout_SendValidRequest()
        {
            //Arrange
            string commandName = "fastreadout";
            string fastReadoutParameterName = "FastReadout";
            bool fastReadoutParameterValue = true;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.SetFastReadout(fastReadoutParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, fastReadoutParameterName, fastReadoutParameterValue);
        }
        
        [Fact]
        public async Task SetFastReadoutAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "fastreadout";
            string fastReadoutParameterName = "FastReadout";
            bool fastReadoutParameterValue = true;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.SetFastReadoutAsync(fastReadoutParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, fastReadoutParameterName, fastReadoutParameterValue);
        }
        
        [Fact]
        public void GetFullWellCapacity_SendValidRequest()
        {
            //Arrange
            string commandName = "fullwellcapacity";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.GetFullWellCapacity();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetFullWellCapacityAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "fullwellcapacity";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.GetFullWellCapacityAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetGain_SendValidRequest()
        {
            //Arrange
            string commandName = "gain";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new IntResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.GetGain();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetGainAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "gain";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new IntResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.GetGainAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void SetGain_SendValidRequest()
        {
            //Arrange
            string commandName = "gain";
            string gainParameterName = "Gain";
            int gainParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.SetGain(gainParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, gainParameterName, gainParameterValue);
        }
        
        [Fact]
        public async Task SetGainAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "gain";
            string gainParameterName = "Gain";
            int gainParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.SetGainAsync(gainParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, gainParameterName, gainParameterValue);
        }
        
        [Fact]
        public void GetGainMax_SendValidRequest()
        {
            //Arrange
            string commandName = "gainmax";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new IntResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.GetGainMax();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetGainMaxAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "gainmax";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new IntResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.GetGainMaxAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetGainMin_SendValidRequest()
        {
            //Arrange
            string commandName = "gainmin";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new IntResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.GetGainMin();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetGainMinAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "gainmin";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new IntResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.GetGainMinAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetGains_SendValidRequest()
        {
            //Arrange
            string commandName = "gains";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<StringListResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new StringListResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.GetGains();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetGainsAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "gains";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<StringListResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new StringListResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.GetGainsAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }

        [Fact]
        public void HasShutter_SendValidRequest()
        {
            //Arrange
            string commandName = "hasshutter";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.HasShutter();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task HasShutterAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "hasshutter";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.HasShutterAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetHeatSinkTemperature_SendValidRequest()
        {
            //Arrange
            string commandName = "heatsinktemperature";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.GetHeatSinkTemperature();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetHeatSinkTemperatureAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "heatsinktemperature";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.GetHeatSinkTemperatureAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetImageArray_SendValidRequest()
        {
            //Arrange
            string commandName = "imagearray";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new RestResponse { Content = "{\"Type\":2,\"Rank\":2,\"Value\":[[184,178],[188,186],[188,190]],\"ClientTransactionID\":59,\"ServerTransactionID\":134,\"ErrorNumber\":0,\"ErrorMessage\":\"\"}"});
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.GetImageArray();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetImageArrayAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "imagearray";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult<IRestResponse>(new RestResponse { Content = "{\"Type\":2,\"Rank\":2,\"Value\":[[184,178],[188,186],[188,190]],\"ClientTransactionID\":59,\"ServerTransactionID\":134,\"ErrorNumber\":0,\"ErrorMessage\":\"\"}"}));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.GetImageArrayAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetImageArrayVariant_SendValidRequest()
        {
            //Arrange
            string commandName = "imagearrayvariant";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new RestResponse { Content = "{\"Type\":2,\"Rank\":2,\"Value\":[[184,178],[188,186],[188,190]],\"ClientTransactionID\":59,\"ServerTransactionID\":134,\"ErrorNumber\":0,\"ErrorMessage\":\"\"}"});
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.GetImageArrayVariant();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetImageArrayVariantAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "imagearrayvariant";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult<IRestResponse>(new RestResponse { Content = "{\"Type\":2,\"Rank\":2,\"Value\":[[184,178],[188,186],[188,190]],\"ClientTransactionID\":59,\"ServerTransactionID\":134,\"ErrorNumber\":0,\"ErrorMessage\":\"\"}"}));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.GetImageArrayVariantAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void IsImageReady_SendValidRequest()
        {
            //Arrange
            string commandName = "imageready";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.IsImageReady();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task IsImageReadyAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "imageready";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.IsImageReadyAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
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
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.IsPulseGuiding();
            
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
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.IsPulseGuidingAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetLastExposureDuration_SendValidRequest()
        {
            //Arrange
            string commandName = "lastexposureduration";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.GetLastExposureDuration();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetLastExposureDurationAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "lastexposureduration";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.GetLastExposureDurationAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetLastExposureStartTime_SendValidRequest()
        {
            //Arrange
            string commandName = "lastexposurestarttime";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<StringResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new StringResponse { Value = "2019-04-26T16:02:33" });
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.GetLastExposureStartTime();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetLastExposureStartTimeAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "lastexposurestarttime";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<StringResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new StringResponse { Value = "2019-04-26T16:02:33" }));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.GetLastExposureStartTimeAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetMaxADU_SendValidRequest()
        {
            //Arrange
            string commandName = "maxadu";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new IntResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.GetMaxADU();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetMaxADUAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "maxadu";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new IntResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.GetMaxADUAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetMaxBinX_SendValidRequest()
        {
            //Arrange
            string commandName = "maxbinx";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new IntResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.GetMaxBinX();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetMaxBinXAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "maxbinx";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new IntResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.GetMaxBinXAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetMaxBinY_SendValidRequest()
        {
            //Arrange
            string commandName = "maxbiny";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new IntResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.GetMaxBinY();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetMaxBinYAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "maxbiny";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new IntResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.GetMaxBinYAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetNumX_SendValidRequest()
        {
            //Arrange
            string commandName = "numx";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new IntResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.GetNumX();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetNumXAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "numx";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new IntResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.GetNumXAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void SetNumX_SendValidRequest()
        {
            //Arrange
            string commandName = "numx";
            string numXParameterName = "NumX";
            int numXParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.SetNumX(numXParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, numXParameterName, numXParameterValue);
        }
        
        [Fact]
        public async Task SetNumXAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "numx";
            string numXParameterName = "NumX";
            int numXParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.SetNumXAsync(numXParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, numXParameterName, numXParameterValue);
        }
        
        [Fact]
        public void GetNumY_SendValidRequest()
        {
            //Arrange
            string commandName = "numy";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new IntResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.GetNumY();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetNumYAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "numy";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new IntResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.GetNumYAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void SetNumY_SendValidRequest()
        {
            //Arrange
            string commandName = "numy";
            string numYParameterName = "NumY";
            int numYParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.SetNumY(numYParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, numYParameterName, numYParameterValue);
        }
        
        [Fact]
        public async Task SetNumYAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "numy";
            string numYParameterName = "NumY";
            int numYParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.SetNumYAsync(numYParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, numYParameterName, numYParameterValue);
        }
        
        [Fact]
        public void GetPercentCompleted_SendValidRequest()
        {
            //Arrange
            string commandName = "percentcompleted";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new IntResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.GetPercentCompleted();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetPercentCompletedAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "percentcompleted";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new IntResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.GetPercentCompletedAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetPixelSizeX_SendValidRequest()
        {
            //Arrange
            string commandName = "pixelsizex";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.GetPixelSizeX();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetPixelSizeXAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "pixelsizex";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.GetPixelSizeXAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetPixelSizeY_SendValidRequest()
        {
            //Arrange
            string commandName = "pixelsizey";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.GetPixelSizeY();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetPixelSizeYAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "pixelsizey";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.GetPixelSizeYAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetReadoutMode_SendValidRequest()
        {
            //Arrange
            string commandName = "readoutmode";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new IntResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.GetReadoutMode();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetReadoutModeAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "readoutmode";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new IntResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.GetReadoutModeAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void SetReadoutMode_SendValidRequest()
        {
            //Arrange
            string commandName = "readoutmode";
            string readoutModeParameterName = "ReadoutMode";
            int readoutModeParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);

            //Act
            camera.SetReadoutMode(readoutModeParameterValue);

            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, readoutModeParameterName, readoutModeParameterValue);
        }

        [Fact]
        public async Task SetReadoutModeAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "readoutmode";
            string readoutModeParameterName = "ReadoutMode";
            int readoutModeParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);

            //Act
            await camera.SetReadoutModeAsync(readoutModeParameterValue);

            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, readoutModeParameterName, readoutModeParameterValue);
        }

        [Fact]
        public void GetReadoutModes_SendValidRequest()
        {
            //Arrange
            string commandName = "readoutmodes";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<StringListResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new StringListResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.GetReadoutModes();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetReadoutModesAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "readoutmodes";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<StringListResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new StringListResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.GetReadoutModesAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetSensorName_SendValidRequest()
        {
            //Arrange
            string commandName = "sensorname";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<StringResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new StringResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.GetSensorName();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetSensorNameAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "sensorname";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<StringResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new StringResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.GetSensorNameAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetSensorType_SendValidRequest()
        {
            //Arrange
            string commandName = "sensortype";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<SensorTypeResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new SensorTypeResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.GetSensorType();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetSensorTypeAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "sensortype";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<SensorTypeResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new SensorTypeResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.GetSensorTypeAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetCCDTemperatureSetPoint_SendValidRequest()
        {
            //Arrange
            string commandName = "setccdtemperature";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.GetCCDTemperatureSetPoint();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetCCDTemperatureSetPointAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "setccdtemperature";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.GetCCDTemperatureSetPointAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void SetCCDTemperatureSetPoint_SendValidRequest()
        {
            //Arrange
            string commandName = "setccdtemperature";
            string temperatureParameterName = "SetCCDTemperature";
            double temperatureParameterValue = -20;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.SetCCDTemperatureSetPoint(temperatureParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, temperatureParameterName, temperatureParameterValue);
        }
        
        [Fact]
        public async Task SetCCDTemperatureSetPointAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "setccdtemperature";
            string temperatureParameterName = "SetCCDTemperature";
            double temperatureParameterValue = -20;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.SetCCDTemperatureSetPointAsync(temperatureParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, temperatureParameterName, temperatureParameterValue);
        }
        
        [Fact]
        public void GetStartX_SendValidRequest()
        {
            //Arrange
            string commandName = "startx";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new IntResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.GetStartX();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetStartXAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "startx";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new IntResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.GetStartXAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void SetStartX_SendValidRequest()
        {
            //Arrange
            string commandName = "startx";
            string startXParameterName = "StartX";
            int startXParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.SetStartX(startXParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, startXParameterName, startXParameterValue);
        }
        
        [Fact]
        public async Task SetStartXAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "startx";
            string startXParameterName = "StartX";
            int startXParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.SetStartXAsync(startXParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, startXParameterName, startXParameterValue);
        }
        
        [Fact]
        public void GetStartY_SendValidRequest()
        {
            //Arrange
            string commandName = "starty";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new IntResponse());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.GetStartY();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetStartYAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "starty";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<IntResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new IntResponse()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.GetStartYAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void SetStartY_SendValidRequest()
        {
            //Arrange
            string commandName = "starty";
            string startYParameterName = "StartY";
            int startYParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.SetStartY(startYParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, startYParameterName, startYParameterValue);
        }
        
        [Fact]
        public async Task SetStartYAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "starty";
            string startYParameterName = "StartY";
            int startYParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.SetStartYAsync(startYParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, startYParameterName, startYParameterValue);
        }
        
        [Fact]
        public void AbortExposure_SendValidRequest()
        {
            //Arrange
            string commandName = "abortexposure";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.AbortExposure();
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task AbortExposureAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "abortexposure";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.AbortExposureAsync();
            
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
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.PulseGuide(directionParameterValue, durationParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, directionParameterName, directionParameterValue);
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
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.PulseGuideAsync(directionParameterValue, durationParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, directionParameterName, directionParameterValue);
            AssertParameter(sentRequest.Parameters, durationParameterName, durationParameterValue);
        }
        
        [Fact]
        public void StartExposure_SendValidRequest()
        {
            //Arrange
            string commandName = "startexposure";
            string durationParameterName = "Duration";
            double durationParameterValue = 2;
            string isLightParameterName = "Light";
            bool isLightParameterValue = true;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.StartExposure(durationParameterValue, isLightParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, durationParameterName, durationParameterValue);
            AssertParameter(sentRequest.Parameters, isLightParameterName, isLightParameterValue);
        }
        
        [Fact]
        public async Task StartExposureAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "startexposure";
            string durationParameterName = "Duration";
            double durationParameterValue = 2;
            string isLightParameterName = "Light";
            bool isLightParameterValue = true;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await camera.StartExposureAsync(durationParameterValue, isLightParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, durationParameterName, durationParameterValue);
            AssertParameter(sentRequest.Parameters, isLightParameterName, isLightParameterValue);
        }
        
        [Fact]
        public void StopExposure_SendValidRequest()
        {
            //Arrange
            string commandName = "stopexposure";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            camera.StopExposure();
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }

        [Fact]
        public async Task StopExposureAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "stopexposure";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var camera = new Camera(_deviceConfiguration, commandSenderMock.Object);

            //Act
            await camera.StopExposureAsync();

            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
    }
}

