using System;
using ASCOM.Alpaca.Client.Configuration;
using ASCOM.Alpaca.Client.Devices;
using ASCOM.Alpaca.Client.Transactions;
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
                    switch (deviceConfiguration.DeviceType)
                    {
                        case DeviceType.FilterWheel:
                            var logger = ctx.GetService<ILogger<FilterWheel>>();
                            var clientTransactionIdGenerator = ctx.GetService<IClientTransactionIdGenerator>();
                            return new FilterWheel(deviceConfiguration, clientTransactionIdGenerator, logger);
                        
                        case DeviceType.Switch:
                        case DeviceType.SafetyMonitor:
                        case DeviceType.Dome:
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