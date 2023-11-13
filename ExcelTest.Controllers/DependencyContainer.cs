using ExcelTest.Controllers.GetCountries;
using ExcelTest.Controllers.GetOrders;
using ExcelTest.Controllers.PostOrders;
using ExcelTest.Controllers.PutOrder;
using ExcelTest.Controllers.RemoveOrder;
using Microsoft.Extensions.DependencyInjection;

namespace ExcelTest.Controllers
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddApplicationControllers(this IServiceCollection services)
        {
            services.AddScoped<IPostOrdersController, PostOrdersController>();
            services.AddScoped<IGetOrdersController, GetOrdersController>();
            services.AddScoped<IPutOrderController, PutOrderController>();
            services.AddScoped<IRemoveOrderController, RemoveOrderController>();
            services.AddScoped<IGetCountriesController, GetCountriesController>();
            return services;
        }
    }
}
