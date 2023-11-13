using CommonLibraryProjects.Validations.Abstractions;
using CommonLibraryProjects.Validations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTest.Dtos.PutOrder
{
    public class PutOrderRequestValidator : ValidatorBase<PutOrderRequest>
    {
        public PutOrderRequestValidator(IValidationService<PutOrderRequest> service) : base(service)
        {
            AddRuleFor(r => r.Customer).AddRequirement(r => !string.IsNullOrWhiteSpace(r.Customer), "You have to specified the Customer");
            AddRuleFor(r => r.Country).AddRequirement(r => !string.IsNullOrWhiteSpace(r.Country), "You have to specified the Country");
        }
    }
}
