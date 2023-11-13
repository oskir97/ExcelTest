using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTest.Dtos.GetCountries
{
    public class GetCountriesResponse
    {
        public required List<string> Countries { get; set; }
    }
}
