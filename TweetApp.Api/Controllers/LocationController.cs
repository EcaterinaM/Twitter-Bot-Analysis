using BusinessLayerCqrs.CQRS.Commands.Command;
using BusinessLayerServices.TwitterServices;
using Cqrs.Commands.Interfaces;
using DomainModels.Models.Twitter;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace TweetApp.Api.Controllers
{
    [Route("api/location")]
    public class LocationController: Controller
    {
        private readonly ITwitterDataService _twitterService;

        private readonly ICommandDispatcher _commandDispatcher;

        public LocationController(ITwitterDataService twitterService,
            ICommandDispatcher commandDispatcher)
        {
            _twitterService = twitterService;
            _commandDispatcher = commandDispatcher;
        }


        [HttpGet]
        public IActionResult GetTweetsByLocationAsync([FromQuery]string hashtag, [FromQuery]int count, [FromQuery]double latitude, [FromQuery]double longitude)
        {
            //40.730610
            //-73.935242
            var tweets = Search.SearchTweets(new SearchTweetsParameters(hashtag)
            {
                SearchType = SearchResultType.Recent,
                MaximumNumberOfResults = count,
                TweetSearchType = TweetSearchType.All,
                GeoCode = new GeoCode(latitude,longitude , 50, DistanceMeasure.Kilometers)
            });

            var result = _twitterService.GetSentimentAnalysisForListOfTweetWithoutComments(tweets.ToList());

            if(result.Count != 0)
            {
                var neutral = 0;
                var positive = 0;
                var negative = 0;

                foreach(var item in result)
                {
                    if (item.SentimentObjectModel.SentimentType.Equals("Neutral"))
                    {
                        neutral++;
                    }

                    if (item.SentimentObjectModel.SentimentType.Equals("Positive"))
                    {
                        positive++;
                    }

                    if (item.SentimentObjectModel.SentimentType.Equals("Negative"))
                    {
                        negative++;
                    }
                }
                var command = new AddHashtagHistoryCommand(new HashtagHistoryModel()
                {
                    HashtagValue = hashtag,
                    NegativeSentimentCounter = negative,
                    PositiveSentimentCounter = positive,
                    NeutralSentimentCounter = neutral
                });
                _commandDispatcher.Execute(command);
            }
            return Ok(result);
        }
    }
}
