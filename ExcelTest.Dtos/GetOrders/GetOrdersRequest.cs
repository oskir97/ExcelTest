namespace ExcelTest.Dtos.GetOrders
{
    public class GetOrdersRequest
    {
        public string? customerid { get; set; }
        public string? country { get; set; }
        public bool? all { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
