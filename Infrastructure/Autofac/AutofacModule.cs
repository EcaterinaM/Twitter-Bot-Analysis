using Autofac;
using DataCore;

namespace Infrastructure.Autofac
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<RepositoriesAutofac>();
            builder.RegisterModule<ServicesAutofacModule>();
            builder.RegisterModule<CqrsAutofacModule>();

        }
    }
}
