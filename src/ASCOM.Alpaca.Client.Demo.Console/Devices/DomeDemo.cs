using System;
using System.Collections.Generic;
using AscomAlpacaClient.Devices;
using Microsoft.Extensions.Logging;

namespace AscomAlpacaClient.Demo.Devices
{
    internal class DomeDemo : DeviceDemoBase, IDeviceDemo
    {
        public DomeDemo(IDeviceProvider deviceProvider, ILogger logger) : base(deviceProvider, logger)
        {
        }

        public void Run()
        {
            IEnumerable<Dome> domes = DeviceProvider.GetDevices<Dome>();

            foreach (var dome in domes)
            {
                try
                {
                    CallDeviceMethods(dome);
                }
                catch (Exception e)
                {
                    Logger.LogError(e, e.Message);
                }
            }
        }

        private void CallDeviceMethods(Dome dome)
        {
            Logger.LogInformation("START CallDeviceMethods");

            Logger.LogInformation("Connect Dome");
            dome.SetConnected(true);

            var isConnected = dome.IsConnected();
            Logger.LogInformation("is Connected : {Connected}", isConnected);

            var shutterStatus = dome.GetShutterStatus();
            Logger.LogInformation("shutterStatus : {shutterStatus}", shutterStatus);
        }
    }
}