using Autofac;
using AutoMapper;
using BookShelf.Web.DTOs;

namespace BookShelf.Web.Autofac
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var mapperConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });

            builder.RegisterInstance(mapperConfig.CreateMapper())
                .As<IMapper>()
                .SingleInstance();
        }
    }
}