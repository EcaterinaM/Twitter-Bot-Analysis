using Cqrs.Queries.Interfaces;
using DomainModels.Models;
using System.Collections.Generic;

namespace BusinessLayerCqrs.CQRS.Queries.QueryResult
{
    public class GetTweetByDateAndHashtagQueryResult : IQueryResult
    {
        public List<TweetModel> TweetModelList { get; set; }

        public GetTweetByDateAndHashtagQueryResult(List<TweetModel> tweetModel)
        {
            TweetModelList = tweetModel;
        }

    }
}
