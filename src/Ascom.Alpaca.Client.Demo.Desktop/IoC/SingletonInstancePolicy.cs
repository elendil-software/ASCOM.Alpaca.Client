using System;
using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using ES.Ascom.Alpaca.Client.Request;
using Lamar;
using Lamar.IoC.Instances;
using Microsoft.Extensions.DependencyInjection;

namespace ES.Ascom.Alpaca.Client.Demo.Desktop.IoC
{
    public class SingletonInstancePolicy : IInstancePolicy
    {
        private static readonly List<Type> Interfaces = new List<Type>
        {
            typeof(IWindowManager),
            typeof(IEventAggregator),
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