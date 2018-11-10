using Autofac;
using BusinessLayerCqrs.CQRS.Commands.Command;
using BusinessLayerCqrs.CQRS.Commands.CommandHandler;
using BusinessLayerCqrs.CQRS.Commands.Interfaces;
using BusinessLayerCqrs.CQRS.Queries;
using BusinessLayerCqrs.CQRS.Queries.Query;
using BusinessLayerCqrs.CQRS.Queries.QueryHandler;
using BusinessLayerCqrs.CQRS.Queries.QueryResult;
using Cqrs.Commands;
using Cqrs.Commands.Interfaces;
using Cqrs.Queries.Interfaces;

namespace Infrastructure.Autofac
{
    public class CqrsAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CommandDispatcher>()
            .As<ICommandDispatcher>();

            builder.RegisterType<AddHashtagHistoryCommand>()
                .As<ICommand>();
            builder.RegisterType<AddTweetCommand>()
                .As<ICommand>();
            builder.RegisterType<UpdateTweetCommand>()
               .As<ICommand>();
            builder.RegisterType<AddUserInformationCommand>()
             .As<ICommand>();

            builder.RegisterType<AddHashtagHistoryCommandHandler>()
                .As<ICommandHandler<AddHashtagHistoryCommand>>();
            builder.RegisterType<AddTweetCommandHandler>()
                .As<ICommandHandler<AddTweetCommand>>();
            builder.RegisterType<UpdateTweetCommandHandler>()
                .As<ICommandHandler<UpdateTweetCommand>>();
            builder.RegisterType<AddUserInformationCommandHandler>()
                .As<ICommandHandler<AddUserInformationCommand>>();


            builder.RegisterType<QueryDispatcher>()
             .As<IQueryDispatcher>();


            builder.RegisterType<GetHashtgHistoryQuery>()
                .As<IQuery<GetHashtagHistoryQueryResult>>();
            builder.RegisterType<IsInHashtagHistoryQuery>()
                .As<IQuery<IsInHashtagHistoryQueryResult>>();
            builder.RegisterType<GetTweetByDateAndHashtagQuery>()
                .As<IQuery<GetTweetByDateAndHashtagQueryResult>>();
            builder.RegisterType<GetUserInformationQuery>()
               .As<IQuery<GetUserInformationQueryResult>>();
            builder.RegisterType<GetUserInformationByUsernameQuery>()
              .As<IQuery<GetUserInformationByUsernameQueryResult>>();
            builder.RegisterType<GetUserInformationHistoryQuery>()
              .As<IQuery<GetUserInformationHistoryQueryResult>>();


            builder.RegisterType<GetHashtagHistoryQueryResult>()
                .As<IQueryResult>();
            builder.RegisterType<IsInHashtagHistoryQueryResult>()
                .As<IQueryResult>();
            builder.RegisterType<GetTweetByDateAndHashtagQueryResult>()
                .As<IQueryResult>();
            builder.RegisterType<GetUserInformationQueryResult>()
               .As<IQueryResult>();
            builder.RegisterType<GetUserInformationByUsernameQueryResult>()
               .As<IQueryResult>();
            builder.RegisterType<GetUserInformationHistoryQueryResult>()
               .As<IQueryResult>();

            builder.RegisterType<GetHashtagHistoryQueryHandler>()
               .As<IQueryHandler<GetHashtgHistoryQuery,GetHashtagHistoryQueryResult>>();
            builder.RegisterType<IsInHashtagHistoryQueryHandler>()
               .As<IQueryHandler<IsInHashtagHistoryQuery, IsInHashtagHistoryQueryResult>>();
            builder.RegisterType<GetTweetByDateAndHashtagQueryHandler>()
               .As<IQueryHandler<GetTweetByDateAndHashtagQuery, GetTweetByDateAndHashtagQueryResult>>();
            builder.RegisterType<GetUserInformationQueryHandler>()
               .As<IQueryHandler<GetUserInformationQuery, GetUserInformationQueryResult>>();
            builder.RegisterType<GetUserInformationByUsernameQueryHandler>()
               .As<IQueryHandler<GetUserInformationByUsernameQuery, GetUserInformationByUsernameQueryResult>>();
            builder.RegisterType<GetUserInformationHistoryQueryHandler>()
               .As<IQueryHandler<GetUserInformationHistoryQuery, GetUserInformationHistoryQueryResult>>();

        }
    }
}