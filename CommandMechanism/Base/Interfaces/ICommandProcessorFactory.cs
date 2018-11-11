namespace CommandMechanism.Base.Interfaces
{
    /// <summary>
    /// This interface gives the initial stage of command execution.
    /// </summary>
    public interface ICommandProcessorFactory
    {
        /// <summary>
        /// This method returns an instance of the command processor.
        /// </summary>
        ICommandProcessor GetCommandProcessor();
    }
}