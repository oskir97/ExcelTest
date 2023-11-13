using ExcelTest.Presenters.GetOrders;
using ExcelTest.Presenters.InsertOrders;
using ExcelTest.UseCasesPorts.GetOrders;
using ExcelTest.UseCasesPorts.InsertOrders;
using Microsoft.Extensions.DependencyInjection;

namespace ExcelTest.Presenters
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddApplicationPresenters(this IServiceCollection services)
        {
            services.AddScoped<IInsertOrdersOutputPort, InsertOrdersPresenter>();
            services.AddScoped<IGetOrdersOutputPort, GetOrdersPresenter>();
            return services;
        }
    }

}
