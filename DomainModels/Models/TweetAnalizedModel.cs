namespace DomainModels.Models
{
    public class TweetAnalizedModel
    {
        public long TweetId { get; set; }

        public string TweetText { get; set; }

        public string Username { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int NumberOfLikes { get; set; }

        public string Location { get; set; }

        public SentimentObjectModel SentimentObjectModel { get; set; }
    }
}
