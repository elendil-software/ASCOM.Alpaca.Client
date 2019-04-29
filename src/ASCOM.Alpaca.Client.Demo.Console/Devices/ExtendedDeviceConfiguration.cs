using ASCOM.Alpaca.Client.Devices;
using ASCOM.Alpaca.Devices;

namespace ASCOM.Alpaca.Client.Demo.Devices
{
    public abstract class ExtendedDeviceConfiguration : DeviceConfiguration
    {
        public DeviceType DeviceType { get; set; } = DeviceType.Telescope;
    }
}