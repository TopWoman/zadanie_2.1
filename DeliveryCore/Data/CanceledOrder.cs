using System;
using System.Collections.Generic;

namespace DeliveryCore.Data
{
    public class CanceledOrder : IOrder
    {
        public int Id { get; set; }

        public Client Client { get; }

        public int ClientId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime CanceleDate { get; set; }
        public double Weight { get; set; }

        public List<OrderLine> OrderLines { get; }

        public double Volume { get; set; }

        public double Distance { get; set; }
        public OrderStatus Status { get; set; }
        public bool IsFragile { get; set; }
    }
}