using ExcelTest.Core.Entities;
using ExcelTest.Dtos.PostOrders;
using ExcelTest.Dtos.PutOrder;
using ExcelTest.Dtos.RemoveOrder;
using ExcelTest.Entities.Interfaces;
namespace ExcelTest.Common.Interfaces
{
    public interface IWritableOrdersRepository : IUnitOfWork
    {
        Task<PostOrdersResponse> PostOrders(List<Order> orders);
        Task<PutOrderResponse> PutOrder(Order order);
        Task<RemoveOrderResponse> RemoveOrder(int id);
    }
}
