using CommonLibraryProjects.Exceptions.Abstractions;

namespace CommonLibraryProjects.Exceptions.Interfaces
{
    public interface IExceptionPresenter
    {
        ProblemDetails Content { get; }

        Task Handle(Exception ex, bool includeDetails, string traceId);
    }
}
