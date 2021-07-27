using System;
using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace BookShelf.Infrastructure.Autofac
{
    public class ConventionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            Assembly thisAssembly = ThisAssembly;
            builder.RegisterAssemblyTypes(thisAssembly)
                .Where(t => t.Name.EndsWith("Service", StringComparison.Ordinal))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(thisAssembly)
                .Where(t => t.Name.EndsWith("Repository", StringComparison.Ordinal))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
