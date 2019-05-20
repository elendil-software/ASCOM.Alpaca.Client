using System;

namespace AscomAlpacaClient.Logging
{
    public class LogEvent 
    {
        public LogLevel LogLevel { get; }
        public string EventId { get; set; }
        public Exception Exception { get; }
        public string Message { get; }
        public object[] PropertyValues { get; }
        
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