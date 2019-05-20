using AscomAlpacaClient.Devices;

namespace AscomAlpacaClient.Demo.Devices
{
    public abstract class ExtendedDeviceConfiguration : DeviceConfiguration
    {
        public DeviceType DeviceType { get; set; } = DeviceType.Telescope;
    }
}