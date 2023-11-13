using CommonLibraryProjects.Validations.Interfaces;
using ExcelTest.Dtos.GetOrders;
using ExcelTest.Dtos.PostOrders;
using Microsoft.Extensions.DependencyInjection;

namespace ExcelTest.Dtos
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddApplicationValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<PostOrdersRequest>, PostOrdersRequestValidator>();
            services.AddScoped<IValidator<GetOrdersRequest>, GetOrdersRequestValidator>();
            return services;
        }
    }

}
