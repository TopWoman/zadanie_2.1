using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    class Machine : Deliveryman
    {
        public Machine(int nextId, string name, int status, int speed, int maxdistance) 
            : base(nextId, name, status, speed, maxdistance)
        {
            Speed = 50;
            MaxDistance = 500;
        }
    }
}
