using CommonLibraryProjects.Validations.Abstractions;
using CommonLibraryProjects.Validations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTest.Dtos.GetOrders
{
    public class GetOrdersRequestValidator : ValidatorBase<GetOrdersRequest>
    {
        public GetOrdersRequestValidator(IValidationService<GetOrdersRequest> service) : base(service)
        {
            AddRuleFor(r=>r.Page).AddRequirement(r => r.Page > 0, "Page must be greater than 0");
            AddRuleFor(r=>r.PageSize).AddRequirement(r => r.PageSize > 0, "Page size must be greater than 0");
        }
    }
}
