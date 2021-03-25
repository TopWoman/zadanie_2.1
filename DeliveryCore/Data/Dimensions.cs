using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryCore.Data
{
    public class Dimensions
    {
        public int Id { get; set; }

        private double _height;
        public double Height //высота
        {
            get => _height;
            set
            {
                if (value < 0) throw new ArgumentException("Value height cannot be less 0.");
                _height = value;
            }
        }
        private double _length;
        public double Length // длина
        {
            get => _length;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Value length cannot be less 0.");
                _length = value;
            }
        }
        private double _width;
        public double Width // ширина
        {
            get => _width;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Value width cannot be less 0.");
                _width = value;
            }
        }
        public double Volume => Height * Length * Width;

        public Dimensions(double height, double length, double width)
        {
            Height = height;
            Length = length;
            Width = width;
        }
    }
}
