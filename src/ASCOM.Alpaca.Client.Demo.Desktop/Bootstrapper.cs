using System;
using System.Collections.Generic;
using System.Windows;
using ASCOM.Alpaca.Client.Demo.Desktop.ViewModels;
using ASCOM.Alpaca.Client.Devices.Providers;
using ASCOM.Alpaca.Client.Request;
using ASCOM.Alpaca.Client.Transactions;
using Caliburn.Micro;
using Lamar;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.AspNetCore;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace ASCOM.Alpaca.Client.Demo.Desktop
{
    public class Bootstrapper : BootstrapperBase
    {
        private Container _container;

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            var registry = new ServiceRegistry();

            registry.AddSingleton<IWindowManager, WindowManager>();
            registry.AddSingleton<IEventAggregator, EventAggregator>();
            registry.AddSingleton<IDeviceFactory, DeviceFactory>();
            registry.AddSingleton<ICommandSender, CommandSender>();
            registry.AddSingleton<IClientTransactionIdGenerator, ClientTransactionIdGenerator>();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Debug()
                .WriteTo.File("Log-.json", rollingInterval:RollingInterval.Day)
                .CreateLogger();
            registry.AddSingleton<ILoggerFactory>(s => new SerilogLoggerFactory(Log.Logger, true));
            registry.For(typeof(ILogger<>)).Use(typeof(Logger<>));

            registry.AddTransient<ShellViewModel, ShellViewModel>();
            registry.AddTransient<FilterWheelViewModel, FilterWheelViewModel>();

            _container = new Container(registry);
        }

        protected override object GetInstance(Type service, string key)
        {
            return string.IsNullOrEmpty(key) ? _container.GetInstance(service) : _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return (IEnumerable<object>) _container.GetAllInstances(service);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}