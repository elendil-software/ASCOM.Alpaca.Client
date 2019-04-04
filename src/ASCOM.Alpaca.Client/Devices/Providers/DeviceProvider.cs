using System;
using System.Collections.Generic;
using System.Linq;
using ASCOM.Alpaca.Client.Configuration;
using Microsoft.Extensions.Options;

namespace ASCOM.Alpaca.Client.Devices.Providers
{
    public class DeviceProvider : IDeviceProvider
    {
        private readonly IEnumerable<IDeviceBase> _devices;
        
        public DeviceProvider(IEnumerable<IDeviceBase> devices)
        {
            _devices = devices ?? throw new ArgumentNullException(nameof(devices));
        }

        public T GetDevice<T>(int deviceNumber)
        {
            IDeviceBase foundDevice = _devices.FirstOrDefault(d => d.GetType() == typeof(T) && d.DeviceNumber == deviceNumber);
            return (T)foundDevice;
        }
        
        public IEnumerable<T> GetDevices<T>()
        {
            IEnumerable<IDeviceBase> foundDevice = _devices.Where(d => d.GetType() == typeof(T));
            return (IEnumerable<T>)foundDevice;
        }
    }
}