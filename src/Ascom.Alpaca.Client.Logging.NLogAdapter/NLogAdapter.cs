using System;
using NLog;

namespace ES.Ascom.Alpaca.Client.Logging
{
    /// <summary>
    /// <see cref="ILogger"/> adapter for <see cref="NLog.ILogger"/>
    /// </summary>
    public class NLogAdapter : ILogger
    {
        private readonly NLog.ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="NLogAdapter" /> class.
        /// </summary>
        /// <param name="logger">A configured instance of <see cref="NLog.ILogger"/></param>
        public NLogAdapter(NLog.ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        
        /// <inheritdoc/>
        public void Log(LogEvent logEvent)
        {
            NLog.LogLevel nLogLevel = ConvertLogLevel(logEvent.LogLevel);
            var logEventInfo = LogEventInfo.Create(nLogLevel, _logger.Name, logEvent.Exception, (IFormatProvider) _logger.Factory.DefaultCultureInfo, logEvent.Message, logEvent.PropertyValues);
            if (!string.IsNullOrWhiteSpace(logEvent.EventId))
            {
                logEventInfo.Properties["EventId"] = logEvent.EventId;
            }
            
            _logger.Log(logEventInfo);
        }
        
        static NLog.LogLevel ConvertLogLevel(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Fatal:
                    return NLog.LogLevel.Fatal;
                case LogLevel.Error:
                    return NLog.LogLevel.Error;
                case LogLevel.Warning:
                    return NLog.LogLevel.Warn;
                case LogLevel.Information:
                    return NLog.LogLevel.Info;
                case LogLevel.Debug:
                    return NLog.LogLevel.Debug;
                default:
                    return NLog.LogLevel.Trace;
            }
        }
    }
}