using ExcelTest.Dtos.PutOrder;

namespace ExcelTest.ViewModels.PutOrder
{
    public class PutOrderViewModel
    {
        public bool Correct { get; }

        public PutOrderViewModel(PutOrderResponse dto)
        {
            Correct = dto.Correct;
        }
    }
}
