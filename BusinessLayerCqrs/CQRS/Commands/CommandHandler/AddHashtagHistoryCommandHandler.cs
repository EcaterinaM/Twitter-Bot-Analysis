using BusinessLayerCqrs.CQRS.Commands.Command;
using Cqrs.Commands.Interfaces;
using DataCore.Respositories.Generic;
using DataDomain.DataModel;
using System;

namespace BusinessLayerCqrs.CQRS.Commands.CommandHandler
{
    public class AddHashtagHistoryCommandHandler : ICommandHandler<AddHashtagHistoryCommand>
    {
        private readonly IBaseRepository<HashtagHistory> _hashtagHistoryRepository;


        public AddHashtagHistoryCommandHandler(IBaseRepository<HashtagHistory> hashtagHistoryRepository)
        {
            _hashtagHistoryRepository = hashtagHistoryRepository;
        }

        public void Execute(AddHashtagHistoryCommand command)
        {
            var hashtagHistoryModel = new HashtagHistory()
            {
                HashtagValue = command.hashtagHistoryModel.HashtagValue,
                NegativeSentimentCounter = command.hashtagHistoryModel.NegativeSentimentCounter,
                NeutralSentimentCounter = command.hashtagHistoryModel.NeutralSentimentCounter,
                PositiveSentimentCounter = command.hashtagHistoryModel.PositiveSentimentCounter,
                SearchTime = DateTime.Now,
                Id = Guid.NewGuid()
            };

            _hashtagHistoryRepository.Add(hashtagHistoryModel);
            _hashtagHistoryRepository.Save();
        }
    }
}
