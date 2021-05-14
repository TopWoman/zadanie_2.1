﻿namespace DeliveryCore.Data
{
    public interface IOrderLine
    {
        int Id { get; set; }

        /// <summary>
        /// Продукт заказа
        /// </summary>

        int ProductId { get; set; }

        Product Product { get; }
        int Count { get; set; }
        double Cost { get; set; }
    }
}