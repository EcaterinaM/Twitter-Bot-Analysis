using System;

namespace DataDomain.DataModel
{
    public class HashtagHistory : BaseModel
    {
        public string HashtagValue { get; set; }

        public Tweet TweetModel { get; set; }

        public int NegativeSentimentCounter { get; set; }

        public int PositiveSentimentCounter { get; set; }

        public int NeutralSentimentCounter { get; set; }

        public DateTime SearchTime { get; set; }

    }
}
