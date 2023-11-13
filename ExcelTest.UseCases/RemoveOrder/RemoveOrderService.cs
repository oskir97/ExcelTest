using CommonLibraryProjects.Validations.Interfaces;
using ExcelTest.Common.Interfaces;
using ExcelTest.Core.Entities;
using ExcelTest.Dtos.PutOrder;
using ExcelTest.Dtos.RemoveOrder;

namespace ExcelTest.UseCases.RemoveOrder
{
    public class RemoveOrderService
    {
        private readonly IWritableOrdersRepository orderWritableRepository;
        private readonly IReadableOrdersRepository orderReadableRepository;

        public RemoveOrderService(IWritableOrdersRepository orderWritableRepository, IReadableOrdersRepository orderReadableRepository)
        {
            this.orderWritableRepository = orderWritableRepository;
            this.orderReadableRepository = orderReadableRepository;
        }

        public async Task<RemoveOrderResponse> RunRemoveOrderResponse(RemoveOrderRequest dto)
        {
            try
            {
                var existOrder = await this.orderReadableRepository.ExistOrder(dto.Id);

                if (!existOrder)
                    throw new KeyNotFoundException();

                return await this.orderWritableRepository.RemoveOrder(dto.Id);
            }
            catch
            {
                throw;
            }
        }
    }
}
