using System.Collections.Generic;
using AscomAlpacaClient.Devices;

namespace AscomAlpacaClient.Demo.Devices
{
    public interface IDeviceProvider
    {
        T GetDevice<T>(int deviceNumber) where T : IDevice;
        IEnumerable<T> GetDevices<T>() where T : IDevice;
    }
}