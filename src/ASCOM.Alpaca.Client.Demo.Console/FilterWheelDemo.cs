using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASCOM.Alpaca.Client.Devices;
using ASCOM.Alpaca.Client.Devices.Providers;
using Microsoft.Extensions.Logging;

namespace ASCOM.Alpaca.Client.Demo
{
    internal class FilterWheelDemo : IDeviceDemo
    {
        private readonly ILogger<FilterWheelDemo> _logger;
        private readonly IDeviceProvider _deviceProvider;

        public FilterWheelDemo(IDeviceProvider deviceProvider, ILogger<FilterWheelDemo> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _deviceProvider = deviceProvider ?? throw new ArgumentNullException(nameof(deviceProvider));
        }

        public void Run()
        {
            IEnumerable<FilterWheel> filterWheels = _deviceProvider.GetDevices<FilterWheel>();

            foreach (var filterWheel in filterWheels)
            {
                try
                {
                    CallDeviceMethods(filterWheel);
                    CallDeviceMethodsAsync(filterWheel);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, e.Message);
                }
            }
        }

        private void CallDeviceMethods(FilterWheel filterWheel)
        {
            _logger.LogInformation("START CallDeviceMethods");

            _logger.LogInformation("Connect Filter wheel");
            filterWheel.SetConnected(true);

            var isConnected = filterWheel.IsConnected();
            _logger.LogInformation("is Connected : {Connected}", isConnected);

            var name = filterWheel.GetName();
            _logger.LogInformation("Name : {Name}", name);

            var description = filterWheel.GetDescription();
            _logger.LogInformation("Description : {Description}", description);

            var driverInfo = filterWheel.GetDriverInfo();
            _logger.LogInformation("DriverInfo : {DriverInfo}", driverInfo);

            var driverVersion = filterWheel.GetDriverVersion();
            _logger.LogInformation("DriverVersion : {DriverVersion}", driverVersion);

            var names = filterWheel.GetNames();
            _logger.LogInformation("Filter names : {Names}", names);

            var offsets = filterWheel.GetFocusOffsets();
            _logger.LogInformation("Filter offsets : {Offsets}", offsets);

            var position = filterWheel.GetPosition();
            _logger.LogInformation("Current position : {Position}", position);

            _logger.LogInformation("Set filter position");
            filterWheel.SetPosition(2);

            position = filterWheel.GetPosition();
            _logger.LogInformation("Current position : {Position}", position);

            try
            {
                filterWheel.SetPosition(1000);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            _logger.LogInformation("END CallDeviceMethods");
        }


        private async Task CallDeviceMethodsAsync(FilterWheel filterWheel)
        {
            _logger.LogInformation("START CallDeviceMethodsAsync");

            _logger.LogInformation("Connect Filter wheel");
            var SetConnectedAsyncTask = filterWheel.SetConnectedAsync(true);
            ContinueTask(SetConnectedAsyncTask);

            var IsConnectedAsyncTask = filterWheel.IsConnectedAsync();
            ContinueTask(IsConnectedAsyncTask);

            _logger.LogInformation("Call GetNameAsync");
            var GetNameAsyncTask = filterWheel.GetNameAsync();
            ContinueTask(GetNameAsyncTask);

            _logger.LogInformation("Call GetDescriptionAsync");
            var GetDescriptionAsyncTask = filterWheel.GetDescriptionAsync();
            ContinueTask(GetDescriptionAsyncTask);

            _logger.LogInformation("Call GetDriverInfoAsync");
            var GetDriverInfoAsyncTask = filterWheel.GetDriverInfoAsync();
            ContinueTask(GetDriverInfoAsyncTask);

            _logger.LogInformation("Call GetDriverVersionAsync");
            var GetDriverVersionAsyncTask = filterWheel.GetDriverVersionAsync();
            ContinueTask(GetDriverVersionAsyncTask);

            _logger.LogInformation("Call GetNamesAsync");
            var GetNamesAsyncTask = filterWheel.GetNamesAsync();
            ContinueTask(GetNamesAsyncTask);

            _logger.LogInformation("Call GetFocusOffsetsAsync");
            var GetFocusOffsetsAsyncTask = filterWheel.GetFocusOffsetsAsync();
            ContinueTask(GetFocusOffsetsAsyncTask);

            _logger.LogInformation("Call SetPositionAsync(2)");
            var SetPositionAsync2Task = filterWheel.SetPositionAsync(2);
            ContinueTask(SetPositionAsync2Task);

            _logger.LogInformation("Call GetPositionAsync");
            var GetPositionAsyncTask = filterWheel.GetPositionAsync();
            ContinueTask(GetPositionAsyncTask);

            _logger.LogInformation("Call SetPositionAsync(1000)");
            var SetPositionAsync1000Task = filterWheel.SetPositionAsync(1000);
            ContinueTask(SetPositionAsync1000Task);

            await Task.WhenAll(SetConnectedAsyncTask, IsConnectedAsyncTask, GetNameAsyncTask,
                GetDescriptionAsyncTask, GetDriverInfoAsyncTask, GetDriverVersionAsyncTask,
                GetNamesAsyncTask, GetFocusOffsetsAsyncTask, SetPositionAsync2Task, GetPositionAsyncTask, SetPositionAsync1000Task);

            _logger.LogInformation("END CallDeviceMethodsAsync");
        }

        private void ContinueTask(Task task)
        {
            task.ContinueWith(t => { _logger.LogInformation("Action executed successfully"); },
                TaskContinuationOptions.OnlyOnRanToCompletion);

            task.ContinueWith(t => { _logger.LogError(t.Exception.Message); },
                TaskContinuationOptions.OnlyOnFaulted);
        }

        private void ContinueTask<T>(Task<T> task)
        {
            task.ContinueWith(t => { _logger.LogInformation("Response : {Value}", t.Result.ToString()); },
                TaskContinuationOptions.OnlyOnRanToCompletion);

            task.ContinueWith(t => { _logger.LogError(t.Exception.Message); },
                TaskContinuationOptions.OnlyOnFaulted);
        }
    }
}