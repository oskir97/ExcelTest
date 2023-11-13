using ExcelTest.Dtos.GetCountries;
using ExcelTest.UseCasesPorts.GetCountries;

namespace ExcelTest.UseCases.GetCountries
{
    public class GetCountriesInteractor: IGetCountriesInputPort
    {
        private readonly IGetCountriesOutputPort outputPort;
        private readonly GetCountriesService service;

        public GetCountriesInteractor(IGetCountriesOutputPort outputPort, GetCountriesService service)
        {
            this.outputPort = outputPort;
            this.service = service;
        }

        public async Task Handle(GetCountriesRequest dto)
        {
            var result = await this.service.RunGetCountriesResponse(dto);
            await this.outputPort.Handle(result);
        }
    }
}
