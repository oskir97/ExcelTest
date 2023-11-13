using ExcelTest.Controllers.GetOrders;
using ExcelTest.Controllers.PostOrders;
using Microsoft.Extensions.DependencyInjection;

namespace ExcelTest.Controllers
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddApplicationControllers(this IServiceCollection services)
        {
            services.AddScoped<IPostOrdersController, PostOrdersController>();
            services.AddScoped<IGetOrdersController, GetOrdersController>();
            return services;
        }
    }
}
