using Autofac;
using BusinessLayerServices.AzureServices.Implementation;
using BusinessLayerServices.AzureServices.Interfaces;
using BusinessLayerServices.HelperServices;
using BusinessLayerServices.SentimentAnalysisServices.Implementation;
using BusinessLayerServices.SentimentAnalysisServices.Interfaces;
using BusinessLayerServices.TwitterServices;
using BusinessLayerServices.TwitterServices.Implementation;
using BusinessLayerServices.TwitterServices.Interfaces;

namespace Infrastructure.Autofac
{
    public class ServicesAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TwitterService>()
                .As<ITwitterDataService>();

            builder.RegisterType<SentimentService>()
                .As<ISentimentService>();

            builder.RegisterType<AzureServices>()
                .As<IAzureServices>();

            builder.RegisterType<HelperServices>()
                .As<IHelperService>();

            builder.RegisterType<TwitterUserService>()
                .As<ITwitterUserService>();

        }
    }
}
