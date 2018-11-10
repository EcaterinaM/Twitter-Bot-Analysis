using BusinessLayerCqrs.CQRS.Commands.Command;
using Cqrs.Commands.Interfaces;
using DataCore.Respositories.Generic;
using DataDomain.DataModel;
using System;
using BusinessLayerServices.AzureServices.Interfaces;

namespace BusinessLayerCqrs.CQRS.Commands.CommandHandler
{
    public class AddTweetCommandHandler : ICommandHandler<AddTweetCommand>
    {
        private readonly IBaseRepository<Tweet> _tweetRepository;

        private readonly IAzureServices _azureService;


        public AddTweetCommandHandler(IBaseRepository<Tweet> tweetRepository,
            IAzureServices azureService)
        {
            _tweetRepository = tweetRepository;
            _azureService = azureService;
        }

        public void Execute(AddTweetCommand command)
        {
            foreach(var item in command.TweetsToAdd)
            {
                var tweet = new Tweet()
                {
                    Id = Guid.NewGuid(),
                    TweetId = item.Id,
                    NumberOfLikes = item.FavoriteCount,
                    TweetText = item.FullText,
                    TweetUsername = item.CreatedBy.ScreenName,
                    TweetDate = item.TweetDTO.CreatedAt,
                    RetweetCount = item.RetweetCount,
                    HashtagSearchValue = command.HashtagValue
                };
                _tweetRepository.Add(tweet);
            }

            _tweetRepository.Save();
        }
    }
}
