namespace DataDomain.DataModel
{
    public class UserInformation : BaseModel
    {
        public long TweetUserId { get; set; }

        public string TweetUsername { get; set; }

        public int NumberOfTweets { get; set; }

        public int DaysActiveAccount { get; set; }

        public double AccountAnonimity { get; set; }

        public double AccountActivity { get; set; }

        public int RetweetsCounter { get; set; }

        public int NumberOfTweetsFromTimeline { get; set; }

        public int NumberOfRetweetsFromTimeline { get; set; }

        public int CollectedTweetsFromTimeline { get; set; }

        public int NumberOfGeneratedUrls { get; set; }

        public double TimelineDecision { get; set; }

        public bool IsBot { get; set; }
    }
}
