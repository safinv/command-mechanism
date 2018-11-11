using System;
using System.Threading.Tasks;
using CommandMechanism.Base;
using CommandMechanism.Base.Interfaces;

namespace CommandMechanism.Example
{
    public class ExampleCommandHandler : ICommandHandler<ExampleCommand>
    {
        public Task Handle(ExampleCommand command, CommandContext context)
        {
            //TODO Implementation.
            //include commands - context.CommandExecutor.Execute();

            throw new NotImplementedException();
        }
    }
}