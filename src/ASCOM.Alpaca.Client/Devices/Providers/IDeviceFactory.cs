using ASCOM.Alpaca.Client.Configuration;

namespace ASCOM.Alpaca.Client.Devices.Providers
{
    public interface IDeviceFactory
    {
        T CreateDeviceInstance<T>(DeviceConfiguration configuration) where T : IDevice;
    }
}