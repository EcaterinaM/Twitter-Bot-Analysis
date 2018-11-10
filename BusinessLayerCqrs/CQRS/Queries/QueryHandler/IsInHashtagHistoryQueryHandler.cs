using BusinessLayerCqrs.CQRS.Queries.Query;
using BusinessLayerCqrs.CQRS.Queries.QueryResult;
using Cqrs.Queries.Interfaces;
using DataCore.Repositories.Generic;

namespace BusinessLayerCqrs.CQRS.Queries.QueryHandler
{
    public class IsInHashtagHistoryQueryHandler : IQueryHandler<IsInHashtagHistoryQuery, IsInHashtagHistoryQueryResult>
    {
        private readonly IHashtagHistoryRepository _hashtagHistoryRepository;

        public IsInHashtagHistoryQueryHandler(IHashtagHistoryRepository hashtagHistoryRepository)
        {
            _hashtagHistoryRepository = hashtagHistoryRepository;
        }

        public IsInHashtagHistoryQueryResult Execute(IsInHashtagHistoryQuery query)
        {
            var value = _hashtagHistoryRepository.CheckIfIsInHashtagHistory(query.HashtagValue);
            return new IsInHashtagHistoryQueryResult(value);
        }
    }
}
