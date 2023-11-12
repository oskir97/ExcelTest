using ExcelTest.Controllers.InsertOrders;
using ExcelTest.Dtos.InsertOrders;

namespace ExcelTest.API.Endpoints
{
    public class InsertOrdersEndpoint
    {
        public async Task<IResult> InsertOrders(InsertOrdersRequest request, IInsertOrdersController controller)
        {
            var result = await controller.InsertOrders(request);
            return Results.Ok(result);
        }
    }

}
