using System;

namespace DeliveryCore.Data
{
    /// <summary>
    /// Строка заказа
    /// </summary>
    public class OrderLine
    {
        /// <summary>
        /// Продукт заказа
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        public int Count { get; set; }

        //Стоимость строки заказа = кол-во * цена продукта.
        public double Cost
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}