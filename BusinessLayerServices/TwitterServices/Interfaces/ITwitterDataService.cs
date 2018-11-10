using DomainModels.Models;
using DomainModels.Models.User;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tweetinvi.Models;

namespace BusinessLayerServices.TwitterServices
{
    public interface ITwitterDataService
    {
        IList<ITweet> GetTweetListByHashtag(string hashtagValue);

        ITweet GetTweetByTweetId(long tweetId);

        IEnumerable<UserModel> GetTimelineForSpecificUser(string username);

        Task<TweetAnalizedModel> GetSentimentAnalysisForTweetWithoutComments(ITweet tweet);

        List<TweetAnalizedModel> GetSentimentAnalysisForListOfTweetWithoutComments(IList<ITweet> tweet);

        BubbleChartTweetModel GetSentimentAnalysisForBubbleChart(IList<ITweet> listOfTexts);


    }
}