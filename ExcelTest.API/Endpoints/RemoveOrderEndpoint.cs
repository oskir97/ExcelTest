using ExcelTest.Controllers.RemoveOrder;
using ExcelTest.Dtos.RemoveOrder;
using Microsoft.AspNetCore.Mvc;

namespace ExcelTest.API.Endpoints
{
    public class RemoveOrderEndpoint
    {
        public async Task<IResult> RemoveOrder([FromBody] RemoveOrderRequest request, IRemoveOrderController controller)
        {
            var result = await controller.RemoveOrder(request);
            return Results.Ok(result);
        }
    }
}
