using System;
using System.Collections.Generic;
using System.Linq;
using ES.Ascom.Alpaca.Client.Devices;
using RestSharp;
using Xunit;

namespace ES.Ascom.Alpaca.Client.Test.Devices
{
    public abstract class DeviceRequestsTestBase
    {
        protected abstract DeviceType DeviceType { get; }
        
        protected void AssertCommonParameters(List<Parameter> sentRequestParameters,
            DeviceConfiguration deviceConfiguration, string commandName)
        {
            Assert.Contains(sentRequestParameters, p => p.Name == "deviceNumber");
            Assert.Equal(deviceConfiguration.DeviceNumber.ToString(),
                sentRequestParameters.FirstOrDefault(p => p.Name == "deviceNumber")?.Value);

            Assert.Contains(sentRequestParameters, p => p.Name == "deviceType");
            Assert.Equal(DeviceType.ToString().ToLower(),
                sentRequestParameters.FirstOrDefault(p => p.Name == "deviceType")?.Value);

            Assert.Contains(sentRequestParameters, p => p.Name == "command");
            Assert.Equal(commandName, sentRequestParameters.FirstOrDefault(p => p.Name == "command")?.Value);
        }

        protected void AssertParameter(List<Parameter> parameters, string positionParameterName, object position)
        {
            Assert.Contains(parameters, p => p.Name == positionParameterName);
            Assert.Equal(position.ToString(), parameters.FirstOrDefault(p => p.Name == positionParameterName)?.Value);
        }
        
        protected void AssertEnumParameter(List<Parameter> parameters, string positionParameterName, Enum position)
        {
            Assert.Contains(parameters, p => p.Name == positionParameterName);
            Assert.Equal(Convert.ToInt32(position).ToString(), parameters.FirstOrDefault(p => p.Name == positionParameterName)?.Value);
        }
    }


}