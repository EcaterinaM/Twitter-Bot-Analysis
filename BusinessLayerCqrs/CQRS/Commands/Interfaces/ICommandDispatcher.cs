using BusinessLayerCqrs.CQRS.Commands.Interfaces;

namespace Cqrs.Commands.Interfaces
{
    public interface ICommandDispatcher
    {
        void Execute<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
