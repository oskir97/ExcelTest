using CommonLibraryProjects.Validations.Interfaces;
using ExcelTest.Common.Interfaces;
using ExcelTest.Core.Entities;
using ExcelTest.Dtos.PutOrder;

namespace ExcelTest.UseCases.PutOrder
{
    public class PutOrderService
    {
        private readonly IValidator<PutOrderRequest> validator;
        private readonly IWritableOrdersRepository orderWritableRepository;
        private readonly IReadableOrdersRepository orderReadableRepository;

        public PutOrderService(IValidator<PutOrderRequest> validator, IWritableOrdersRepository orderWritableRepository, IReadableOrdersRepository orderReadableRepository)
        {
            this.validator = validator;
            this.orderWritableRepository = orderWritableRepository;
            this.orderReadableRepository = orderReadableRepository;
        }

        public void RunValidationDTO(PutOrderRequest dto)
        {
            if (!validator.Validate(dto))
            {
                throw new CommonLibraryProjects.Validations.Abstractions.ValidationException(validator.Failures);
            }
        }

        public async Task<PutOrderResponse> RunPutOrderResponse(PutOrderRequest dto)
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

                var existOrder = await this.orderReadableRepository.ExistOrder(order.Id);

                if (!existOrder)
                    throw new KeyNotFoundException();

                return await this.orderWritableRepository.PutOrder(order);
            }
            catch
            {
                throw;
            }
        }
    }
}
