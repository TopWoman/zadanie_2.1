using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DeliveryCore.Data
{
    class Courier : Deliveryman
    {
        public int id;
        public int speed;
        public override int Speed
        {
            get => speed;
            set
            {
                if (value > 10) speed = 10;
                if (value <= 10 && value >= 0) speed = value;
                if (value < 0) speed = 0;
            }
        }
        public int maxdistance;
        public override int MaxDistance
        {
            get => maxdistance;
            set
            {
                if (value > 50) maxdistance = 50;
                if (value <= 50 && value >= 0) maxdistance = value;
                if (value < 0) maxdistance = 0;
            }
        }

        public Courier (string name, DeliveryStatus status, int speed, int maxdistance) 
              : base(name, status, speed, maxdistance)
        {
            Speed = 10;
            MaxDistance = 50;
        }

        public override void Deliver(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
