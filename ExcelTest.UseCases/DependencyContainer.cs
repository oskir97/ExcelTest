using ExcelTest.UseCases.GetCountries;
using ExcelTest.UseCases.GetOrders;
using ExcelTest.UseCases.PostOrders;
using ExcelTest.UseCases.PutOrder;
using ExcelTest.UseCases.RemoveOrder;
using ExcelTest.UseCasesPorts.GetCountries;
using ExcelTest.UseCasesPorts.GetOrders;
using ExcelTest.UseCasesPorts.PostOrders;
using ExcelTest.UseCasesPorts.PutOrder;
using ExcelTest.UseCasesPorts.RemoveOrder;
using Microsoft.Extensions.DependencyInjection;

namespace ExcelTest.UseCases
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddApplicationUseCases(this IServiceCollection services)
        {
            services.AddScoped<PostOrdersService>();
            services.AddScoped<GetOrdersService>();
            services.AddScoped<PutOrderService>();
            services.AddScoped<RemoveOrderService>();
            services.AddScoped<GetCountriesService>();
            services.AddTransient<IPostOrdersInputPort, PostOrdersInteractor>();
            services.AddTransient<IGetOrdersInputPort, GetOrdersInteractor>();
            services.AddTransient<IPutOrderInputPort, PutOrderInteractor>();
            services.AddTransient<IRemoveOrderInputPort, RemoveOrderInteractor>();
            services.AddTransient<IGetCountriesInputPort, GetCountriesInteractor>();
            return services;
        }
    }
}
