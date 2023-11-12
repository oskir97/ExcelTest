using ExcelTest.Core.Entities;
using ExcelTest.Dtos.InsertOrder;
using ExcelTest.Entities.Interfaces;
namespace ExcelTest.Common.Interfaces
{
    public interface IWritableOrderRepository : IUnitOfWork
    {
        Task<InsertOrderResponse> InsertOrder(Order request);
    }
}
