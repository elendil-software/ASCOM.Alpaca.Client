using System;
using System.Collections.Generic;
using System.Linq;
using AscomAlpacaClient.Request;
using Caliburn.Micro;
using Lamar;
using Lamar.IoC.Instances;
using Microsoft.Extensions.DependencyInjection;

namespace AscomAlpacaClient.Demo.Desktop.IoC
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