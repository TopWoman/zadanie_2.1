using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DeliveryCore.Data
{
    public class Machine : IDeliveryman
    {
        public double CarryingCapacity { get; set; }//грузоподъемность
        public double Volume { get; set; } // вместимость (объём)
        public string Number { get; set; } // номер

        //TODO сделать таблицу доставки, где будут столбцы: id строки, id курьера, номер заказа.
        //TODO Данная коллекция должна получать выборку из этой таблицы.
        public List<Order> Orders
        {
            get
            {
                using (AppContext dbContext = new AppContext())
                {
                    return null;
                }
            }
        }

        public int DriverId { get; set; }
        public CourierDriver Driver { get; set; }

        public int Id { get; set; }
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
