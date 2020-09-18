using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    class Courier : Deliveryman
    {
        public Courier(int nextId, string name, int status, int speed, int maxdistance) 
              : base(nextId, name, status, speed, maxdistance)
          {
            Speed = 10;
            MaxDistance = 50;
          } 

    }
}
