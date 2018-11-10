using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayerCqrs.CQRS.Commands.Command;
using BusinessLayerServices.SentimentAnalysisServices.Interfaces;
using Cqrs.Commands.Interfaces;
using DomainModels.Models;
using DomainModels.Models.CqrsModels;
using DomainModels.Models.User;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace BusinessLayerServices.TwitterServices.Implementation
{
    public class TwitterService : ITwitterDataService
    {
        private readonly ISentimentService _sentimentService;

        private readonly ICommandDispatcher _commandDispatcher;

        public TwitterService(ISentimentService sentimentService,
            ICommandDispatcher commandDispatcher)
        {
            _sentimentService = sentimentService;
            _commandDispatcher = commandDispatcher;
        }

        /// <summary>
        /// Get a list of ITweet by hashtag received as parameter.
        /// </summary>
        /// <param name="hashtagValue">Hash tag value.</param>
        /// <returns>List of ITweets.</returns>
        public IList<ITweet> GetTweetListByHashtag(string hashtagValue)
        {
            int count = 10000;
            var searchParameter = new SearchTweetsParameters(hashtagValue)
            {
                SearchType = SearchResultType.Popular,
                MaximumNumberOfResults = count,
                TweetSearchType = TweetSearchType.All
            };

            var tweetsList = Search.SearchTweets(searchParameter).ToList();

            _commandDispatcher.Execute(new AddTweetCommand(tweetsList, hashtagValue));

            //for(int index = 0; index < tweetsList.Count; index++)
            //{
            //   // _commandDispatcher.Execute(new AddTweetCommand(tweetsList[index], hashtagValue));
            //}

            return tweetsList;
        }

        /// <summary>
        /// Get a ITweet object by tweet id.
        /// </summary>
        /// <param name="tweetId">Long type tweet id.</param>
        /// <returns>ITweet object that has the tweetId given by parameter.</returns>
        public ITweet GetTweetByTweetId(long tweetId)
        {
            var tweet = Tweet.GetTweet(tweetId);
            return tweet;
        }


        public IEnumerable<UserModel> GetTimelineForSpecificUser(string username)
        {
            var userTimelineParameters = new UserTimelineParameters() {
                MaximumNumberOfTweetsToRetrieve = 500,
            };
            var tweets = Timeline.GetUserTimeline(username, userTimelineParameters);

            var listOfUsers = new List<UserModel>();
            foreach(var item in tweets){
                var user = new UserModel()
                {
                    ScreenName = item.CreatedBy.ScreenName
                };
                listOfUsers.Add(user);
            }

            //var user1 = User.GetUserFromScreenName(username);
            //user1.CreatedAt

            return listOfUsers;
        }

        public async Task<TweetAnalizedModel> GetSentimentAnalysisForTweetWithoutComments(ITweet tweet)
        {
            if( tweet.Text == null)
            {
                throw new ArgumentException("No text");
            }

            var sentimentAnalysis = await _sentimentService.GetSentimentAnalysisForTextAsync(tweet.Text);

            return new TweetAnalizedModel()
            {
                TweetText = tweet.Text,
                SentimentObjectModel = sentimentAnalysis,
                Username = tweet.CreatedBy.Name,
                Latitude = tweet.CreatedBy.GeoEnabled ? tweet.Coordinates.Latitude : 0,
                Longitude = tweet.CreatedBy.GeoEnabled ? tweet.Coordinates.Longitude : 0
            };
        }

        public List<TweetAnalizedModel> GetSentimentAnalysisForListOfTweetWithoutComments(IList<ITweet> tweet)
        {
            var sentimentAnalysis = _sentimentService.GetSentimentAnalysisForAListOfTextAsync(tweet);
            var list = new List<TweetAnalizedModel>();
            
            for(int index = 0; index < sentimentAnalysis.Count; index++)
            {
                var tweetAnalizedModel = new TweetAnalizedModel()
                {
                    TweetId = tweet[index].Id,
                    TweetText = sentimentAnalysis[index].Text,
                    SentimentObjectModel = sentimentAnalysis[index],
                    NumberOfLikes = tweet[index].FavoriteCount,
                    Username = tweet[index].CreatedBy.ScreenName,
                    Location = tweet[index].CreatedBy.GeoEnabled == true ? tweet[index].CreatedBy.Location : String.Empty,
                };

                list.Add(tweetAnalizedModel);
            }
            return list;
        }


        public BubbleChartTweetModel GetSentimentAnalysisForBubbleChart(IList<ITweet> listOfTexts)
        {
            var bubbleChartModel = new BubbleChartTweetModel();

            var list = GetSentimentAnalysisForListOfTweetWithoutComments(listOfTexts);
            var sentimentList = new List<SentimentModel>();

            foreach (var item in list)
            {

                if (item.SentimentObjectModel.SentimentType.Equals("Negative"))
                {
                    sentimentList.Add(new SentimentModel(item.TweetId, Common.Enums.SentimentTypeEnum.Negative));
                    //_commandDispatcher.Execute(new UpdateTweetCommand(item.TweetId, Common.Enums.SentimentTypeEnum.Negative));
                    bubbleChartModel.BubbleChartNegative.Add(item);
                }
                else if (item.SentimentObjectModel.SentimentType.Equals("Positive"))
                {
                    sentimentList.Add(new SentimentModel(item.TweetId, Common.Enums.SentimentTypeEnum.Positive));
                    //_commandDispatcher.Execute(new UpdateTweetCommand(item.TweetId, Common.Enums.SentimentTypeEnum.Positive));
                    bubbleChartModel.BubbleChartPositive.Add(item);
                }
                else
                {
                    sentimentList.Add(new SentimentModel(item.TweetId, Common.Enums.SentimentTypeEnum.Neutral));
                    //_commandDispatcher.Execute(new UpdateTweetCommand(item.TweetId, Common.Enums.SentimentTypeEnum.Neutral));
                    bubbleChartModel.BubbleChartNeutral.Add(item);
                }

            }


            _commandDispatcher.Execute(new UpdateTweetCommand(sentimentList));
            return bubbleChartModel;
        }
    }
}
