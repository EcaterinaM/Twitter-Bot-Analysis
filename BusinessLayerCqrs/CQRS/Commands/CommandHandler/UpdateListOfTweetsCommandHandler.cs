using BusinessLayerCqrs.CQRS.Commands.Command;
using Cqrs.Commands.Interfaces;

namespace BusinessLayerCqrs.CQRS.Commands.CommandHandler
{
    public class UpdateListOfTweetsCommandHandler : ICommandHandler<UpdateListOfTweetsCommand>
    {
      
        public void Execute(UpdateListOfTweetsCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}
