using System;
using ASCOM.Alpaca.Client.Device;
using Microsoft.Extensions.Logging;

namespace ConsoleApp1
{
    internal class FilterWheelDemo
    {
        private readonly ILogger<FilterWheelDemo> _logger;
        private readonly FilterWheel _filterWheel;

        public FilterWheelDemo(FilterWheel filterWheel, ILogger<FilterWheelDemo> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _filterWheel = filterWheel ?? throw new ArgumentNullException(nameof(filterWheel));
        }

        public void Run()
        {
            try
            {
                _logger.LogInformation("Connect Filter wheel");
                var connectResponse = _filterWheel.SetConnected(true);
                
                var isConnectedResponse = _filterWheel.IsConnected();
                _logger.LogInformation("is Connected : {Connected}", isConnectedResponse.Value);
                
                var infoResponse = _filterWheel.GetName();
                _logger.LogInformation("Name : {Name}", infoResponse.Value);
                
                infoResponse = _filterWheel.GetDescription();
                _logger.LogInformation("Description : {Description}", infoResponse.Value);
                
                infoResponse = _filterWheel.GetDriverInfo();
                _logger.LogInformation("DriverInfo : {DriverInfo}", infoResponse.Value);
                
                infoResponse = _filterWheel.GetDriverVersion();
                _logger.LogInformation("DriverVersion : {DriverVersion}", infoResponse.Value);
                
                var namesResponse = _filterWheel.GetNames();
                _logger.LogInformation("Filter names : {Names}", namesResponse.Value);

                var positionResponse = _filterWheel.GetPosition();
                _logger.LogInformation("Current position : {Position}", positionResponse.Value);
                
                _logger.LogInformation("Set filter position");
                var setPositionResponse = _filterWheel.SetPosition(2);
                
                positionResponse = _filterWheel.GetPosition();
                _logger.LogInformation("Current position : {Position}", positionResponse.Value);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
        }
    }
}