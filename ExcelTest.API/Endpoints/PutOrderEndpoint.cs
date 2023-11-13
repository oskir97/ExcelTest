using ExcelTest.Controllers.PutOrder;
using ExcelTest.Dtos.PutOrder;

namespace ExcelTest.API.Endpoints
{
    public class PutOrderEndpoint
    {
        public async Task<IResult> PutOrder(PutOrderRequest request, IPutOrderController controller)
        {
            var result = await controller.PutOrder(request);
            return Results.Ok(result);
        }
    }
}
