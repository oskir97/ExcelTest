using ExcelTest.Dtos.Common;

namespace ExcelTest.Dtos.GetOrders
{
    public class GetOrdersResponse
    {
        public required List<OrderDto> Orders { get; set; }
    }
}
