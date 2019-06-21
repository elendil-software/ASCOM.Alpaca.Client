using System;

namespace ES.Ascom.Alpaca.Client.Logging
{
    /// <summary>
    /// Represents a log event
    /// </summary>
    public class LogEvent 
    {
        /// <summary>
        /// Level of the event
        /// </summary>
        public LogLevel LogLevel { get; }
        /// <summary>
        /// Id of the event. Some logger call this information as a "context"
        /// </summary>
        public string EventId { get; }
        /// <summary>
        /// Exception related to this event
        /// </summary>
        public Exception Exception { get; }
        /// <summary>
        /// Message to write in the log
        /// </summary>
        public string Message { get; }
        
        /// <summary>
        /// List of parameters that can be use to format the message
        /// </summary>
        public object[] PropertyValues { get; }

        /// <summary>
        /// Initializes a new <see cref="LogEvent"/>
        /// </summary>
        /// <param name="logLevel">Level of the event</param>
        /// <param name="eventId">Id of the event. Some logger call this information as a "context"</param>
        /// <param name="exception">Exception related to this event</param>
        /// <param name="message">Message to write in the log</param>
        /// <param name="propertyValues">List of parameters that can be use to format the message</param>
        public LogEvent(LogLevel logLevel, string eventId = null, Exception exception = null, string message = null, object[] propertyValues = null)
        {
            LogLevel = logLevel;
            EventId = eventId;
            Exception = exception;
            Message = message;
            PropertyValues = propertyValues;
        }
    }
}