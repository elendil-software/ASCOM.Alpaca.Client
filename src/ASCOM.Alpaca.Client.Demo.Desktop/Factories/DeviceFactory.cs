using System;
using ASCOM.Alpaca.Client.Devices;
using ASCOM.Alpaca.Client.Request;
using ASCOM.Alpaca.Client.Transactions;

namespace ASCOM.Alpaca.Client.Demo.Desktop.Factories
{
    public class DeviceFactory : IDeviceFactory
    {
        private readonly IClientTransactionIdGenerator _clientTransactionIdGenerator;
        private readonly ICommandSender _commandSender;

        public DeviceFactory(IClientTransactionIdGenerator clientTransactionIdGenerator, ICommandSender commandSender)
        {
            _clientTransactionIdGenerator = clientTransactionIdGenerator ?? throw new ArgumentNullException(nameof(clientTransactionIdGenerator));
            _commandSender = commandSender ?? throw new ArgumentNullException(nameof(commandSender));
        }
        
        public T CreateDeviceInstance<T>(DeviceConfiguration configuration) where T : IDevice
        {
            Type deviceType = typeof(T);
            
            switch (deviceType.Name)
            {
                case nameof(FilterWheel):
                    IDevice device = new FilterWheel(configuration, _clientTransactionIdGenerator, _commandSender);
                    return (T) device;

                case nameof(SafetyMonitor):
                    IDevice safetyMonitor = new SafetyMonitor(configuration, _clientTransactionIdGenerator, _commandSender);
                    return (T) safetyMonitor;
                
                case nameof(Dome):
                    IDevice dome = new Dome(configuration, _clientTransactionIdGenerator, _commandSender);
                    return (T) dome;
                
                case nameof(Camera):
                    IDevice camera = new Camera(configuration, _clientTransactionIdGenerator, _commandSender);
                    return (T) camera;
                
                case nameof(Focuser):
                    IDevice focuser = new Focuser(configuration, _clientTransactionIdGenerator, _commandSender);
                    return (T) focuser;
                
                case nameof(ObservingConditions):
                    IDevice observingConditions = new ObservingConditions(configuration, _clientTransactionIdGenerator, _commandSender);
                    return (T) observingConditions;
                
                case nameof(Rotator):
                    IDevice rotator = new Rotator(configuration, _clientTransactionIdGenerator, _commandSender);
                    return (T) rotator;
                
                case nameof(Switch):
                    IDevice @switch = new Switch(configuration, _clientTransactionIdGenerator, _commandSender);
                    return (T) @switch;
                
                case nameof(Telescope):
                    IDevice telescope = new Telescope(configuration, _clientTransactionIdGenerator, _commandSender);
                    return (T) telescope;

                default:
                    throw new InvalidOperationException($"Type {deviceType.Name} is not supported");
            }
        }
    }
}