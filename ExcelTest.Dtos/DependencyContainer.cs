using CommonLibraryProjects.Validations.Interfaces;
using ExcelTest.Dtos.InsertOrders;
using Microsoft.Extensions.DependencyInjection;

namespace ExcelTest.Dtos
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddApplicationValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<InsertOrdersRequest>, InsertOrdersRequestValidator>();
            return services;
        }
    }

}
