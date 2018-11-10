using BusinessLayerCqrs.CQRS.Commands.Command;
using BusinessLayerCqrs.CQRS.Queries.Query;
using BusinessLayerCqrs.CQRS.Queries.QueryResult;
using BusinessLayerServices.TwitterServices;
using Cqrs.Commands.Interfaces;
using Cqrs.Queries.Interfaces;
using DomainModels.Models.Twitter;
using Microsoft.AspNetCore.Mvc;

namespace TweetApp.Api.Controllers
{

    [Route("api/bubblechart")]
    public class BubbleChartController : Controller
    {
        private readonly ITwitterDataService _twitterService;

        private readonly ICommandDispatcher _commandDispatcher;

        private readonly IQueryDispatcher _queryDispatcher;

        public BubbleChartController(ITwitterDataService twitterService,
            ICommandDispatcher commandDispatcher,
            IQueryDispatcher queryDispatcher)
        {
            _twitterService = twitterService;
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet("getTweetsByHashTag")]
        public IActionResult GetTweetsByHashTag(string hashtag = null)
        {
            var tweets = _twitterService.GetTweetListByHashtag(hashtag);

            var isInDb = _queryDispatcher.Execute<IsInHashtagHistoryQuery, IsInHashtagHistoryQueryResult>(new IsInHashtagHistoryQuery(hashtag));

            var sentimentAnalysisLists = _twitterService.GetSentimentAnalysisForBubbleChart(tweets);

            var command = new AddHashtagHistoryCommand(new HashtagHistoryModel()
            {
                HashtagValue = hashtag,
                NegativeSentimentCounter = sentimentAnalysisLists.BubbleChartNegative.Count,
                PositiveSentimentCounter = sentimentAnalysisLists.BubbleChartPositive.Count,
                NeutralSentimentCounter = sentimentAnalysisLists.BubbleChartNeutral.Count
            });
            _commandDispatcher.Execute(command);

            sentimentAnalysisLists.IsInHashtagHistory = isInDb.IsInHashtagHistory;
            return Ok(sentimentAnalysisLists);

        }
    }
}
