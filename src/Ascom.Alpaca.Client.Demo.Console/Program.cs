using System;
using System.IO;
using ES.Ascom.Alpaca.Client.Demo.Console.Devices;
using ES.Ascom.Alpaca.Client.Demo.Console.IoC;
using ES.Ascom.Alpaca.Client.Devices;
using ES.Ascom.Alpaca.Client.Request;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.AspNetCore;

namespace ES.Ascom.Alpaca.Client.Demo.Console
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
            
            Log.CloseAndFlush();
            System.Console.ReadKey();
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
                .AddLogging(configure => configure.AddSerilog())
                .AddSingleton<ILoggerFactory>(s => new SerilogLoggerFactory(Log.Logger, true))
                .AddSingleton<IClientTransactionIdGenerator, ClientTransactionIdGenerator>()
                .AddDevices(devicesConfiguration)
                .AddSingleton<IDeviceProvider, DeviceProvider>()
                .AddTransient<IDeviceDemo, DomeDemo>();
        }
    }
}