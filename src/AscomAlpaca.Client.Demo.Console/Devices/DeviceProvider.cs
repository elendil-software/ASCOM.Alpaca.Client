using System;
using System.Collections.Generic;
using System.Linq;
using ES.AscomAlpaca.Devices;

namespace ES.AscomAlpaca.Client.Demo.Console.Devices
{
    public class DeviceProvider : IDeviceProvider
    {
        private readonly IEnumerable<IDevice> _devices;

        public DeviceProvider(IEnumerable<IDevice> devices)
        {
            _devices = devices ?? throw new ArgumentNullException(nameof(devices));
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