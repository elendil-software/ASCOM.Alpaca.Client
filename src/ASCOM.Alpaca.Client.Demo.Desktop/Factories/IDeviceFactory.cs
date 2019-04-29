using ASCOM.Alpaca.Client.Configuration;
using ASCOM.Alpaca.Client.Devices;

namespace ASCOM.Alpaca.Client.Demo.Desktop.Factories
{
    public interface IDeviceFactory
    {
        T CreateDeviceInstance<T>(DeviceConfiguration configuration) where T : IDevice;
    }
}