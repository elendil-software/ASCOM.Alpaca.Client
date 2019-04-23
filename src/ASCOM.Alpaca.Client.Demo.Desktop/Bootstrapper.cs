using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using ASCOM.Alpaca.Client.Demo.Desktop.IoC;
using ASCOM.Alpaca.Client.Demo.Desktop.ViewModels;
using ASCOM.Alpaca.Client.Devices;
using Caliburn.Micro;
using Lamar;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.AspNetCore;

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
            
            registry.Policies.Add<SingletonInstancePolicy>();
            
            registry.Scan(s =>
            {
                s.AssemblyContainingType(typeof(Bootstrapper));
                s.AssemblyContainingType(typeof(DeviceBase));
                s.AssemblyContainingType(typeof(BootstrapperBase));
                s.AssemblyContainingType(typeof(EventAggregator));

                s.Convention<ViewModelConventionScanner>();
                s.WithDefaultConventions();    
            });
            
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Debug()
                .WriteTo.File("Log-.json", rollingInterval:RollingInterval.Day)
                .CreateLogger();
            registry.AddSingleton<ILoggerFactory>(s => new SerilogLoggerFactory(Log.Logger, true));
            registry.For(typeof(ILogger<>)).Use(typeof(Logger<>));
            
            _container = new Container(registry);
            
            #if DEBUG
            Debug.Write(_container.WhatDidIScan());
            Debug.Write(_container.WhatDoIHave());
            #endif
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