using CommonLibraryProjects.Ports.Interfaces;
using ExcelTest.Dtos.GetCountries;

namespace ExcelTest.UseCasesPorts.GetCountries
{
    public interface IGetCountriesOutputPort : IPort<GetCountriesResponse>
    {
    }
}
