using ExcelTest.UseCases.GetOrders;
using ExcelTest.UseCases.InsertOrders;
using ExcelTest.UseCasesPorts.GetOrders;
using ExcelTest.UseCasesPorts.InsertOrders;
using Microsoft.Extensions.DependencyInjection;

namespace ExcelTest.UseCases
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddApplicationUseCases(this IServiceCollection services)
        {
            services.AddScoped<InsertOrdersService>();
            services.AddScoped<GetOrdersService>();
            services.AddTransient<IInsertOrdersInputPort, InsertOrdersInteractor>();
            services.AddTransient<IGetOrdersInputPort, GetOrdersInteractor>();
            return services;
        }
    }
}
