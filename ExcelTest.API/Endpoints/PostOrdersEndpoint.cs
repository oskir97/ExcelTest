using ExcelTest.Controllers.PostOrders;
using ExcelTest.Dtos.PostOrders;
using Microsoft.AspNetCore.Mvc;

namespace ExcelTest.API.Endpoints
{
    public class PostOrdersEndpoint
    {
        public async Task<IResult> PostOrders([FromBody] PostOrdersRequest request, IPostOrdersController controller)
        {
            var result = await controller.PostOrders(request);
            return Results.Ok(result);
        }
    }

}
