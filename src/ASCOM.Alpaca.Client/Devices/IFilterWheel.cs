using ASCOM.Alpaca.Client.Responses;

namespace ASCOM.Alpaca.Client.Device
{
    public interface IFilterWheel : ICommonMethods
    {
        /// <summary>
        /// Get the filter focus offsets
        /// </summary>
        /// <returns></returns>
        IntArrayResponse GetFocusOffsets();
        
        /// <summary>
        /// Get the Filter wheel filter names
        /// </summary>
        /// <returns></returns>
        StringArrayResponse GetNames();
        
        /// <summary>
        /// Returns the current filter wheel position
        /// </summary>
        /// <returns></returns>
        IntResponse GetPosition();

        /// <summary>
        /// Sets the filter wheel position
        /// </summary>
        /// <param name="position">The number of the filter wheel position to select</param>
        /// <returns></returns>
        MethodResponse SetPosition(int position);
    }
}