using BusinessLayerCqrs.CQRS.Queries.Query;
using BusinessLayerCqrs.CQRS.Queries.QueryResult;
using Cqrs.Queries.Interfaces;
using DataCore.Repositories.Generic;
using System;

namespace BusinessLayerCqrs.CQRS.Queries.QueryHandler
{
    public class GetUserInformationHistoryQueryHandler : IQueryHandler<GetUserInformationHistoryQuery, GetUserInformationHistoryQueryResult>
    {
        private readonly IUserInformationRepository _userInformationRepository;

        public GetUserInformationHistoryQueryHandler(IUserInformationRepository userInformationRepository)
        {
            _userInformationRepository = userInformationRepository;
        }

        public GetUserInformationHistoryQueryResult Execute(GetUserInformationHistoryQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
