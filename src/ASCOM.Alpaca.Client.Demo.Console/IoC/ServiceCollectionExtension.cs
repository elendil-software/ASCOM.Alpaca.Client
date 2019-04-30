using System.ComponentModel;
using ASCOM.Alpaca.Client.Demo.Devices;
using ASCOM.Alpaca.Client.Devices;
using ASCOM.Alpaca.Client.Request;
using ASCOM.Alpaca.Client.Transactions;
using ASCOM.Alpaca.Devices;
using Microsoft.Extensions.DependencyInjection;
using ASCOM.Alpaca.Logging;

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
                            return new FilterWheel(deviceConfiguration, clientTransactionIdGenerator, commandSender, ctx.GetService<ILogger>());
                        
                        case DeviceType.Switch:
                            return new Switch(deviceConfiguration, clientTransactionIdGenerator, commandSender, ctx.GetService<ILogger>());
                            
                        case DeviceType.SafetyMonitor:
                            return new SafetyMonitor(deviceConfiguration, clientTransactionIdGenerator, commandSender, ctx.GetService<ILogger>());
                            
                        case DeviceType.Dome:
                            return new Dome(deviceConfiguration, clientTransactionIdGenerator, commandSender, ctx.GetService<ILogger>());

                        case DeviceType.Camera:
                            return new Camera(deviceConfiguration, clientTransactionIdGenerator, commandSender, ctx.GetService<ILogger>());
                            
                        case DeviceType.ObservingConditions:
                            return new ObservingConditions(deviceConfiguration, clientTransactionIdGenerator, commandSender, ctx.GetService<ILogger>());

                        case DeviceType.Focuser:
                            return new Focuser(deviceConfiguration, clientTransactionIdGenerator, commandSender, ctx.GetService<ILogger>());

                        case DeviceType.Rotator:
                            return new Rotator(deviceConfiguration, clientTransactionIdGenerator, commandSender, ctx.GetService<ILogger>());

                        case DeviceType.Telescope:
                            return new Telescope(deviceConfiguration, clientTransactionIdGenerator, commandSender, ctx.GetService<ILogger>());
                        
                        default:
                            throw new InvalidEnumArgumentException(deviceConfiguration.DeviceType.ToString());
                    }
                });
            }
            
            return services;
        }
    }
}