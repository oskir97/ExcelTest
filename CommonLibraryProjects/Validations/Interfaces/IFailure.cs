
namespace CommonLibraryProjects.Validations.Interfaces
{
    public interface IFailure
    {
        string PropertyName { get; }

        string ErrorMessage { get; }
    }
}
