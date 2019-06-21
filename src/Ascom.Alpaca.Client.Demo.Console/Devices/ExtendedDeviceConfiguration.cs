using ES.Ascom.Alpaca.Client.Devices;

namespace ES.Ascom.Alpaca.Client.Demo.Console.Devices
{
    public abstract class ExtendedDeviceConfiguration : DeviceConfiguration
    {
        public DeviceType DeviceType { get; set; } = DeviceType.Telescope;
    }
}