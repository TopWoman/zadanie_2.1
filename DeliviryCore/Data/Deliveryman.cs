using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DeliveryCore.Data
{
    /// <summary>
    /// Абстрактный класс
    /// </summary>
    abstract class Deliveryman
    {
        public abstract int ID {get;}
        public string Name { get; set; }
        public DeliveryStatus Status { get; set; }
        public abstract int Speed { get; set; }
        public abstract int MaxDistance { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        public Deliveryman(string name, DeliveryStatus status, int speed, int maxdistance)
        {
            Name = name;
            Status = status;
            Speed = speed;
            MaxDistance = maxdistance;
        }
        public abstract void Deliver(Order order);

    }
}