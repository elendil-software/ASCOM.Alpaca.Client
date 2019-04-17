using System;
using ASCOM.Alpaca.Client.Configuration;
using ASCOM.Alpaca.Client.Request;
using ASCOM.Alpaca.Client.Transactions;
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

        public T GetDevice<T>(DeviceConfiguration configuration) where T : IDevice
        {

            switch (configuration.DeviceType)
            {
                case DeviceType.FilterWheel:
                    //TODO : handle the case without logger
                    ILogger<FilterWheel.FilterWheel> logger = _loggerFactory.CreateLogger<FilterWheel.FilterWheel>();
                    IDevice device = new FilterWheel.FilterWheel(configuration, _clientTransactionIdGenerator, _commandSender, logger);
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