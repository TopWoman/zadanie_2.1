namespace DeliveryCore.Data
{
    public interface IDelivery
    {
        public int Id { get; set; }

        /// <summary>
        /// id текущего доставщика
        /// </summary>
        public int DeliverId { get; set; }

        /// <summary>
        /// Тип доставки
        /// </summary>
        public DeliveryType DeliveryType { get; set; }

        /// <summary>
        /// Название типа доставки
        /// </summary>
        public string DeliveryTypeName { get; set; }
    }
}