using ASCOM.Alpaca.Client.Devices;
using ASCOM.Alpaca.Enums.Devices;

namespace ASCOM.Alpaca.Client.Configuration
{
    public class DeviceConfiguration
    {
        public string Protocol { get; set; } = "http://";
        public string Host { get; set; } = "127.0.0.1";
        public string ApiVersion { get; set; } = "v1";
        public int Port { get; set; } = 11111;

        public DeviceType DeviceType { get; set; } = DeviceType.Telescope;
        public int DeviceNumber { get; set; } = 0;
        public int ClientId { get; set; } = 1;

        public string GetBaseUrl() => $"{Protocol}{Host}:{Port}/api/{ApiVersion}/";
    }
}