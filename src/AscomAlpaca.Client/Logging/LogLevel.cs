namespace ES.AscomAlpaca.Client.Logging
{
    /// <summary>
    /// Defines logging severity levels.
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// The most detailed level
        /// </summary>
        Trace = 0,
        /// <summary>
        /// Logs that are useful during development or for debugging
        /// </summary>
        Debug = 1,
        /// <summary>
        /// Logs that track the general flow of the application.
        /// </summary>
        Information = 2,
        /// <summary>
        /// Log that describe an unexpected event in the current execution flow,
        /// but that do not cause the execution to stop.
        /// </summary>
        Warning = 3,
        /// <summary>
        /// Log that describes an error in the current execution flow.
        /// </summary>
        Error = 4,
        /// <summary>
        /// Log that describes an unrecoverable application crash that requires immediate attention.
        /// </summary>
        Fatal = 5
    };
}