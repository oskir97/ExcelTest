using CommonLibraryProjects.Exceptions.Abstractions;
using CommonLibraryProjects.Exceptions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryProjects.Exceptions.WebApi.Presenters
{
    public class WebExceptionPresenter : IExceptionPresenter
    {
        private static readonly Dictionary<Type, Type> ExceptionHandlers = new Dictionary<Type, Type>();
        public ProblemDetails Content { get; private set; } = null!;

        public WebExceptionPresenter(Assembly exceptionHandlerAssembly)
        {
            Type[] types = exceptionHandlerAssembly.GetTypes();
            Type[] array = types;
            foreach (Type type in array)
            {
                IEnumerable<Type> enumerable = from i in type.GetInterfaces()
                                               where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IExceptionHandler<>)
                                               select i;
                foreach (Type item in enumerable)
                {
                    Type key = item.GetGenericArguments()[0];
                    ExceptionHandlers.TryAdd(key, type);
                }
            }
        }
        public async Task Handle(Exception ex, bool includeDetails, string traceId)
        {
            ProblemDetails problem = null!;
            if (ExceptionHandlers.TryGetValue(ex.GetType(), out var handlerType))
            {
                object handler = Activator.CreateInstance(handlerType)!;
                if (handler != null)
                {
                    MethodInfo methodHandle = handlerType.GetMethod("Handle")!;
                    if (methodHandle != null)
                    {
                        object objResult = methodHandle.Invoke(handler, new object[2] { ex, traceId })!;
                        if (objResult != null)
                        {
                            problem = await (Task<ProblemDetails>)objResult;
                        }
                    }
                }
            }
            else
            {
                string title;
                string detail;
                if (includeDetails)
                {
                    title = ex.Message;
                    detail = ex.ToString();
                }
                else
                {
                    title = "An error occurred while processing the response";
                    detail = ex.Message;
                }

                problem = new ProblemDetails
                {
                    Status = 500,
                    Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
                    Title = title,
                    Detail = detail,
                    TraceId = traceId
                };
            }

            Content = problem;
        }
    }
}
