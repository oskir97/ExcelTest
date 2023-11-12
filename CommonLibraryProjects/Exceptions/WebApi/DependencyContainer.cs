﻿using CommonLibraryProjects.Exceptions.Interfaces;
using CommonLibraryProjects.Exceptions.WebApi.Presenters;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace CommonLibraryProjects.Exceptions.WebApi
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddWebExceptionHandlerPresenter(this IServiceCollection services, Assembly exceptionHandlersAssembly)
        {
            Assembly exceptionHandlersAssembly2 = exceptionHandlersAssembly;
            services.AddSingleton((Func<IServiceProvider, IExceptionPresenter>)((IServiceProvider provider) => new WebExceptionPresenter(exceptionHandlersAssembly2)));
            return services;
        }
    }
}
