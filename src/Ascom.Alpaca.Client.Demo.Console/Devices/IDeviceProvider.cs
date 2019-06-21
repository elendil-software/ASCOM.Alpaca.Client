using System.Collections.Generic;
using ES.Ascom.Alpaca.Devices;

namespace ES.Ascom.Alpaca.Client.Demo.Console.Devices
{
    public interface IDeviceProvider
    {
        T GetDevice<T>(int deviceNumber) where T : IDevice;
        IEnumerable<T> GetDevices<T>() where T : IDevice;
    }
}