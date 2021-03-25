using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DeliveryCore.Data
{
    /// <summary>
    /// Абстрактный класс
    /// </summary>
    interface IDeliveryman
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DeliveryStatus Status { get; set; }
        public int Speed { get; set; }
        public int MaxDistance { get; set; }

        public void Deliver(Order order);

    }
}