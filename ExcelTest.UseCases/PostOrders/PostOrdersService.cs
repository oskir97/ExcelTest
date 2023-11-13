using CommonLibraryProjects.Validations.Interfaces;
using ExcelTest.Common.Interfaces;
using ExcelTest.Core.Entities;
using ExcelTest.Dtos.PostOrders;

namespace ExcelTest.UseCases.PostOrders
{
    public class PostOrdersService
    {
        private readonly IValidator<PostOrdersRequest> validator;
        private readonly IWritableOrdersRepository orderWritableRepository;
        private readonly IReadableOrdersRepository orderReadableRepository;

        public PostOrdersService(IValidator<PostOrdersRequest> validator, IWritableOrdersRepository orderWritableRepository, IReadableOrdersRepository orderReadableRepository)
        {
            this.validator = validator;
            this.orderWritableRepository = orderWritableRepository;
            this.orderReadableRepository = orderReadableRepository;
        }

        public void RunValidationDTO(PostOrdersRequest dto)
        {
            if (!validator.Validate(dto))
            {
                throw new CommonLibraryProjects.Validations.Abstractions.ValidationException(validator.Failures);
            }
        }

        public async Task<PostOrdersResponse> RunPostOrdersResponse(PostOrdersRequest dto)
        {
            try
            {
                List<Order> orders = new();

                foreach(var orderDto in dto.Orders)
                {
                    var order = new Order
                    {
                        Id = orderDto.Id,
                        Customer = orderDto.Customer,
                        Freight = orderDto.Freight,
                        Country = orderDto.Country
                    };

                    var existOrder = await this.orderReadableRepository.ExistOrder(order.Id);

                    if(!existOrder)
                        orders.Add(order);
                }

                return await this.orderWritableRepository.PostOrders(orders);

            }catch
            {
                throw;
            }
        }
    }
}
