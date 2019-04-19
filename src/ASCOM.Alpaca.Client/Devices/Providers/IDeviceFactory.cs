using ASCOM.Alpaca.Client.Configuration;

namespace ASCOM.Alpaca.Client.Devices.Providers
{
    public interface IDeviceFactory
    {
        T GetDevice<T>(DeviceConfiguration configuration) where T : IDevice;
    }
}