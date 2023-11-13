using ExcelTest.Presenters.GetOrders;
using ExcelTest.Presenters.PostOrders;
using ExcelTest.UseCasesPorts.GetOrders;
using ExcelTest.UseCasesPorts.PostOrders;
using Microsoft.Extensions.DependencyInjection;

namespace ExcelTest.Presenters
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddApplicationPresenters(this IServiceCollection services)
        {
            services.AddScoped<IPostOrdersOutputPort, PostOrdersPresenter>();
            services.AddScoped<IGetOrdersOutputPort, GetOrdersPresenter>();
            return services;
        }
    }

}
