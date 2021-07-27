using System.Linq;
using System.Reflection;
using Autofac;

namespace BookShelf.Web.Autofac
{
    public static class IoCConfig
    {
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
    }
}