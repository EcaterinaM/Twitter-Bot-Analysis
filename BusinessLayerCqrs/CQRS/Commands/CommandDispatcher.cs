using System;
using Autofac;
using BusinessLayerCqrs.CQRS.Commands.Interfaces;
using Cqrs.Commands.Interfaces;

namespace Cqrs.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _context;

        public CommandDispatcher(IComponentContext context)
        {
            _context = context;
        }

        public void Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var handler = _context.Resolve<ICommandHandler<TCommand>>();

            handler.Execute(command);

        }
    }
}
