using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryCore.Data
{
    /// <summary>
    /// Строка заказа
    /// </summary>
    public class OrderLine : IOrderLine
    {
        public int Id { get; set; }
        /// <summary>
        /// Продукт заказа
        /// </summary>

        public int ProductId { get; set; }

        [NotMapped]
        public Product Product
        {
            get
            {
                using AppContext dbContext = new AppContext();
                return dbContext.Products.Find(ProductId);
            }
        }

        /// <summary>
        /// Количество
        /// </summary>
        private int _count;
        public int Count
        {
            get => _count;
            set
            {
                if (value > 0) _count = value;
            }
        }

        private double _cost;
        //Стоимость строки заказа = кол-во * цена продукта.
        public double Cost
        {
            get => Cost;
            set => _cost = value;
        }
        public int OrderId { get; set; }

        public OrderLine(int productId, int count)
        {
            using AppContext dbContext = new AppContext();
            if (dbContext.Products.Find(ProductId) != null)
                ProductId = productId;
            else
                throw new ArgumentException($"No product with id = {productId}");
            Cost = Count * Product.Price;
        }
    }
}