using ExcelTest.Controllers.RemoveOrder;
using ExcelTest.Dtos.RemoveOrder;

namespace ExcelTest.API.Endpoints
{
    public class RemoveOrderEndpoint
    {
        public async Task<IResult> RemoveOrder(RemoveOrderRequest request, IRemoveOrderController controller)
        {
            var result = await controller.RemoveOrder(request);
            return Results.Ok(result);
        }
    }
}
