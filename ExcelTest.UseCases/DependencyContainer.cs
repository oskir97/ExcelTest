using ExcelTest.UseCases.InsertOrders;
using ExcelTest.UseCasesPorts.InsertOrders;
using Microsoft.Extensions.DependencyInjection;

namespace ExcelTest.UseCases
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddApplicationUseCases(this IServiceCollection services)
        {
            services.AddScoped<InsertOrdersService>();
            services.AddTransient<IInsertOrdersInputPort, InsertOrdersInteractor>();
            return services;
        }
    }
}
