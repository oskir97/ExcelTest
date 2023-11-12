using System.Linq.Expressions;

namespace CommonLibraryProjects.Validations.Interfaces
{
    public interface IRule<T>
    {
        IRule<T> AddRequirement(Expression<Func<T, bool>> requirement, string ErrorMessage);

        IRule<T> AddCollectionItemsValidator(Expression<Func<T, IEnumerable<IFailure>>> itemsValidator);
    }
}
