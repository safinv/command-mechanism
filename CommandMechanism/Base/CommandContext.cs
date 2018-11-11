using System;

namespace CommandMechanism.Base
{
    public class CommandContext
    {
        //TODO Can add dbContext and more.

        public CommandContext(CommandExecutor commandExecutor)
        {
            CommandExecutor = commandExecutor ?? throw new ArgumentNullException(nameof(commandExecutor));
        }

        public CommandExecutor CommandExecutor { get; }
    }
}