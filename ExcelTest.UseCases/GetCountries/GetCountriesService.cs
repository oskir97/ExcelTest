using CommonLibraryProjects.Validations.Interfaces;
using ExcelTest.Common.Interfaces;
using ExcelTest.Dtos.GetCountries;
using ExcelTest.Dtos.RemoveOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTest.UseCases.GetCountries
{
    public class GetCountriesService
    {
        private readonly IReadableOrdersRepository orderReadableRepository;

        public GetCountriesService(IReadableOrdersRepository orderReadableRepository)
        {
            this.orderReadableRepository = orderReadableRepository;
        }

        public async Task<GetCountriesResponse> RunGetCountriesResponse(GetCountriesRequest dto)
        {
            try
            {
                return await this.orderReadableRepository.GetCountries();
            }
            catch
            {
                throw;
            }
        }
    }
}
