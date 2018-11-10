using System.Collections.Generic;

namespace DomainModels.Models
{
    public class BubbleChartTweetModel
    {
        public List<TweetAnalizedModel> BubbleChartPositive { get; set; }

        public List<TweetAnalizedModel> BubbleChartNegative { get; set; }

        public List<TweetAnalizedModel> BubbleChartNeutral { get; set; }

        public bool IsInHashtagHistory { get; set; }

        public BubbleChartTweetModel()
        {
            BubbleChartPositive = new List<TweetAnalizedModel>();
            BubbleChartNegative = new List<TweetAnalizedModel>();
            BubbleChartNeutral = new List<TweetAnalizedModel>();
        }
    }
}
