using System;
using ASCOM.Alpaca.Client.Configuration;
using ASCOM.Alpaca.Client.Devices;
using ASCOM.Alpaca.Client.Request;
using ASCOM.Alpaca.Client.Transactions;
using ASCOM.Alpaca.Devices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ASCOM.Alpaca.Client.DependencyInjection.Microsoft
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
                            return new FilterWheel(deviceConfiguration, clientTransactionIdGenerator, commandSender, ctx.GetService<ILogger<FilterWheel>>());
                        
                        case DeviceType.Switch:
                        case DeviceType.SafetyMonitor:
                        case DeviceType.Dome:
                            return new Dome(deviceConfiguration, clientTransactionIdGenerator, commandSender, ctx.GetService<ILogger<Dome>>());

                        case DeviceType.Camera:
                        case DeviceType.ObservingConditions:
                        case DeviceType.Focuser:
                        case DeviceType.Rotator:
                        case DeviceType.Telescope:
                            throw new NotImplementedException(deviceConfiguration.DeviceType.ToString());
                        
                        default:
                            throw new ArgumentOutOfRangeException(nameof(deviceConfiguration.DeviceType));
                    }
                });
            }
            
            return services;
        }
    }
}