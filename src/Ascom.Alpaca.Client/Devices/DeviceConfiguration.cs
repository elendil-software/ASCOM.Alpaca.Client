namespace ES.Ascom.Alpaca.Client.Devices
{
    /// <summary>
    /// Represents the configuration for an ASCOM Alpaca device
    /// </summary>
    public class DeviceConfiguration
    {
        /// <summary>
        /// The protocol to use to communicate with the device
        /// <para>Default value is http://</para>
        /// </summary>
        public string Protocol { get; set; } = "http://";
        
        /// <summary>
        /// The host to use to communicate with the device
        /// <para>This can be an IP address or a host name</para>
        /// <para>Default value is 127.0.0.1</para>
        /// </summary>
        public string Host { get; set; } = "127.0.0.1";
        
        /// <summary>
        /// The ASCOM Alpaca API version to use to communicate with the device
        /// <para>The only available version is v1</para>
        /// <para>Default value is v1</para>
        /// </summary>
        public string ApiVersion { get; set; } = "v1";
        /// <summary>
        /// The port to use to communicate with the device
        /// <para>Default value is 11111</para>
        /// </summary>
        public int Port { get; set; } = 11111;
        /// <summary>
        /// The device number of the device
        /// <para>Default value is 0</para>
        /// </summary>
        public int DeviceNumber { get; set; }
        
        /// <summary>
        /// The client ID
        /// </summary>
        public int ClientId { get; set; } = -1;
        
        /// <summary>
        /// Timout duration in seconds that have to be use for long running synchronous operation
        /// <para>Default value is 120 seconds</para> 
        /// </summary>
        public int LongTimeout { get; set; } = 120;
        
        /// <summary>
        /// Builds the base URL based on the set parameters
        /// <para>With default parameters the returned URL will be http://127.0.0.1:11111/api/v1/</para>
        /// </summary>
        /// <returns></returns>
        public string GetBaseUrl() => $"{Protocol}{Host}:{Port}/api/{ApiVersion}/";
    }
}