using System;
using ASCOM.Alpaca.Client.Configuration;
using ASCOM.Alpaca.Client.Request;
using ASCOM.Alpaca.Client.Transactions;
using ASCOM.Alpaca.Devices;
using Microsoft.Extensions.Logging;

namespace ASCOM.Alpaca.Client.Devices.Providers
{
    public class DeviceFactory : IDeviceFactory
    {
        private readonly IClientTransactionIdGenerator _clientTransactionIdGenerator;
        private readonly ICommandSender _commandSender;
        private readonly ILoggerFactory _loggerFactory;

        public DeviceFactory(IClientTransactionIdGenerator clientTransactionIdGenerator, ICommandSender commandSender)
        {
            _clientTransactionIdGenerator = clientTransactionIdGenerator ?? throw new ArgumentNullException(nameof(clientTransactionIdGenerator));
            _commandSender = commandSender ?? throw new ArgumentNullException(nameof(commandSender));
        }

        public DeviceFactory(IClientTransactionIdGenerator clientTransactionIdGenerator, ICommandSender commandSender, ILoggerFactory loggerFactory)
        {
            _clientTransactionIdGenerator = clientTransactionIdGenerator ?? throw new ArgumentNullException(nameof(clientTransactionIdGenerator));
            _commandSender = commandSender ?? throw new ArgumentNullException(nameof(commandSender));
            _loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));
        }

        public T CreateDeviceInstance<T>(DeviceConfiguration configuration) where T : IDevice
        {
            //TODO : handle the case without logger
            switch (configuration.DeviceType)
            {
                case DeviceType.FilterWheel:
                    ILogger<FilterWheel> logger = _loggerFactory.CreateLogger<FilterWheel>();
                    IDevice device = new FilterWheel(configuration, _clientTransactionIdGenerator, _commandSender, logger);
                    return (T) device;

                case DeviceType.SafetyMonitor:
                    ILogger<SafetyMonitor> safetyMonitorLogger = _loggerFactory.CreateLogger<SafetyMonitor>();
                    IDevice safetyMonitor = new SafetyMonitor(configuration, _clientTransactionIdGenerator, _commandSender, safetyMonitorLogger);
                    return (T) safetyMonitor;
                
                case DeviceType.Dome:
                    ILogger<Dome> domeLogger = _loggerFactory.CreateLogger<Dome>();
                    IDevice dome = new Dome(configuration, _clientTransactionIdGenerator, _commandSender, domeLogger);
                    return (T) dome;
                
                case DeviceType.Camera:
                    ILogger<SafetyMonitor> cameraLogger = _loggerFactory.CreateLogger<SafetyMonitor>();
                    IDevice camera = new Camera(configuration, _clientTransactionIdGenerator, _commandSender, cameraLogger);
                    return (T) camera;
                
                case DeviceType.Focuser:
                    ILogger<Focuser> focuserLogger = _loggerFactory.CreateLogger<Focuser>();
                    IDevice focuser = new Focuser(configuration, _clientTransactionIdGenerator, _commandSender, focuserLogger);
                    return (T) focuser;
                
                case DeviceType.ObservingConditions:
                    ILogger<ObservingConditions> observingConditionsLogger = _loggerFactory.CreateLogger<ObservingConditions>();
                    IDevice observingConditions = new ObservingConditions(configuration, _clientTransactionIdGenerator, _commandSender, observingConditionsLogger);
                    return (T) observingConditions;
                
                case DeviceType.Switch:
                case DeviceType.Rotator:
                case DeviceType.Telescope:
                    throw new NotImplementedException(configuration.DeviceType.ToString());

                default:
                    throw new ArgumentOutOfRangeException(nameof(configuration.DeviceType));
            }
        }
    }
}