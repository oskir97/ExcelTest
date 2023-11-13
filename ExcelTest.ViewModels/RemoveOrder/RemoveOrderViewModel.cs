using ExcelTest.Dtos.RemoveOrder;

namespace ExcelTest.ViewModels.RemoveOrder
{
    public class RemoveOrderViewModel
    {
        public bool Correct { get; }

        public RemoveOrderViewModel(RemoveOrderResponse dto)
        {
            Correct = dto.Correct;
        }
    }
}
