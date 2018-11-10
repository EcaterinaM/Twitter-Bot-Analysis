using Autofac;
using AutoMapper;
using Infrastructure.Automapper.Profiles;

namespace Infrastructure.Automapper
{
    public class AutomapperConfig
    {
        public AutomapperConfig(ContainerBuilder builder)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<HashtagHistoryProfile>();
            });

            var mapper = config.CreateMapper();

            builder.RegisterInstance(config)
              .As<AutoMapper.IConfigurationProvider>();

            builder.Register(context =>
            {
                var provider = context.Resolve<AutoMapper.IConfigurationProvider>();
                var resolver = context.Resolve<IComponentContext>();
                return new Mapper(provider, type => resolver.Resolve(type));
            }).As<IMapper>();

        }

    }
}
