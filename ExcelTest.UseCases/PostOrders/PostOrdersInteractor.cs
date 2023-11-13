using ExcelTest.Dtos.PostOrders;
using ExcelTest.UseCasesPorts.PostOrders;

namespace ExcelTest.UseCases.PostOrders
{
    public class PostOrdersInteractor : IPostOrdersInputPort
    {
        private readonly IPostOrdersOutputPort outputPort;
        private readonly PostOrdersService service;

        public PostOrdersInteractor(IPostOrdersOutputPort outputPort, PostOrdersService service)
        {
            this.outputPort = outputPort;
            this.service = service;
        }

        public async Task Handle(PostOrdersRequest dto)
        {
            this.service.RunValidationDTO(dto);
            var result = await this.service.RunPostOrdersResponse(dto);
            await this.outputPort.Handle(result);
        }
    }
}
