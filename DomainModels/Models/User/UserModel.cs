namespace DomainModels.Models.User
{
    public class UserModel
    {
        public long TweetUserId { get; set; }

        public bool UserFound { get; set; }

        public string ScreenName { get; set; }

        public int NumberOfTweets { get; set; }

        public int DaysActiveAccount { get; set; }

        public double AccountAnonimity { get; set; }

        public double AccountActivity { get; set; }

        public TimelineModel TimelineModel { get; set; }

        public bool IsBot { get; set; }
    }
}
