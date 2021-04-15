namespace DeliveryCore.Data
{
    /// <summary>
    /// Таблица, показывающая текущие доставки.
    /// </summary>
    public class Delivery
    {
        public int Id { get; set; }

        /// <summary>
        /// id текущего доставщик
        /// </summary>
        public int DeliverId { get; set; }

        /// <summary>
        /// Id заказа в доставке
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Тип доставки
        /// </summary>
        public DeliveryType DeliveryType { get; set; }

        /// <summary>
        /// Название типа доставки
        /// </summary>
        public string DeliveryTypeName { get; set; }

        public Delivery(int deliverId, int orderId, DeliveryType deliveryType)
        {
            DeliverId = deliverId;
            OrderId = orderId;
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