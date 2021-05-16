using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryCore.Data
{
    public interface IOrder<T> where T : IOrderLine
    {
        public int Id { get; set; }

        [NotMapped]
        public Client Client { get; }
        public int ClientId { get; set; }
        public string Address1 { get; set; } // адрес 1
        public string Address2 { get; set; } // адрес 2
        public DateTime CreateDate { get; set; } //дата создания заказа
        public double Weight { get; } //вес
        public List<T> OrderLines { get; }
        public double Volume { get; }
        public double Distance { get; set; }
        public OrderStatus Status { get; set; } // статус
        public bool IsFragile { get; set; } // Показатель хрупкости
        public void RemoveOrderLine(T orderLine);
        public void RemoveOrderLine(int id);
    }
}