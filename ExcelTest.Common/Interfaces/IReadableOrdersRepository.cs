using ExcelTest.Core.Entities;
using ExcelTest.Dtos.GetCountries;
using ExcelTest.Dtos.GetOrders;

namespace ExcelTest.Common.Interfaces
{
    public interface IReadableOrdersRepository
    {
        ValueTask<bool> ExistOrder(int id);
        ValueTask<GetOrdersResponse> GetOrders(GetOrdersRequest dto);
        ValueTask<GetCountriesResponse> GetCountries();
    }
}
