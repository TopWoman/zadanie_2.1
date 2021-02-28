using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryCore.Data
{
    public class Dimensions
    {
        private double height;
        public double Height //высота
        { 
            get => height; 
            set
            {
                if (value < 0) height = 0;
                else height = value;
            }
        }
        private double length;
        public double Length // длина
        {
            get => length;
            set
            {
                if (value < 0) length = 0;
                else length = value;
            }
        }
        private double width;
        public double Width // ширина
        { 
            get => width; 
            set
            {
                if (value < 0) width = 0;
                else width = value;
            }
        } 
        public double Volume
        {
            get => Height * Length * Width;
        }
        public Dimensions (double height, double length, double width )
        {
            Height = height;
            Length = length;
            Width = width;
        }
    }
}
