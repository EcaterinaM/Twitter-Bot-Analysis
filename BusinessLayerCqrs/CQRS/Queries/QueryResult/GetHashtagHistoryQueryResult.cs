using Cqrs.Queries.Interfaces;
using DomainModels.Models.Twitter;
using System.Collections.Generic;

namespace BusinessLayerCqrs.CQRS.Queries.QueryResult
{
    public class GetHashtagHistoryQueryResult : IQueryResult
    {
        public IList<HashtagHistoryModel> HashtagHistoryModel;

        public GetHashtagHistoryQueryResult(IList<HashtagHistoryModel> hashtagHistoryModel)
        {
            HashtagHistoryModel = hashtagHistoryModel;
        }
    }
}
