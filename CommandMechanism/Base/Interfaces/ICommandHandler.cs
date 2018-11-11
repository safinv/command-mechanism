using System.Threading.Tasks;

namespace CommandMechanism.Base.Interfaces
{
    /// <summary>
    /// Basic command processing interface.
    /// </summary>
    /// <typeparam name="TCommand">Command type.</typeparam>
    public interface ICommandHandler<in TCommand> where TCommand : BaseCommand
    {
        /// <summary>
        /// Method for command processing.
        /// </summary>
        /// <param name="command">Command.</param>
        /// <param name="context"><see cref="CommandContext"/></param>
        /// <returns>Can add result.</returns>
        Task Handle(TCommand command, CommandContext context);
    }
}