using BusinessLayerCqrs.CQRS.Queries.Query;
using BusinessLayerCqrs.CQRS.Queries.QueryResult;
using Cqrs.Queries.Interfaces;
using DataCore.Repositories.Generic;
using DomainModels.Models.User;
using System.Collections.Generic;

namespace BusinessLayerCqrs.CQRS.Queries.QueryHandler
{
    public class GetUserInformationQueryHandler : IQueryHandler<GetUserInformationQuery, GetUserInformationQueryResult>
    {
        private readonly IUserInformationRepository _userInformationRepository;

        public GetUserInformationQueryHandler(IUserInformationRepository userInformationRepository)
        {
            _userInformationRepository = userInformationRepository;
        }

        public GetUserInformationQueryResult Execute(GetUserInformationQuery query)
        {
            var list = _userInformationRepository.GetAll();

            var userModelList = new List<UserModel>();

            foreach(var item in list)
            {
                var timelineModel = new TimelineModel()
                {
                    TimelineDecision = item.TimelineDecision,
                    NumberOfGeneratedUrls = item.NumberOfGeneratedUrls,
                    NumberOfRetweetsFromTimeline = item.NumberOfRetweetsFromTimeline,
                    NumberOfTweetsFromTimeline = item.NumberOfTweetsFromTimeline,
                    RetweetsCounter = item.RetweetsCounter,
                    CollectedTweetsFromTimeline = item.CollectedTweetsFromTimeline
                };

                var user = new UserModel()
                {
                    AccountActivity = item.AccountActivity,
                    AccountAnonimity = item.AccountAnonimity,
                    DaysActiveAccount = item.DaysActiveAccount,
                    ScreenName = item.TweetUsername,
                    NumberOfTweets = item.NumberOfTweets,
                    IsBot = item.IsBot,
                    TimelineModel = timelineModel
                };

                userModelList.Add(user);
            }

            return new GetUserInformationQueryResult(userModelList);
        }
    }
}
