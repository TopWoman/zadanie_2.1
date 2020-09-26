using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace OOP
{
    class Package : Deliveryman
    {
        private static int nextId;
        private readonly int id;
        public override int ID => id;
        public int speed;
        public override int Speed
        {
            get => speed;
            set
            {
                if (value >= 0) speed = 10;
                if (value < 0) speed = 0;
            }
        }
        public int maxdistance;
        public override int MaxDistance
        {
            get => maxdistance;
            set
            {
                if (value > 0) maxdistance = 0;
                if (value < 0) maxdistance = 0;
            }
        }

        public Package(string name, DeliveryStatus status, int speed, int maxdistance) 
            : base(name, status, speed, maxdistance)
        {
            Speed = 0;
            MaxDistance = 0;
            id = Interlocked.Increment(ref nextId);
        }

        public override void Deliver(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
