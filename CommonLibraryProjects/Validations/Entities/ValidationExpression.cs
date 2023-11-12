using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryProjects.Validations.Entities
{
    public class ValidationExpression
    {
        public Expression Expression { get; }

        public string ErrorMessage { get; }

        public ValidationExpression(Expression expression, string errorMessage)
        {
            Expression = expression;
            ErrorMessage = errorMessage;
        }
    }
}
