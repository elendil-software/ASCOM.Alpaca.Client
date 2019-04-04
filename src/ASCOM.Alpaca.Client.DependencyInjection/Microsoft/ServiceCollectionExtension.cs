using System;
using ASCOM.Alpaca.Client.Configuration;
using ASCOM.Alpaca.Client.Devices;
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
                services.AddScoped<IDeviceBase>(ctx =>
                {
                    switch (deviceConfiguration.DeviceType)
                    {
                        case DeviceType.FilterWheel:
                            var logger = ctx.GetService<ILogger<FilterWheel>>();
                            return new FilterWheel(deviceConfiguration, logger);
                        default:
                            throw new Exception("Unsupported device");
                    }
                });
            }
            
            return services;
        }
    }
}