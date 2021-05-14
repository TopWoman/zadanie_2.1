namespace DeliveryCore.Data
{
    public class CompletedDelivery : IDelivery
    {
        public int Id { get; set; }

        /// <summary>
        /// id текущего доставщик
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

        public CompletedDelivery(int deliverId, DeliveryType deliveryType)
        {
            DeliverId = deliverId;
            DeliveryType = deliveryType;
            switch (deliveryType)
            {
                case DeliveryType.Courier:
                    DeliveryTypeName = "Курьер";
                    break;
                case DeliveryType.Machine:
                    DeliveryTypeName = "Машина";
                    break;
                case DeliveryType.Package:
                    DeliveryTypeName = "Почта";
                    break;
                default:
                    DeliveryTypeName = "Не задано";
                    break;
            }
        }
    }
}