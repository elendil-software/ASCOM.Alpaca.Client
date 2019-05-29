using System;

namespace ES.AscomAlpaca.Client.Logging
{
    internal static class LoggerExtensions
    {
        internal static void LogTrace(this ILogger logger, string message, params object[] args)
        {
            logger.Log(new LogEvent(LogLevel.Trace, message:message, propertyValues:args));
        }
        
        internal static void LogTrace(this ILogger logger, Exception exception, string message, params object[] args)
        {
            logger.Log(new LogEvent(LogLevel.Trace, exception:exception, message:message, propertyValues:args));
        }
        
        internal static void LogDebug(this ILogger logger, string message, params object[] args)
        {
            logger.Log(new LogEvent(LogLevel.Debug, message:message, propertyValues:args));
        }
        
        internal static void LogDebug(this ILogger logger, Exception exception, string message, params object[] args)
        {
            logger.Log(new LogEvent(LogLevel.Debug, exception:exception, message:message, propertyValues:args));
        }
        
        internal static void LogInformation(this ILogger logger, string message, params object[] args)
        {
            logger.Log(new LogEvent(LogLevel.Information, message:message, propertyValues:args));
        }
        
        internal static void LogInformation(this ILogger logger, Exception exception, string message, params object[] args)
        {
            logger.Log(new LogEvent(LogLevel.Information, exception:exception, message:message, propertyValues:args));
        }
        
        internal static void LogWarning(this ILogger logger, string message, params object[] args)
        {
            logger.Log(new LogEvent(LogLevel.Warning, message:message, propertyValues:args));
        }

        internal static void LogWarning(this ILogger logger, Exception exception, string message, params object[] args)
        {
            logger.Log(new LogEvent(LogLevel.Warning, exception:exception, message:message, propertyValues:args));
        }

        internal static void LogError(this ILogger logger, string message, params object[] args)
        {
            logger.Log(new LogEvent(LogLevel.Error, message:message, propertyValues:args));
        }
        
        internal static void LogError(this ILogger logger, Exception exception, string message, params object[] args)
        {
            logger.Log(new LogEvent(LogLevel.Error, exception:exception, message:message, propertyValues:args));
        }
    }
}