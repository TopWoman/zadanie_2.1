using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DeliveryCore.Data
{
    class CourierDriver : IDeliveryman // курьер-водитель
    {
        public readonly string DriverLicense; // водительское удостоверение 
        private int speed;
        public int ID { get; set; }
        public string Name { get; set; }
        public DeliveryStatus Status { get; set; }

        public int Speed
        {
            get => speed;
            set
            {
                if (value > 50) speed = 50;
                if (value <= 50 && value >= 0) speed = value;
                if (value < 0) speed = 0;
            }
        }
        private int _maxDistance;
        public int MaxDistance
        {
            get => _maxDistance;
            set
            {
                if (value > 500) _maxDistance = 500;
                if (value <= 500 && value >= 0) _maxDistance = value;
                if (value < 0) _maxDistance = 0;
            }
        }

        public CourierDriver(string name, DeliveryStatus status, int speed, int maxDistance, string driverlicense)
        {
            Name = name;
            Status = status;
            Speed = speed;
            MaxDistance = maxDistance;
            DriverLicense = driverlicense;
        }

        //TODO доделать доставку.
        public void Deliver(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
