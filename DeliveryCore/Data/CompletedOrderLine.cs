namespace DeliveryCore.Data
{
    public class CompletedOrderLine : IOrderLine
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
        public double Cost { get; set; }
    }
}