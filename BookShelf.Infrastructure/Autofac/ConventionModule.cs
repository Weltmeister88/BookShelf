using System;
using Autofac;

namespace BookShelf.Infrastructure.Autofac
{
    public class ConventionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.EndsWith("Service", StringComparison.Ordinal))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.EndsWith("Repository", StringComparison.Ordinal))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
