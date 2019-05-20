using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace AscomAlpacaClient.Demo.Devices
{
    internal abstract class DeviceDemoBase
    {
        protected readonly ILogger Logger;
        protected readonly IDeviceProvider DeviceProvider;

        protected DeviceDemoBase(IDeviceProvider deviceProvider, ILogger logger)
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