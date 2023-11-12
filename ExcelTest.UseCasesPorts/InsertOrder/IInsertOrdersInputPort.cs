using CommonLibraryProjects.Ports.Interfaces;
using ExcelTest.Dtos.InsertOrders;

namespace ExcelTest.UseCasesPorts.InsertOrders
{
    public interface IInsertOrdersInputPort : IPort<InsertOrdersRequest>
    {
    }
}
