using ExcelTest.Controllers.GetOrders;
using ExcelTest.Dtos.GetOrders;

namespace ExcelTest.API.Endpoints
{
    public class GetOrdersEndpoint
    {
        public async Task<IResult> GetOrders(GetOrdersRequest request, IGetOrdersController controller)
        {
            var result = await controller.GetOrders(request);
            return Results.Ok(result);
        }
    }
}
