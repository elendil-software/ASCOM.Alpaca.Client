using System;
using System.Collections.Generic;
using System.Linq;
using ASCOM.Alpaca.Client.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ASCOM.Alpaca.Client.Devices.Providers
{
    public class DeviceProvider : IDeviceProvider
    {
        private readonly IEnumerable<IDeviceBase> _devices;
        private readonly ILogger<DeviceProvider> _logger;
        
        public DeviceProvider(IEnumerable<IDeviceBase> devices)
        {
            _devices = devices ?? throw new ArgumentNullException(nameof(devices));
        }
        
        public DeviceProvider(IEnumerable<IDeviceBase> devices, ILogger<DeviceProvider> logger)
        {
            _devices = devices ?? throw new ArgumentNullException(nameof(devices));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public T GetDevice<T>(int deviceNumber) where T : IDeviceBase
        {
            IDeviceBase foundDevice = _devices.FirstOrDefault(d => d.GetType() == typeof(T) && d.DeviceNumber == deviceNumber);
            return (T)foundDevice;
        }
        
        public IEnumerable<T> GetDevices<T>() where T : IDeviceBase
        {
            IEnumerable<IDeviceBase> foundDevice = _devices.Where(d => d.GetType() == typeof(T));
            return (IEnumerable<T>)foundDevice;
        }
    }
}