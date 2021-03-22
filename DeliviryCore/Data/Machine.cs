using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DeliveryCore.Data
{
    class Machine : IDeliveryman
    {
        public readonly double CarryingCapacity; //грузоподъемность
        public readonly double Volume; // вместительность (объём)
        public readonly string Number; // номер
        public List<Order> Orders { get; set; }

        public CourierDriver Driver { get; set; }

        public int ID { get; set; }
        public string Name { get; set; }
        public DeliveryStatus Status { get; set; }

        private int _speed;
        public int Speed
        {
            get => _speed;
            set
            {
                if (value > 50) _speed = 50;
                if (value <= 50 && value >= 0) _speed = value;
                if (value < 0) _speed = 0;
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

        // текущая грузоподъемность
        public double CurrentCarryingCapacity { get; private set; }

        // текущий объем
        public double CurrentVolume { get; private set; }

        public Machine(string name, DeliveryStatus status, int speed, int maxDistance,
                        double volume, double carryingCapacity, string number)
        {
            Name = name;
            Status = status;
            Speed = speed;
            MaxDistance = maxDistance;
            CarryingCapacity = carryingCapacity;
            Volume = volume;
            Number = number;
            Orders = new List<Order>();
        }

        public void AddProduct(Order order)
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

        public void DeleteProduct(Order order)
        {
            if (order != null)
            {
                //TODO добавить проверку на наличие заказа
                Orders.Remove(order);
                CurrentCarryingCapacity -= order.Weight;
                CurrentVolume -= order.Volume;
            }
        }

        //TODO метод доставки
        public void Deliver(Order order)
        {
            throw new NotImplementedException();
        }

    }
}
