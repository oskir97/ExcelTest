using ExcelTest.Presenters.InsertOrders;
using ExcelTest.UseCasesPorts.InsertOrders;
using Microsoft.Extensions.DependencyInjection;

namespace ExcelTest.Presenters
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddApplicationPresenters(this IServiceCollection services)
        {
            services.AddScoped<IInsertOrdersOutputPort, InsertOrdersPresenter>();
            return services;
        }
    }

}
