namespace CommonLibraryProjects.Ports.Interfaces
{
    public interface IPort<in T>
    {
        Task Handle(T entity);
    }
}
