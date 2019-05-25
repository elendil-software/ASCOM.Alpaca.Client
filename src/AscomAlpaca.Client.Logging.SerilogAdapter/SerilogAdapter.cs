using System;
using Serilog.Events;

namespace ES.AscomAlpaca.Client.Logging
{
    public class SerilogAdapter : ILogger
    {
        private readonly Serilog.ILogger _logger;

        public SerilogAdapter(Serilog.ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Log(LogEvent logEvent)
        {
            LogEventLevel serilogLogLevel = ConvertLogLevel(logEvent.LogLevel);
            var logger = _logger;
            
            if (!string.IsNullOrWhiteSpace(logEvent.EventId))
            {
                logger = _logger.ForContext("EventId", logEvent.EventId);
            }
            
            logger.Write(serilogLogLevel, logEvent.Exception, logEvent.Message, logEvent.PropertyValues);
        }
        
        static LogEventLevel ConvertLogLevel(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Fatal:
                    return LogEventLevel.Fatal;
                case LogLevel.Error:
                    return LogEventLevel.Error;
                case LogLevel.Warning:
                    return LogEventLevel.Warning;
                case LogLevel.Information:
                    return LogEventLevel.Information;
                case LogLevel.Debug:
                    return LogEventLevel.Debug;
                default:
                    return LogEventLevel.Verbose;
            }
        }
    }
}