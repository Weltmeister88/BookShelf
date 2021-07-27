using Autofac;
using BookShelf.Infrastructure.Database;

namespace BookShelf.Infrastructure.Autofac
{
    public class DatabaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}