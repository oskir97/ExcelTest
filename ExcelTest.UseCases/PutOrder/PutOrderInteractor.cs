using ExcelTest.Dtos.PutOrder;
using ExcelTest.UseCasesPorts.PutOrder;

namespace ExcelTest.UseCases.PutOrder
{
    public class PutOrderInteractor : IPutOrderInputPort
    {
        private readonly IPutOrderOutputPort outputPort;
        private readonly PutOrderService service;

        public PutOrderInteractor(IPutOrderOutputPort outputPort, PutOrderService service)
        {
            this.outputPort = outputPort;
            this.service = service;
        }

        public async Task Handle(PutOrderRequest dto)
        {
            this.service.RunValidationDTO(dto);
            var result = await this.service.RunPutOrderResponse(dto);
            await this.outputPort.Handle(result);
        }
    }
}
