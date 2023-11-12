using ExcelTest.Dtos.InsertOrders;
using ExcelTest.UseCasesPorts.InsertOrders;

namespace ExcelTest.UseCases.InsertOrders
{
    public class InsertOrdersInteractor : IInsertOrdersInputPort
    {
        private readonly IInsertOrdersOutputPort outputPort;
        private readonly InsertOrdersService service;

        public InsertOrdersInteractor(IInsertOrdersOutputPort outputPort, InsertOrdersService service)
        {
            this.outputPort = outputPort;
            this.service = service;
        }

        public async Task Handle(InsertOrdersRequest dto)
        {
            this.service.RunValidationDTO(dto);
            var result = await this.service.RunInsertOrderResponse(dto);
            await this.outputPort.Handle(result);
        }
    }
}
