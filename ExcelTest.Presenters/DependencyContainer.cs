using ExcelTest.Presenters.GetCountries;
using ExcelTest.Presenters.GetOrders;
using ExcelTest.Presenters.PostOrders;
using ExcelTest.Presenters.PutOrder;
using ExcelTest.Presenters.RemoveOrder;
using ExcelTest.UseCasesPorts.GetCountries;
using ExcelTest.UseCasesPorts.GetOrders;
using ExcelTest.UseCasesPorts.PostOrders;
using ExcelTest.UseCasesPorts.PutOrder;
using ExcelTest.UseCasesPorts.RemoveOrder;
using Microsoft.Extensions.DependencyInjection;

namespace ExcelTest.Presenters
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddApplicationPresenters(this IServiceCollection services)
        {
            services.AddScoped<IPostOrdersOutputPort, PostOrdersPresenter>();
            services.AddScoped<IGetOrdersOutputPort, GetOrdersPresenter>();
            services.AddScoped<IPutOrderOutputPort, PutOrderPresenter>();
            services.AddScoped<IRemoveOrderOutputPort, RemoveOrderPresenter>();
            services.AddScoped<IGetCountriesOutputPort, GetCountriesPresenter>();
            return services;
        }
    }

}
