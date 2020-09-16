using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_2._1
{
    class Courier : Deliveryman
    {
        public Courier(int speed, int maxdistance) 
        {
            speed = 10;
            maxdistance = 50;
        }
    }
}
