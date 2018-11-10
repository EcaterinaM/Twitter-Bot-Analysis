using Cqrs.Queries.Interfaces;

namespace BusinessLayerCqrs.CQRS.Queries.QueryResult
{
    public class IsInHashtagHistoryQueryResult : IQueryResult
    {
        public bool IsInHashtagHistory { get; set; }

        public IsInHashtagHistoryQueryResult(bool isInHashtagHistory)
        {
            IsInHashtagHistory = isInHashtagHistory;
        }
    }
}
