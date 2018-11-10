using Autofac;
using DataCore.Repositories.Generic;
using DataCore.Repositories.Implementation;
using DataCore.Respositories.Generic;
using DataDomain.DataModel;
using DataPersistance.Context;

namespace DataCore
{
    public class RepositoriesAutofac : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DatabaseContext>()
                .As<IDatabaseContext>();

            builder.RegisterType<BaseRepository<HashtagHistory>>()
                .As<IBaseRepository<HashtagHistory>>();
            builder.RegisterType<HashtagHistoryRepository>()
                .As<IHashtagHistoryRepository>();


            builder.RegisterType<BaseRepository<Tweet>>()
                .As<IBaseRepository<Tweet>>();

            builder.RegisterType<TweetRepository>()
                .As<ITweetRepository>();

            builder.RegisterType<UserInformationRepository>()
               .As<IUserInformationRepository>();
            builder.RegisterType<BaseRepository<UserInformation>>()
            .As<IBaseRepository<UserInformation>>();

        }
    }
}
