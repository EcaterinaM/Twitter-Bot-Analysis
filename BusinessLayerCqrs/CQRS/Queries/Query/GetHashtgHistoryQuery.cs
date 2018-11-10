using BusinessLayerCqrs.CQRS.Queries.QueryResult;

namespace BusinessLayerCqrs.CQRS.Queries.Query
{
    public class GetHashtgHistoryQuery : Cqrs.Queries.Interfaces.IQuery<GetHashtagHistoryQueryResult>
    {
        public string HashtagValue { get; set; }

        public int PageNumber { get; set; }

        public GetHashtgHistoryQuery(string hashtagValue, int pageNumber)
        {
            HashtagValue = hashtagValue;
            PageNumber = pageNumber;
        }
    }
}
