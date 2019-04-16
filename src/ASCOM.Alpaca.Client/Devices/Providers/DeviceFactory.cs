using System;
using ASCOM.Alpaca.Client.Configuration;
using ASCOM.Alpaca.Client.Request;
using ASCOM.Alpaca.Client.Transactions;

namespace ASCOM.Alpaca.Client.Devices.Providers
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

        public T GetDevice<T>(DeviceConfiguration configuration) where T : IDevice
        {

            switch (configuration.DeviceType)
            {
                case DeviceType.FilterWheel:
                    IDevice device = new FilterWheel.FilterWheel(configuration, _clientTransactionIdGenerator, _commandSender);
                    return (T) device;

                case DeviceType.Switch:
                case DeviceType.SafetyMonitor:
                case DeviceType.Dome:
                case DeviceType.Camera:
                case DeviceType.ObservingConditions:
                case DeviceType.Focuser:
                case DeviceType.Rotator:
                case DeviceType.Telescope:
                    throw new NotImplementedException(configuration.DeviceType.ToString());

                default:
                    throw new ArgumentOutOfRangeException(nameof(configuration.DeviceType));
            }
        }
    }
}