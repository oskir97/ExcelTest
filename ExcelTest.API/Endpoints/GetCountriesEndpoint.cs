using ExcelTest.Controllers.GetCountries;
using ExcelTest.Controllers.GetOrders;
using ExcelTest.Dtos.GetCountries;
using ExcelTest.Dtos.GetOrders;
using Microsoft.AspNetCore.Mvc;

namespace ExcelTest.API.Endpoints
{
    public class GetCountriesEndpoint
    {
        public async Task<IResult> GetCountries([FromBody] GetCountriesRequest request, IGetCountriesController controller)
        {
            var result = await controller.GetCountries(request);
            return Results.Ok(result);
        }
    }
}
