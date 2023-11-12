using ExcelTest.Core.Entities;
using ExcelTest.Dtos.InsertOrders;
using ExcelTest.Entities.Interfaces;
namespace ExcelTest.Common.Interfaces
{
    public interface IWritableOrdersRepository : IUnitOfWork
    {
        Task<InsertOrdersResponse> InsertOrders(List<Order> request);
    }
}
