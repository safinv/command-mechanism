namespace CommandMechanism.Base.Interfaces
{
    /// <summary>
    /// Interface for component recognition.
    /// </summary>
    public interface IComponentResolver
    {
        T Resolve<T>() where T : class;
    }
}