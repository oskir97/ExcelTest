using CommonLibraryProjects.Presenters.Interfaces;
using ExcelTest.Dtos.GetCountries;
using ExcelTest.Dtos.PostOrders;
using ExcelTest.UseCasesPorts.GetCountries;
using ExcelTest.UseCasesPorts.PostOrders;
using ExcelTest.ViewModels.Common;
using ExcelTest.ViewModels.GetCountries;
using ExcelTest.ViewModels.PostOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTest.Controllers.GetCountries
{
    public class GetCountriesController : IGetCountriesController
    {
        private readonly IGetCountriesInputPort inputPort;
        private readonly IGetCountriesOutputPort outputPort;

        public GetCountriesController(IGetCountriesInputPort inputPort, IGetCountriesOutputPort outputPort)
        {
            this.inputPort = inputPort;
            this.outputPort = outputPort;
        }

        public async ValueTask<GenericResponse<GetCountriesViewModel>> GetCountries(GetCountriesRequest dto)
        {
            await inputPort.Handle(dto);
            return ((IPresenter<GenericResponse<GetCountriesViewModel>>)outputPort).Content;
        }
    }
}
