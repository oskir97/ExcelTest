using ExcelTest.Dtos.PostOrders;
using ExcelTest.ViewModels.Common;
using ExcelTest.ViewModels.PostOrders;

namespace ExcelTest.Controllers.PostOrders
{
    public interface IPostOrdersController
    {
        ValueTask<GenericResponse<PostOrdersViewModel>> PostOrders(PostOrdersRequest dto);
    }
}
