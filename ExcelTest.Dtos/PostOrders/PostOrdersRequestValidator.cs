using CommonLibraryProjects.Validations.Abstractions;
using CommonLibraryProjects.Validations.Interfaces;

namespace ExcelTest.Dtos.PostOrders
{
    public class PostOrdersRequestValidator : ValidatorBase<PostOrdersRequest>
    {
        public PostOrdersRequestValidator(IValidationService<PostOrdersRequest> service) : base(service)
        {
            AddRuleFor(r => r.Orders).AddRequirement(r => !r.Orders.Any(o=>string.IsNullOrWhiteSpace(o.Customer)), "You have to specified all Customers of orders");
            AddRuleFor(r => r.Orders).AddRequirement(r => !r.Orders.Any(o => string.IsNullOrWhiteSpace(o.Country)), "You have to specified all Country of orders");
        }
    }
}
