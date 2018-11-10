using BusinessLayerCqrs.CQRS.Commands.Interfaces;

namespace Cqrs.Commands.Interfaces
{
    public interface ICommandHandler<in TCommand>
        where TCommand : ICommand
    {
        void Execute(TCommand command);
    }
}
