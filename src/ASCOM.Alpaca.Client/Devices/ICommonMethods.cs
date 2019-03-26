using System.Collections.Generic;

namespace ASCOM.Alpaca.Client.Device
{
    public interface ICommonMethods
    {
        /// <summary>
        /// Invokes the specified device-specific action.
        /// </summary>
        /// <param name="actionName">A well known name that represents the action to be carried out.</param>
        /// <param name="actionParameters">List of required parameters or an Empty String if none are required</param>
        /// <returns>String response from the device</returns>
        string Action(string actionName, string actionParameters);
        
        /// <summary>
        /// Transmits an arbitrary string to the device and does not wait for a response. Optionally, protocol framing characters may be added to the string before transmission.
        /// </summary>
        /// <param name="command">The literal command string to be transmitted</param>
        /// <param name="raw">If set to true the string is transmitted 'as-is', if set to false then protocol framing characters may be added prior to transmission</param>
        void CommandBlind(string command, bool raw = false);
        
        /// <summary>
        /// Transmits an arbitrary string to the device and waits for a boolean response. Optionally, protocol framing characters may be added to the string before transmission.
        /// </summary>
        /// <param name="command">The literal command string to be transmitted</param>
        /// <param name="raw">If set to true the string is transmitted 'as-is', if set to false then protocol framing characters may be added prior to transmission</param>
        /// <returns>Boolean response from the device.</returns>
        bool CommandBool(string command, bool raw = false);
        
        /// <summary>
        /// Transmits an arbitrary string to the device and waits for a string response. Optionally, protocol framing characters may be added to the string before transmission.
        /// </summary>
        /// <param name="command">The literal command string to be transmitted.</param>
        /// <param name="raw">If set to true the string is transmitted 'as-is', if set to false then protocol framing characters may be added prior to transmission</param>
        /// <returns>String response from the device.</returns>
        string CommandString(string command, bool raw = false);
        
        /// <summary>
        /// Retrieves the connected state of the device
        /// </summary>
        /// <returns><c>True</c> if the device is connected, <c>false</c> if not</returns>
        bool IsConnected();
        
        /// <summary>
        /// Sets the connected state of the device
        /// </summary>
        /// <param name="connected">Set True to connect to the device hardware, set False to disconnect from the device hardware</param>
        void SetConnected(bool connected);
        
        /// <summary>
        /// Retrives the description of the device
        /// </summary>
        /// <returns></returns>
        string GetDescription();
        
        /// <summary>
        /// Retrives the description of the driver
        /// </summary>
        /// <returns></returns>
        string GetDriverInfo();
        
        /// <summary>
        /// Retrives the version of the driver
        /// </summary>
        /// <returns>A string containing only the major and minor version of the driver.</returns>
        string GetDriverVersion();
        
        /// <summary>
        /// Retrives the name of the device
        /// </summary>
        /// <returns></returns>
        string GetName();
        
        /// <summary>
        /// Returns the list of action names supported by this driver. 
        /// </summary>
        /// <returns></returns>
        List<string> GetSupportedActions();
    }
}