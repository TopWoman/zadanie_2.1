namespace DeliveryCore.Data
{
    public interface IDeliveryLine
    {
        /// <summary>
        /// Id строки доставки
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Id доставки
        /// </summary>
        public int DeliveryId { get; set; }
        
        /// <summary>
        /// Id заказа в доставке
        /// </summary>
        public int OrderId { get; set; }

    }
}