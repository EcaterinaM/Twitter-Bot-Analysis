using BusinessLayerServices.TwitterServices.Interfaces;
using DomainModels.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace BusinessLayerServices.TwitterServices.Implementation
{
    public class TwitterUserService : ITwitterUserService
    {
        public int GetNumberOfDaysFromAccountCreated(string screenName)
        {
            var user = User.GetUserFromScreenName(screenName);
            var createDate = user.CreatedAt;
            var activeAccountDays = DateTime.Now.Subtract(createDate).Days;
            return activeAccountDays;
        }

        public int GetNumberOfTweets(string screenName)
        {
            var user = User.GetUserFromScreenName(screenName);
            if(user == null)
            {
                return 0; 
            }
            return user.StatusesCount;
        }

        public UserModel GetScreenNameInformation(string screenName)
        {
            var user = new UserModel()
            {
                ScreenName = screenName,
                DaysActiveAccount = GetNumberOfDaysFromAccountCreated(screenName),
                NumberOfTweets = GetNumberOfTweets(screenName)
            };
            return user;
        }

        public async Task<System.IO.Stream> GetProfilePictoreAsync(string screenName)
        {
            var user = User.GetUserFromScreenName(screenName);

            var stream = await user.GetProfileImageStreamAsync(ImageSize.mini);

            return stream;
        }

        public double DetermineAccountAnonimity(string screenName)
        {
            var user = User.GetUserFromScreenName(screenName);

            double counter = 1;

            var x = user.Name;
            var y = user.Notifications;
            var z = user.Protected;
            var t = user.Retweets;
            var u = user.Status;
            var r = user.UserIdentifier;
            
            var profile = user.ProfileImageUrl;

            if (profile.Contains("default_profile"))
            {
                counter = counter - 0.2;
            }

            var hasDefaultProfile = user.DefaultProfile;

            if (hasDefaultProfile)
            {
                counter = counter - 0.2;
            }

            var hasDescription = user.Description.Length == 0 ? false : true;

            if (!hasDescription)
            {
                counter = counter - 0.2;
            }

            var hasLocation = user.Location.Length == 0 ? false : true;

            if (!hasLocation)
            {
                counter = counter - 0.2;
            }

            var hasBackgroundImage = user.ProfileUseBackgroundImage;

            if (!hasBackgroundImage)
            {
                counter = counter - 0.1;
            }

            var isVerified = user.Verified;
            if (!isVerified)
            {
                counter = counter - 0.1;
            }


            return counter;
        }

        public double DetermineAccountActivity(string screenName)
        {
            var numberOfPosts = GetNumberOfTweets(screenName);
            var numberOfActiveDays = GetNumberOfDaysFromAccountCreated(screenName);

            if( numberOfPosts / numberOfActiveDays > 50)
            {
                var x = numberOfPosts / numberOfActiveDays;
                double y = Convert.ToDouble(1 / x);
                return y;
            }

            return 1;
        }

        public TimelineModel DetermineAccountTimeline(string screeName)
        {

            var user = User.GetUserFromScreenName(screeName);

            //var timelineParameters = new UserTimelineParameters
            //{
            //    IncludeRTS = true,
            //    ExcludeReplies = true,
            //    MaximumNumberOfTweetsToRetrieve = 100
            //};

            //var timeline = Timeline.GetUserTimeline(user, timelineParameters);
            var timeline = Timeline.GetUserTimeline(user);

            if(timeline == null)
            {
                return new TimelineModel();
            }

            var collectedTweetsFromTimeline = timeline.ToList().Count;

            var numberOfFollowers = user.FollowersCount;

            var retweetsCounter = 0;
            var tweetsCounter = 0;
            var numberOfGeneratedUrls = 0;
            var numberOfRetweetedTweets = 0;
            var numberOfTweetsWithUrl = 0;
            var languageSet = new HashSet<string>();

            foreach(var tweet in timeline)
            {
                //de vazut si cu likes
                var x = tweet.Language;
                languageSet.Add(x.ToString());

                var likesForTweet = tweet.FavoriteCount;

                var retweetCount = tweet.RetweetCount;
                var urls = tweet.Urls;

                if (retweetCount > numberOfFollowers)
                {
                    numberOfRetweetedTweets++;
                }

                if (tweet.IsRetweet)
                {
                    retweetsCounter++;
                }
                else
                {
                    tweetsCounter++;
                }

                if(urls.Count != 0)
                {
                    numberOfTweetsWithUrl++;
                    foreach (var url in urls)
                    {
                        var u = url.URL;
                        if( u.Length < 25)
                        {
                            numberOfGeneratedUrls++;
                        }
                    }
                }
            }

            double decision = 1;

            if(retweetsCounter > tweetsCounter)
            {
                decision = Convert.ToDouble(decision) - 0.5;
            }

            if(numberOfRetweetedTweets > (collectedTweetsFromTimeline / 2) + 1)
            {
                decision = Convert.ToDouble(decision) - 0.2;
            }

            if( numberOfGeneratedUrls > (numberOfTweetsWithUrl / 2) + 1)
            {
                decision = Convert.ToDouble(decision) - 0.2;
            }

            if (languageSet.ToList().Count > 1 && decision != 1)
            {
                decision = decision - 0.1;
            }

            if (languageSet.ToList().Count > 1 && decision == 1)
            {
                decision = 0.8;
            }


            var timelineModel = new TimelineModel()
            {
                RetweetsCounter = retweetsCounter,
                NumberOfTweetsFromTimeline = tweetsCounter,
                CollectedTweetsFromTimeline = collectedTweetsFromTimeline,
                NumberOfRetweetsFromTimeline = numberOfRetweetedTweets,
                NumberOfGeneratedUrls = numberOfGeneratedUrls,
                TimelineDecision = decision
            };

            return timelineModel;
        }

        public UserModel DetermineBotAnalysis(string screenName)
        {
           var user = User.GetUserFromScreenName(screenName);

            if (user == null)
            {
                var model = new UserModel()
                {
                    UserFound = false
                };

                return model;
            }

            var accountActivityDecision = DetermineAccountActivity(screenName);
            var accountAnonimityDecision = DetermineAccountAnonimity(screenName);
            var accountTimelineModel = DetermineAccountTimeline(screenName);

            var determineIfBotOrNot = DetermineIfBotOrNot(accountActivityDecision, accountAnonimityDecision, accountTimelineModel.TimelineDecision);

            var userModel = new UserModel() { 
                TweetUserId = user.Id,
                UserFound = true,
                NumberOfTweets = GetNumberOfTweets(screenName),
                ScreenName = screenName,
                DaysActiveAccount = GetNumberOfDaysFromAccountCreated(screenName),
                AccountActivity = accountActivityDecision,
                AccountAnonimity = accountAnonimityDecision,
                TimelineModel = accountTimelineModel,
                IsBot = determineIfBotOrNot
            };

            return userModel;
        }

        public bool DetermineIfBotOrNot(double activityDecision, double anonimityDecision, double timelineDecision)
        {
            var counter = 0;

            if(1 - activityDecision > 0.5)
            {
                counter++;
            }

            if (1 - anonimityDecision > 0.5)
            {
                counter++;
            }


            if (1 - timelineDecision > 0.5)
            {
                counter++;
            }

            if( counter >= 2)
            {
                return true;
            }

            return false;
        }

        public FollowersModel DetermineFollowersType(string screenName, int numberOfFollowers)
        {
            var user = User.GetUserFromScreenName(screenName);

            if(user == null)
            {
                return new FollowersModel();
            }

            var followersList = User.GetFollowers(screenName, numberOfFollowers);
            var botList = new List<IUser>();
            var resultList = new List<UserModel>();

            foreach(var follower in followersList)
            {
                var accountActivityDecision = DetermineAccountActivity(follower.ScreenName);
                var accountAnonimityDecision = DetermineAccountAnonimity(follower.ScreenName);
                var accountTimelineModel = DetermineAccountTimeline(follower.ScreenName);

                var f = DetermineBotAnalysis(follower.ScreenName);
                resultList.Add(f);

                var isBot = DetermineIfBotOrNot(accountActivityDecision, accountAnonimityDecision, accountTimelineModel.TimelineDecision);

                if (isBot)
                {
                    botList.Add(follower);
                }
            }

            var followersModel = new FollowersModel();
            followersModel.UserModelList = resultList;
            followersModel.NumberOfBots = botList.Count;
            followersModel.NumberOfFollowersTested = numberOfFollowers;
            return followersModel;
        }
    }
}
