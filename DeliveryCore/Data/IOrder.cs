using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryCore.Data
{
    public interface IOrder
    {
        public int Id { get; set; }

        [NotMapped]
        public Client Client { get; }
        public int ClientId { get; set; }
        public string Address1 { get; set; } // адрес 1
        public string Address2 { get; set; } // адрес 2
        public DateTime CreateDate { get; set; } //дата создания заказа
        public double Weight { get; set; } //вес
        public List<OrderLine> OrderLines { get; }
        public double Volume { get; }
        public double Distance { get; set; }
        public OrderStatus Status { get; set; } // статус
        public bool IsFragile { get; set; } // хрупкий или нет
    }
}