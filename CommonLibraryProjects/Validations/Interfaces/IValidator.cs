using System.Linq.Expressions;

namespace CommonLibraryProjects.Validations.Interfaces
{
    public interface IValidator<T>
    {
        List<IFailure> Failures { get; }

        IValidationService<T> ServiceValidator { get; }

        IRule<T> AddRuleFor<TProperty>(Expression<Func<T, TProperty>> expression, bool stopOfFirstFailure);

        bool Validate(T entity);

        List<IFailure> SetValidatorFor<ItemsType>(IEnumerable<ItemsType> items, IValidator<ItemsType> validator);
    }
}
