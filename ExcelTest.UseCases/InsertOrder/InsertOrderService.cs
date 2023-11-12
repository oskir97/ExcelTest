using CommonLibraryProjects.Validations.Interfaces;
using ExcelTest.Common.Interfaces;
using ExcelTest.Core.Entities;
using ExcelTest.Dtos.InsertOrder;

namespace ExcelTest.UseCases.InsertOrder
{
    public class InsertOrderService
    {
        private readonly IValidator<InsertOrderRequest> validator;
        private readonly IWritableOrderRepository orderWritableRepository;

        public InsertOrderService(IValidator<InsertOrderRequest> validator, IWritableOrderRepository orderWritableRepository)
        {
            this.validator = validator;
            this.orderWritableRepository = orderWritableRepository;
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
                var order = new Order
                {
                    Id = dto.Id,
                    Customer = dto.Customer,
                    Freight = dto.Freight,
                    Country = dto.Country
                };

                return await this.orderWritableRepository.InsertOrder(order);

            }catch
            {
                throw;
            }
        }
    }
}
