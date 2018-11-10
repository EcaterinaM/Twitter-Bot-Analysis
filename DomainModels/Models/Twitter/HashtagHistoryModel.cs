using System;

namespace DomainModels.Models.Twitter
{
    public class HashtagHistoryModel
    {
        public string HashtagValue { get; set; }

        public long TweetId { get; set; }

        public int NegativeSentimentCounter { get; set; }

        public int PositiveSentimentCounter { get; set; }

        public int NeutralSentimentCounter { get; set; }

        public DateTime SearchTime { get; set; }

    }
}
