using ExcelTest.Dtos.PostOrders;

namespace ExcelTest.ViewModels.PostOrders
{
    public class PostOrdersViewModel
    {

        public bool Correct { get; }

        public PostOrdersViewModel(PostOrdersResponse dto)
        {
            Correct = dto.Correct;
        }

    }
}
