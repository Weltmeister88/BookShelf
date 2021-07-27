using System.Linq;
using System.Reflection;
using Autofac;

namespace BookShelf.Web.Autofac
{
    public static class IoCConfig
    {
        public static ILifetimeScope Container { get; private set; } = BuildContainer();

        private static ILifetimeScope BuildContainer()
        {
            var builder = new ContainerBuilder();
            RegisterSolutionModules(
                builder); // note: register known types first because we need them to discover the plugin types
            return builder.Build();
        }

        public static void RegisterSolutionModules(ContainerBuilder builder)
        {
            var solutionAssemblyNames = new[]
            {
                "BookShelf.Web",
                "BookShelf.Core",
                "BookShelf.Infrastructure"
            };

            builder.RegisterAssemblyModules(solutionAssemblyNames.Select(Assembly.Load).ToArray());
        }

        public static void DeregisterContainer()
        {
            Container.Dispose();
            Container = null;
        }
    }
}