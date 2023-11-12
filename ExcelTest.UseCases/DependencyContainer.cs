using ExcelTest.UseCases.InsertOrder;
using ExcelTest.UseCasesPorts.InsertOrder;
using Microsoft.Extensions.DependencyInjection;

namespace ExcelTest.UseCases
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddApplicationUseCases(this IServiceCollection services)
        {
            services.AddScoped<InsertOrderService>();
            services.AddTransient<IInsertOrderInputPort, InsertOrderInteractor>();
            return services;
        }
    }
}
