using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace OOP
{
    class Machine : Deliveryman
    {
        private readonly double CarryingCapacity; //грузоподъемность
        private readonly double Volume; // вместительность (объём)
        private string Number { get; set; } // номер
        private List<Product> Products { get; set; }

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
            Products = new List<Product>();
        }

        public double CurrentCarryingCapacity
        {
            get; //допишу!!!
            private set
            {
                   
            }
        }

        public void Adding (Product product)
        {
            Products.Add(product);
            CurrentCarryingCapacity += product.Weight;
        }

        public void Deleting (Product product)
        {
            //ПОТОМ!
        }

        public override void Deliver(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
