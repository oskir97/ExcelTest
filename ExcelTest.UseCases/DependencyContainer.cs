using ExcelTest.UseCases.GetOrders;
using ExcelTest.UseCases.PostOrders;
using ExcelTest.UseCasesPorts.GetOrders;
using ExcelTest.UseCasesPorts.PostOrders;
using Microsoft.Extensions.DependencyInjection;

namespace ExcelTest.UseCases
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddApplicationUseCases(this IServiceCollection services)
        {
            services.AddScoped<PostOrdersService>();
            services.AddScoped<GetOrdersService>();
            services.AddTransient<IPostOrdersInputPort, PostOrdersInteractor>();
            services.AddTransient<IGetOrdersInputPort, GetOrdersInteractor>();
            return services;
        }
    }
}
