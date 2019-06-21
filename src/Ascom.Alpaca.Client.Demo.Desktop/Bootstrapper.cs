using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using Caliburn.Micro;
using ES.Ascom.Alpaca.Client.Demo.Desktop.Converters;
using ES.Ascom.Alpaca.Client.Demo.Desktop.IoC;
using ES.Ascom.Alpaca.Client.Demo.Desktop.ViewModels;
using ES.Ascom.Alpaca.Client.Devices;
using ES.Ascom.Alpaca.Client.Logging;
using Lamar;
using Serilog;

namespace ES.Ascom.Alpaca.Client.Demo.Desktop
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
            
            registry.For<Logging.ILogger>().Use(c => new SerilogAdapter(Log.Logger));

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