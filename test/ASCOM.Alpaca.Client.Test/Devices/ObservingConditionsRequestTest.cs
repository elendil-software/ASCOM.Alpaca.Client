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
    public class ObservingConditionsRequestTest : DeviceRequestsTestBase
    {
        private readonly DeviceConfiguration _deviceConfiguration = new DeviceConfiguration { DeviceNumber = 5 };
        private readonly ClientTransactionIdGenerator _clientTransactionIdGenerator = new ClientTransactionIdGenerator();
        protected override DeviceType DeviceType { get; } = DeviceType.ObservingConditions;
        
        [Fact]
        public void GetAveragePeriod_SendValidRequest()
        {
            //Arrange
            string commandName = "averageperiod";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var observingConditions = new ObservingConditions(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            observingConditions.GetAveragePeriod();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetAveragePeriodAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "averageperiod";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var observingConditions = new ObservingConditions(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await observingConditions.GetAveragePeriodAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void SetAveragePeriod_SendValidRequest()
        {
            //Arrange
            string commandName = "averageperiod";
            string periodParameterName = "AveragePeriod";
            double periodParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var observingConditions = new ObservingConditions(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            observingConditions.SetAveragePeriod(periodParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, periodParameterName, periodParameterValue);
        }
        
        [Fact]
        public async Task SetAveragePeriodAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "averageperiod";
            string periodParameterName = "AveragePeriod";
            double periodParameterValue = 2;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var observingConditions = new ObservingConditions(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await observingConditions.SetAveragePeriodAsync(periodParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, periodParameterName, periodParameterValue);
        }
        
        [Fact]
        public void GetCloudCover_SendValidRequest()
        {
            //Arrange
            string commandName = "cloudcover";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var observingConditions = new ObservingConditions(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            observingConditions.GetCloudCover();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetCloudCoverAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "cloudcover";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var observingConditions = new ObservingConditions(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await observingConditions.GetCloudCoverAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetDewPoint_SendValidRequest()
        {
            //Arrange
            string commandName = "dewpoint";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var observingConditions = new ObservingConditions(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            observingConditions.GetDewPoint();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetDewPointAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "dewpoint";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var observingConditions = new ObservingConditions(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await observingConditions.GetDewPointAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetHumidity_SendValidRequest()
        {
            //Arrange
            string commandName = "humidity";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var observingConditions = new ObservingConditions(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            observingConditions.GetHumidity();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetHumidityAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "humidity";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var observingConditions = new ObservingConditions(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await observingConditions.GetHumidityAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetPressure_SendValidRequest()
        {
            //Arrange
            string commandName = "pressure";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var observingConditions = new ObservingConditions(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            observingConditions.GetPressure();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetPressureAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "pressure";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var observingConditions = new ObservingConditions(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await observingConditions.GetPressureAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetRainRate_SendValidRequest()
        {
            //Arrange
            string commandName = "rainrate";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var observingConditions = new ObservingConditions(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            observingConditions.GetRainRate();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetRainRateAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "rainrate";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var observingConditions = new ObservingConditions(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await observingConditions.GetRainRateAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetSkyBrightness_SendValidRequest()
        {
            //Arrange
            string commandName = "skybrightness";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var observingConditions = new ObservingConditions(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            observingConditions.GetSkyBrightness();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetSkyBrightnessAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "skybrightness";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var observingConditions = new ObservingConditions(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await observingConditions.GetSkyBrightnessAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetSkyQuality_SendValidRequest()
        {
            //Arrange
            string commandName = "skyquality";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var observingConditions = new ObservingConditions(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            observingConditions.GetSkyQuality();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetSkyQualityAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "skyquality";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var observingConditions = new ObservingConditions(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await observingConditions.GetSkyQualityAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetSkyTemperature_SendValidRequest()
        {
            //Arrange
            string commandName = "skytemperature";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var observingConditions = new ObservingConditions(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            observingConditions.GetSkyTemperature();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetSkyTemperatureAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "skytemperature";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var observingConditions = new ObservingConditions(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await observingConditions.GetSkyTemperatureAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetStarFwhm_SendValidRequest()
        {
            //Arrange
            string commandName = "starfwhm";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var observingConditions = new ObservingConditions(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            observingConditions.GetStarFwhm();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetStarFwhmAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "starfwhm";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var observingConditions = new ObservingConditions(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await observingConditions.GetStarFwhmAsync();
            
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
            var observingConditions = new ObservingConditions(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            observingConditions.GetTemperature();
            
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
            var observingConditions = new ObservingConditions(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await observingConditions.GetTemperatureAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetWindDirection_SendValidRequest()
        {
            //Arrange
            string commandName = "winddirection";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var observingConditions = new ObservingConditions(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            observingConditions.GetWindDirection();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetWindDirectionAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "winddirection";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var observingConditions = new ObservingConditions(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await observingConditions.GetWindDirectionAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetWindGust_SendValidRequest()
        {
            //Arrange
            string commandName = "windgust";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var observingConditions = new ObservingConditions(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            observingConditions.GetWindGust();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetWindGustAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "windgust";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var observingConditions = new ObservingConditions(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await observingConditions.GetWindGustAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetWindSpeed_SendValidRequest()
        {
            //Arrange
            string commandName = "windspeed";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var observingConditions = new ObservingConditions(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            observingConditions.GetWindSpeed();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetWindSpeedAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "windspeed";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var observingConditions = new ObservingConditions(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await observingConditions.GetWindSpeedAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void Refresh_SendValidRequest()
        {
            //Arrange
            string commandName = "refresh";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new Response());
            var observingConditions = new ObservingConditions(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            observingConditions.Refresh();
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task RefreshAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "refresh";
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var observingConditions = new ObservingConditions(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await observingConditions.RefreshAsync();
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetSensorDescription_SendValidRequest()
        {
            //Arrange
            string commandName = "sensordescription";
            string sensorNameParameterName = "SensorName";
            ObservingConditionSensorName sensorNameParameterValue = ObservingConditionSensorName.WindSpeed;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<StringResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new StringResponse());
            var observingConditions = new ObservingConditions(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            observingConditions.GetSensorDescription(sensorNameParameterValue);
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, sensorNameParameterName, sensorNameParameterValue);
        }
        
        [Fact]
        public async Task GetSensorDescriptionAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "sensordescription";
            string sensorNameParameterName = "SensorName";
            ObservingConditionSensorName sensorNameParameterValue = ObservingConditionSensorName.WindSpeed;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<StringResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new StringResponse()));
            var observingConditions = new ObservingConditions(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await observingConditions.GetSensorDescriptionAsync(sensorNameParameterValue);
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, sensorNameParameterName, sensorNameParameterValue);
        }
        
        [Fact]
        public void GetTimeSinceLastUpdate_SendValidRequest()
        {
            //Arrange
            string commandName = "timesincelastupdate";
            string sensorNameParameterName = "SensorName";
            ObservingConditionSensorName sensorNameParameterValue = ObservingConditionSensorName.WindSpeed;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var observingConditions = new ObservingConditions(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            observingConditions.GetTimeSinceLastUpdate(sensorNameParameterValue);
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, sensorNameParameterName, sensorNameParameterValue);
        }
        
        [Fact]
        public async Task GetTimeSinceLastUpdateAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "timesincelastupdate";
            string sensorNameParameterName = "SensorName";
            ObservingConditionSensorName sensorNameParameterValue = ObservingConditionSensorName.WindSpeed;
            IRestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, IRestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var observingConditions = new ObservingConditions(_deviceConfiguration, commandSenderMock.Object);
            
            //Act
            await observingConditions.GetTimeSinceLastUpdateAsync(sensorNameParameterValue);
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, sensorNameParameterName, sensorNameParameterValue);
        }
        
    }
}

