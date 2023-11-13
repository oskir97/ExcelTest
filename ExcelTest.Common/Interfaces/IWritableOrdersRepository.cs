using ExcelTest.Core.Entities;
using ExcelTest.Dtos.PostOrders;
using ExcelTest.Entities.Interfaces;
namespace ExcelTest.Common.Interfaces
{
    public interface IWritableOrdersRepository : IUnitOfWork
    {
        Task<PostOrdersResponse> PostOrders(List<Order> request);
    }
}
