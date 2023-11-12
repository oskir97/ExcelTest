namespace ExcelTest.Dtos.InsertOrder
{
    public class InsertOrderRequest
    {
        public int Id { get; set; }
        public required string Customer { get; set; }
        public decimal Freight { get; set; }
        public required string Country { get; set; }
    }
}
