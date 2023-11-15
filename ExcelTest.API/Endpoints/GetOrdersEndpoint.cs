using ExcelTest.Controllers.GetOrders;
using ExcelTest.Dtos.GetOrders;
using Microsoft.AspNetCore.Mvc;

namespace ExcelTest.API.Endpoints
{
    public class GetOrdersEndpoint
    {
        public async Task<IResult> GetOrders([FromBody] GetOrdersRequest request, IGetOrdersController controller)
        {
            var result = await controller.GetOrders(request);
            return Results.Ok(result);
        }
    }
}
