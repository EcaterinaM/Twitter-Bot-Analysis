using DomainModels.Models.User;
using System.IO;
using System.Threading.Tasks;

namespace BusinessLayerServices.TwitterServices.Interfaces
{
    public interface ITwitterUserService
    {
        int GetNumberOfDaysFromAccountCreated(string screenName);

        int GetNumberOfTweets(string screenName);

        UserModel GetScreenNameInformation(string screenName);

        Task<Stream> GetProfilePictoreAsync(string screenName);


        bool DetermineIfBotOrNot(double activityDecision, double anonimityDecision, double timelineDecision);

        double DetermineAccountAnonimity(string screenName);

        double DetermineAccountActivity(string screenName);

        TimelineModel DetermineAccountTimeline(string screeName);

        FollowersModel DetermineFollowersType(string screenName, int numberOfFollowers);

        UserModel DetermineBotAnalysis(string screenName);

       
    }
}
