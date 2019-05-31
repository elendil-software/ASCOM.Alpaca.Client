namespace ES.AscomAlpaca.Client.Logging
{
    /// <summary>
    /// Represents a type used to log events
    /// <para>An implementation of the interface can act as an adapter for common loggers</para>
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Write a log event
        /// </summary>
        /// <param name="logEvent">Object that contains all the log information</param>
        void Log(LogEvent logEvent);
    }
}