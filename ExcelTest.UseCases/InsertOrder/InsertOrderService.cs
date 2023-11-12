using CommonLibraryProjects.Validations.Interfaces;
using ExcelTest.Common.Interfaces;
using ExcelTest.Core.Entities;
using ExcelTest.Dtos.InsertOrder;

namespace ExcelTest.UseCases.InsertOrder
{
    public class InsertOrderService
    {
        private readonly IValidator<InsertOrderRequest> validator;
        private readonly IWritableOrdersRepository orderWritableRepository;
        private readonly IReadableOrdersRepository orderReadableRepository;

        public InsertOrderService(IValidator<InsertOrderRequest> validator, IWritableOrdersRepository orderWritableRepository, IReadableOrdersRepository orderReadableRepository)
        {
            this.validator = validator;
            this.orderWritableRepository = orderWritableRepository;
            this.orderReadableRepository = orderReadableRepository;
        }

        public void RunValidationDTO(InsertOrderRequest dto)
        {
            if (!validator.Validate(dto))
            {
                throw new CommonLibraryProjects.Validations.Abstractions.ValidationException(validator.Failures);
            }
        }

        public async Task<InsertOrderResponse> RunInsertOrderResponse(InsertOrderRequest dto)
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

                return await this.orderWritableRepository.InsertOrder(orders);

            }catch
            {
                throw;
            }
        }
    }
}
