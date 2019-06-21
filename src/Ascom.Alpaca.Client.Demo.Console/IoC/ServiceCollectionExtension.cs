using System.ComponentModel;
using ES.Ascom.Alpaca.Client.Demo.Console.Devices;
using ES.Ascom.Alpaca.Client.Devices;
using ES.Ascom.Alpaca.Client.Request;
using ES.Ascom.Alpaca.Devices;
using Microsoft.Extensions.DependencyInjection;

namespace ES.Ascom.Alpaca.Client.Demo.Console.IoC
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
                    
                    switch (deviceConfiguration.DeviceType)
                    {
                        case DeviceType.FilterWheel:
                            return new FilterWheel(deviceConfiguration, clientTransactionIdGenerator);
                        
                        case DeviceType.Switch:
                            return new Switch(deviceConfiguration, clientTransactionIdGenerator);
                            
                        case DeviceType.SafetyMonitor:
                            return new SafetyMonitor(deviceConfiguration, clientTransactionIdGenerator);
                            
                        case DeviceType.Dome:
                            return new Dome(deviceConfiguration, clientTransactionIdGenerator);

                        case DeviceType.Camera:
                            return new Camera(deviceConfiguration, clientTransactionIdGenerator);
                            
                        case DeviceType.ObservingConditions:
                            return new ObservingConditions(deviceConfiguration, clientTransactionIdGenerator);

                        case DeviceType.Focuser:
                            return new Focuser(deviceConfiguration, clientTransactionIdGenerator);

                        case DeviceType.Rotator:
                            return new Rotator(deviceConfiguration, clientTransactionIdGenerator);

                        case DeviceType.Telescope:
                            return new Telescope(deviceConfiguration, clientTransactionIdGenerator);
                        
                        default:
                            throw new InvalidEnumArgumentException(deviceConfiguration.DeviceType.ToString());
                    }
                });
            }
            
            return services;
        }
    }
}