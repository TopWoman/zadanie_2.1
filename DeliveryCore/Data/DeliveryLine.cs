namespace DeliveryCore.Data
{
    public class DeliveryLine : IDeliveryLine
    {
        public int Id { get; set; }
        public int DeliveryId { get; set; }
        public int OrderId { get; set; }
    }
}