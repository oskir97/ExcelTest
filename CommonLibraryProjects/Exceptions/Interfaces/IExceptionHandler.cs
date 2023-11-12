using CommonLibraryProjects.Exceptions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryProjects.Exceptions.Interfaces
{
    public interface IExceptionHandler<in TExceptionType> where TExceptionType : Exception
    {
        Task<ProblemDetails> Handle(TExceptionType exception, string traceId);
    }
}
