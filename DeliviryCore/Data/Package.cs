using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DeliveryCore.Data
{
    class Package : IDeliveryman
    {
        public int speed;
        public int ID { get; set; }
        public string Name { get; set; }
        public DeliveryStatus Status { get; set; }

        public int Speed
        {
            get => speed;
            set
            {
                if (value >= 0) speed = 10;
                if (value < 0) speed = 0;
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

        public Package(string name, DeliveryStatus status, int speed, int maxdistance) 
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
