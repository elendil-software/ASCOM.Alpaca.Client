using ASCOM.Alpaca.Client.Configuration;

namespace ASCOM.Alpaca.Client.Devices.Providers
{
    public interface IDeviceFactory
    {
        IDeviceBase CreateDevice(DeviceConfiguration deviceConfiguration);
    }
}