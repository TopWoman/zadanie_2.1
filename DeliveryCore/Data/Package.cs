using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DeliveryCore.Data
{
    /// <summary>
    /// Почта
    /// </summary>
    class Package : IDeliveryman
    {
        private int _speed;
        public int Id { get; set; }
        public string Name { get; set; }
        public DeliveryStatus Status { get; set; }

        public int Speed
        {
            get => _speed;
            set
            {
                if (value >= 0) _speed = 10;
                if (value < 0) _speed = 0;
            }
        }

        private int _maxDistance;
        public int MaxDistance
        {
            get => _maxDistance;
            set
            {
                if (value > 0) _maxDistance = 0;
                if (value < 0) _maxDistance = 0;
            }
        }

        public Package(string name, DeliveryStatus status, int speed, int maxDistance) 
        {
            Name = name;
            Status = status;
            Speed = 0;
            MaxDistance = 0;
        }

        //TODO доделать доставку.
        public void Deliver(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
