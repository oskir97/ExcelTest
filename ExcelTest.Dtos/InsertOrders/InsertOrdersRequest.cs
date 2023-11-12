namespace ExcelTest.Dtos.InsertOrders
{
    public class InsertOrdersRequest
    {
        public required List<InsertOrdersRequestOrder> Orders { get; set; }
    }
}
