using System.Threading.Tasks;

namespace ES.AscomAlpaca.Client.Devices
{
    /// <summary>
    /// Defines the capabilities supported by an ASCOM Alpaca Rotator device
    /// </summary>
    public interface IRotator : IDevice
    {
        /// <summary>
        /// Indicates whether the Rotator supports the Reverse method.
        /// </summary>
        /// <returns>True if the Rotator supports the Reverse method.</returns>
        bool CanReverse();
        
        /// <summary>
        /// Indicates whether the Rotator supports the Reverse method.
        /// </summary>
        /// <returns>True if the Rotator supports the Reverse method.</returns>
        Task<bool> CanReverseAsync();

        /// <summary>
        /// Indicates whether the rotator is currently moving.
        /// </summary>
        /// <returns></returns>
        bool IsMoving();

        /// <summary>
        /// Indicates whether the rotator is currently moving.
        /// </summary>
        /// <returns></returns>
        Task<bool> IsMovingAsync();

        /// <summary>
        /// Returns the rotator's current position.
        /// </summary>
        /// <returns>Current instantaneous Rotator position, in degrees.</returns>
        double GetPosition();

        /// <summary>
        /// Returns the rotator's current position.
        /// </summary>
        /// <returns>Current instantaneous Rotator position, in degrees.</returns>
        Task<double> GetPositionAsync();

        /// <summary>
        /// Returns the rotator’s Reverse state.
        /// </summary>
        /// <returns></returns>
        bool IsReversed();
        
        /// <summary>
        /// Returns the rotator’s Reverse state.
        /// </summary>
        /// <returns></returns>
        Task<bool> IsReversedAsync();

        /// <summary>
        /// Sets the rotator’s Reverse state.
        /// </summary>
        /// <param name="reversed">True if the rotation and angular direction must be reversed to match the optical characteristcs</param>
        void SetReversed(bool reversed);

        /// <summary>
        /// Sets the rotator’s Reverse state.
        /// </summary>
        /// <param name="reversed">True if the rotation and angular direction must be reversed to match the optical characteristcs</param>
        Task SetReversedAsync(bool reversed);

        /// <summary>
        /// Returns the minimum StepSize
        /// </summary>
        /// <returns>The minimum StepSize, in degrees.</returns>
        double GetStepSize();

        /// <summary>
        /// Returns the minimum StepSize
        /// </summary>
        /// <returns>The minimum StepSize, in degrees.</returns>
        Task<double> GetStepSizeAsync();

        /// <summary>
        /// Returns the destination position angle for Move() and MoveAbsolute().
        /// </summary>
        /// <returns></returns>
        double GetTargetPosition();

        /// <summary>
        /// Returns the destination position angle for Move() and MoveAbsolute().
        /// </summary>
        /// <returns></returns>
        Task<double> GetTargetPositionAsync();

        /// <summary>
        /// Immediately stop any Rotator motion due to a previous Move or MoveAbsolute method call.
        /// </summary>
        void Halt();

        /// <summary>
        /// Immediately stop any Rotator motion due to a previous Move or MoveAbsolute method call.
        /// </summary>
        Task HaltAsync();

        /// <summary>
        /// Causes the rotator to move Position degrees relative to the current Position value.
        /// </summary>
        /// <param name="position">Relative position to move in degrees from current Position.</param>
        void Move(double position);

        /// <summary>
        /// Causes the rotator to move Position degrees relative to the current Position value.
        /// </summary>
        /// <param name="position">Relative position to move in degrees from current Position.</param>
        Task MoveAsync(double position);

        /// <summary>
        /// Causes the rotator to move the absolute position of Position degrees.
        /// </summary>
        /// <param name="position">Absolute position in degrees.</param>
        void MoveAbsolute(double position);

        /// <summary>
        /// Causes the rotator to move the absolute position of Position degrees.
        /// </summary>
        /// <param name="position">Absolute position in degrees.</param>
        Task MoveAbsoluteAsync(double position);
    }
}