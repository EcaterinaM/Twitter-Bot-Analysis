using BusinessLayerCqrs.CQRS.Queries.Query;
using BusinessLayerCqrs.CQRS.Queries.QueryResult;
using Cqrs.Queries.Interfaces;
using DataCore.Repositories.Generic;
using DomainModels.Models.User;

namespace BusinessLayerCqrs.CQRS.Queries.QueryHandler
{
    public class GetUserInformationByUsernameQueryHandler : IQueryHandler<GetUserInformationByUsernameQuery, GetUserInformationByUsernameQueryResult>
    {
        private readonly IUserInformationRepository _userInformationRepository;

        public GetUserInformationByUsernameQueryHandler(IUserInformationRepository userInformationRepository)
        {
            _userInformationRepository = userInformationRepository;
        }

        public GetUserInformationByUsernameQueryResult Execute(GetUserInformationByUsernameQuery query)
        {
            var user = _userInformationRepository.GetByUsername(query.Username);

            if( user != null)
            {
                var timelineModel = new TimelineModel()
                {
                    TimelineDecision = user.TimelineDecision,
                    NumberOfGeneratedUrls = user.NumberOfGeneratedUrls,
                    NumberOfRetweetsFromTimeline = user.NumberOfRetweetsFromTimeline,
                    NumberOfTweetsFromTimeline = user.NumberOfTweetsFromTimeline,
                    RetweetsCounter = user.RetweetsCounter,
                    CollectedTweetsFromTimeline = user.CollectedTweetsFromTimeline
                };

                var usermodel = new UserModel()
                {
                    AccountActivity = user.AccountActivity,
                    AccountAnonimity = user.AccountAnonimity,
                    DaysActiveAccount = user.DaysActiveAccount,
                    ScreenName = user.TweetUsername,
                    NumberOfTweets = user.NumberOfTweets,
                    IsBot = user.IsBot,
                    TimelineModel = timelineModel
                };

                return new GetUserInformationByUsernameQueryResult(usermodel);
            }

            return null;
        }
    }
}
