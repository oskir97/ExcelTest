using ExcelTest.Dtos.InsertOrder;
using ExcelTest.UseCasesPorts.InsertOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTest.UseCases.InsertOrder
{
    public class InsertOrderInteractor : IInsertOrderInputPort
    {
        private readonly IInsertOrderOutputPort outputPort;
        private readonly InsertOrderService service;

        public InsertOrderInteractor(IInsertOrderOutputPort outputPort, InsertOrderService service)
        {
            this.outputPort = outputPort;
            this.service = service;
        }

        public async Task Handle(InsertOrderRequest dto)
        {
            this.service.RunValidationDTO(dto);
            var result = await this.service.RunInsertOrderResponse(dto);
            await this.outputPort.Handle(result);
        }
    }
}
