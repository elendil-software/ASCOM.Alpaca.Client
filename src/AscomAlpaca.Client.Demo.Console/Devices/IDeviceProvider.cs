using System.Collections.Generic;
using ES.AscomAlpaca.Client.Devices;

namespace ES.AscomAlpaca.Client.Demo.Console.Devices
{
    public interface IDeviceProvider
    {
        T GetDevice<T>(int deviceNumber) where T : IDevice;
        IEnumerable<T> GetDevices<T>() where T : IDevice;
    }
}