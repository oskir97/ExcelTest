
using CommonLibraryProjects.Validations.Interfaces;
using System.Linq.Expressions;

namespace CommonLibraryProjects.Validations.Abstractions
{
    public abstract class ValidatorBase<T> : IValidator<T>
    {
        private IValidationService<T> service;

        public List<IFailure> Failures => service.Failures;

        public IValidationService<T> ServiceValidator => service;

        protected ValidatorBase(IValidationService<T> service)
        {
            this.service = service;
        }

        public IRule<T> AddRuleFor<TProperty>(Expression<Func<T, TProperty>> expression, bool stopOfFirstFailure = true)
        {
            return service.AddRuleFor(expression, stopOfFirstFailure);
        }

        public bool Validate(T entity)
        {
            return service.Validate(entity);
        }

        public List<IFailure> SetValidatorFor<ItemsType>(IEnumerable<ItemsType> items, IValidator<ItemsType> validator)
        {
            return service.SetValidatorFor(items, validator);
        }
    }
}
