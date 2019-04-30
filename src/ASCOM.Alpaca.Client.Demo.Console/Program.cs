using System;
using System.IO;
using ASCOM.Alpaca.Client.Demo.Devices;
using ASCOM.Alpaca.Client.Demo.IoC;
using ASCOM.Alpaca.Client.Devices;
using ASCOM.Alpaca.Client.Request;
using ASCOM.Alpaca.Client.Transactions;
using ASCOM.Alpaca.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using ILogger = ASCOM.Alpaca.Logging.ILogger;

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
            
            Log.CloseAndFlush();
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
                .AddLogging(configure => configure.AddSerilog())
                .AddTransient<ILogger>(s => new SerilogAdapter(Log.Logger))
                .AddSingleton<IClientTransactionIdGenerator, ClientTransactionIdGenerator>()
                .AddTransient<ICommandSender, CommandSender>()
                .AddDevices(devicesConfiguration)
                .AddSingleton<IDeviceProvider, DeviceProvider>()
                .AddTransient<IDeviceDemo, DomeDemo>();
        }
    }
}