using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_2._1
{
    /// <summary>
    /// Абстрактный класс
    /// </summary>
    abstract class Deliveryman
    {
        public int ID;
        public string Name;
        public int Status;
        public int Speed;
        public int MaxDistance;
        /// <summary>
        /// Конструктор
        /// </summary>
        public Deliveryman() { }
        public Deliveryman(int id, string name, int status, int speed, int maxdistance)
        {
            ID = id;
            Name = name;
            Status = status;
            Speed = speed;
            MaxDistance = maxdistance;
        }
        public void Deliver(bool parameter)
        {
            
        }

        enum STATUS
        {
            Expectation,
            DuringDelivery,
            CompletedOrder
        }
    }
}