using System;
using System.Threading.Tasks;
using ASCOM.Alpaca.Client.Devices.Providers;
using Microsoft.Extensions.Logging;

namespace ASCOM.Alpaca.Client.Demo.Devices
{
    internal abstract class DeviceDemoBase
    {
        protected readonly ILogger<IDeviceDemo> Logger;
        protected readonly IDeviceProvider DeviceProvider;

        protected DeviceDemoBase(IDeviceProvider deviceProvider, ILogger<IDeviceDemo> logger)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            DeviceProvider = deviceProvider ?? throw new ArgumentNullException(nameof(deviceProvider));
        }

        protected void ContinueTask(Task task)
        {
            task.ContinueWith(t => { Logger.LogInformation("Action executed successfully"); },
                TaskContinuationOptions.OnlyOnRanToCompletion);

            task.ContinueWith(t => { Logger.LogError(t.Exception?.Message); },
                TaskContinuationOptions.OnlyOnFaulted);
        }

        protected void ContinueTask<T>(Task<T> task)
        {
            task.ContinueWith(t => { Logger.LogInformation("Response : {Value}", t.Result.ToString()); },
                TaskContinuationOptions.OnlyOnRanToCompletion);

            task.ContinueWith(t => { Logger.LogError(t.Exception?.Message); },
                TaskContinuationOptions.OnlyOnFaulted);
        }
    }
}