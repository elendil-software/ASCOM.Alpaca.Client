using System;
using ASCOM.Alpaca.Client.Devices;
using ASCOM.Alpaca.Client.Exceptions;
using Microsoft.Extensions.Logging;

namespace ASCOM.Alpaca.Client.Demo
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
                _filterWheel.SetConnected(true);
                
                var isConnected = _filterWheel.IsConnected();
                _logger.LogInformation("is Connected : {Connected}", isConnected);
                
                var name = _filterWheel.GetName();
                _logger.LogInformation("Name : {Name}", name);
                
                var description = _filterWheel.GetDescription();
                _logger.LogInformation("Description : {Description}", description);
                
                var driverInfo = _filterWheel.GetDriverInfo();
                _logger.LogInformation("DriverInfo : {DriverInfo}", driverInfo);
                
                var driverVersion = _filterWheel.GetDriverVersion();
                _logger.LogInformation("DriverVersion : {DriverVersion}", driverVersion);
                
                var names = _filterWheel.GetNames();
                _logger.LogInformation("Filter names : {Names}", names);

                var offsets = _filterWheel.GetFocusOffsets();
                _logger.LogInformation("Filter offsets : {Offsets}", offsets);

                var position = _filterWheel.GetPosition();
                _logger.LogInformation("Current position : {Position}", position);
                
                _logger.LogInformation("Set filter position");
                _filterWheel.SetPosition(2);
                
                position = _filterWheel.GetPosition();
                _logger.LogInformation("Current position : {Position}", position);
                
                _filterWheel.SetPosition(1000);
            }
            catch (ASCOMRemoteResponseException e)
            {
                _logger.LogError(e, $"{e.ErrorNumber} : {e.Message}");
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
        }
    }
}