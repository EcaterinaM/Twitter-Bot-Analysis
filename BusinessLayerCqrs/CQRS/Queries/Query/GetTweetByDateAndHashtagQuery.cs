using BusinessLayerCqrs.CQRS.Queries.QueryResult;
using Cqrs.Queries.Interfaces;
using System;

namespace BusinessLayerCqrs.CQRS.Queries.Query
{
    public class GetTweetByDateAndHashtagQuery : IQuery<GetTweetByDateAndHashtagQueryResult>
    {
        public DateTime Date { get; set; }

        public string Hashtag { get; set; }

        public GetTweetByDateAndHashtagQuery(DateTime date, string hashtag)
        {
            Date = date;
            Hashtag = hashtag;
        }
    }
}
