using CommonLibraryProjects.Validations.Interfaces;
using ExcelTest.Common.Interfaces;
using ExcelTest.Core.Entities;
using ExcelTest.Dtos.InsertOrders;

namespace ExcelTest.UseCases.InsertOrders
{
    public class InsertOrdersService
    {
        private readonly IValidator<InsertOrdersRequest> validator;
        private readonly IWritableOrdersRepository orderWritableRepository;
        private readonly IReadableOrdersRepository orderReadableRepository;

        public InsertOrdersService(IValidator<InsertOrdersRequest> validator, IWritableOrdersRepository orderWritableRepository, IReadableOrdersRepository orderReadableRepository)
        {
            this.validator = validator;
            this.orderWritableRepository = orderWritableRepository;
            this.orderReadableRepository = orderReadableRepository;
        }

        public void RunValidationDTO(InsertOrdersRequest dto)
        {
            if (!validator.Validate(dto))
            {
                throw new CommonLibraryProjects.Validations.Abstractions.ValidationException(validator.Failures);
            }
        }

        public async Task<InsertOrdersResponse> RunInsertOrderResponse(InsertOrdersRequest dto)
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

                    var existOrder = await this.orderReadableRepository.ExistOrder(order);

                    if(!existOrder)
                        orders.Add(order);
                }

                return await this.orderWritableRepository.InsertOrders(orders);

            }catch
            {
                throw;
            }
        }
    }
}
