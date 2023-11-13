using CommonLibraryProjects.Ports.Interfaces;
using ExcelTest.Dtos.PostOrders;

namespace ExcelTest.UseCasesPorts.PostOrders
{
    public interface IPostOrdersInputPort : IPort<PostOrdersRequest>
    {
    }
}
