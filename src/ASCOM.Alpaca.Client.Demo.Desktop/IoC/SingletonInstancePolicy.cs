using System;
using System.Collections.Generic;
using System.Linq;
using ASCOM.Alpaca.Client.Devices;
using ASCOM.Alpaca.Client.Devices.Providers;
using ASCOM.Alpaca.Client.Request;
using ASCOM.Alpaca.Client.Transactions;
using Caliburn.Micro;
using Lamar;
using Lamar.IoC.Instances;
using Microsoft.Extensions.DependencyInjection;

namespace ASCOM.Alpaca.Client.Demo.Desktop.IoC
{
    public class SingletonInstancePolicy : IInstancePolicy
    {
        private static readonly List<Type> Interfaces = new List<Type>
        {
            typeof(IWindowManager),
            typeof(IEventAggregator),
            typeof(IDeviceProvider),
            typeof(IClientTransactionIdGenerator)
        };
        
        public void Apply(Instance instance)
        {
            if (Interfaces.Any(i => i.IsAssignableFrom(instance.ImplementationType)))
            {
                instance.Lifetime = ServiceLifetime.Singleton;
            }
        }
    }
}