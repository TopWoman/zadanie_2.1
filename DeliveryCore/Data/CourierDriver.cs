using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DeliveryCore.Data
{
    class CourierDriver : IDeliveryman // курьер-водитель
    {
        public readonly string DriverLicense; // водительское удостоверение 
        private int _speed;
        public int Id { get; set; }
        public string Name { get; set; }
        public DeliveryStatus Status { get; set; }

        public int Speed
        {
            get => _speed;
            set
            {
                if (value > 50)
                    throw new ArgumentException("Value Speed cannot be bigger 50.");
                if (value < 0)
                    throw new ArgumentException("Value Speed cannot be less 0.");
                _speed = value;
            }
        }
        private int _maxDistance;
        public int MaxDistance
        {
            get => _maxDistance;
            set
            {
                if (value > 500)
                    throw new ArgumentException("Value MaxDistance cannot be bigger 500.");
                if (value < 0) 
                    throw new ArgumentException("Value MaxDistance cannot be less 0.");
                _maxDistance = value;
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
