using System;
using System.Collections.Generic;
using ASCOM.Alpaca.Client.Devices;
using ASCOM.Alpaca.Client.Devices.Providers;
using Microsoft.Extensions.Logging;

namespace ASCOM.Alpaca.Client.Demo
{
    internal class FilterWheelDemo : IDeviceDemo
    {
        private readonly ILogger<FilterWheelDemo> _logger;
        private readonly IDeviceProvider _deviceProvider;

        public FilterWheelDemo(IDeviceProvider deviceProvider, ILogger<FilterWheelDemo> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _deviceProvider = deviceProvider ?? throw new ArgumentNullException(nameof(deviceProvider));
        }

        public void Run()
        {
            IEnumerable<FilterWheel> filterWheels = _deviceProvider.GetDevices<FilterWheel>();

            foreach (var filterWheel in filterWheels)
            {
                try
                {
                    CallDeviceMethods(filterWheel);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, e.Message);
                }
            }
        }

        private void CallDeviceMethods(FilterWheel filterWheel)
        {
            _logger.LogInformation("Connect Filter wheel");
            filterWheel.SetConnected(true);

            var isConnected = filterWheel.IsConnected();
            _logger.LogInformation("is Connected : {Connected}", isConnected);

            var name = filterWheel.GetName();
            _logger.LogInformation("Name : {Name}", name);

            var description = filterWheel.GetDescription();
            _logger.LogInformation("Description : {Description}", description);

            var driverInfo = filterWheel.GetDriverInfo();
            _logger.LogInformation("DriverInfo : {DriverInfo}", driverInfo);

            var driverVersion = filterWheel.GetDriverVersion();
            _logger.LogInformation("DriverVersion : {DriverVersion}", driverVersion);

            var names = filterWheel.GetNames();
            _logger.LogInformation("Filter names : {Names}", names);

            var offsets = filterWheel.GetFocusOffsets();
            _logger.LogInformation("Filter offsets : {Offsets}", offsets);

            var position = filterWheel.GetPosition();
            _logger.LogInformation("Current position : {Position}", position);

            _logger.LogInformation("Set filter position");
            filterWheel.SetPosition(2);

            position = filterWheel.GetPosition();
            _logger.LogInformation("Current position : {Position}", position);

            filterWheel.SetPosition(1000);
        }
    }
}