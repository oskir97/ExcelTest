using ExcelTest.Core.Entities;

namespace ExcelTest.Common.Interfaces
{
    public interface IReadableOrdersRepository
    {
        ValueTask<bool> ExistOrder(Order order);
    }
}
