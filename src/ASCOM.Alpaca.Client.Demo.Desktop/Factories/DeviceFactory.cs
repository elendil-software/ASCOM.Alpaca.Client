using System;
using AscomAlpacaClient.Devices;
using AscomAlpacaClient.Request;

namespace AscomAlpacaClient.Demo.Desktop.Factories
{
    public class DeviceFactory : IDeviceFactory
    {
        private readonly IClientTransactionIdGenerator _clientTransactionIdGenerator;

        public DeviceFactory(IClientTransactionIdGenerator clientTransactionIdGenerator)
        {
            _clientTransactionIdGenerator = clientTransactionIdGenerator ?? throw new ArgumentNullException(nameof(clientTransactionIdGenerator));
        }
        
        public T CreateDeviceInstance<T>(DeviceConfiguration configuration) where T : IDevice
        {
            Type deviceType = typeof(T);
            
            switch (deviceType.Name)
            {
                case nameof(FilterWheel):
                    IDevice device = new FilterWheel(configuration, _clientTransactionIdGenerator);
                    return (T) device;

                case nameof(SafetyMonitor):
                    IDevice safetyMonitor = new SafetyMonitor(configuration, _clientTransactionIdGenerator);
                    return (T) safetyMonitor;
                
                case nameof(Dome):
                    IDevice dome = new Dome(configuration, _clientTransactionIdGenerator);
                    return (T) dome;
                
                case nameof(Camera):
                    IDevice camera = new Camera(configuration, _clientTransactionIdGenerator);
                    return (T) camera;
                
                case nameof(Focuser):
                    IDevice focuser = new Focuser(configuration, _clientTransactionIdGenerator);
                    return (T) focuser;
                
                case nameof(ObservingConditions):
                    IDevice observingConditions = new ObservingConditions(configuration, _clientTransactionIdGenerator);
                    return (T) observingConditions;
                
                case nameof(Rotator):
                    IDevice rotator = new Rotator(configuration,  _clientTransactionIdGenerator);
                    return (T) rotator;
                
                case nameof(Switch):
                    IDevice @switch = new Switch(configuration, _clientTransactionIdGenerator);
                    return (T) @switch;
                
                case nameof(Telescope):
                    IDevice telescope = new Telescope(configuration, _clientTransactionIdGenerator);
                    return (T) telescope;

                default:
                    throw new InvalidOperationException($"Type {deviceType.Name} is not supported");
            }
        }
    }
}