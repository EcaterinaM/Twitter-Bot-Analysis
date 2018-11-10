using BusinessLayerCqrs.CQRS.Commands.Command;
using Cqrs.Commands.Interfaces;
using DataCore.Repositories.Generic;

namespace BusinessLayerCqrs.CQRS.Commands.CommandHandler
{
    public class UpdateTweetCommandHandler : ICommandHandler<UpdateTweetCommand>
    {
        private readonly ITweetRepository _tweetRepository;

        public UpdateTweetCommandHandler(ITweetRepository tweetRepository)
        {
            _tweetRepository = tweetRepository;
        }

        public void Execute(UpdateTweetCommand command)
        {
            foreach(var item in command.SentimentModelList)
            {
                var tweet = _tweetRepository.GetByTweetId(item.TweetId);
                tweet.SentimentType = (int)item.SentimentTypeEnum;
                _tweetRepository.Update(tweet);
            }

            _tweetRepository.SaveChanges();
        }
    }
}
