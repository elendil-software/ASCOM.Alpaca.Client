using System;
using System.Collections.Generic;
using ASCOM.Alpaca.Client.Devices;
using Microsoft.Extensions.Logging;

namespace ASCOM.Alpaca.Client.Demo.Devices
{
    internal class DomeDemo : DeviceDemoBase, IDeviceDemo
    {
        public DomeDemo(IDeviceProvider deviceProvider, ILogger<IDeviceDemo> logger) : base(deviceProvider, logger)
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