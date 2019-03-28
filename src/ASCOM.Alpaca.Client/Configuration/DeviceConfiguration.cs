namespace ASCOM.Alpaca.Client.Configuration
{
    public class DeviceConfiguration
    {
        public string Protocol { get; set; } = "http://";
        public string Host { get; set; } = "127.0.0.1";
        public string ApiVersion { get; set; } = "v1";
        public int Port { get; set; } = 11111;
        public int DeviceNumber { get; set; } = 0;

        public string GetBaseUrl() => $"{Protocol}{Host}:{Port}/api/{ApiVersion}/";
    }
}