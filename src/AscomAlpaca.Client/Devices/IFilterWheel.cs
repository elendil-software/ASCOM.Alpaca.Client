using System.Collections.Generic;
using System.Threading.Tasks;

namespace ES.AscomAlpaca.Client.Devices
{
    /// <summary>
    /// Defines the capabilities supported by an ASCOM Alpaca Filter wheel device
    /// </summary>
    public interface IFilterWheel : IDevice
    {
        /// <summary>
        /// Get the filter focus offsets
        /// </summary>
        /// <returns>Focus offsets</returns>
        IList<int> GetFocusOffsets();

        /// <summary>
        /// Get the filter focus offsets
        /// </summary>
        /// <returns>Focus offsets</returns>
        Task<IList<int>> GetFocusOffsetsAsync();
        
        /// <summary>
        /// Get the Filter wheel filter names
        /// </summary>
        /// <returns>Filter names</returns>
        IList<string> GetNames();
        
        /// <summary>
        /// Get the Filter wheel filter names
        /// </summary>
        /// <returns>Filter names</returns>
        Task<IList<string>> GetNamesAsync();
        
        /// <summary>
        /// Returns the current filter wheel position or -1 if wheel is moving.
        /// <para>The position is a number 0 and N-1, where N is the number of filter slots.
        /// Starts filter wheel rotation immediately when written.</para>
        /// </summary>
        /// <returns>current filter wheel position or -1 if wheel is moving</returns>
        int GetPosition();
        
        /// <summary>
        /// Returns the current filter wheel position or -1 if wheel is moving.
        /// <para>The position is a number 0 and N-1, where N is the number of filter slots.
        /// Starts filter wheel rotation immediately when written.</para>
        /// </summary>
        /// <returns>current filter wheel position or -1 if wheel is moving</returns>
        Task<int> GetPositionAsync();

        /// <summary>
        /// Sets the filter wheel position.
        /// <para>The position is a number 0 and N-1, where N is the number of filter slots.
        /// Starts filter wheel rotation immediately when written.</para>
        /// </summary>
        /// <param name="position">The filter wheel position</param>
        void SetPosition(int position);
        
        /// <summary>
        /// Sets the filter wheel position.
        /// <para>The position is a number 0 and N-1, where N is the number of filter slots.
        /// Starts filter wheel rotation immediately when written.</para>
        /// </summary>
        /// <param name="position">The filter wheel position</param>
        Task SetPositionAsync(int position);
    }
}