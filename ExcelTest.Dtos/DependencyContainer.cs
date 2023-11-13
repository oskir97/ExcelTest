using CommonLibraryProjects.Validations.Interfaces;
using ExcelTest.Dtos.GetOrders;
using ExcelTest.Dtos.PostOrders;
using ExcelTest.Dtos.PutOrder;
using Microsoft.Extensions.DependencyInjection;

namespace ExcelTest.Dtos
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddApplicationValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<PostOrdersRequest>, PostOrdersRequestValidator>();
            services.AddScoped<IValidator<GetOrdersRequest>, GetOrdersRequestValidator>();
            services.AddScoped<IValidator<PutOrderRequest>, PutOrderRequestValidator>();
            return services;
        }
    }

}
