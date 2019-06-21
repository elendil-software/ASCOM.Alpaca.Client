using System;
using log4net;
using log4net.Core;

namespace ES.Ascom.Alpaca.Client.Logging
{
    /// <summary>
    /// <see cref="ILogger"/> adapter for <see cref="ILog"/>
    /// </summary>
    public class Log4NetAdapter : ILogger
    {
        private readonly ILog _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ILog" /> class.
        /// </summary>
        /// <param name="logger">A configured instance of <see cref="ILog"/></param>
        public Log4NetAdapter(ILog logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        
        /// <inheritdoc/>
        public void Log(LogEvent logEvent)
        {
            switch (logEvent.LogLevel)
            {
                case LogLevel.Fatal:
                    _logger.Fatal(logEvent.Message, logEvent.Exception);
                    break;
                case LogLevel.Error:
                    _logger.Error(logEvent.Message, logEvent.Exception);
                    break;
                case LogLevel.Warning:
                    _logger.Warn(logEvent.Message, logEvent.Exception);
                    break;
                case LogLevel.Information:
                    _logger.Info(logEvent.Message, logEvent.Exception);
                    break;
                case LogLevel.Debug:
                    _logger.Debug(logEvent.Message, logEvent.Exception);
                    break;
                default:
                    _logger.Debug(logEvent.Message, logEvent.Exception);
                    break;
            }
        }
    }
}