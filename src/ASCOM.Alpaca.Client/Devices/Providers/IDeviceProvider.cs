using System.Collections.Generic;

namespace ASCOM.Alpaca.Client.Devices.Providers
{
    public interface IDeviceProvider
    {
        T GetDevice<T>(int deviceNumber) where T : IDevice;
        IEnumerable<T> GetDevices<T>() where T : IDevice;
    }
}