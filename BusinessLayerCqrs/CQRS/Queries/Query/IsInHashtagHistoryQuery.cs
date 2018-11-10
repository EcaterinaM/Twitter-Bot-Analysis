using BusinessLayerCqrs.CQRS.Queries.QueryResult;
using Cqrs.Queries.Interfaces;

namespace BusinessLayerCqrs.CQRS.Queries.Query
{
    public class IsInHashtagHistoryQuery : IQuery<IsInHashtagHistoryQueryResult>
    {
        public string HashtagValue { get; set; }

        public IsInHashtagHistoryQuery(string hashtagValue)
        {
            HashtagValue = hashtagValue;
        }
    }
}
