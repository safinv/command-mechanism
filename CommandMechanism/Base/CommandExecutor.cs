using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommandMechanism.Base.Interfaces;

namespace CommandMechanism.Base
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly IComponentResolver _componentResolver;

        private readonly Dictionary<Guid, string> _listOfRunningCommands;

        public CommandExecutor(IComponentResolver componentResolver)
        {
            _componentResolver = componentResolver ?? throw new ArgumentNullException(nameof(componentResolver));

            _listOfRunningCommands = new Dictionary<Guid, string>();
        }

        public async Task Execute<TCommand>(TCommand command) where TCommand : BaseCommand
        {
            if (!CheckExistCommand(command))
            {
                AddCommandToListOfRunningCommands(command);
            }
            else
            {
                throw new ArgumentException($"Command with Guid = {command.Guid} already started.");
            }

            try
            {
                var commandHandler = ResolveCommandHandler<TCommand>();
                var context = new CommandContext(this);

                await commandHandler.Handle(command, context);

                RemovingCommandFromListOfRunningCommands(command);
            }
            catch (Exception e)
            {
                //TODO add logs.
                throw;
            }
        }

        private ICommandHandler<TCommand> ResolveCommandHandler<TCommand>() where TCommand : BaseCommand
        {
            return _componentResolver.Resolve<ICommandHandler<TCommand>>();
        }

        private void AddCommandToListOfRunningCommands<TCommand>(TCommand command) where TCommand : BaseCommand
        {
            _listOfRunningCommands.Add(command.Guid, command.ToString());
        }

        private void RemovingCommandFromListOfRunningCommands<TCommand>(TCommand command) where TCommand : BaseCommand
        {
            _listOfRunningCommands.Remove(command.Guid);
        }

        private bool CheckExistCommand<TCommand>(TCommand command) where TCommand : BaseCommand
        {
            return _listOfRunningCommands.ContainsKey(command.Guid);
        }
    }
}