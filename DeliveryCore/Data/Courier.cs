using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DeliveryCore.Data
{
    public class Courier : IDeliveryman
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DeliveryStatus Status { get; set; }

        private int _speed;
        public int Speed
        {
            get => _speed;
            set
            {
                if (value > 10) _speed = 10;
                if (value <= 10 && value >= 0) _speed = value;
                if (value < 0) _speed = 0;
            }
        }

        private int _maxDistance;
        public int MaxDistance
        {
            get => _maxDistance;
            set
            {
                if (value > 50) _maxDistance = 50;
                if (value <= 50 && value >= 0) _maxDistance = value;
                if (value < 0) _maxDistance = 0;
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public Courier(string name, DeliveryStatus status, int speed, int maxDistance)
        {
            Name = name;
            Status = status;
            Speed = speed;
            MaxDistance = maxDistance;
        }

        //TODO метод доставки
        public void Deliver(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
