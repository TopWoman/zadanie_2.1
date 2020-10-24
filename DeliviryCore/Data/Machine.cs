using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DeliveryCore.Data
{
    class Machine : Deliveryman
    {
        private readonly double CarryingCapacity; //грузоподъемность
        private readonly double Volume; // вместительность (объём)
        private readonly string Number; // номер
        private List<Order> Orders { get; set; }

        public CourierDriver Driver { get; set; }

        private static int nextId;
        private readonly int id;
        public override int ID => id;
        public int speed;
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
        public int maxdistance;
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
        public Machine( string name, DeliveryStatus status, int speed, int maxdistance, 
                        double volume, double carryingcapacity, string number) 
                        : base( name, status, speed, maxdistance)
        {
            Speed = speed;
            MaxDistance = maxdistance;
            id = Interlocked.Increment(ref nextId);
            CarryingCapacity = carryingcapacity;
            Volume = volume;
            Number = number;
            Orders = new List<Order>();
        }

        public double CurrentCarryingCapacity // текущая грузоподъемность
        {
            get; 
            private set;
        }

        public double CurrentVolume // текущий объем
        {
            get;
            private set;
        }
        public void AddProduct (Order order)
        {
            if (order != null)
            {
                if ((CarryingCapacity - CurrentCarryingCapacity) > order.Weight &&
                (Volume - CurrentVolume) > order.Volume)
                {
                    Orders.Add(order);
                    CurrentCarryingCapacity += order.Weight;
                    CurrentVolume += order.Volume;
                }
            }
        }

        public void DeletingProduct (Order order)
        {
            if (order != null)
            {
                Orders.Remove(order);
                CurrentCarryingCapacity -= order.Weight;
                CurrentVolume -= order.Volume;
            }
        }

        public override void Deliver(Order order)
        {
            throw new NotImplementedException();
        }

    }
}
