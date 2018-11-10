using BusinessLayerCqrs.CQRS.Commands.Interfaces;
using System.Collections.Generic;

namespace BusinessLayerCqrs.CQRS.Commands.Command
{
    public class UpdateListOfTweetsCommand : ICommand
    {
        public List<UpdateTweetCommand> ListUpdateTweetCommand { get; set; }
    }
}
