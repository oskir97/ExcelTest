using ExcelTest.Dtos.GetCountries;

namespace ExcelTest.ViewModels.GetCountries
{
    public class GetCountriesViewModel
    {
        public List<string> Countries{ get; }

        public GetCountriesViewModel(GetCountriesResponse dto)
        {
            Countries = dto.Countries;
        }
    }
}
