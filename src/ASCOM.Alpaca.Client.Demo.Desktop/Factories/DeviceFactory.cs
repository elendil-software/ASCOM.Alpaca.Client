using System;
using ASCOM.Alpaca.Client.Devices;
using ASCOM.Alpaca.Client.Request;
using ASCOM.Alpaca.Client.Transactions;
using Microsoft.Extensions.Logging;

namespace ASCOM.Alpaca.Client.Demo.Desktop.Factories
{
    public class DeviceFactory : IDeviceFactory
    {
        private readonly IClientTransactionIdGenerator _clientTransactionIdGenerator;
        private readonly ICommandSender _commandSender;
        private readonly ILoggerFactory _loggerFactory;

        public DeviceFactory(IClientTransactionIdGenerator clientTransactionIdGenerator, ICommandSender commandSender, ILoggerFactory loggerFactory)
        {
            _clientTransactionIdGenerator = clientTransactionIdGenerator ?? throw new ArgumentNullException(nameof(clientTransactionIdGenerator));
            _commandSender = commandSender ?? throw new ArgumentNullException(nameof(commandSender));
            _loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));
        }

        public T CreateDeviceInstance<T>(DeviceConfiguration configuration) where T : IDevice
        {
            Type deviceType = typeof(T);
            
            switch (deviceType.Name)
            {
                case nameof(FilterWheel):
                    ILogger<FilterWheel> logger = _loggerFactory.CreateLogger<FilterWheel>();
                    IDevice device = new FilterWheel(configuration, _clientTransactionIdGenerator, _commandSender, logger);
                    return (T) device;

                case nameof(SafetyMonitor):
                    ILogger<SafetyMonitor> safetyMonitorLogger = _loggerFactory.CreateLogger<SafetyMonitor>();
                    IDevice safetyMonitor = new SafetyMonitor(configuration, _clientTransactionIdGenerator, _commandSender, safetyMonitorLogger);
                    return (T) safetyMonitor;
                
                case nameof(Dome):
                    ILogger<Dome> domeLogger = _loggerFactory.CreateLogger<Dome>();
                    IDevice dome = new Dome(configuration, _clientTransactionIdGenerator, _commandSender, domeLogger);
                    return (T) dome;
                
                case nameof(Camera):
                    ILogger<SafetyMonitor> cameraLogger = _loggerFactory.CreateLogger<SafetyMonitor>();
                    IDevice camera = new Camera(configuration, _clientTransactionIdGenerator, _commandSender, cameraLogger);
                    return (T) camera;
                
                case nameof(Focuser):
                    ILogger<Focuser> focuserLogger = _loggerFactory.CreateLogger<Focuser>();
                    IDevice focuser = new Focuser(configuration, _clientTransactionIdGenerator, _commandSender, focuserLogger);
                    return (T) focuser;
                
                case nameof(ObservingConditions):
                    ILogger<ObservingConditions> observingConditionsLogger = _loggerFactory.CreateLogger<ObservingConditions>();
                    IDevice observingConditions = new ObservingConditions(configuration, _clientTransactionIdGenerator, _commandSender, observingConditionsLogger);
                    return (T) observingConditions;
                
                case nameof(Rotator):
                    ILogger<Rotator> rotatorLogger = _loggerFactory.CreateLogger<Rotator>();
                    IDevice rotator = new Rotator(configuration, _clientTransactionIdGenerator, _commandSender, rotatorLogger);
                    return (T) rotator;
                
                case nameof(Switch):
                    ILogger<Switch> switchLogger = _loggerFactory.CreateLogger<Switch>();
                    IDevice @switch = new Switch(configuration, _clientTransactionIdGenerator, _commandSender, switchLogger);
                    return (T) @switch;
                
                case nameof(Telescope):
                    ILogger<Rotator> telescopeLogger = _loggerFactory.CreateLogger<Rotator>();
                    IDevice telescope = new Telescope(configuration, _clientTransactionIdGenerator, _commandSender, telescopeLogger);
                    return (T) telescope;

                default:
                    throw new InvalidOperationException($"Type {deviceType.Name} is not supported");
            }
        }
    }
}