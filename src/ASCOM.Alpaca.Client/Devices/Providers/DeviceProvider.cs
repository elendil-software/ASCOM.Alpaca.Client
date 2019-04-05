using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace ASCOM.Alpaca.Client.Devices.Providers
{
    public class DeviceProvider : IDeviceProvider
    {
        private readonly IEnumerable<IDevice> _devices;
        private readonly ILogger<DeviceProvider> _logger;
        
        public DeviceProvider(IEnumerable<IDevice> devices)
        {
            _devices = devices ?? throw new ArgumentNullException(nameof(devices));
        }
        
        public DeviceProvider(IEnumerable<IDevice> devices, ILogger<DeviceProvider> logger)
        {
            _devices = devices ?? throw new ArgumentNullException(nameof(devices));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public T GetDevice<T>(int deviceNumber) where T : IDevice
        {
            IDevice foundDevice = _devices.FirstOrDefault(d => d.GetType() == typeof(T) && d.DeviceNumber == deviceNumber);
            return (T)foundDevice;
        }
        
        public IEnumerable<T> GetDevices<T>() where T : IDevice
        {
            IEnumerable<T> foundDevices = _devices.Where(d => d.GetType() == typeof(T)).Cast<T>();
            return foundDevices;
        }
    }
}