using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    class Dimensions
    {
        private double height;
        private double Height //высота
        { 
            get => height; 
            set
            {
                if (value < 0) height = 0;
                else height = value;
            }
        }
        private double length;
        private double Length // длина
        {
            get => length;
            set
            {
                if (value < 0) length = 0;
                else length = value;
            }
        }
        private double width;
        private double Width // ширина
        { 
            get => width; 
            set
            {
                if (value < 0) width = 0;
                else width = value;
            }
        } 

        public Dimensions (double height, double length, double width )
        {
            Height = height;
            Length = length;
            Width = width;
        }
    }
}
