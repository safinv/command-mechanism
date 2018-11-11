using System;
using System.Threading.Tasks;
using System.Transactions;
using CommandMechanism.Base.Interfaces;

namespace CommandMechanism.Base
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly ICommandExecutor _commandExecutor;

        public CommandProcessor(ICommandExecutor commandExecutor)
        {
            _commandExecutor = commandExecutor ?? throw new ArgumentNullException(nameof(commandExecutor));
        }

        public async Task Process<TCommand>(TCommand command) where TCommand : BaseCommand
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    await _commandExecutor.Execute(command).ConfigureAwait(false);

                    scope.Complete();
                }
                catch (Exception e)
                {
                    //TODO add logs.
                    throw;
                }
            }
        }
    }
}