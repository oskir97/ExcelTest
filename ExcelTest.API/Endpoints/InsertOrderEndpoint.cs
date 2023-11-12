using ExcelTest.Controllers.InsertOrder;
using ExcelTest.Dtos.InsertOrder;

namespace ExcelTest.API.Endpoints
{
    public class InsertOrderEndpoint
    {
        public async Task<IResult> InsertOrder(InsertOrderRequest request, IInsertOrderController controller)
        {
            var result = await controller.InsertOrder(request);
            return Results.Ok(result);
        }
    }

}
