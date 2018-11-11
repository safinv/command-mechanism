using System.Threading.Tasks;

namespace CommandMechanism.Base.Interfaces
{
    /// <summary>
    /// Main interface of the command execution mechanism.
    /// </summary>
    public interface ICommandProcessor
    {
        /// <summary>
        /// Method for the process of starting the command execution mechanism.
        /// </summary>
        /// <typeparam name="TCommand">Command type.</typeparam>
        /// <param name="command">Command.</param>
        Task Process<TCommand>(TCommand command) where TCommand : BaseCommand;
    }
}