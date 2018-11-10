using BusinessLayerServices.TwitterServices;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Tweetinvi;

namespace TweetApp.Api.Controllers
{

    [Route("api/twitter")]
    public class TwitterController : Controller
    {
        private readonly ITwitterDataService _twitterService;

        public TwitterController(ITwitterDataService twitterService)
        {
            _twitterService = twitterService;
        }

        [HttpGet("{username}/username")]
        public IActionResult GetTimelineForSpecificUser(string username)
        {
            var tweetList = _twitterService.GetTimelineForSpecificUser(username);
            return Ok(tweetList);
        }

        [HttpGet("{hashtag}/hashtag")]
        public async Task<IActionResult> GetTweetsByHashTag(string hashtag)
        {
            var tweets = _twitterService.GetTweetListByHashtag(hashtag);

            var x = _twitterService.GetSentimentAnalysisForListOfTweetWithoutComments(tweets);

            return Ok(x);

        }

        [HttpGet("{id}/tweetId")]
        public async Task<IActionResult> GetTweet(long id)
        {
            var tweetResult = _twitterService.GetTweetByTweetId(id);
            await _twitterService.GetSentimentAnalysisForTweetWithoutComments(tweetResult);
            //var x = tweetResult.GetRetweets();
            return Ok(tweetResult);
        }

        [HttpGet("{id}/retweet")]
        public IActionResult GetRetwets(long id)
        {
            var httpClient = new HttpClient();
            var httpContent = new StringContent(id.ToString());

            //httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(StringConstants.ApplicationJsonMediaTypeHeaderValue);
            var response =  httpClient.GetAsync($"https://api.twitter.com/1.1/statuses/retweets/{httpContent}.json");
            var result = response.Result;
            return Ok(result);
        }


       

        [HttpGet("trends")]
        public IActionResult GetTrendsLocation()
        {
            var closestTrendLocations = Trends.GetClosestTrendLocations(37.8, -122.4);
            return Ok(closestTrendLocations);
        }

    }
}
