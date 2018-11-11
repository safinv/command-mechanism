using System;
using CommandMechanism.Base.Interfaces;

namespace CommandMechanism.Base
{
    public class CommandProcessorFactory : ICommandProcessorFactory
    {
        private readonly IComponentResolver _componentResolver;

        public CommandProcessorFactory(IComponentResolver componentResolver)
        {
            _componentResolver = componentResolver ?? throw new ArgumentNullException(nameof(componentResolver));
        }

        public ICommandProcessor GetCommandProcessor()
        {
            return _componentResolver.Resolve<ICommandProcessor>();
        }
    }
}