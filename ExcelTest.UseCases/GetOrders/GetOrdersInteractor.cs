using ExcelTest.Dtos.GetOrders;
using ExcelTest.UseCasesPorts.GetOrders;

namespace ExcelTest.UseCases.GetOrders
{
    internal class GetOrdersInteractor : IGetOrdersInputPort
    {
        private readonly IGetOrdersOutputPort outputPort;
        private readonly GetOrdersService service;

        public GetOrdersInteractor(IGetOrdersOutputPort outputPort, GetOrdersService service)
        {
            this.outputPort = outputPort;
            this.service = service;
        }

        public async Task Handle(GetOrdersRequest dto)
        {
            this.service.RunValidationDTO(dto);
            var result = await this.service.RunGetOrdersResponse(dto);
            await this.outputPort.Handle(result);
        }
    }
}
