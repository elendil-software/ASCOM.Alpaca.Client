using System.Collections.Generic;
using ASCOM.Alpaca.Client.Devices;

namespace ASCOM.Alpaca.Client.Demo.Devices
{
    public interface IDeviceProvider
    {
        T GetDevice<T>(int deviceNumber) where T : IDevice;
        IEnumerable<T> GetDevices<T>() where T : IDevice;
    }
}