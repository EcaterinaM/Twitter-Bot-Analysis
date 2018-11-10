using AutoMapper;
using BusinessLayerCqrs.CQRS.Queries.Query;
using BusinessLayerCqrs.CQRS.Queries.QueryResult;
using Cqrs.Queries.Interfaces;
using DataCore.Repositories.Generic;
using DataDomain.DataModel;
using DomainModels.Models.Twitter;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayerCqrs.CQRS.Queries.QueryHandler
{
    public class GetHashtagHistoryQueryHandler : IQueryHandler<GetHashtgHistoryQuery, GetHashtagHistoryQueryResult>
    {
        private readonly IHashtagHistoryRepository _hashtagHistoryRepository;
        private readonly IMapper _mapper;

        public GetHashtagHistoryQueryHandler(
             IHashtagHistoryRepository hashtagHistoryRepository,
             IMapper mapper)
        {
            _hashtagHistoryRepository = hashtagHistoryRepository;
            _mapper = mapper;
        }

        public GetHashtagHistoryQueryResult Execute(GetHashtgHistoryQuery query)
        {
            var list = _hashtagHistoryRepository
                        .GetByHashtagValuePaginated(query.HashtagValue, query.PageNumber)
                        .ToList();

            var hashtagHistoryList = _mapper.Map<IList<HashtagHistory>, IList<HashtagHistoryModel>>(list);
            return new GetHashtagHistoryQueryResult(hashtagHistoryList);
           
        }
    }
}
