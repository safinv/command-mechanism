using System.Threading.Tasks;

namespace CommandMechanism.Base.Interfaces
{
    /// <summary>
    /// Command executor interface.
    /// </summary>
    public interface ICommandExecutor
    {
        /// <summary>
        /// Method to run the command.
        /// </summary>
        /// <typeparam name="TCommand">Command type.</typeparam>
        /// <param name="command">Command.</param>
        Task Execute<TCommand>(TCommand command) where TCommand : BaseCommand;
    }
}