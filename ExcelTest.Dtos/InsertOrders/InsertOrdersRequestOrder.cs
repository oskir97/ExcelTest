namespace ExcelTest.Dtos.InsertOrders
{
    public class InsertOrdersRequestOrder
    {
        public int Id { get; set; }
        public required string Customer { get; set; }
        public decimal Freight { get; set; }
        public required string Country { get; set; }
    }
}
