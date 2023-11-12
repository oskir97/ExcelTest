using CommonLibraryProjects.Validations.Abstractions;
using CommonLibraryProjects.Validations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryProjects.Validations.Entities
{
    public class Validator<T> : IValidator<T>
    {
        private readonly List<IRule<T>> rules = new List<IRule<T>>();

        private readonly List<IFailure> failures = new List<IFailure>();

        public List<IFailure> Failures => failures;

        public IValidationService<T> ServiceValidator => ServiceValidator;

        public IRule<T> AddRuleFor<TProperty>(Expression<Func<T, TProperty>> expression, bool stopOnFirstFailure)
        {
            Rule<T> rule = new Rule<T>(expression, stopOnFirstFailure);
            rules.Add(rule);
            return rule;
        }

        public bool Validate(T instance)
        {
            failures.Clear();
            if (rules.Any())
            {
                foreach (Rule<T> rule in rules)
                {
                    if (!rule.IsValid(instance))
                    {
                        failures.AddRange(rule.Failures);
                    }
                }
            }

            return failures == null || !failures.Any();
        }

        public List<IFailure> SetValidatorFor<ItemsType>(IEnumerable<ItemsType> items, IValidator<ItemsType> validator)
        {
            List<IFailure> list = new List<IFailure>();
            int i;
            for (i = 0; i < items.Count(); i++)
            {
                if (!validator.Validate(items.ElementAt(i)))
                {
                    list.AddRange(validator.Failures.Select(delegate (IFailure f)
                    {
                        DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 2);
                        defaultInterpolatedStringHandler.AppendLiteral("[");
                        defaultInterpolatedStringHandler.AppendFormatted(i);
                        defaultInterpolatedStringHandler.AppendLiteral("] ");
                        defaultInterpolatedStringHandler.AppendFormatted(f.PropertyName);
                        return new Failure(defaultInterpolatedStringHandler.ToStringAndClear(), f.ErrorMessage);
                    }).ToList());
                }
            }

            return list;
        }
    }
}
