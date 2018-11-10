namespace DomainModels.Models.User
{
    public class TimelineModel
    {
        public int RetweetsCounter {get; set;}

        public int NumberOfTweetsFromTimeline { get; set; }

        public int NumberOfRetweetsFromTimeline { get; set; }

        public int CollectedTweetsFromTimeline { get; set; }

        public int NumberOfGeneratedUrls { get; set; }

        public double TimelineDecision { get; set; }
    }
}
