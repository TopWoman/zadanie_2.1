using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryCore.Data
{
    /// <summary>
    /// Размеры товаров
    /// </summary>
    public class Dimensions
    {
        public int Id { get; set; }

        private double _length;
        /// <summary>
        /// Длина
        /// </summary>
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

        /// <summary>
        /// Ширина
        /// </summary>
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

        private double _height;

        /// <summary>
        /// Высота
        /// </summary>
        public double Height
        {
            get => _height;
            set
            {
                if (value < 0) throw new ArgumentException("Value height cannot be less 0.");
                _height = value;
            }
        }

        /// <summary>
        /// Объём
        /// </summary>
        public double Volume => Height * Length * Width;

        public Dimensions(double height, double length, double width)
        {
            Height = height;
            Length = length;
            Width = width;
        }
    }
}
