using System;

namespace CommandMechanism.Base
{
    public abstract class BaseCommand
    {
        public Guid Guid { get; }

        protected BaseCommand()
        {
            Guid = Guid.NewGuid();
        }

        public abstract string GetDescription();
    }
}