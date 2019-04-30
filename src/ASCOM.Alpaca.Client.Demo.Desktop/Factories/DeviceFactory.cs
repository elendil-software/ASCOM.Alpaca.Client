using System;
using ASCOM.Alpaca.Client.Devices;
using ASCOM.Alpaca.Client.Request;
using ASCOM.Alpaca.Client.Transactions;
using ASCOM.Alpaca.Logging;

namespace ASCOM.Alpaca.Client.Demo.Desktop.Factories
{
    public class DeviceFactory : IDeviceFactory
    {
        private readonly IClientTransactionIdGenerator _clientTransactionIdGenerator;
        private readonly ICommandSender _commandSender;
        private readonly ILogger _logger;

        public DeviceFactory(IClientTransactionIdGenerator clientTransactionIdGenerator, ICommandSender commandSender)
        {
            _clientTransactionIdGenerator = clientTransactionIdGenerator ?? throw new ArgumentNullException(nameof(clientTransactionIdGenerator));
            _commandSender = commandSender ?? throw new ArgumentNullException(nameof(commandSender));
        }

        public DeviceFactory(IClientTransactionIdGenerator clientTransactionIdGenerator, ICommandSender commandSender, ILogger logger)
        {
            _clientTransactionIdGenerator = clientTransactionIdGenerator ?? throw new ArgumentNullException(nameof(clientTransactionIdGenerator));
            _commandSender = commandSender ?? throw new ArgumentNullException(nameof(commandSender));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public T CreateDeviceInstance<T>(DeviceConfiguration configuration) where T : IDevice
        {
            Type deviceType = typeof(T);
            
            switch (deviceType.Name)
            {
                case nameof(FilterWheel):
                    IDevice device = new FilterWheel(configuration, _clientTransactionIdGenerator, _commandSender, _logger);
                    return (T) device;

                case nameof(SafetyMonitor):
                    IDevice safetyMonitor = new SafetyMonitor(configuration, _clientTransactionIdGenerator, _commandSender, _logger);
                    return (T) safetyMonitor;
                
                case nameof(Dome):
                    IDevice dome = new Dome(configuration, _clientTransactionIdGenerator, _commandSender, _logger);
                    return (T) dome;
                
                case nameof(Camera):
                    IDevice camera = new Camera(configuration, _clientTransactionIdGenerator, _commandSender, _logger);
                    return (T) camera;
                
                case nameof(Focuser):
                    IDevice focuser = new Focuser(configuration, _clientTransactionIdGenerator, _commandSender, _logger);
                    return (T) focuser;
                
                case nameof(ObservingConditions):
                    IDevice observingConditions = new ObservingConditions(configuration, _clientTransactionIdGenerator, _commandSender, _logger);
                    return (T) observingConditions;
                
                case nameof(Rotator):
                    IDevice rotator = new Rotator(configuration, _clientTransactionIdGenerator, _commandSender, _logger);
                    return (T) rotator;
                
                case nameof(Switch):
                    IDevice @switch = new Switch(configuration, _clientTransactionIdGenerator, _commandSender, _logger);
                    return (T) @switch;
                
                case nameof(Telescope):
                    IDevice telescope = new Telescope(configuration, _clientTransactionIdGenerator, _commandSender, _logger);
                    return (T) telescope;

                default:
                    throw new InvalidOperationException($"Type {deviceType.Name} is not supported");
            }
        }
    }
}