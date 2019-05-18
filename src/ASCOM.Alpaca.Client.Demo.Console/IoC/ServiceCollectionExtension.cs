using System.ComponentModel;
using ASCOM.Alpaca.Client.Demo.Devices;
using ASCOM.Alpaca.Client.Devices;
using ASCOM.Alpaca.Client.Request;
using ASCOM.Alpaca.Client.Transactions;
using Microsoft.Extensions.DependencyInjection;

namespace ASCOM.Alpaca.Client.Demo.IoC
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDevices(this IServiceCollection services, DevicesConfiguration devicesConfiguration)
        {
            foreach (var deviceConfiguration in devicesConfiguration.Devices)
            {
                services.AddScoped<IDevice>(ctx =>
                {
                    var clientTransactionIdGenerator = ctx.GetService<IClientTransactionIdGenerator>();
                    var commandSender = ctx.GetService<ICommandSender>();
                    
                    switch (deviceConfiguration.DeviceType)
                    {
                        case DeviceType.FilterWheel:
                            return new FilterWheel(deviceConfiguration, clientTransactionIdGenerator, commandSender);
                        
                        case DeviceType.Switch:
                            return new Switch(deviceConfiguration, clientTransactionIdGenerator, commandSender);
                            
                        case DeviceType.SafetyMonitor:
                            return new SafetyMonitor(deviceConfiguration, clientTransactionIdGenerator, commandSender);
                            
                        case DeviceType.Dome:
                            return new Dome(deviceConfiguration, clientTransactionIdGenerator, commandSender);

                        case DeviceType.Camera:
                            return new Camera(deviceConfiguration, clientTransactionIdGenerator, commandSender);
                            
                        case DeviceType.ObservingConditions:
                            return new ObservingConditions(deviceConfiguration, clientTransactionIdGenerator, commandSender);

                        case DeviceType.Focuser:
                            return new Focuser(deviceConfiguration, clientTransactionIdGenerator, commandSender);

                        case DeviceType.Rotator:
                            return new Rotator(deviceConfiguration, clientTransactionIdGenerator, commandSender);

                        case DeviceType.Telescope:
                            return new Telescope(deviceConfiguration, clientTransactionIdGenerator, commandSender);
                        
                        default:
                            throw new InvalidEnumArgumentException(deviceConfiguration.DeviceType.ToString());
                    }
                });
            }
            
            return services;
        }
    }
}