using System.Collections.Generic;

namespace ASCOM.Alpaca.Client.Devices
{
    public interface IFilterWheel : IDevice
    {
        /// <summary>
        /// Get the filter focus offsets
        /// </summary>
        /// <returns></returns>
        List<int> GetFocusOffsets();
        
        /// <summary>
        /// Get the Filter wheel filter names
        /// </summary>
        /// <returns></returns>
        List<string> GetNames();
        
        /// <summary>
        /// Returns the current filter wheel position
        /// </summary>
        /// <returns></returns>
        int GetPosition();

        /// <summary>
        /// Sets the filter wheel position
        /// </summary>
        /// <param name="position">The number of the filter wheel position to select</param>
        /// <returns></returns>
        void SetPosition(int position);
    }
}