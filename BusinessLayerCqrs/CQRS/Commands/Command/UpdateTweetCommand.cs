using BusinessLayerCqrs.CQRS.Commands.Interfaces;
using DomainModels.Models.CqrsModels;
using System.Collections.Generic;

namespace BusinessLayerCqrs.CQRS.Commands.Command
{
    public class UpdateTweetCommand : ICommand
    {
        public IList<SentimentModel> SentimentModelList { get; set; }

        public UpdateTweetCommand(IList<SentimentModel> sentimentModelList)
        {
            SentimentModelList = sentimentModelList;
        }
    }
}
