using ExcelTest.Controllers.PostOrders;
using ExcelTest.Dtos.PostOrders;

namespace ExcelTest.API.Endpoints
{
    public class PostOrdersEndpoint
    {
        public async Task<IResult> PostOrders(PostOrdersRequest request, IPostOrdersController controller)
        {
            var result = await controller.PostOrders(request);
            return Results.Ok(result);
        }
    }

}
