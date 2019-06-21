using ES.AscomAlpaca.Client.Devices;

namespace ES.AscomAlpaca.Client.Demo.Console.Devices
{
    public abstract class ExtendedDeviceConfiguration : DeviceConfiguration
    {
        public DeviceType DeviceType { get; set; } = DeviceType.Telescope;
    }
}