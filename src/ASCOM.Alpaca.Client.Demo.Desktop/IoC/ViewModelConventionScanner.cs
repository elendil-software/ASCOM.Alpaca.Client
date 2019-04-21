using System;
using System.Linq;
using Lamar;
using Lamar.Scanning;
using Lamar.Scanning.Conventions;
using Microsoft.Extensions.DependencyInjection;

namespace ASCOM.Alpaca.Client.Demo.Desktop.IoC
{
    public class ViewModelConventionScanner : IRegistrationConvention
    {
        public OverwriteBehavior Overwrites { get; set; } = OverwriteBehavior.NewType;
        
        public void ScanTypes(TypeSet types, ServiceRegistry services)
        {
            foreach (var type in types.FindTypes(TypeClassification.Concretes).Where(type => type.Name.EndsWith("ViewModel") && type.GetConstructors().Any()))
            {
                if (type != null && ShouldAdd(services, type, type))
                {
                    services.AddTransient(type, type);
                }
            }
        }

        public bool ShouldAdd(IServiceCollection services, Type serviceType, Type implementationType)
        {
            if (Overwrites == OverwriteBehavior.Always) return true;
            
            var matches = services.Where(x => x.ServiceType == serviceType).ToArray();
            if (!matches.Any()) return true;

            if (Overwrites == OverwriteBehavior.Never) return false;

            var hasMatch = matches.Any(x => x.Matches(serviceType, implementationType));

            return !hasMatch;

        }

        public override string ToString()
        {
            return "ViewModel registration convention";
        }
    }
}