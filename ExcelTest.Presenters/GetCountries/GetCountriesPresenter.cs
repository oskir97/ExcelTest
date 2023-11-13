using CommonLibraryProjects.Presenters.Interfaces;
using ExcelTest.Dtos.GetCountries;
using ExcelTest.UseCasesPorts.GetCountries;
using ExcelTest.ViewModels.Common;
using ExcelTest.ViewModels.GetCountries;

namespace ExcelTest.Presenters.GetCountries
{
    public class GetCountriesPresenter : IGetCountriesOutputPort, IPresenter<GenericResponse<GetCountriesViewModel>>
    {
        public GenericResponse<GetCountriesViewModel>  Content { get; private set; } = null!;

        public async Task Handle(GetCountriesResponse dto)
        {
            Content = new GenericResponse<GetCountriesViewModel>(new GetCountriesViewModel(dto));
        }
    }
}
