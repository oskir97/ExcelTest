using ExcelTest.Core.Entities;
using ExcelTest.Dtos.GetOrders;

namespace ExcelTest.Common.Interfaces
{
    public interface IReadableOrdersRepository
    {
        ValueTask<bool> ExistOrder(Order order);
        ValueTask<GetOrdersResponse> GetOrders(GetOrdersRequest dto);
    }
}
