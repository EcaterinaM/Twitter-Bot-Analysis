namespace DomainModels.Models
{
    public class TweetModel
    {
        public long TweetId { get; set; }

        public string TweetText { get; set; }

        public string TweetUsername { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int RetweetCount { get; set; }

        public int NumberOfLikes { get; set; }

        public string MediaUrlImage { get; set; }

        public string Language { get; set; }
    }
}
