using ExcelTest.Presenters.InsertOrder;
using ExcelTest.UseCasesPorts.InsertOrder;
using Microsoft.Extensions.DependencyInjection;

namespace ExcelTest.Presenters
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddApplicationPresenters(this IServiceCollection services)
        {
            services.AddScoped<IInsertOrderOutputPort, InsertOrderPresenter>();
            return services;
        }
    }

}
