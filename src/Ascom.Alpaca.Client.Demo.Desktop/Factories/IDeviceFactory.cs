using ES.AscomAlpaca.Client.Devices;
using ES.AscomAlpaca.Devices;

namespace ES.AscomAlpaca.Client.Demo.Desktop.Factories
{
    public interface IDeviceFactory
    {
        T CreateDeviceInstance<T>(DeviceConfiguration configuration) where T : IDevice;
    }
}