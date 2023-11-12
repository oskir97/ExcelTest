using ExcelTest.Core.Entities;
using ExcelTest.Dtos.InsertOrder;
using ExcelTest.Entities.Interfaces;
namespace ExcelTest.Common.Interfaces
{
    public interface IWritableOrdersRepository : IUnitOfWork
    {
        Task<InsertOrderResponse> InsertOrder(List<Order> request);
    }
}
