using ES.Ascom.Alpaca.Client.Devices;
using ES.Ascom.Alpaca.Devices;

namespace ES.Ascom.Alpaca.Client.Demo.Desktop.Factories
{
    public interface IDeviceFactory
    {
        T CreateDeviceInstance<T>(DeviceConfiguration configuration) where T : IDevice;
    }
}