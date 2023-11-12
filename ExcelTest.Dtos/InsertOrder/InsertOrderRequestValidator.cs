using CommonLibraryProjects.Validations.Abstractions;
using CommonLibraryProjects.Validations.Interfaces;

namespace ExcelTest.Dtos.InsertOrder
{
    public class InsertOrderRequestValidator : ValidatorBase<InsertOrderRequest>
    {
        public InsertOrderRequestValidator(IValidationService<InsertOrderRequest> service) : base(service)
        {
            AddRuleFor(r => r.Orders).AddRequirement(r => !r.Orders.Any(o=>string.IsNullOrWhiteSpace(o.Customer)), "You have to specified all Customers of orders");
            AddRuleFor(r => r.Orders).AddRequirement(r => !r.Orders.Any(o => string.IsNullOrWhiteSpace(o.Country)), "You have to specified all Country of orders");
        }
    }
}
