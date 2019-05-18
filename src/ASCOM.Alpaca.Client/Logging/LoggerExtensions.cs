using System;

namespace ASCOM.Alpaca.Client.Logging
{
    public static class LoggerExtensions
    {
        public static void LogTrace(this ILogger logger, string message, params object[] args)
        {
            logger.Log(new LogEvent(LogLevel.Trace, message:message, propertyValues:args));
        }
        
        public static void LogTrace(this ILogger logger, string eventId, string message, params object[] args)
        {
            logger.Log(new LogEvent(LogLevel.Trace, eventId, message:message, propertyValues:args));
        }
        
        public static void LogTrace(this ILogger logger, Exception exception, string message, params object[] args)
        {
            logger.Log(new LogEvent(LogLevel.Trace, exception:exception, message:message, propertyValues:args));
        }
        
        public static void LogTrace(this ILogger logger, string eventId, Exception exception, string message, params object[] args)
        {
            logger.Log(new LogEvent(LogLevel.Trace, eventId, exception, message, args));
        }
        
        public static void LogDebug(this ILogger logger, string message, params object[] args)
        {
            logger.Log(new LogEvent(LogLevel.Debug, message:message, propertyValues:args));
        }
        
        public static void LogDebug(this ILogger logger, string eventId, string message, params object[] args)
        {
            logger.Log(new LogEvent(LogLevel.Debug, eventId, message:message, propertyValues:args));
        }
        
        public static void LogDebug(this ILogger logger, Exception exception, string message, params object[] args)
        {
            logger.Log(new LogEvent(LogLevel.Debug, exception:exception, message:message, propertyValues:args));
        }
        
        public static void LogDebug(this ILogger logger, string eventId, Exception exception, string message, params object[] args)
        {
            logger.Log(new LogEvent(LogLevel.Debug, eventId, exception, message, args));
        }
        
        public static void LogInformation(this ILogger logger, string message, params object[] args)
        {
            logger.Log(new LogEvent(LogLevel.Information, message:message, propertyValues:args));
        }
        
        public static void LogInformation(this ILogger logger, string eventId, string message, params object[] args)
        {
            logger.Log(new LogEvent(LogLevel.Information, eventId, message:message, propertyValues:args));
        }
        
        public static void LogInformation(this ILogger logger, Exception exception, string message, params object[] args)
        {
            logger.Log(new LogEvent(LogLevel.Information, exception:exception, message:message, propertyValues:args));
        }
        
        public static void LogInformation(this ILogger logger, string eventId, Exception exception, string message, params object[] args)
        {
            logger.Log(new LogEvent(LogLevel.Information, eventId, exception, message, args));
        }
        
        public static void LogWarning(this ILogger logger, string message, params object[] args)
        {
            logger.Log(new LogEvent(LogLevel.Warning, message:message, propertyValues:args));
        }
        
        public static void LogWarning(this ILogger logger, string eventId, string message, params object[] args)
        {
            logger.Log(new LogEvent(LogLevel.Warning, eventId, message:message, propertyValues:args));
        }
        
        public static void LogWarning(this ILogger logger, Exception exception, string message, params object[] args)
        {
            logger.Log(new LogEvent(LogLevel.Warning, exception:exception, message:message, propertyValues:args));
        }
        
        public static void LogWarning(this ILogger logger, string eventId, Exception exception, string message, params object[] args)
        {
            logger.Log(new LogEvent(LogLevel.Warning, eventId, exception, message, args));
        }
        
        public static void LogError(this ILogger logger, string message, params object[] args)
        {
            logger.Log(new LogEvent(LogLevel.Error, message:message, propertyValues:args));
        }
        
        public static void LogError(this ILogger logger, string eventId, string message, params object[] args)
        {
            logger.Log(new LogEvent(LogLevel.Error, eventId, message:message, propertyValues:args));
        }
        
        public static void LogError(this ILogger logger, Exception exception, string message, params object[] args)
        {
            logger.Log(new LogEvent(LogLevel.Error, exception:exception, message:message, propertyValues:args));
        }
        
        public static void LogError(this ILogger logger, string eventId, Exception exception, string message, params object[] args)
        {
            logger.Log(new LogEvent(LogLevel.Error, eventId, exception, message, args));
        }

        public static void LogFatal(this ILogger logger, string message, params object[] args)
        {
            logger.Log(new LogEvent(LogLevel.Fatal, message:message, propertyValues:args));
        }

        public static void LogFatal(this ILogger logger, string eventId, string message, params object[] args)
        {
            logger.Log(new LogEvent(LogLevel.Fatal, eventId, message:message, propertyValues:args));
        }

        public static void LogFatal(this ILogger logger, Exception exception, string message, params object[] args)
        {
            logger.Log(new LogEvent(LogLevel.Fatal, exception:exception, message:message, propertyValues:args));
        }

        public static void LogFatal(this ILogger logger, string eventId, Exception exception, string message, params object[] args)
        {
            logger.Log(new LogEvent(LogLevel.Fatal, eventId, exception, message, args));
        }
    }
}