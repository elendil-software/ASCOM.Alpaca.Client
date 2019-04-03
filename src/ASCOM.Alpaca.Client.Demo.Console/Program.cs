using System;
using System.IO;
using ASCOM.Alpaca.Client.Configuration;
using ASCOM.Alpaca.Client.Devices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.AspNetCore;

namespace ASCOM.Alpaca.Client.Demo
{
    static class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            IConfiguration config = BuildConfiguration();
            ConfigureLogger(config);
            ConfigureServices(serviceCollection, config);
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            
            foreach (IDeviceDemo deviceDemo in serviceProvider.GetServices<IDeviceDemo>())
            {
                deviceDemo.Run();
            }
            
            Console.ReadKey();
        }

        private static IConfiguration BuildConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppContext.BaseDirectory))
                .AddJsonFile("appsettings.json", optional: false)
                .Build();
        }

        private static void ConfigureLogger(IConfiguration config)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .CreateLogger();
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            DevicesConfiguration devicesConfiguration = new DevicesConfiguration();
            configuration.Bind(devicesConfiguration);

            services
                .Configure<DeviceConfiguration>("FilterWheel", configuration.GetSection("Devices:FilterWheel"))
                .AddSingleton<ILoggerFactory>(s => new SerilogLoggerFactory(Log.Logger, true))
                .AddLogging(configure => configure.AddSerilog())
                .AddDevices(devicesConfiguration)
                .AddTransient<IDeviceDemo, FilterWheelDemo>();
        }

        private static IServiceCollection AddDevices(this IServiceCollection services, DevicesConfiguration devicesConfiguration)
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