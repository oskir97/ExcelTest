using CommonLibraryProjects.Ports.Interfaces;
using ExcelTest.Dtos.InsertOrder;

namespace ExcelTest.UseCasesPorts.InsertOrder
{
    public interface IInsertOrderInputPort : IPort<InsertOrderRequest>
    {
    }
}
