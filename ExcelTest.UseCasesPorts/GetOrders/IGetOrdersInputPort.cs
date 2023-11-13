using CommonLibraryProjects.Ports.Interfaces;
using ExcelTest.Dtos.GetOrders;

namespace ExcelTest.UseCasesPorts.GetOrders
{
    public interface IGetOrdersInputPort : IPort<GetOrdersRequest>
    {
    }
}
