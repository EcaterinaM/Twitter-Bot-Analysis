using BusinessLayerCqrs.CQRS.Commands.Interfaces;
using System.Collections.Generic;
using Tweetinvi.Models;

namespace BusinessLayerCqrs.CQRS.Commands.Command
{
    public class AddTweetCommand: ICommand
    {
        public List<ITweet> TweetsToAdd { get; set; }

        public string HashtagValue { get; set; }

        public AddTweetCommand(List<ITweet> tweets, string hashtag)
        {
            TweetsToAdd = tweets;
            HashtagValue = hashtag;
        }
    }
}
