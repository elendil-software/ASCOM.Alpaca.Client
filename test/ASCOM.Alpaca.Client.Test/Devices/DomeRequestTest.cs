﻿using System.Threading.Tasks;
using ASCOM.Alpaca.Client.Configuration;
using ASCOM.Alpaca.Client.Devices;
using ASCOM.Alpaca.Client.Request;
using ASCOM.Alpaca.Client.Transactions;
using ASCOM.Alpaca.Devices;
using ASCOM.Alpaca.Devices.Dome;
using ASCOM.Alpaca.Responses;
using Moq;
using RestSharp;
using Xunit;

namespace ASCOM.Alpaca.Client.Test.Devices
{
    public class DomeRequestTest : DeviceRequestsTestBase
    {
        private readonly DeviceConfiguration _deviceConfiguration = new DeviceConfiguration { DeviceNumber = 5, DeviceType = DeviceType.Dome };
        private readonly ClientTransactionIdGenerator _clientTransactionIdGenerator = new ClientTransactionIdGenerator();
        
        [Fact]
        public void GetAltitude_SendValidRequest()
        {
            //Arrange
            string commandName = "altitude";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            dome.GetAltitude();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetAltitudeAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "altitude";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await dome.GetAltitudeAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void IsAtHome_SendValidRequest()
        {
            //Arrange
            string commandName = "athome";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            dome.IsAtHome();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task IsAtHomeAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "athome";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await dome.IsAtHomeAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void IsAtPark_SendValidRequest()
        {
            //Arrange
            string commandName = "atpark";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            dome.IsAtPark();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task IsAtParkAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "atpark";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await dome.IsAtParkAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetAzimuth_SendValidRequest()
        {
            //Arrange
            string commandName = "azimuth";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(new DoubleResponse());
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            dome.GetAzimuth();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetAzimuthAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "azimuth";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<DoubleResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new DoubleResponse()));
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await dome.GetAzimuthAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void CanFindHome_SendValidRequest()
        {
            //Arrange
            string commandName = "canfindhome";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            dome.CanFindHome();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task CanFindHomeAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "canfindhome";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await dome.CanFindHomeAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void CanPark_SendValidRequest()
        {
            //Arrange
            string commandName = "canpark";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            dome.CanPark();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task CanParkAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "canpark";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await dome.CanParkAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void CanSetAltitude_SendValidRequest()
        {
            //Arrange
            string commandName = "cansetaltitude";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            dome.CanSetAltitude();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task CanSetAltitudeAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "cansetaltitude";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await dome.CanSetAltitudeAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void CanSetAzimuth_SendValidRequest()
        {
            //Arrange
            string commandName = "cansetazimuth";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            dome.CanSetAzimuth();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task CanSetAzimuthAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "cansetazimuth";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await dome.CanSetAzimuthAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void CanSetPark_SendValidRequest()
        {
            //Arrange
            string commandName = "cansetpark";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            dome.CanSetPark();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task CanSetParkAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "cansetpark";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await dome.CanSetParkAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void CanSetShutter_SendValidRequest()
        {
            //Arrange
            string commandName = "cansetshutter";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            dome.CanSetShutter();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task CanSetShutterAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "cansetshutter";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await dome.CanSetShutterAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void CanSlave_SendValidRequest()
        {
            //Arrange
            string commandName = "canslave";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            dome.CanSlave();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task CanSlaveAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "canslave";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await dome.CanSlaveAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void CanSyncAzimuth_SendValidRequest()
        {
            //Arrange
            string commandName = "cansyncazimuth";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            dome.CanSyncAzimuth();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task CanSyncAzimuthAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "cansyncazimuth";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await dome.CanSyncAzimuthAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void GetShutterStatus_SendValidRequest()
        {
            //Arrange
            string commandName = "shutterstatus";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<ValueResponse<ShutterState>>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(new ValueResponse<ShutterState>());
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            dome.GetShutterStatus();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task GetShutterStatusAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "shutterstatus";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<ValueResponse<ShutterState>>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new ValueResponse<ShutterState>()));
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await dome.GetShutterStatusAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void IsSlaved_SendValidRequest()
        {
            //Arrange
            string commandName = "slaved";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            dome.IsSlaved();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task IsSlavedAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "slaved";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await dome.IsSlavedAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void SetSlaved_SendValidRequest()
        {
            //Arrange
            string commandName = "slaved";
            string slavedParameterName = "Slaved";
            bool slavedParameterValue = true;
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(new Response());
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            dome.SetSlaved(slavedParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, slavedParameterName, slavedParameterValue);
        }
        
        [Fact]
        public async Task SetSlavedAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "slaved";
            string slavedParameterName = "Slaved";
            bool slavedParameterValue = true;
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await dome.SetSlavedAsync(slavedParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, slavedParameterName, slavedParameterValue);
        }
        
        [Fact]
        public void IsSlewing_SendValidRequest()
        {
            //Arrange
            string commandName = "slewing";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(new BoolResponse());
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            dome.IsSlewing();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task IsSlewingAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "slewing";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<BoolResponse>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new BoolResponse()));
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await dome.IsSlewingAsync();
            
            //Assert
            Assert.Equal(Method.GET, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void AbortSlew_SendValidRequest()
        {
            //Arrange
            string commandName = "abortslew";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(new Response());
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            dome.AbortSlew();
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task AbortSlewAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "abortslew";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await dome.AbortSlewAsync();
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void CloseShutter_SendValidRequest()
        {
            //Arrange
            string commandName = "closeshutter";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(new Response());
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            dome.CloseShutter();
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task CloseShutterAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "closeshutter";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await dome.CloseShutterAsync();
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void FindHome_SendValidRequest()
        {
            //Arrange
            string commandName = "findhome";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(new Response());
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            dome.FindHome();
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task FindHomeAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "findhome";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await dome.FindHomeAsync();
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void OpenShutter_SendValidRequest()
        {
            //Arrange
            string commandName = "openshutter";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(new Response());
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            dome.OpenShutter();
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task OpenShutterAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "openshutter";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await dome.OpenShutterAsync();
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void Park_SendValidRequest()
        {
            //Arrange
            string commandName = "park";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(new Response());
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            dome.Park();
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task ParkAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "park";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await dome.ParkAsync();
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void SetPark_SendValidRequest()
        {
            //Arrange
            string commandName = "setpark";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(new Response());
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            dome.SetPark();
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public async Task SetParkAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "setpark";
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await dome.SetParkAsync();
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
        }
        
        [Fact]
        public void SlewToAltitude_SendValidRequest()
        {
            //Arrange
            string commandName = "slewtoaltitude";
            string altitudeParameterName = "Altitude";
            double altitudeParameterValue = 2;
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(new Response());
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            dome.SlewToAltitude(altitudeParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, altitudeParameterName, altitudeParameterValue);
        }
        
        [Fact]
        public async Task SlewToAltitudeAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "slewtoaltitude";
            string altitudeParameterName = "Altitude";
            double altitudeParameterValue = 2;
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await dome.SlewToAltitudeAsync(altitudeParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, altitudeParameterName, altitudeParameterValue);
        }
        
        [Fact]
        public void SlewToAzimuth_SendValidRequest()
        {
            //Arrange
            string commandName = "slewtoazimuth";
            string azimuthParameterName = "Azimuth";
            double azimuthParameterValue = 2;
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(new Response());
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            dome.SlewToAzimuth(azimuthParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, azimuthParameterName, azimuthParameterValue);
        }
        
        [Fact]
        public async Task SlewToAzimuthAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "slewtoazimuth";
            string azimuthParameterName = "Azimuth";
            double azimuthParameterValue = 2;
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await dome.SlewToAzimuthAsync(azimuthParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, azimuthParameterName, azimuthParameterValue);
        }
        
        [Fact]
        public void SyncToAzimuth_SendValidRequest()
        {
            //Arrange
            string commandName = "synctoazimuth";
            string azimuthParameterName = "Azimuth";
            double azimuthParameterValue = 2;
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequest<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(new Response());
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            dome.SyncToAzimuth(azimuthParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, azimuthParameterName, azimuthParameterValue);
        }
        
        [Fact]
        public async Task SyncToAzimuthAsync_SendValidRequest()
        {
            //Arrange
            string commandName = "synctoazimuth";
            string azimuthParameterName = "Azimuth";
            double azimuthParameterValue = 2;
            RestRequest sentRequest = null;
            var commandSenderMock = new Mock<ICommandSender>();
            commandSenderMock
                .Setup(x => x.ExecuteRequestAsync<Response>(It.IsAny<string>(), It.IsAny<RestRequest>()))
                .Callback((string baseUrl, RestRequest request) => sentRequest = request)
                .Returns(Task.FromResult(new Response()));
            var dome = new Dome(_deviceConfiguration, _clientTransactionIdGenerator, commandSenderMock.Object);
            
            //Act
            await dome.SyncToAzimuthAsync(azimuthParameterValue);
            
            //Assert
            Assert.Equal(Method.PUT, sentRequest.Method);
            AssertCommonParameters(sentRequest.Parameters, _deviceConfiguration, commandName);
            AssertParameter(sentRequest.Parameters, azimuthParameterName, azimuthParameterValue);
        }
        
    }
}
