using CommonLibraryProjects.Validations.Interfaces;
using ExcelTest.Dtos.InsertOrder;
using Microsoft.Extensions.DependencyInjection;

namespace ExcelTest.Dtos
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddApplicationValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<InsertOrderRequest>, InsertOrderRequestValidator>();
            return services;
        }
    }

}
