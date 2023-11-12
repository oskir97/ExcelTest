using CommonLibraryProjects.Validations.Abstractions;
using CommonLibraryProjects.Validations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryProjects.Validations.Entities
{
    public class ValidationService<T> : IValidationService<T>, IValidator<T>
    {
        private readonly Validator<T> apiValidatorField;

        public List<IFailure> Failures => ((IEnumerable<IFailure>)apiValidatorField.Failures.Select((IFailure f) => new Failure(f.PropertyName, f.ErrorMessage))).ToList();

        public IValidationService<T> ServiceValidator => this;

        public Validator<T> ValidatorApi => apiValidatorField;

        public ValidationService()
        {
            apiValidatorField = new Validator<T>();
        }

        public IRule<T> AddRuleFor<TProperty>(Expression<Func<T, TProperty>> expression, bool stopOnFirstFailure)
        {
            return apiValidatorField.AddRuleFor(expression, stopOnFirstFailure);
        }

        public List<IFailure> SetValidatorFor<ItemsType>(IEnumerable<ItemsType> items, IValidator<ItemsType> validator)
        {
            List<IFailure> result = new List<IFailure>();
            ValidationService<ItemsType> validationService = validator.ServiceValidator as ValidationService<ItemsType>;
            if (validationService != null)
            {
                Validator<ItemsType> validatorApi = validationService.ValidatorApi;
                result = ((IEnumerable<IFailure>)apiValidatorField.SetValidatorFor(items, validatorApi)).Select((Func<IFailure, IFailure>)((IFailure f) => new Failure(f.PropertyName, f.ErrorMessage))).ToList();
            }

            return result;
        }

        public bool Validate(T instance)
        {
            return apiValidatorField.Validate(instance);
        }
    }
}
