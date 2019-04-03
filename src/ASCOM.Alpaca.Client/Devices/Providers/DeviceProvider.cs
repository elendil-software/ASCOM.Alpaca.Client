using System;
using System.Collections.Generic;
using System.Linq;
using ASCOM.Alpaca.Client.Configuration;
using Microsoft.Extensions.Options;

namespace ASCOM.Alpaca.Client.Devices.Providers
{
    public class DeviceProvider : IDeviceProvider
    {
        private readonly List<IDeviceBase> _devices = new List<IDeviceBase>();
        private readonly DevicesConfiguration _devicesConfiguration;
        private readonly IDeviceFactory _deviceFactory;
        private readonly object devicesLock = new object();
        
        public DeviceProvider(IOptionsSnapshot<DevicesConfiguration> devicesConfiguration, IDeviceFactory deviceFactory)
        {
            _devicesConfiguration = devicesConfiguration?.Value ?? throw new ArgumentNullException(nameof(devicesConfiguration));
            _deviceFactory = deviceFactory ?? throw new ArgumentNullException(nameof(deviceFactory));
        }

        public T GetDevice<T>(int deviceNumber)
        {
            lock (devicesLock)
            {
                IDeviceBase foundDevice = _devices.FirstOrDefault(d => d.GetType() == typeof(T) && d.DeviceNumber == deviceNumber);

                if (foundDevice == null)
                {
                    //TODO : create new instance of device and add to the collection
                }

                return (T)foundDevice;
            }
        }
    }
}