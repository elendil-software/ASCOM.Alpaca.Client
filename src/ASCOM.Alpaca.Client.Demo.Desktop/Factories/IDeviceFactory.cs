using AscomAlpacaClient.Devices;

namespace AscomAlpacaClient.Demo.Desktop.Factories
{
    public interface IDeviceFactory
    {
        T CreateDeviceInstance<T>(DeviceConfiguration configuration) where T : IDevice;
    }
}