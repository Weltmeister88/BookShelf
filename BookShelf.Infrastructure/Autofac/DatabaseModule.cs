using Autofac;
using BookShelf.Core.Repositories;
using BookShelf.Infrastructure.Database;
using BookShelf.Infrastructure.Repositories;

namespace BookShelf.Infrastructure.Autofac
{
    public class DatabaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>()
                .InstancePerLifetimeScope();

            builder.RegisterType<DbInitializer>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();
        }
    }
}