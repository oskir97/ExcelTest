using ExcelTest.Controllers.PutOrder;
using ExcelTest.Dtos.PutOrder;
using Microsoft.AspNetCore.Mvc;

namespace ExcelTest.API.Endpoints
{
    public class PutOrderEndpoint
    {
        public async Task<IResult> PutOrder([FromBody] PutOrderRequest request, IPutOrderController controller)
        {
            var result = await controller.PutOrder(request);
            return Results.Ok(result);
        }
    }
}
