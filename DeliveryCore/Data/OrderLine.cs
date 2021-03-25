using System;
using System.Collections.Generic;

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
        public Product Product { get;  set; }

        /// <summary>
        /// Количество
        /// </summary>
        private int count;
        public int Count 
        {
            get => count;
            set
            {
                if (value > 0) count = value;
            }
        }

        //Стоимость строки заказа = кол-во * цена продукта.
        public double Cost
        {
            get
            {
                double CountLineOrder = Count * Product.Price;
                return CountLineOrder;
            }
        }
    }
}