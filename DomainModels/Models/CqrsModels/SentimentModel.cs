using Common.Enums;

namespace DomainModels.Models.CqrsModels
{
    public class SentimentModel
    {
        public long TweetId { get; set; }

        public SentimentTypeEnum SentimentTypeEnum { get; set; }

        public SentimentModel(long id, SentimentTypeEnum sentimentTypeEnum)
        {
            SentimentTypeEnum = sentimentTypeEnum;
            TweetId = id;
        }
    }
}
