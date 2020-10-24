using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DeliveryCore.Data
{
    class CourierDriver : Deliveryman // курьер-водитель
    {
        public readonly string DriverLicense; // водительское удостоверение 
        private static int nextId;
        private readonly int id;
        public override int ID => id;
        private int speed;
        public override int Speed
        {
            get => speed;
            set
            {
                if (value > 50) speed = 50;
                if (value <= 50 && value >= 0) speed = value;
                if (value < 0) speed = 0;
            }
        }
        private int maxdistance;
        public override int MaxDistance
        {
            get => maxdistance;
            set
            {
                if (value > 500) maxdistance = 500;
                if (value <= 500 && value >= 0) maxdistance = value;
                if (value < 0) maxdistance = 0;
            }
        }

        public CourierDriver(string name, DeliveryStatus status, int speed, int maxdistance, string driverlicense)
           : base(name, status, speed, maxdistance)
        {
            DriverLicense = driverlicense;
            id = Interlocked.Increment(ref nextId);
        }

        public override void Deliver(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
