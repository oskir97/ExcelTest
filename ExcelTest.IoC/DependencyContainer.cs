using CommonLibraryProjects.Exceptions.WebApi;
using CommonLibraryProjects.Exceptions.WebApi.Handlers;
using CommonLibraryProjects.Validations.Entities;
using ExcelTest.Controllers;
using ExcelTest.Dtos;
using ExcelTest.EFC.IoC;
using ExcelTest.Presenters;
using ExcelTest.UseCases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExcelTest.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration, string readConnectionStringName, string writeConnectionStringName)
        {
            services.AddWebExceptionHandlerPresenter(ExceptionHandlersPresenters.Assembly)
            .AddValidationService()
            .AddApplicationRepositories(configuration, readConnectionStringName, writeConnectionStringName)
            .AddApplicationValidators()
            .AddApplicationPresenters()
            .AddApplicationControllers()
            .AddApplicationUseCases();
            return services;
        }
    }

}
