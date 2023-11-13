using CommonLibraryProjects.Validations.Interfaces;
using ExcelTest.Common.Interfaces;
using ExcelTest.Dtos.GetOrders;

namespace ExcelTest.UseCases.GetOrders
{
    public class GetOrdersService
    {
        private readonly IValidator<GetOrdersRequest> validator;
        private readonly IReadableOrdersRepository orderReadableRepository;

        public GetOrdersService(IValidator<GetOrdersRequest> validator, IReadableOrdersRepository orderReadableRepository)
        {
            this.validator = validator;
            this.orderReadableRepository = orderReadableRepository;
        }

        public void RunValidationDTO(GetOrdersRequest dto)
        {
            if (!validator.Validate(dto))
            {
                throw new CommonLibraryProjects.Validations.Abstractions.ValidationException(validator.Failures);
            }
        }

        public async Task<GetOrdersResponse> RunGetOrdersResponse(GetOrdersRequest dto)
        {
            try
            {
                return await orderReadableRepository.GetOrders(dto);
            }
            catch
            {
                throw;
            }
        }
    }
}
