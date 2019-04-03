namespace ASCOM.Alpaca.Client.Devices.Providers
{
    public interface IDeviceProvider
    {
        T GetDevice<T>(int deviceNumber);
    }
}