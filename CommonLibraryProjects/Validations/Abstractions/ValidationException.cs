﻿using CommonLibraryProjects.Validations.Interfaces;

namespace CommonLibraryProjects.Validations.Abstractions
{
    public class ValidationException : Exception
    {
        public IEnumerable<IFailure> Failures { get; set; } = null!;

        public ValidationException()
        {
        }

        public ValidationException(string message)
            : base(message)
        {
        }

        public ValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public ValidationException(IEnumerable<IFailure> failures)
        {
            Failures = failures;
        }
    }
}
