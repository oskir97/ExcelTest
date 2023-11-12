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
    public class Rule<T> : IRule<T>
    {
        private readonly List<ValidationExpression> validationExpressions = new List<ValidationExpression>();

        private readonly bool stopOnFirstFailure = false;

        private readonly List<Failure> failures = new List<Failure>();

        private readonly LambdaExpression propertyExpression;

        public List<Failure> Failures => failures;

        private string RulePropertyName
        {
            get
            {
                MemberExpression memberExpression = propertyExpression.Body as MemberExpression;
                if (memberExpression != null)
                {
                    return memberExpression.Member.Name;
                }

                return propertyExpression.Body.Type.Name;
            }
        }

        public Rule(LambdaExpression propertyExpression, bool stopOnFirstFailure)
        {
            bool flag = stopOnFirstFailure;
            this.propertyExpression = propertyExpression;
            this.stopOnFirstFailure = flag;
        }

        public IRule<T> AddRequirement(Expression<Func<T, bool>> requirement, string errorMessage)
        {
            validationExpressions.Add(new ValidationExpression(requirement, errorMessage));
            return this;
        }

        public IRule<T> AddCollectionItemsValidator(Expression<Func<T, IEnumerable<IFailure>>> itemsValidatorExpression)
        {
            Expression<Func<T, IEnumerable<IFailure>>> itemsValidatorExpression2 = itemsValidatorExpression;
            Expression<Func<T, IEnumerable<KeyValuePair<string, string>>>> expression = (T instance) => from s in itemsValidatorExpression2.Compile()(instance)
                                                                                                        select new KeyValuePair<string, string>(s.PropertyName, s.ErrorMessage);
            validationExpressions.Add(new ValidationExpression(expression, ""));
            return this;
        }

        public bool IsValid(T instance)
        {
            Failures.Clear();
            List<ValidationExpression>.Enumerator enumerator = validationExpressions.GetEnumerator();
            bool flag = true;
            while (enumerator.MoveNext() && flag)
            {
                try
                {
                    Expression<Func<T, bool>> expression = enumerator.Current.Expression as Expression<Func<T, bool>>;
                    if (expression != null)
                    {
                        if (!expression.Compile()(instance))
                        {
                            Failures.Add(new Failure(RulePropertyName, enumerator.Current.ErrorMessage));
                            flag = !stopOnFirstFailure;
                        }

                        continue;
                    }

                    Expression<Func<T, IEnumerable<KeyValuePair<string, string>>>> expression2 = enumerator.Current.Expression as Expression<Func<T, IEnumerable<KeyValuePair<string, string>>>>;
                    if (expression2 == null)
                    {
                        continue;
                    }

                    IEnumerable<KeyValuePair<string, string>> source = expression2.Compile()(instance);
                    if (source.Any())
                    {
                        Failures.AddRange(source.Select((KeyValuePair<string, string> f) => new Failure(f.Key, f.Value)));
                        flag = !stopOnFirstFailure;
                    }
                }
                catch
                {
                }
            }

            return !Failures.Any();
        }
    }
}
