using ExcelTest.Dtos.GetCountries;
using ExcelTest.ViewModels.Common;
using ExcelTest.ViewModels.GetCountries;

namespace ExcelTest.Controllers.GetCountries
{
    public interface IGetCountriesController
    {
        ValueTask<GenericResponse<GetCountriesViewModel>> GetCountries(GetCountriesRequest dto);
    }
}
