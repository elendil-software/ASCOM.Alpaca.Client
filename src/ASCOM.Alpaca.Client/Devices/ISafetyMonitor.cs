using System.Threading.Tasks;

namespace AscomAlpacaClient.Devices
{
    public interface ISafetyMonitor : IDevice
    {
        /// <summary>
        /// Indicates whether the monitored state is safe for use.
        /// </summary>
        /// <returns>True if the state is safe, False if it is unsafe.</returns>
        bool IsSafe();
        
        /// <summary>
        /// Indicates whether the monitored state is safe for use.
        /// </summary>
        /// <returns>True if the state is safe, False if it is unsafe.</returns>
        Task<bool> IsSafeAsync();
    }
}