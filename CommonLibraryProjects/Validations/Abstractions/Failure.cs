using CommonLibraryProjects.Validations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryProjects.Validations.Abstractions
{
    public class Failure : IFailure
    {
        public string PropertyName { get; set; }

        public string ErrorMessage { get; set; }

        public Failure(string propertyName, string errorMessage)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
        }

        public override string ToString()
        {
            return PropertyName + ": " + ErrorMessage;
        }
    }
}
