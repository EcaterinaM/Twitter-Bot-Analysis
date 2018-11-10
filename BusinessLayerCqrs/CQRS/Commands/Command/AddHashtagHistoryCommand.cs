using BusinessLayerCqrs.CQRS.Commands.Interfaces;
using DomainModels.Models.Twitter;

namespace BusinessLayerCqrs.CQRS.Commands.Command
{
    public class AddHashtagHistoryCommand : ICommand
    {
        public AddHashtagHistoryCommand(HashtagHistoryModel _hashtagHistoryModel)
        {
            hashtagHistoryModel = _hashtagHistoryModel;

        }
        public HashtagHistoryModel hashtagHistoryModel { get; set; }
    }
}
