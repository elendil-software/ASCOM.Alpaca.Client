using System.Threading.Tasks;

namespace ASCOM.Alpaca.Client.Devices.Focuser
{
    public interface IFocuser
    {
        /// <summary>
        /// Indicates whether the focuser is capable of absolute position.
        /// </summary>
        /// <returns>True if the focuser is capable of absolute position</returns>
        bool IsAbsolute();
        
        /// <summary>
        /// Indicates whether the focuser is capable of absolute position.
        /// </summary>
        /// <returns>True if the focuser is capable of absolute position</returns>
        Task<bool> IsAbsoluteAsync();

        /// <summary>
        /// Indicates whether the focuser is currently moving.
        /// </summary>
        /// <returns>True if the focuser is currently moving to a new position. False if the focuser is stationary.</returns>
        bool IsMoving();

        /// <summary>
        /// Indicates whether the focuser is currently moving.
        /// </summary>
        /// <returns>True if the focuser is currently moving to a new position. False if the focuser is stationary.</returns>
        Task<bool> IsMovingAsync();

        /// <summary>
        /// Maximum increment size allowed by the focuser; i.e. the maximum number
        /// of steps allowed in one move operation.
        /// </summary>
        /// <returns></returns>
        int GetMaxIncrement();

        /// <summary>
        /// Maximum increment size allowed by the focuser; i.e. the maximum number
        /// of steps allowed in one move operation.
        /// </summary>
        /// <returns></returns>
        Task<int> GetMaxIncrementAsync();

        /// <summary>
        /// Returns the focuser's maximum step size.
        /// </summary>
        /// <returns></returns>
        int GetMaxStep();

        /// <summary>
        /// Returns the focuser's maximum step size.
        /// </summary>
        /// <returns></returns>
        Task<int> GetMaxStepAsync();

        /// <summary>
        /// Returns the focuser's current position.
        /// </summary>
        /// <returns></returns>
        int GetPosition();

        /// <summary>
        /// Returns the focuser's current position.
        /// </summary>
        /// <returns></returns>
        Task<int> GetPositionAsync();

        /// <summary>
        /// Returns the focuser's step size.
        /// </summary>
        /// <returns>Step size (microns) for the focuser.</returns>
        double GetStepSize();

        /// <summary>
        /// Returns the focuser's step size.
        /// </summary>
        /// <returns>Step size (microns) for the focuser.</returns>
        Task<double> GetStepSizeAsync();

        /// <summary>
        /// Gets the state of temperature compensation mode (if available), else always False.
        /// </summary>
        /// <returns></returns>
        bool IsTempComp();

        /// <summary>
        /// Gets the state of temperature compensation mode (if available), else always False.
        /// </summary>
        /// <returns></returns>
        Task<bool> IsTempCompAsync();
        
        /// <summary>
        /// Sets the state of temperature compensation mode.
        /// </summary>
        /// <param name="tempComp">Set true to enable the focuser's temperature compensation mode, otherwise false for normal operation.</param>
        void SetTempComp(bool tempComp);
        
        /// <summary>
        /// Sets the state of temperature compensation mode.
        /// </summary>
        /// <param name="tempComp">Set true to enable the focuser's temperature compensation mode, otherwise false for normal operation.</param>
        Task SetTempCompAsync(bool tempComp);

        /// <summary>
        /// Indicates whether the focuser has temperature compensation.
        /// </summary>
        /// <returns>True if focuser has temperature compensation available.</returns>
        bool IsTempCompAvailable();

        /// <summary>
        /// Indicates whether the focuser has temperature compensation.
        /// </summary>
        /// <returns>True if focuser has temperature compensation available.</returns>
        Task<bool> IsTempCompAvailableAsync();

        /// <summary>
        /// Returns the focuser's current temperature.
        /// </summary>
        /// <returns></returns>
        double GetTemperature();

        /// <summary>
        /// Returns the focuser's current temperature.
        /// </summary>
        /// <returns></returns>
        Task<double> GetTemperatureAsync();

        /// <summary>
        /// Immediatley stops focuser motion.
        /// </summary>
        void Halt();

        /// <summary>
        /// Immediatley stops focuser motion.
        /// </summary>
        Task HaltAsync();

        /// <summary>
        /// Moves the focuser by the specified amount or to the specified position depending on the value of the Absolute property.
        /// </summary>
        /// <param name="position">Step distance or absolute position, depending on the value of the Absolute property</param>
        void Move(int position);

        /// <summary>
        /// Moves the focuser by the specified amount or to the specified position depending on the value of the Absolute property.
        /// </summary>
        /// <param name="position">Step distance or absolute position, depending on the value of the Absolute property</param>
        Task MoveAsync(int position);
    }
}