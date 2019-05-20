using System.Collections.Generic;
using System.Threading.Tasks;

namespace AscomAlpacaClient.Devices
{
    public interface IFilterWheel : IDevice
    {
        /// <summary>
        /// Get the filter focus offsets
        /// </summary>
        /// <returns></returns>
        IList<int> GetFocusOffsets();

        Task<IList<int>> GetFocusOffsetsAsync();
        
        /// <summary>
        /// Get the Filter wheel filter names
        /// </summary>
        /// <returns></returns>
        IList<string> GetNames();
        
        
        Task<IList<string>> GetNamesAsync();
        
        /// <summary>
        /// Returns the current filter wheel position
        /// </summary>
        /// <returns></returns>
        int GetPosition();
        
        Task<int> GetPositionAsync();

        /// <summary>
        /// Sets the filter wheel position
        /// </summary>
        /// <param name="position">The number of the filter wheel position to select</param>
        /// <returns></returns>
        void SetPosition(int position);
        
        Task SetPositionAsync(int position);
    }
}