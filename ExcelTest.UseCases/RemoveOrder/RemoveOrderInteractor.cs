using ExcelTest.Dtos.RemoveOrder;
using ExcelTest.UseCasesPorts.RemoveOrder;

namespace ExcelTest.UseCases.RemoveOrder
{
    public class RemoveOrderInteractor : IRemoveOrderInputPort
    {
        private readonly IRemoveOrderOutputPort outputPort;
        private readonly RemoveOrderService service;

        public RemoveOrderInteractor(IRemoveOrderOutputPort outputPort, RemoveOrderService service)
        {
            this.outputPort = outputPort;
            this.service = service;
        }

        public async Task Handle(RemoveOrderRequest dto)
        {
            var result = await this.service.RunRemoveOrderResponse(dto);
            await this.outputPort.Handle(result);
        }
    }
}
