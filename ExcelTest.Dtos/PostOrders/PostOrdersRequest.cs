using ExcelTest.Dtos.Common;

namespace ExcelTest.Dtos.PostOrders
{
    public class PostOrdersRequest
    {
        public required List<OrderDto> Orders { get; set; }
    }
}
