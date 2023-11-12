using CommonLibraryProjects.Validations.Abstractions;
using CommonLibraryProjects.Validations.Interfaces;

namespace ExcelTest.Dtos.InsertOrder
{
    public class InsertOrderRequestValidator : ValidatorBase<InsertOrderRequest>
    {
        public InsertOrderRequestValidator(IValidationService<InsertOrderRequest> service) : base(service)
        {
            AddRuleFor(r => r.Customer).AddRequirement(r => !string.IsNullOrWhiteSpace(r.Customer), "Cannot specified a Customer");
            AddRuleFor(r => r.Country).AddRequirement(r => !string.IsNullOrWhiteSpace(r.Customer), "Cannot specified a Country");
        }
    }
}
