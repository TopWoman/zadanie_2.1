using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace OOP
{
    /// <summary>
    /// Абстрактный класс
    /// </summary>
    abstract class Deliveryman
    {
        public int NextId { get; set; }
        public int ID {get; private set;}
        public string Name { get; set; }
        public int Status { get; set; }
        public int Speed { get; set; }
        public int MaxDistance { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        public Deliveryman(int nextId, string name, int status, int speed, int maxdistance)
        {
            ID = Interlocked.Increment(ref nextId); ;
            Name = name;
            Status = status;
            Speed = speed;
            MaxDistance = maxdistance;
        }
        public void Deliver(bool parameter)
        {
            
        }
    }
}