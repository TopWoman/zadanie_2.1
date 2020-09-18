using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    class Package : Deliveryman
    {
        public Package(int nextId, string name, int status, int speed, int maxdistance) 
            : base(nextId, name, status, speed, maxdistance)
        {
            Speed = 10;
            MaxDistance = 0;
        }
    }
}
