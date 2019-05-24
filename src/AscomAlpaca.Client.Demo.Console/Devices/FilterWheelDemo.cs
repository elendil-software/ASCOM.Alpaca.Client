using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ES.AscomAlpaca.Client.Devices;
using Microsoft.Extensions.Logging;

namespace ES.AscomAlpaca.Client.Demo.Console.Devices
{
    internal class FilterWheelDemo : DeviceDemoBase, IDeviceDemo
    {

        public FilterWheelDemo(IDeviceProvider deviceProvider, ILogger logger) : base(deviceProvider, logger)
        {
        }

        public async void Run()
        {
            IEnumerable<FilterWheel> filterWheels = DeviceProvider.GetDevices<FilterWheel>();

            foreach (var filterWheel in filterWheels)
            {
                try
                {
                    CallDeviceMethods(filterWheel);
                    await CallDeviceMethodsAsync(filterWheel);
                }
                catch (Exception e)
                {
                    Logger.LogError(e, e.Message);
                }
            }
        }

        private void CallDeviceMethods(FilterWheel filterWheel)
        {
            Logger.LogInformation("START CallDeviceMethods");

            Logger.LogInformation("Connect Filter wheel");
            filterWheel.SetConnected(true);

            var isConnected = filterWheel.IsConnected();
            Logger.LogInformation("is Connected : {Connected}", isConnected);

            var name = filterWheel.GetName();
            Logger.LogInformation("Name : {Name}", name);

            var description = filterWheel.GetDescription();
            Logger.LogInformation("Description : {Description}", description);

            var driverInfo = filterWheel.GetDriverInfo();
            Logger.LogInformation("DriverInfo : {DriverInfo}", driverInfo);

            var driverVersion = filterWheel.GetDriverVersion();
            Logger.LogInformation("DriverVersion : {DriverVersion}", driverVersion);

            var names = filterWheel.GetNames();
            Logger.LogInformation("Filter names : {Names}", names);

            var offsets = filterWheel.GetFocusOffsets();
            Logger.LogInformation("Filter offsets : {Offsets}", offsets);

            var position = filterWheel.GetPosition();
            Logger.LogInformation("Current position : {Position}", position);

            Logger.LogInformation("Set filter position");
            filterWheel.SetPosition(2);

            position = filterWheel.GetPosition();
            Logger.LogInformation("Current position : {Position}", position);

            try
            {
                filterWheel.SetPosition(1000);
            }
            catch (Exception e)
            {
                Logger.LogError(e, e.Message);
            }

            Logger.LogInformation("END CallDeviceMethods");
        }


        private async Task CallDeviceMethodsAsync(FilterWheel filterWheel)
        {
            Logger.LogInformation("START CallDeviceMethodsAsync");

            Logger.LogInformation("Connect Filter wheel");
            var setConnectedAsyncTask = filterWheel.SetConnectedAsync(true);
            ContinueTask(setConnectedAsyncTask);

            var isConnectedAsyncTask = filterWheel.IsConnectedAsync();
            ContinueTask(isConnectedAsyncTask);

            Logger.LogInformation("Call GetNameAsync");
            var getNameAsyncTask = filterWheel.GetNameAsync();
            ContinueTask(getNameAsyncTask);

            Logger.LogInformation("Call GetDescriptionAsync");
            var getDescriptionAsyncTask = filterWheel.GetDescriptionAsync();
            ContinueTask(getDescriptionAsyncTask);

            Logger.LogInformation("Call GetDriverInfoAsync");
            var getDriverInfoAsyncTask = filterWheel.GetDriverInfoAsync();
            ContinueTask(getDriverInfoAsyncTask);

            Logger.LogInformation("Call GetDriverVersionAsync");
            var getDriverVersionAsyncTask = filterWheel.GetDriverVersionAsync();
            ContinueTask(getDriverVersionAsyncTask);

            Logger.LogInformation("Call GetNamesAsync");
            var getNamesAsyncTask = filterWheel.GetNamesAsync();
            ContinueTask(getNamesAsyncTask);

            Logger.LogInformation("Call GetFocusOffsetsAsync");
            var getFocusOffsetsAsyncTask = filterWheel.GetFocusOffsetsAsync();
            ContinueTask(getFocusOffsetsAsyncTask);

            Logger.LogInformation("Call SetPositionAsync(2)");
            var setPositionAsync2Task = filterWheel.SetPositionAsync(2);
            ContinueTask(setPositionAsync2Task);

            Logger.LogInformation("Call GetPositionAsync");
            var getPositionAsyncTask = filterWheel.GetPositionAsync();
            ContinueTask(getPositionAsyncTask);

            Logger.LogInformation("Call SetPositionAsync(1000)");
            var setPositionAsync1000Task = filterWheel.SetPositionAsync(1000);
            ContinueTask(setPositionAsync1000Task);

            await Task.WhenAll(setConnectedAsyncTask, isConnectedAsyncTask, getNameAsyncTask,
                getDescriptionAsyncTask, getDriverInfoAsyncTask, getDriverVersionAsyncTask,
                getNamesAsyncTask, getFocusOffsetsAsyncTask, setPositionAsync2Task, getPositionAsyncTask, setPositionAsync1000Task);

            Logger.LogInformation("END CallDeviceMethodsAsync");
        }
    }
}